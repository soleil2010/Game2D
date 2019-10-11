using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    class Monster : Character
    {
        #region Private Attributes
        //private bool _move; // fait déjà partie de Character
        //private bool jump; // fait déjà partie de Character
        private bool _flee;
        private bool _pickUp;
        //private bool eat; // fait déjà partie de Character
        private bool _threw;
        #endregion Private Attributes

        #region Constructor
        /// <summary>
        /// Construis l'objet Monstre
        /// </summary>
        /// <param name="maxHealth">Monster's max Health</param>
        /// <param name="speed"></param>
        /// <param name="defense"></param>
        /// <param name="damages"></param>
        public Monster(int maxHealth, int speed, int defense, int resistance, int damages) : base(maxHealth, speed, defense, resistance, damages)
        {

        }
        #endregion Constructor

        #region Methods
        public void Flee()
        {
            double calculLife = this.CurrentHealth/ this.MaxHealth;
            int lifePercent = Convert.ToInt32(Math.Round(calculLife, MidpointRounding.AwayFromZero));
            if (lifePercent <= 10)
            {
                this._flee = true;
            }
        }

        public void FleeDirection(Directions direction)
        {

        }
        #endregion Methods

        #region Accessors

        public bool PickUp
        {
            get
            {
                return this._pickUp = true;
            }
        }


        #endregion Accessors
    }
}
