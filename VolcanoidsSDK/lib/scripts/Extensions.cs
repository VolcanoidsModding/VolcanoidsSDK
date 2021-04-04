using System.Reflection;
using UnityEngine;

namespace VolcanoidsSDK.lib.scripts
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   All Extension Methods for this Framework. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public static class Extensions
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that sets private field. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="obj">          The obj to act on. </param>
        /// <param name="fieldName">    Name of the field. </param>
        /// <param name="newValue">     The new value. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static bool SetPrivateField<T>(this T obj, string fieldName, object newValue)
        {
            var fieldInfo = typeof(ItemDefinition).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (fieldInfo == null)
            {
                Debug.LogError($"Error: Unable to find private field `{fieldName}` in `{typeof(T)}`.");
                return false;
            }
            fieldInfo.SetValue(obj, newValue);
            return true;
        }
    }
}
