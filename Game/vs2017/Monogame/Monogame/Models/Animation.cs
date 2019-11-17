using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Models
{
    /// <summary>
    /// Create an animation with a sprite image
    /// (picture with multiples images to generate a specific mouvement)
    /// </summary>
    public class Animation
    {
        #region properties
        /// <summary>
        /// animation is actually used
        /// </summary>
        public bool IsLooping { get; set; }
        /// <summary>
        /// define or get the current picture(frame) on the big image
        /// </summary>
        public int CurrentFrame { get; set; }
        /// <summary>
        /// how many pictures(frames) we have on the big image
        /// </summary>
        public int FrameCount { get; private set; }
        /// <summary>
        /// what's the speed to change between frames
        /// </summary>
        public float FrameSpeed { get; private set; }
        /// <summary>
        /// get the height size of big image
        /// </summary>
        public int FrameHeight { get { return Texture.Height; } }
        /// <summary>
        /// get the size of each picture(frame) in big image
        /// </summary>
        public int FrameWidth { get { return Texture.Width / FrameCount; } }
        #endregion properties
        /// <summary>
        /// get the big picture with all frames
        /// </summary>
        public Texture2D Texture { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture">big picture with multiple images to generate an mouvement</param>
        /// <param name="frameCount">how many frames do you have for specific mouvements</param>
        public Animation(Texture2D texture, int frameCount)
        {
            Texture = texture;
            FrameCount = frameCount;
            IsLooping = true;
            FrameSpeed = 0.2f;
        }
    }
}
