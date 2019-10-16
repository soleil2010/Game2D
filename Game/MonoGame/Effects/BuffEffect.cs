using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class BuffEffect : Effect
    {
        #region Private attributes
        private BuffType _type;
        private int _valueToGive;
        private int _time;
        #endregion Private attributes
        #region Constructor
        public BuffEffect(BuffType buffType, int valueToGive, int seconds = 1)
        {
            this._type = buffType;
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
        /// get the type of buff
        /// </summary>
        public BuffType buffType
        {
            get => _type;
        }
        #endregion Accessors
    }
}
