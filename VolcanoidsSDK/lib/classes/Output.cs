using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolcanoidsSDK.lib.classes
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Output Typing Class. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class Output
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name of the output. </summary>
        ///
        /// <value> The name of the output. </value>
        ///-------------------------------------------------------------------------------------------------

        public string output_name { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the output amount. </summary>
        ///
        /// <value> The output amount. </value>
        ///-------------------------------------------------------------------------------------------------

        public int output_amount { get; set; }
    }
}
