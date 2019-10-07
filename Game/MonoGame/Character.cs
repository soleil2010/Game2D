using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class Character
    {
        #region Private attributes
        private int _currentHealth;
        private int _maxHealth;
        private int _speed;
        private int _posX;
        private int _posY;
        private bool _squad;
        private bool _jump;
        private bool _eat;
        #endregion Private attributes

        #region Constructor
        #endregion Constructor

        #region Public methods
        public void Move(string direction)
        {
            switch(direction)
            {
                case "left":
                    this._posX -= this._speed;
                    break;
                case "right":
                    this._posX += this._speed;
                    break;
                case "up":
                    this._jump = true;
                    break;
                case "down":
                    this._squad = true;
                    break;
            }
        }
        #endregion Public methods

        #region Private methods
        #endregion Private methods

        #region Accessors
        public int CurrentHealth
        {
            get
            {
                return this._currentHealth;
            }
            set
            {
                this._currentHealth = value;
            }
        }
        public int MaxHealth
        {

            get
            {
                return this._maxHealth;
            }
            set
            {
                this._maxHealth = value;
            }
        }
        public int Speed
        {

            get
            {
                return this._speed;
            }
            set
            {
                this._speed = value;
            }
        }
        public bool Squad
        {
            get
            {
                return this._squad;
            }
            set
            {
                this._squad = value;
            }
        }
        public bool Jump
        {

            get
            {
                return this._jump;
            }
            set
            {
                this._jump = value;
            }
        }
        public bool Eat
        {

            get
            {
                return this._eat;
            }
            set
            {
                this._eat = value;
            }
        }
        
        #endregion Accessors
    }
}
