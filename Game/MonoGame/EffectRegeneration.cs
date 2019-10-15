using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class EffectRegeneration : Effect
    {
        private Regeneration _regeneration;
        private int _valueToGive;
        private int _time;

        /// <summary>
        /// Constructor for Regeneration Effect
        /// </summary>
        /// <param name="regeneration">what do you want regenerate?</param>
        public EffectRegeneration(Regeneration regeneration, int valueToGive, int seconds=1)
        {
            _regeneration = regeneration;
            _valueToGive = valueToGive;
            _time = seconds;
        }

        /// <summary>
        /// Increment value of reference 
        /// </summary>
        /// <param name="actualValue">What do you want regenerate?</param>
        /// <param name="valueToGive">What value your element have to add?</param>
        /// <param name="seconds">During what's time?</param>
        /// <example>Regeneration(value => Character.Health += value,50,5) <-- give 10 Health point each second</example>
        public void RegenerationHealth(ref Character character)
        {
            //we split value for give equivalent value after x time
            if (_time != 0)
                _valueToGive = Convert.ToInt32(Math.Round((_valueToGive / (float)_time), MidpointRounding.AwayFromZero));

            for (int i = 0; i < _time; i++)
            {
                character.CurrentHealth += _valueToGive;
                if (_time > 1)
                    System.Threading.Thread.Sleep(1000);
            }
        }
        public void RegenerationMana(ref Player player)
        {
            //we split value for give equivalent value after x time
            if (_time != 0)
                _valueToGive = Convert.ToInt32(Math.Round((_valueToGive / (float)_time), MidpointRounding.AwayFromZero));

            for (int i = 0; i < _time; i++)
            {
                player.CurrentMana += _valueToGive;
                if (_time > 1)
                    System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
