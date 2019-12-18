using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame.Models
{
    public class Terrain
    {

        #region Properties
        protected Rectangle _rectangle;
        protected Texture2D _texture;
        #endregion Properties

        #region Accessors
        /// <summary>
        /// Get or redefine the texture of plateform
        /// </summary>
        public Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
        }
        /// <summary>
        /// get location of plateform
        /// </summary>
        public Vector2 Position
        {
            get => _rectangle.Location.ToVector2();
        }
        /// <summary>
        /// get the size of plateform
        /// </summary>
        public Point Size
        {
            get => _rectangle.Size;
        }

        public Rectangle Rectangle
        {
            get => _rectangle;
        }
        #endregion Accessors
    }
}
