using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class Player : Character
    {
        #region Private attributes
        private int _maxMana;
        private int _currentMana;
        #endregion Private attributes

        #region Constructor
        /// <summary>
        /// Player have health and mana to use magic.
        /// He have a basic speed to move in world
        /// </summary>
        /// <param name="maxHealth">Max health of player</param>
        /// <param name="speed">Player's basic speed to move in world</param>
        /// <param name="maxMana">Magic points to use magic power</param>
        /// <param name="damages">Physical damages of player</param>
        /// <param name="defense">Player's physical defence</param>
        /// <param name="resistance">Magic resistance</param>
        public Player(int maxHealth, int speed, int defense, int resistance, int damages, int maxMana) : base(maxHealth, speed, defense, resistance, damages)
        {
            this._maxMana = maxMana;
            this._currentMana = MaxMana;
        }
        #endregion Constructor

        #region Public methods 
        /// <summary>
        /// When player eat, receive a specific effect
        /// player can regenerate mana
        /// </summary>
        /// <param name="food">what food are you eating?</param>
        public void Eating(Food food)
        {
            if (this.Eat)
            {
                if (food.Effect != null)
                {
                    //we look effect on our food and active this.
                    switch (food.Effect)
                    {
                        case RegenerationEffect Regeneration:
                            //food with mana effect regenerate the mana of player
                            if (Regeneration.regenerationType == RegenerationType.Mana)
                            {
                                Regeneration.RegenerationMana(this);
                            }
                            break;
                    }
                }
                this.Eat = false;
            }
        }
        #endregion Public methods

            #region Private methods
            #endregion Private methods

            #region Accessors
        public int MaxMana
        {
            get
            {
                return _maxMana;
            }
        }
        public int CurrentMana
        {
            get
            {
                return this._currentMana;
            }
            set
            {
                if ( value > this._maxMana)
                    this._currentMana = this._maxMana;
                else
                    this._currentMana = value;
            }
        }
        #endregion Accessors

    }
}
