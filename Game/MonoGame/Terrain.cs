using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public enum TypeTerrain { ground, roof, wall, plateform }
    class Terrain
    {
        #region Attributes
        private bool _ground;
        private bool _roof;
        private bool _wall;
        private bool _plateform;
        #endregion Attributes

        #region Constructor
        /// <summary>
        /// Construct the object Terrain
        /// Ein terrain Ein Affectation
        /// </summary>
        /// <param name="ground"></param>
        /// <param name="roof"></param>
        /// <param name="wall"></param>
        /// <param name="platform"></param>
        public Terrain(TypeTerrain typeTerrain)
        {
            switch (typeTerrain)
            {
                case TypeTerrain.ground:
                    this._ground = true;
                    break;
                case TypeTerrain.roof:
                    this._roof = true;
                    break;
                case TypeTerrain.wall:
                    this._wall = true;
                    break;
                case TypeTerrain.plateform:
                    this._plateform = true;
                    break;
            }
        }
        #endregion Constructor

        #region Public Methods
        #endregion Public Methods

        #region Private Methods
        #endregion Private Methods

        #region Accessors
        public bool Ground
        {
            get
            {
                return this._ground;
            }
        }

        public bool Roof
        {
            get
            {
                return this._roof;
            }
        }

        public bool Wall
        {
            get
            {
                return this._wall;
            }
        }

        public bool Plateform
        {
            get
            {
                return this._plateform;
            }
        }
        #endregion Accessors
    }
}
