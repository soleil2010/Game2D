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
        private int _damages;
        private int _defense;// physical defense
        private int _resistance;// magic resistance
        private int _speed;
        private Location _location;
        private bool _squat;
        private bool _jump;
        private bool _eat;
        private bool _onGround;
        private bool _isCrouch;
        #endregion Private attributes

        #region Constructor
        /// <summary>
        /// A Character has a max health and not eat, jump or eat when he is created.
        /// Its default location is 0;0
        /// </summary>
        /// <param name="maxHealth">max health of character</param>
        /// <param name="speed">move speed of character</param>
        /// <param name="defense">total damages you can protect by physical attack</param>
        /// <param name="resistance">total damages you can protect by magic attack</param>
        /// <param name="damages">total physical damages</param>
        public Character(int maxHealth, int speed, int defense, int resistance, int damages)
        {
            this._location = new Location();
            this._maxHealth = maxHealth;
            this._currentHealth = maxHealth;
            this._squat = false;
            this._jump = false;
            this._eat = false;
            this._defense = defense;
            this._resistance = resistance;
            this._damages = damages;
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
            if(direction == Directions.Left)
                this._location.X -= this._speed;
            if(direction == Directions.Right)
                this._location.X += this._speed;
            if (direction == Directions.Up)
                this._jump = true;
            if (direction == Directions.Down)
                Squating();
        }
        /// <summary>
        /// Jump on the world
        /// show an message on console
        /// </summary>
        public void Jumping()
        {
            if (this._jump)
                Console.WriteLine("I jump to infinity and the afterlife");
            this._jump = false;
        }
        /// <summary>
        /// Squat to hide presence 
        /// </summary>
        public void Squating()
        {
            this._squat = true;
            Console.WriteLine("You will not see me, little discreet laugh.");
        }
        /// <summary>
        /// Squat to hide presence 
        /// </summary>
        public void GetUp()
        {
            if (this._squat)
            {
                Console.WriteLine("Enemy is far, i can get up now...");
                this._squat = false;
            }
        }
        /// <summary>
        /// When player eat, receive a specific effect
        /// </summary>
        /// <param name="food">what food are you eating?</param>
        public bool Eating(Food food)
        {
           if(this.Eat)
            {
                if(food.Effect!=null)
                {
                    //we look effect on our food and active this.
                    switch (food.Effect)
                    {
                        case RegenerationEffect Regeneration:
                            //food with health effect regenerate the life of characters
                            if(Regeneration.regenerationType == RegenerationType.Health)
                                Regeneration.RegenerationHealth(this);
                            break;
                        case SicknessEffect sickness:
                            //sickness.Sickness();
                            break;
                        case BuffEffect buff:
                            //sickness.Sickness();
                            break;
                    }
                }
                this.Eat = false;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Make the character move to 16 px whenever this method is called
        /// The speed define how fast the character make this action.
        /// Exemple:
        /// (Speed = 1) = walk
        /// (Speed = 2) = run
        /// </summary>
        /// <param name="direction"></param>
        public void Movement(Directions direction)
        {
            if (direction == Directions.Right)
            {

                    this._location.X += this._speed;

            }
            if (direction == Directions.Left)
            {

                    this._location.X -= this._speed;

            }
        }
        /// <summary>
        /// How to jump
        /// </summary>
        /// <param name="direction"></param>
        public void Jumpment(Directions direction)
        {
            if (direction == Directions.Up && this._onGround)
            {

                this._location.Y += 5 * this._speed;

            }
        }
        /// <summary>
        /// How to squat
        /// </summary>
        /// <param name="direction"></param>
        public void Squattingment(Directions direction)
        {
            if(direction == Directions.Down && this._onGround && !this._squat)
            {
                this._location.Y -= 5;
                this._squat = true;
            }
            else
            this._squat = false;
        }

        #endregion Public methods

        #region Private methods
        public void IsOnGround(TypeTerrain typeTerrain, Terrain terrain)
        {
            switch (typeTerrain)
            {
                case TypeTerrain.ground:
                    if (this._location.Y == terrain.Location.Y)
                    {
                        _onGround = true;
                    }
                    else
                        _onGround = false;
                    break;
                case TypeTerrain.roof:
                    _onGround = false;
                    break;
                case TypeTerrain.wall:
                    _onGround = false;
                    break;
                case TypeTerrain.plateform:
                    _onGround = false;
                    break;
            }
                
        }
        #endregion Private methods

        #region Accessors
        /// <summary>
        /// Get or modify the current health
        /// </summary>
        public int CurrentHealth
        {
            get
            {
                return this._currentHealth;
            }
            set
            {
                if ( value > this._maxHealth)
                    this._currentHealth = this._maxHealth;
                else
                    this._currentHealth = value;
            }
        }
        /// <summary>
        /// Get the max health of your character
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return this._maxHealth;
            }
        }
        /// <summary>
        /// Modify or get the speed of your character
        /// </summary>
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
        /// <summary>
        /// Modify or get the phyysical defence of your character
        /// </summary>
        public int Defense
        {
            get
            {
                return this._defense;
            }
            set
            {
                this._defense = value;
            }
        }
        /// <summary>
        /// Modify or get the magic resistance of your character
        /// </summary>
        public int Resistance
{
            get
            {
                return this._resistance;
            }
            set
            {
                this._resistance = value;
            }
        }
        /// <summary>
        /// Modify or get the physical damages of your character
        /// </summary>
        public int Damages
{
            get
            {
                return this._damages;
            }
            set
            {
                this._damages = value;
            }
        }
        /// <summary>
        /// Define or get if your character squat
        /// </summary>
        public bool Squat
        {
            get
            {
                return this._squat;
            }
            set
            {
                this._squat = value;
            }
        }
        /// <summary>
        /// Define or get if your character jump
        /// </summary>
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
        /// <summary>
        /// Define or get if your character eat
        /// </summary>
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

        public bool OnGround
        {
            get
            {
                return this._onGround;
            }
        }
        /// <summary>
        /// get the current location of character or define a new location
        /// </summary>
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
