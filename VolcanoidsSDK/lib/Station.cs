using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using VolcanoidsSDK.lib.scripts;

namespace VolcanoidsSDK.lib
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   The Station Production Class. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    class Station
    {
        /// <summary>   (Immutable) unique identifier for the production station. </summary>
        private static readonly GUID productionStationGUID = GUID.Parse("7c32d187420152f4da3a79d465cbe87a");

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Initializes the passed Object. </summary>
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
        /// <summary>   Creates a station. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="factoryType">  Type of the factory. </param>
        /// <param name="codename">     The codename. </param>
        /// <param name="maxStack">     Max Stack Size of this Item. </param>
        /// <param name="name">         The name. </param>
        /// <param name="desc">         The description. </param>
        /// <param name="guidString">   The unique identifier string. </param>
        /// <param name="icon">         The icon. </param>
        /// <param name="variantname">  The variantname. </param>
        /// <param name="categories">   The categories. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void CreateStation(FactoryType factoryType, string codename, int maxStack, LocalizedString name, LocalizedString desc, string guidString, Sprite icon, string variantname, RecipeCategory[] categories)
        {
            var category = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == productionStationGUID)?.Category;
            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            if (item == null) { Debug.Log("Item is null"); return; }
            if (category == null) { Debug.Log("Category is null"); return; }
            item.name = codename;
            item.Category = category;
            item.MaxStack = maxStack;
            item.Icon = icon;

            var prefabParent = new GameObject();
            var olditem = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == productionStationGUID);
            prefabParent.SetActive(false);
            var newmodule = UnityEngine.Object.Instantiate(olditem.Prefabs[0], prefabParent.transform);
            var module = newmodule.GetComponentInChildren<FactoryStation>();
            var producer = newmodule.GetComponentInChildren<Producer>();
            newmodule.SetName("AlloyForgeStation");
            var gridmodule = newmodule.GetComponent<GridModule>();
            gridmodule.VariantName = variantname;
            gridmodule.Item = item;

            var productionGroup = Typings.GetOrCreateTyping(factoryType);

            LocalizedString nameStr = name;
            LocalizedString descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);

            item.SetPrivateField("m_name", nameStr);
            item.SetPrivateField("m_description", descStr);
            typeof(FactoryStation).GetField("m_factoryType", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, factoryType);
            typeof(FactoryStation).GetField("m_productionGroup", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, productionGroup);
            typeof(Producer).GetField("m_categories", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(producer, categories);

            var guid = GUID.Parse(guidString);
            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guid);

            item.Prefabs = new GameObject[] { newmodule };

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}
