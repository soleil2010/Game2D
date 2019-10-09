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
        private bool _attack;
        private bool _threw;
        #endregion Private Attributes

        #region Constructor
        /// <summary>
        /// Construis l'objet Monstre
        /// </summary>
        /// <param name="maxHealth">Monster's max Health</param>
        /// <param name="speed"></param>
        /// <param name="defense"></param>
        /// <param name="Damage"></param>
        public Monster(int maxHealth, int speed, int defense, int damage)
        {
            this.MaxHealth = maxHealth;
            this.Speed = speed;
            this.Defense = defense;
            this.Damage = damage;
        }
        #endregion Constructor

        #region Methods
        #endregion Methods

        #region Accessors
        public bool Flee
        {
            get
            {
                return this._flee = true;
            }
        }

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
