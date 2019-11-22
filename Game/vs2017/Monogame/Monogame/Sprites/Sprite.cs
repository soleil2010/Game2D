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
        /// <summary>
        /// get the sprite skin
        /// </summary>
        public Texture2D Texture2D
        {
            get => _texture;
        }
        #endregion properties

        #region Methods
        /// <summary>
        /// Constructor with multiples sprites(picture with multiple images to generate an mouvement)
        /// </summary>
        /// <param name="animations">sprite with specific mouvement</param>
        /// <example>we want add sprite of right walk with 3 frames --> animations.Add("WalkRight", new Animation(Content.Load<Texture2D>("Character/WalkRight"), 3))</example>
        public Sprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
        }
        /// <summary>
        /// constructor with a simple sprite
        /// </summary>
        /// <param name="texture">picture</param>
        /// <example>new Character(Content.Load<Texture2D>("staticCharacter"))</example>
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }
        /// <summary>
        /// draw on screen our sprite with specific texture and position
        /// </summary>
        /// <param name="spriteBatch"></param>
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
                if (Keyboard.GetState().IsKeyDown(Input.Sprint))
                    Velocity.X += -Speed * 2;
                else
                    Velocity.X += -Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Right))
                if (Keyboard.GetState().IsKeyDown(Input.Sprint))
                    Velocity.X += Speed * 2;
                else
                    Velocity.X += Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Jump) && !_jump)
            {
                _jump = true;
            }
        }
        /// <summary>
        /// when jump, disable the jump
        /// </summary>
        protected virtual void Jump()
        {
            if (_jump)
            {
                _jump = false;
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
