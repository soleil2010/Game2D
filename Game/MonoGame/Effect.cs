using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    /// <summary>
    /// Enum for constructor Effect
    /// </summary>
    public enum Regeneration { Health, Mana}
    /// <summary>
    /// Enum for constructor Effect
    /// </summary>
    public enum Sickness { Vomit, Vision, Weakness, Confused, Lazyness, LowIQ, Rage}
    /// <summary>
    /// Enum for constructor Effect
    /// </summary>
    public enum Buff { Ghost, FireBolt, Insensitive, Boo, Gaz, NightVision, SeeSecrets}

    public abstract class Effect
    {
       /* private string _name;
        private TypeEffect _type;

        
        /// <summary>
        /// Constructor for Buff effect
        /// </summary>
        /// <param name="buff">what buff do you want add?</param>
        public Effect(Buff buff)
        {
            _type = TypeEffect.Sickness;
            _name = buff.ToString();
        }

        public void Sickness(Action<int> actualValue, int valueToGive, int seconds = 1)
        {
            //we split value for give equivalent value after x time
            if (seconds != 0)
                valueToGive = Convert.ToInt32(Math.Round((valueToGive / (float)seconds), MidpointRounding.AwayFromZero));
            actualValue(-valueToGive);

        }
        /// <summary>
        /// Get the effect type of our object
        /// </summary>
        public TypeEffect Type
        {
            get => _type;
        }*/
    }
}
