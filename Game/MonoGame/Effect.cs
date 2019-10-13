using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public enum Type { Regeneration, Sickness, Buff}

    public class Effect
    {
        private string _name;
        private Type _type;

        public Effect(Type type, string name)
        {
            _type = type;
            _name = name;
        }
        /// <summary>
        /// Increment value of reference 
        /// </summary>
        /// <param name="actualValue">What do you want regenerate?</param>
        /// <param name="valueToGive">What value your element have to add?</param>
        /// <param name="seconds">During what's time?</param>
        /// <example>Regeneration(value => Character.Health += value,50,5) <-- give 10 Health point each second</example>
        public void Regeneration(Action<int> actualValue, int valueToGive, int seconds=1)
        {
            //we split value for give equivalent value after x time
            if (seconds != 0)
               valueToGive = Convert.ToInt32(Math.Round((valueToGive / (float)seconds), MidpointRounding.AwayFromZero));

            for (int i=0; i<seconds; i++)
            {
                actualValue(valueToGive);
                if(seconds>1)
                    System.Threading.Thread.Sleep(1000);
            }
        }

        public Type Type
        {
            get => _type;
        }
    }
}
