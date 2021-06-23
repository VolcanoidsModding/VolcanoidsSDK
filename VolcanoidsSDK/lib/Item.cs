using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace VolcanoidsSDK.lib
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   The Item Creation Class. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    class Item
    {

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates an item. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 6/23/2021. </remarks>
        ///
        /// <param name="codename">             The codename. </param>
        /// <param name="maxstack">             The maxstack. </param>
        /// <param name="name">                 The name. </param>
        /// <param name="desc">                 The description. </param>
        /// <param name="guidstring">           The guidstring. </param>
        /// <param name="recipecategoryname">   The recipecategoryname. </param>
        /// <param name="icon">                 The icon. </param>
        ///-------------------------------------------------------------------------------------------------

        private void CreateItem(string codename, int maxstack, LocalizedString name, LocalizedString desc, string guidstring, string recipecategoryname, Sprite icon)
        {
            var itemPassthrough = GUID.Parse(recipecategoryname);
            var recipecategory = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == itemPassthrough);

            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name = codename;
            item.Category = recipecategory.Category;
            item.MaxStack = maxstack;
            item.Icon = icon;
            LocalizedString nameStr = name;
            LocalizedString descStr = desc;

            typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, nameStr);
            typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, descStr);

            var guid = GUID.Parse(guidstring);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates an item. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 6/23/2021. </remarks>
        ///
        /// <param name="codename">             The codename. </param>
        /// <param name="maxstack">             The maxstack. </param>
        /// <param name="name">                 The name. </param>
        /// <param name="desc">                 The description. </param>
        /// <param name="guidstring">           The guidstring. </param>
        /// <param name="recipecategoryname">   The recipecategoryname. </param>
        /// <param name="icon">                 The icon. </param>
        ///-------------------------------------------------------------------------------------------------

        private void CreateItem(string codename, int maxstack, LocalizedString name, LocalizedString desc, GUID guidstring, string recipecategoryname, Sprite icon)
        {
            var itemPassthrough = GUID.Parse(recipecategoryname);
            var recipecategory = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == itemPassthrough);

            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name = codename;
            item.Category = recipecategory.Category;
            item.MaxStack = maxstack;
            item.Icon = icon;
            LocalizedString nameStr = name;
            LocalizedString descStr = desc;

            typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, nameStr);
            typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, descStr);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guidstring);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets);
        }
    }
}
