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
        public Player(int maxHealth, int speed, int maxMana) : base(maxHealth, speed)
        {
            this._maxMana = maxMana;
            this._currentMana = MaxMana;
        }
        #endregion Constructor

        #region Public methods
        /// <summary>
        /// Jump on the world
        /// show an message on console
        /// </summary>
        public void Jumping()
        {
            base.Jump = true;
            Console.WriteLine("I jump to infinity and the afterlife");
            base.Jump = false;
        }
        /// <summary>
        /// Squat to hide presence 
        /// </summary>
        public void Squating()
        {
            base.Squat = true;
            Console.WriteLine("You will not see me, little discreet laugh.");
        }
        /// <summary>
        /// Squat to hide presence 
        /// </summary>
        public void GetUp()
        {
            Console.WriteLine("Enemy is far, i can get up now...");
            base.Squat = false;
        }
        /// <summary>
        /// Eat to restore health
        /// </summary>
        /// <param name="fruit"></param>
        public void Eating(string fruit)
        {
            base.Eat = true;
            Console.WriteLine("Take "+ fruit);

            Console.Write("Eating the "+ fruit);
            for(int i=0; i<6; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(300);
            }
            Console.WriteLine();
            Console.WriteLine("Its was good!");
            base.Eat = false;
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
                this._currentMana = value;
            }
        }
        #endregion Accessors

    }
}
