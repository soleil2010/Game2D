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
        private bool _jumped = false;
        private float _jumpPosMax;
        private float _jumpPosMin;
        #endregion properties

        #region Methods
        /// <summary>
        /// Constructor with multiples sprites
        /// </summary>
        /// <param name="animations">sprite with specific mouvement</param>
        /// <example>we want add sprite of right walk with 3 frames --> animations.Add("WalkRight", new Animation(Content.Load<Texture2D>("Character/WalkRight"), 3))</example>
        public Character(Dictionary<string, Animation> animations) : base(animations){ }
        /// <summary>
        /// constructor with a simple sprite
        /// </summary>
        /// <param name="texture">picture</param>
        /// <example>new Character(Content.Load<Texture2D>("staticCharacter"))</example>
        public Character(Texture2D texture) : base(texture){ }

        /// <summary>
        /// modify the velocity of sprite in terms of keys
        /// </summary>
        protected override void Move()
        {
            if (Keyboard.GetState().IsKeyDown(this.Input.Up) && !this._jump)
                this.Velocity.Y += -this.Speed * 2;
            if (Keyboard.GetState().IsKeyDown(this.Input.Down))
                this.Velocity.Y += this.Speed;
            if (Keyboard.GetState().IsKeyDown(this.Input.Left))
                if (Keyboard.GetState().IsKeyDown(this.Input.Sprint))
                    this.Velocity.X += -this.Speed * 2;
                else
                    this.Velocity.X += -this.Speed;
            if (Keyboard.GetState().IsKeyDown(this.Input.Right))
                if (Keyboard.GetState().IsKeyDown(this.Input.Sprint))
                    this.Velocity.X += this.Speed * 2;
                else
                    this.Velocity.X += this.Speed;
            if (Keyboard.GetState().IsKeyDown(this.Input.Jump) && !this._jump)
            {
                this._jump = true;
                if (_animationManager != null)
                    this._jumpPosMax = this.Position.Y - this._animationManager.Animation.FrameHeight / 2;
                else
                    this._jumpPosMax = this.Position.Y - this._texture.Height / 2;
                this._jumpPosMin = this.Position.Y;
                if (this._jumpPosMax < 0)
                    this._jumpPosMax = 0;
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

        /// <summary>
        /// Set the animation depending of the behaviour of our character
        /// </summary>        
        protected override void SetAnimations()
        {
            if (_animations != null)
            {
                if(Velocity.X > 0) //walk to the right while stading
                    this._animationManager.Play(_animations["WalkRight"]);
                else if(Velocity.X < 0) //walk to the left while stading
                    this._animationManager.Play(_animations["WalkLeft"]);
                else if(Velocity.Y < 0) //walk to the up while stading
                    this._animationManager.Play(_animations["WalkUp"]);
                else if(Velocity.Y > 0) //walk to the down while stading
                    this._animationManager.Play(_animations["WalkDown"]);
                else
                    this._animationManager.Stop();
            }
        }
        #endregion Methods
    }
}
