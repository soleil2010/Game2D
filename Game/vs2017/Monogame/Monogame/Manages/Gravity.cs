using Microsoft.Xna.Framework;
using Monogame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Manages
{
    public class Gravity
    {
        #region Property

        private double _timer;

        public double PreviousTimer;

        public float GravityValue;

        private float _previousSpeed = 0;

        private int _earthAttraction = 10;
        #endregion Property

        #region Constructor
        #endregion Constructor

        #region Methods

        public float SpeedChange()
        {

            if (this._timer != this.PreviousTimer)
            {
                this.GravityValue = (float)((this._earthAttraction * this._timer) + this._previousSpeed);
            }
            this._previousSpeed = this.GravityValue;
            return GravityValue;
        }

        #endregion Methods

        #region Accessors
        public double Timer
        {
            get
            {
                return this._timer;
            }
            set
            {
                this._timer = value;
            }
        }

        public float PreviousSpeed
        {
            get
            {
                return this._previousSpeed;
            }
            set
            {
                this._previousSpeed = value;
            }
        }
        #endregion Accessors
    }
}
