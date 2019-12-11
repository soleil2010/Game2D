using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Models.terrain
{
    /// <summary>
    /// Define plateforms of the game
    /// </summary>
    public class Plateform
    {
        #region Properties
        private Rectangle _rectangle;
        private Texture2D _texture;
        private Color _color;
        #endregion Properties

        #region constructor
        /// <summary>
        /// create a plateform based on texture
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position">location on game</param>
        public Plateform(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            _color = Color.White;
        }
        /// <summary>
        /// create a plateform with specific data
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="rectangle">size of texture and its location</param>
        public Plateform(Texture2D texture, Rectangle rectangle)
        {
            _texture = texture;
            _rectangle = rectangle;
            _color = Color.White;
        }
        /// <summary>
        /// create a plateform without texture
        /// </summary>
        /// <param name="rectangle">size of plateform and its location</param>
        public Plateform(Rectangle rectangle)
        {
            _color = Color.Black;
            _rectangle = rectangle;
        }
        /// <summary>
        /// create a plateform without texture but with color
        /// </summary>
        /// <param name="rectangle">size of plateform and its location</param>
        /// <param name="color"></param>
        public Plateform(Rectangle rectangle, Color color)
        {
            _color = color;
            _rectangle = rectangle;
        }
        #endregion constructor
        
        #region methods
        /// <summary>
        /// Show on the game the plateform
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if(_texture==null)
            {
                _texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                _texture.SetData(new Color[] { _color });
            }
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }
        #endregion methods

        #region Accessors
        /// <summary>
        /// get location of plateform
        /// </summary>
        public Vector2 Location
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
        /// <summary>
        /// Get or redefine the texture of plateform
        /// </summary>
        public Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
        }

        public Rectangle Rectangle
        {
            get => _rectangle;
        }
        #endregion Accessors
    }
}
