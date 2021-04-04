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
        /// <summary>   Creates an item. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="codename">             The codename. </param>
        /// <param name="maxstack">             The maxstack. </param>
        /// <param name="name">                 The name. </param>
        /// <param name="desc">                 The description. </param>
        /// <param name="guidstring">           The guidstring. </param>
        /// <param name="recipecategoryname">   The recipecategoryname. </param>
        /// <param name="icon">                 The icon. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void CreateItem(string codename, int maxstack, LocalizedString name, LocalizedString desc, string guidstring, string recipecategoryname, Sprite icon)
        {
            var recipecategory = GameResources.Instance.Items.FirstOrDefault(s => s.name == recipecategoryname);

            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name = codename;
            item.Category = recipecategory.Category;
            item.MaxStack = maxstack;
            item.Icon = icon;
            LocalizedString nameStr = name;
            LocalizedString descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);

            typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, nameStr);
            typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, descStr);

            var guid = GUID.Parse(guidstring);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}
