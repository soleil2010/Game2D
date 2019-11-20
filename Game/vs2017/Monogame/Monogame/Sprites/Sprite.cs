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
        protected bool _jump;
        protected bool _jumped = false;
        private float _jumpPosMax;
        private float _jumpPosMin;
        protected Animation _animation;
        protected Dictionary<string, Animation> _animations;

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
        public Sprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
        }
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
            if (Keyboard.GetState().IsKeyDown(Input.Up) && !_jump)
                Velocity.Y += -Speed*2;
            if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y += Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X += -Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X += Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Jump) && !_jump)
            {
                _jump = true;
                _jumpPosMax = Position.Y - this._texture.Height/2;
                _jumpPosMin = Position.Y;
                if (_jumpPosMax < 0)
                    _jumpPosMax = 0;
            }
        }
        /// <summary>
        /// sprite up until middle of height and fall 
        /// before to allow another jump (same position than before the jump)
        /// </summary>
        protected virtual void Jump()
        {
            if (_jump)
            {
                if (_jumpPosMax < Position.Y && !_jumped)
                {
                    Velocity.Y -= Speed*2;
                }
                else
                {
                    _jumped = true;
                    if (Position.Y >= _jumpPosMin)
                    {
                        _jump = false;
                        _jumped = false;
                    }
                }
            }
        }

        /// <summary>
        /// method used to update data of sprite
        /// </summary>
        public virtual void Update()
        {
            Move();
            Jump();
            Position += Velocity;
            Velocity = Vector2.Zero;
        }
        #endregion Methods

    }
}
