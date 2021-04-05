using UnityEngine;

namespace VolcanoidsSDK.lib
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Category Creation Class. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 4/4/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class Category
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a Factory Category. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 4/4/2021. </remarks>
        ///
        /// <param name="name">             Category Name </param>
        /// <param name="categoryId">       The String ID of your Category. </param>
        ///-------------------------------------------------------------------------------------------------
        public static void CreateFactoryCategory(string name, string categoryId)
        {
            var ok = ScriptableObject.CreateInstance<FactoryType>();
            ok.name = name;
            var guid = GUID.Parse(categoryId);
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = ok, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a Factory Category. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 4/4/2021. </remarks>
        ///
        /// <param name="name">             Category Name </param>
        /// <param name="categoryId">       The GUID ID of your Category. </param>
        ///-------------------------------------------------------------------------------------------------
        public static void CreateFactoryCategory(string name, GUID categoryId)
        {
            var ok = ScriptableObject.CreateInstance<FactoryType>();
            ok.name = name;
            var guid = categoryId;
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = ok, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a Module Category. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 4/4/2021. </remarks>
        ///
        /// <param name="name">             Category Name </param>
        /// <param name="categoryId">       The String ID of your Category. </param>
        ///-------------------------------------------------------------------------------------------------
        public static void CreateModuleCategory(string name, string categoryId)
        {
            var ok = ScriptableObject.CreateInstance<ModuleCategory>();
            ok.name = name;
            var guid = GUID.Parse(categoryId);
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = ok, Guid = guid, Labels = new string[4] } };
            RuntimeAssetStorage.Add(assets, default);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a Module Category. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 4/4/2021. </remarks>
        ///
        /// <param name="name">             Category Name </param>
        /// <param name="categoryId">       The GUID ID of your Category. </param>
        ///-------------------------------------------------------------------------------------------------
        public static void CreateModuleCategory(string name, GUID categoryId)
        {
            var ok = ScriptableObject.CreateInstance<ModuleCategory>();
            ok.name = name;
            var guid = categoryId;
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = ok, Guid = guid, Labels = new string[4] } };
            RuntimeAssetStorage.Add(assets, default);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a Recipe Category. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 4/4/2021. </remarks>
        ///
        /// <param name="name">             Category Name </param>
        /// <param name="categoryId">       The String ID of your Category. </param>
        ///-------------------------------------------------------------------------------------------------
        public static void CreateRecipeCategory(string name, string categoryId)
        {
            var Forge = ScriptableObject.CreateInstance<RecipeCategory>();
            Forge.name = name;
            var guid = GUID.Parse(categoryId);
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = Forge, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a Recipe Category. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 4/4/2021. </remarks>
        ///
        /// <param name="name">             Category Name </param>
        /// <param name="categoryId">       The GUID ID of your Category. </param>
        ///-------------------------------------------------------------------------------------------------
        public static void CreateRecipeCategory(string name, GUID categoryId)
        {
            var Forge = ScriptableObject.CreateInstance<RecipeCategory>();
            Forge.name = name;
            var guid = categoryId;
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = Forge, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}
