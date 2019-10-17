using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class SicknessEffect : Effect
    {
        #region Private attributes
        private SicknessType _type;
        private int _valueToGive;
        private int _time;
        #endregion Private attributes
        #region Constructor
        /// <summary>
        /// Constructor for Sickness effect
        /// </summary>
        /// <param name="sickness">what sickness do you want add?</param>
        public SicknessEffect(SicknessType sicknessType, int valueToGive, int seconds = 1)
        {
            this._type = sicknessType;
            this._valueToGive = valueToGive;
            this._time = seconds;
        }
        #endregion Constructor

        #region Public methods 
        #endregion Public methods 

        #region Private methods 
        #endregion Private methods 

        #region Accessors
        /// <summary>
        /// get the type of sickness
        /// </summary>
        public SicknessType sicknessType
        {
            get => this._type;
        }
        #endregion Accessors
    }
}
