using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class EffectSickness:Effect
    {
        private string _name;

        /// <summary>
        /// Constructor for Sickness effect
        /// </summary>
        /// <param name="sickness">what sickness do you want add?</param>
        public EffectSickness(Sickness sickness)
        {
            _name = sickness.ToString();
        }

        public void Sickness(Action<int> actualValue, int valueToGive, int seconds = 1)
        {
            //we split value for give equivalent value after x time
            if (seconds != 0)
                valueToGive = Convert.ToInt32(Math.Round((valueToGive / (float)seconds), MidpointRounding.AwayFromZero));
            actualValue(-valueToGive);

        }
    }
}
