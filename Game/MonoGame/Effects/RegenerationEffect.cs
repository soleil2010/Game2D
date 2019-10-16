using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class RegenerationEffect : Effect
    {
        #region Private attributes
        private RegenerationType _regenerationType;
        private int _valueToGive;
        private int _time;
        #endregion Private attributes

        #region Constructor
        /// <summary>
        /// Constructor for Regeneration Effect
        /// </summary>
        /// <param name="regeneration">what do you want regenerate?</param>
        public RegenerationEffect(RegenerationType regenerationType, int valueToGive, int seconds=1)
        {
            _regenerationType = regenerationType;
            _valueToGive = valueToGive;
            _time = seconds;
        }
        #endregion Construtor

        #region Public methods 
        #endregion Public methods 

        /// <summary>
        /// Increment value of reference 
        /// </summary>
        /// <param name="actualValue">What do you want regenerate?</param>
        /// <param name="valueToGive">What value your element have to add?</param>
        /// <param name="seconds">During what's time?</param>
        /// <example>Regeneration(value => Character.Health += value,50,5) <-- give 10 Health point each second</example>
        public void RegenerationHealth(Character character)
        {
            //we split value for give equivalent value after x time
            if (_time != 0)
                _valueToGive = Convert.ToInt32(Math.Round((_valueToGive / (float)_time), MidpointRounding.AwayFromZero));

            //loop during a specific time (seconds)
            for (int i = 0; i < _time; i++)
            {
                character.CurrentHealth += _valueToGive;
                if (_time > 1)
                    System.Threading.Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// Add mana points to player
        /// </summary>
        /// <param name="player">what player have to regenerate mana?</param>
        public void RegenerationMana(Player player)
        {
            //we split value for give equivalent value after x time
            if (_time != 0)
                _valueToGive = Convert.ToInt32(Math.Round((_valueToGive / (float)_time), MidpointRounding.AwayFromZero));

            //loop during a specific time (seconds)
            for (int i = 0; i < _time; i++)
            {
                player.CurrentMana += _valueToGive;
                if (_time > 1)
                    System.Threading.Thread.Sleep(1000);
            }
        }

        #region Private methods 
        #endregion Private methods 

        #region Accessors
        /// <summary>
        /// get the type of regeneration
        /// </summary>
        public RegenerationType regenerationType
        {
            get => _regenerationType;
        }
        #endregion Accessors
    }
}
