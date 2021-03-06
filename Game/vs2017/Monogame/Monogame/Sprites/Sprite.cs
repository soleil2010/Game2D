﻿using Microsoft.Xna.Framework;
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
        public enum Direction { Up, Down, Right, Left}
        /// <summary>
        /// Direction where sprite looks
        /// </summary>
        public Direction Looking;

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

        /// <summary>
        /// sprite is an rectangle
        /// </summary>
        protected Rectangle _rectangle;

        /// <summary>
        /// define if sprite is on ground
        /// </summary>
        public bool Grounded;

        /// <summary>
        /// define a gravity value
        /// </summary>
        public float Gravity=0;
        /// <summary>
        /// define a friction value
        /// </summary>
        public float Friction=1;
        #endregion properties

        #region Constructor
        public Sprite(Texture2D texture)
        {
            this._texture = texture;
            this._rectangle = new Rectangle(0, 0, this._texture.Width, this._texture.Height);
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// Modify the velocity of sprite in terms of keys
        /// </summary>
        protected virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Jump) && Grounded)
            {
                Looking = Direction.Up;
                this.Velocity.Y = -20;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Looking = Direction.Up;
                this.Velocity.Y = -Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Down) && !Grounded)
            {
                Looking = Direction.Down;
                this.Velocity.Y = Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Looking = Direction.Left;
                this.Velocity.X = -Speed;
                if (Keyboard.GetState().IsKeyDown(Input.Sprint))
                    this.Velocity.X *= 2;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Looking = Direction.Right;
                this.Velocity.X = Speed;
                if (Keyboard.GetState().IsKeyDown(Input.Sprint))
                    this.Velocity.X *= 2;
            }
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
            if (Math.Abs(Velocity.X) < Friction) Velocity.X = 0;

            if (Velocity.X < 0)
                Velocity.X += Friction;
            else if (Velocity.X > 0)
                Velocity.X -= Friction;
            

            Velocity.Y += Gravity;
            Position += Velocity;
        }
        #endregion Methods

        #region Accessors
        /// <summary>
        /// Define the position or get the current position
        /// </summary>
        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                _rectangle.Location = this._position.ToPoint();
            }
        }
        /// <summary>
        /// Get the current texture of sprite
        /// </summary>
        public Texture2D Texture
        {
            get => this._texture;
        }

        public Rectangle Rectangle
        {
            get => _rectangle;
        }
        #endregion Accessors

    }
}
