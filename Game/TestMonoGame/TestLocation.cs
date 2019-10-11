using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoGame
{
    [TestClass]
    public class TestLocation
    {
        #region Private attributes
        private int _posX;
        private int _posY;
        private Location _location;
        #endregion Private attributes

        /// <summary>
        /// initialize private attibutes for next tests
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _posX = 10;
            _posY = 23;
            _location = new Location(_posX,_posY);
        }
        /// <summary>
        /// check if position X are qeual our class
        /// </summary>
        [TestMethod]
        public void TestLocationX()
        {
            Assert.AreEqual(_posX, _location.X);
        }
        /// <summary>
        /// check if position Y are qeual our class
        /// </summary>
        [TestMethod]
        public void TestLocationY()
        {
            Assert.AreEqual(_posY, _location.Y);
        }
    }
}
