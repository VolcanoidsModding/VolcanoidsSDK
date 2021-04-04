namespace VolcanoidsSDK.lib.scripts
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A Category Finder. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    class FindCategory
    {
        /// <summary>   The tempcategory for returning. </summary>
        private static RecipeCategory tempcategory;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Searches for the first category name. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="categoryname"> The categoryname. </param>
        ///
        /// <returns>   The found category name. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static RecipeCategory FindCategoryName(string categoryname)
        {
            tempcategory = null;
            foreach (Recipe recipe in GameResources.Instance.Recipes)
            {
                foreach (RecipeCategory category in recipe.Categories)
                {
                    if (category != null && categoryname != null)
                    {
                        if (category.name == categoryname)
                        {
                            tempcategory = category;
                        }
                    }
                }
            }
            return tempcategory;
        }
    }
}
