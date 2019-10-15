using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class Food : Object
    {
        #region private attributes
        private Effect _effect;
        #endregion private attributes

        #region constructors
        /// <summary>
        /// Create a new food
        /// </summary>
        /// <param name="name">what's name of your food</param>
        /// <param name="location">where is its location</param>
        public Food(string name, Location location, Effect effect=null):base(name,location)
        {
            _effect = effect;            
        }
        #endregion constructors

        #region private methods
        #endregion private methods

        #region public methods
        #endregion public methods

        #region accessors and mutators
        public Effect Effect
        {
            get => _effect;
        }
        #endregion accessors and mutators
    }
}
