using System.IO;
using UnityEngine;

namespace VolcanoidsSDK.lib.scripts
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A sprite generator. </summary>
    ///
    /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
    ///-------------------------------------------------------------------------------------------------

    class SpriteGenerator
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Generates a sprite. </summary>
        ///
        /// <remarks>   MelodicAlbuild, 3/30/2021. </remarks>
        ///
        /// <param name="iconpath"> The iconpath. </param>
        ///
        /// <returns>   The sprite. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static Sprite GenerateSprite(string iconpath)
        {
            var path = Path.Combine(Application.persistentDataPath, "Mods", iconpath);
            if (!File.Exists(path))
            {
                Debug.LogError("[Questing Update | Modules]: Specified Icon path not found: " + path);
                return null;
            }
            var bytes = File.ReadAllBytes(path);


            var texture = new Texture2D(512, 512, TextureFormat.ARGB32, true);
            texture.LoadImage(bytes);

            var sprite = Sprite.Create(texture, new Rect(Vector2.zero, Vector2.one * texture.width), new Vector2(0.5f, 0.5f), texture.width, 0, SpriteMeshType.FullRect, Vector4.zero, false);
            return sprite;
        }
    }
}
