using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Sprites
{
    /// <summary>
    /// Template of sprite
    /// </summary>
    public class Sprite
    {
        #region properties
        protected Animation _animation;

        // position of sprite
        protected Vector2 _position;
        protected Texture2D _texture;

        /// <summary>
        /// speed on x, y position
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// input used to move our sprite
        /// </summary>
        public Input Input;

        /// <summary>
        /// what's the speed of sprite
        /// </summary>
        public float Speed = 1;

        /// <summary>
        /// define the position or get the current position
        /// </summary>
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public Texture2D Texture2D
        {
            get => _texture;
        }
        #endregion properties

        #region Methods
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, Color.White);
            else
                throw new Exception("Sprite doesn't has a texture...");
        }
        /// <summary>
        /// modify the velocity of sprite in terms of keys
        /// </summary>
        protected virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
                Velocity.Y += -Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y += Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X += -Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X += Speed;
        }
        /// <summary>
        /// method used to update data of sprite
        /// </summary>
        public virtual void Update()
        {
            Move();

            Position += Velocity;
            Velocity = Vector2.Zero;
        }
        #endregion Methods

    }
}
