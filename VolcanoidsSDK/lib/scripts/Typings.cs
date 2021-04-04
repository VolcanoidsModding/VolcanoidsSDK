namespace VolcanoidsSDK.lib.scripts
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   The Typings Creation Class. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    class Typings
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or creates a Train Group Typing. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="factoryType">  Type of the factory. </param>
        ///
        /// <returns>   The or create typing. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static TrainProduction.GroupInfo GetOrCreateTyping(FactoryType factoryType)
        {
            TrainProduction production = new TrainProduction();
            return production.GetOrCreate(factoryType);
        }
    }
}
