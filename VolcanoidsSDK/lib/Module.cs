using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using VolcanoidsSDK.lib.scripts;

namespace VolcanoidsSDK.lib
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   The Module Creation Class. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    class Module
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Initializes this object. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="str">  [in,out] The string. </param>
        ///-------------------------------------------------------------------------------------------------

        private static void Initialize<T>(ref T str)
        where T : struct, ISerializationCallbackReceiver
        {
            str.OnAfterDeserialize();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates production module. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="codename">         The codename. </param>
        /// <param name="variantname">      The variantname. </param>
        /// <param name="maxstack">         The maxstack. </param>
        /// <param name="baseitem">         The baseitem. </param>
        /// <param name="name">             The name. </param>
        /// <param name="desc">             The description. </param>
        /// <param name="guidstring">       The guidstring. </param>
        /// <param name="categoryname">     The categoryname. </param>
        /// <param name="factorytypename">  The factorytypename. </param>
        /// <param name="icon">             The icon. </param>
        /// <param name="categories">       The categories. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void CreateProductionModule(string codename, string variantname, int maxstack, string baseitem, LocalizedString name, LocalizedString desc, string guidstring, string categoryname, string factorytypename, Sprite icon, RecipeCategory[] categories)
        {
            var category = GameResources.Instance.Items.FirstOrDefault(s => s.name == categoryname).Category;
            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name = codename;
            item.Category = category;
            item.MaxStack = maxstack;
            item.Icon = icon;

            var prefabParent = new GameObject();
            var olditem = GameResources.Instance.Items.FirstOrDefault(s => s.name == baseitem);
            var factorytype = GameResources.Instance.FactoryTypes.FirstOrDefault(s => s.name == factorytypename);
            prefabParent.SetActive(false);
            var newmodule = Object.Instantiate(olditem.Prefabs[0], prefabParent.transform);
            var module = newmodule.GetComponentInChildren<ProductionModule>();
            var gridmodule = newmodule.GetComponent<GridModule>();
            gridmodule.VariantName = variantname;
            gridmodule.Item = item;
            newmodule.name = codename;
            item.Prefabs = new GameObject[] { newmodule };
            var modulecategory = RuntimeAssetCacheLookup.Get<ModuleCategory>().First(s => s.name == factorytypename);
            modulecategory.Modules = modulecategory.Modules.Concat(new ItemDefinition[] { item }).ToArray();

            var productionGroup = Typings.GetOrCreateTyping(factorytype);

            LocalizedString nameStr = name;
            LocalizedString descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);

            typeof(ProductionModule).GetField("m_factoryType", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, factorytype);
            typeof(ProductionModule).GetField("m_module", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, gridmodule);
            typeof(ProductionModule).GetField("m_categories", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, categories);
            typeof(ProductionModule).GetField("m_productionGroup", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, productionGroup);
            typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, nameStr);
            typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, descStr);

            var guid = GUID.Parse(guidstring);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates production module. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="codename">         The codename. </param>
        /// <param name="variantname">      The variantname. </param>
        /// <param name="maxstack">         The maxstack. </param>
        /// <param name="basename">         The basename. </param>
        /// <param name="name">             The name. </param>
        /// <param name="desc">             The description. </param>
        /// <param name="guidstring">       The guidstring. </param>
        /// <param name="categoryname">     The categoryname. </param>
        /// <param name="factorytypename">  The factorytypename. </param>
        /// <param name="icon">             The icon. </param>
        /// <param name="categories">       The categories. </param>
        /// <param name="looping">          True to looping. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void CreateProductionModule(string codename, string variantname, int maxstack, string basename, LocalizedString name, LocalizedString desc, string guidstring, string categoryname, string factorytypename, Sprite icon, RecipeCategory[] categories, bool looping)
        {
            var category = GameResources.Instance.Items.FirstOrDefault(s => s.name == categoryname).Category;
            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name = codename;
            item.Category = category;
            item.MaxStack = maxstack;
            item.Icon = icon;

            var prefabParent = new GameObject();
            var olditem = GameResources.Instance.Items.FirstOrDefault(s => s.name == basename);
            var factorytype = GameResources.Instance.FactoryTypes.FirstOrDefault(s => s.name == factorytypename);
            prefabParent.SetActive(false);
            var newmodule = Object.Instantiate(olditem.Prefabs[0], prefabParent.transform);
            var module = newmodule.GetComponentInChildren<ProductionModule>();
            var gridmodule = newmodule.GetComponent<GridModule>();
            gridmodule.VariantName = variantname;
            gridmodule.Item = item;
            item.Prefabs = new GameObject[] { newmodule };
            var modulecategory = RuntimeAssetCacheLookup.Get<ModuleCategory>().First(s => s.name == factorytypename);
            var concatinated = new ItemDefinition[] { item };
            modulecategory.Modules = concatinated.ToArray();

            LocalizedString nameStr = name;
            LocalizedString descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);

            typeof(ProductionModule).GetField("m_factoryType", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, factorytype);
            typeof(ProductionModule).GetField("m_module", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, gridmodule);
            typeof(ProductionModule).GetField("m_categories", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, categories);
            typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, nameStr);
            typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, descStr);

            var guid = GUID.Parse(guidstring);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}
