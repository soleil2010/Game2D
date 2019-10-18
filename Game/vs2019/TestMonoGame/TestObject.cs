using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoGame
{
    [TestClass]
    public class TestObjects
    {
        #region private attributes
        private Object _object;
        private Location _location;
        private string _name;
        #endregion private attributes

        /// <summary>
        /// Creation of our object for next tests
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _name = "Pen";
            _location = new Location(30, 70);
            _object = new Object(_name, _location);
        }
        /// <summary>
        /// Test if our name is always de like after initialization
        /// </summary>
        [TestMethod]
        public void TestObjectName()
        {
            string actual = _object.Name;
            Assert.AreEqual(_name, actual);
        }
        /// <summary>
        /// Test the location X of object after initialization
        /// </summary>
        [TestMethod]
        public void TestObjectLocationX()
        {
            int expected = _location.X;
            int actual = _object.Location.X;
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test the location Y of object after initialization
        /// </summary>
        [TestMethod]
        public void TestObjectLocationY()
        {
            int expected = _location.Y;
            int actual = _object.Location.Y;
            Assert.AreEqual(expected, actual);
        }
    }
}
