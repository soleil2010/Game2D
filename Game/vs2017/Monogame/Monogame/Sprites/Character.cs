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
    public class Character : Sprite
    {

        #region properties
        private float _jumpPosMax;
        private float _jumpPosMin;


        public Texture2D Texture2D
        {
            get => _texture;
        }
        #endregion properties

        #region Methods
        public Character(Dictionary<string, Animation> animations):base(animations)
        {
            this._animations = animations;
        }
        public Character(Texture2D texture):base(texture)
        {
            this._texture = texture;
        }


        /// <summary>
        /// modify the velocity of sprite in terms of keys
        /// </summary>
        protected override void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up) && !this._jump)
                this.Velocity.Y += -this.Speed * 2;
            if (Keyboard.GetState().IsKeyDown(Input.Down))
                this.Velocity.Y += this.Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                this.Velocity.X += -this.Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Right))
                this.Velocity.X += this.Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Jump) && !_jump)
            {
                this._jump = true;
                this._jumpPosMax = this.Position.Y - this._texture.Height/2;
                this._jumpPosMin = this.Position.Y;
                if (_jumpPosMax < 0)
                    _jumpPosMax = 0;
            }
        }
        /// <summary>
        /// sprite up until middle of height and fall 
        /// before to allow another jump (same position than before the jump)
        /// </summary>
        protected override void Jump()
        {
            if (this._jump)
            {
                this._jump = false;
                if (this._jumpPosMax < this.Position.Y && !this._jumped)
                {
                    this.Velocity.Y -= this.Speed *2;
                }
                else
                {
                    this._jumped = true;
                    if (this.Position.Y >= this._jumpPosMin)
                    {
                        this._jump = false;
                        this._jumped = false;
                    }
                }
            }
        }
        #endregion Methods
    }
}
