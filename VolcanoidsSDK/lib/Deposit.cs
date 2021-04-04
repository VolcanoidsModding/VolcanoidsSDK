using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace VolcanoidsSDK.lib
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Deposit Creation System. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    class Deposit
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a deposit. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="Underground">          If Deposit is Underground. </param>
        /// <param name="PercentageToReplace">  The percentage to replace. </param>
        /// <param name="outputname">           The outputname. </param>
        /// <param name="minyield">             The minyield. </param>
        /// <param name="maxyield">             The maxyield. </param>
        /// <param name="ItemToReplace">        The item to replace. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void CreateDeposit(bool Underground, int PercentageToReplace, string outputname, float minyield, float maxyield, string ItemToReplace)
        {
            DepositLocationSurface[] depositsurface = Resources.FindObjectsOfTypeAll<DepositLocationSurface>();
            DepositLocationUnderground[] depositunderground = Resources.FindObjectsOfTypeAll<DepositLocationUnderground>();
            if (Underground)
            {
                foreach (DepositLocationUnderground underground in depositunderground)
                {
                    if (Random.Range(0, 100) <= PercentageToReplace)
                    {
                        if ((ItemToReplace != null && underground.Ore == GetItem(ItemToReplace)) || ItemToReplace == null)
                        {
                            underground.Yield = Random.Range(minyield, maxyield);
                            OreField.SetValue(underground, GetItem(outputname));
                        }
                    }
                }
            }
            if (!Underground)
            {
                foreach (DepositLocationSurface surface in depositsurface)
                {
                    if (Random.Range(0, 100) <= PercentageToReplace)
                    {
                        if ((ItemToReplace != null && surface.Ore == GetItem(ItemToReplace)) || ItemToReplace == null)
                        {
                            surface.Yield = Random.Range(minyield, maxyield);
                            OreField.SetValue(surface, GetItem(outputname));
                        }
                    }
                }
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets an item. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="itemname"> The itemname. </param>
        ///
        /// <returns>   The item. </returns>
        ///-------------------------------------------------------------------------------------------------

        private static ItemDefinition GetItem(string itemname)
        {
            ItemDefinition item = GameResources.Instance.Items.FirstOrDefault(s => s.name == itemname);
            if (item == null)
            {
                Debug.LogError("Item is null, name: " + itemname + ". Replacing with NullItem");
                return GameResources.Instance.Items.FirstOrDefault(s => s.name == "NullItem");
            }
            return item;

        }
        /// <summary>   (Immutable) the ore field. </summary>
        private static readonly FieldInfo OreField = typeof(DepositLocation).GetField("m_ore", BindingFlags.NonPublic | BindingFlags.Instance);
    }
}
