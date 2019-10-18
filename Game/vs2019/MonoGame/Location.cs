using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    /// <summary>
    /// Define or Get the location for an object
    /// </summary>
    public class Location
    {
        private int _x;
        private int _y;
        /// <summary>
        /// Define the location of your object
        /// </summary>
        /// <param name="x">position X</param>
        /// <param name="y">position Y</param>
        public Location(int x=0, int y=0)
        {
            this._x = x;
            this._y = y;
        }
        /// <summary>
        /// Insert or Get value of position X
        /// </summary>
        public int X
        {
            get
            {
                return this._x;
            }
            set
            {
                this._x = value;
            }
        }
        /// <summary>
        /// Insert or Get value of position Y
        /// </summary>
        public int Y
        {
            get
            {
                return this._y;
            }
            set
            {
                this._y = value;
            }
        }
    }
}
