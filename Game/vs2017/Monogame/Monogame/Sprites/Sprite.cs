using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame.Manages;
using Monogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Sprites
{
    /// <summary>
    /// Basic sprite,
    /// It has an basic texture2D and we can move it
    /// </summary>
    public class Sprite
    {
        #region properties
        // Texture of sprite
        protected Texture2D _texture;

        // Position of sprite
        protected Vector2 _position;

        /// <summary>
        /// Speed on x, y position
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// Input used to move our sprite
        /// </summary>
        public Input Input;

        /// <summary>
        /// What's the speed of sprite, default:1
        /// </summary>
        public float Speed = 1;
        #endregion properties

        #region Constructor
        public Sprite(Texture2D texture)
        {
            this._texture = texture;
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// Modify the velocity of sprite in terms of keys
        /// </summary>
        protected virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
                this.Velocity.Y += -Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Down))
                this.Velocity.Y += Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                this.Velocity.X += -Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Right))
                this.Velocity.X += Speed;
        }
        
        /// <summary>
        /// Method used to draw sprite
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (this._texture != null)
                spriteBatch.Draw(this._texture, this._position, Color.White);
            else
                throw new Exception("Sprite doesn't have texture...");
        }

        /// <summary>
        /// Method used to update data of sprite
        /// </summary>
        public virtual void Update(GameTime gameTime)
        {
            Move();
            _position += Velocity;
            Velocity = Vector2.Zero;
        }
        #endregion Methods

        #region Accessors
        /// <summary>
        /// Define the position or get the current position
        /// </summary>
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }
        /// <summary>
        /// Get the current texture of sprite
        /// </summary>
        public Texture2D Texture
        {
            get => this._texture;
        }
        #endregion Accessors

    }
}
