using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Manages
{
    /// <summary>
    /// Manage the Animation of our sprite, setting the frames
    /// Make our object not being static when they move (animation!)
    /// </summary>
    public class AnimationManager
    {
        private Animation _animation;

        private float _timer;

        /// <summary>
        /// Define where our object is right now
        /// </summary>
        public Vector2 Position { get; set; }

        #region Constructor
        /// <summary>
        /// Give us the texture for our animation
        /// </summary>
        /// <param name="animation"></param>
        public AnimationManager(Animation animation)
        {
            _animation = animation;
        }
        #endregion Constructor

        #region Methods

        /// <summary>
        /// Draw in game the sprite
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_animation.Texture, Position, new Rectangle(_animation.CurrentFrame * _animation.FrameWidth, 0, _animation.FrameWidth, _animation.FrameHeight), Color.White);
        }

        /// <summary>
        /// Play the sequence define by the current frame
        /// </summary>
        /// <param name="animation"></param>
        public void Play(Animation animation)
        {
            if (_animation == animation)
                return;

            _animation = animation;

            _animation.CurrentFrame = 0;

            _timer = 0;
        }
        /// <summary>
        /// Stop the animation to the frame 0
        /// </summary>
        public void Stop()
        {
            _timer = 0;
            _animation.CurrentFrame = 0;
        }
        /// <summary>
        /// Update the animation given by the sequence in the art, taking one frame after an other
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;

                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                {
                    _animation.CurrentFrame = 0;
                }
            }
        }
        #endregion Methods
        /// <summary>
        /// Allow to get the current animation
        /// </summary>
        #region Accessors
        public Animation Animation
        {
            get => this._animation;         
        }
        #endregion Accessors
    }
}
