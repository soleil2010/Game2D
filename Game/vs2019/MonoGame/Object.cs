using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    /// <summary>
    /// All objects have a name and location
    /// </summary>
    public class Object
    {

        #region private attributes
        private Location _location;
        private string _name;
        #endregion private attributes

        #region constructors
        /// <summary>
        /// Define our object
        /// </summary>
        /// <param name="name">what's name of our object</param>
        /// <param name="location">where is my object (X,Y)</param>
        public Object(string name, Location location)
        {
            this._name = name;
            this._location = location;
        }
        #endregion constructors

        #region private methods
        #endregion private methods

        #region public methods
        #endregion public methods

        #region accessors and mutators
        /// <summary>
        /// Get the position of object
        /// Set a new location of object (example, when your object move)
        /// </summary>
        public Location Location
        {
            get
            {
                return this._location;
            }
            set
            {
                this._location = value;
            }
        }
        /// <summary>
        /// Get the name of object
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
        }
        #endregion accessors and mutators
    }
}
