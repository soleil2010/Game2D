using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    /// <summary>
    /// allows to use a term for the direction, avoiding writing errors.
    /// exemple: Directions.Up mean top direction
    /// </summary>
    public enum Directions { Up, Down, Left, Right };
    public class Character
    {
        #region Private attributes
        private int _currentHealth;
        private int _maxHealth;
        private int _speed;
        private Location _location;
        private bool _squad;
        private bool _jump;
        private bool _eat;
        #endregion Private attributes

        #region Constructor
        public Character(int maxHealth)
        {
            _location = new Location();
            _maxHealth = maxHealth;
            _squad = false;
            _jump = false;
            _eat = false;
        }
        #endregion Constructor

        #region Public methods
        /// <summary>
        /// What's direction your character move?
        /// Left, Right, Top or Down?
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Directions direction)
        {
            switch(direction)
            {
                case Directions.Left:
                    this._location.X -= this._speed;
                    break;
                case Directions.Right:
                    this._location.X += this._speed;
                    break;
                case Directions.Up:
                    this._jump = true;
                    break;
                case Directions.Down:
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
        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                this._location = value;
            }
        }
        #endregion Accessors
    }
}
