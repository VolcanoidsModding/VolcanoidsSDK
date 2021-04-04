namespace VolcanoidsSDK.lib.scripts
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A Category Array Generator. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    class GenerateCategories
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Generates a category array. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="categories">   The categories. </param>
        ///
        /// <returns>   An array of recipe categories. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static RecipeCategory[] GenerateCategoryArray(string[] categories)
        {
            RecipeCategory[] finalInput = new RecipeCategory[categories.Length];
            var i = 0;
            foreach (string category in categories)
            {
                finalInput[i] = FindCategory.FindCategoryName(category);
                i++;
            }
            return finalInput;
        }
    }
}
