using System.Collections.Generic;
using System.Linq;

namespace VolcanoidsSDK.lib.scripts
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   The Class to Find a Factory Category. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    class FindFactoryCategories
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Searches for the first factory names. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="categoryName"> Name of the category. </param>
        ///
        /// <returns>   The found factory names. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static FactoryType FindFactoryNames(string categoryName)
        {
            return GameResources.Instance.FactoryTypes.FirstOrDefault(type => type?.name == categoryName);
        }
    }
}
