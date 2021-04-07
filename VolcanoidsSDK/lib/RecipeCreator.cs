using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VolcanoidsSDK.lib.scripts;

namespace VolcanoidsSDK.lib
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   The Recipe Creator Class. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    class RecipeCreator
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a recipe. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="recipeName">       Name of the recipe. </param>
        /// <param name="inputs">           The inputs. </param>
        /// <param name="outputs">          The outputs. </param>
        /// <param name="baseRecipe">       The base recipe. </param>
        /// <param name="itemId">           Identifier for the item. </param>
        /// <param name="requiredItems">    The required items. </param>
        /// <param name="recipeCategory">   Category the recipe belongs to. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void CreateRecipe(string recipeName, classes.Input[] inputs, classes.Output[] outputs, string baseRecipe, string itemId, string[] requiredItems, string recipeCategory)
        {
            var outputItem = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputs[0].output_name);
            var finalInput = new InventoryItemData[inputs.Length];
            var i = 0;
            foreach (classes.Input input in inputs)
            {
                var itemVar = GameResources.Instance.Items.FirstOrDefault(s => s.name == input.input_name);
                finalInput[i] = new InventoryItemData { Item = itemVar, Amount = input.input_amount };
                i++;
            }

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = finalInput;
            recipe.Output = new InventoryItemData { Item = outputItem, Amount = outputs[0].output_amount };
            if (requiredItems[0] != "")
            {
                var requiredFinal = new ItemDefinition[inputs.Length];
                var iReq = 0;
                foreach (string item in requiredItems)
                {
                    var instanceVar = GameResources.Instance.Items.FirstOrDefault(s => s.name == item);
                    requiredFinal[iReq] = instanceVar;
                    iReq++;
                }
                recipe.RequiredUpgrades = requiredFinal;
            }
            else
            {
                var baseRecipeTag = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipe);
                recipe.RequiredUpgrades = baseRecipeTag.RequiredUpgrades;
            }
            if (recipeCategory != "")
            {
                recipe.Categories = new RecipeCategory[] { FindCategory.FindCategoryName(recipeCategory) };
            }
            else
            {
                var baseRecipeTag = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipe);
                recipe.Categories = baseRecipeTag.Categories.ToArray();
            }

            var guid = GUID.Parse(itemId);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}
