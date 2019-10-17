using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoGame
{
    [TestClass]
    public class TestFood
    {
        #region private attributes
        private Food _food;
        private string _name;
        private Location _location;
        #endregion private attributes

        /// <summary>
        /// Creation of Food for next tests
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _name = "Apple";
            _location = new Location(10, 5);
            _food = new Food(_name, _location);
        }
        /// <summary>
        /// Test if our name is always de like after initialization
        /// </summary>
        [TestMethod]
        public void TestObjectName()
        {
            string actual = _food.Name;
            Assert.AreEqual(_name, actual);
        }
        /// <summary>
        /// After creation of food, is the effect always the same?
        /// </summary>
        [TestMethod]
        public void TestFoodRegenerationEffect()
        {
            RegenerationEffect effect = new RegenerationEffect(RegenerationType.Health, 20);
            _food = new Food(_name, _location,effect);
            Assert.AreEqual(effect,_food.Effect);
        }
        /// <summary>
        /// After creation of food, is the effect always the same?
        /// </summary>
        [TestMethod]
        public void TestFoodManaEffect()
        {
            RegenerationEffect effect = new RegenerationEffect(RegenerationType.Mana, 20);
            _food = new Food(_name, _location,effect);
            Assert.AreEqual(effect,_food.Effect);
        }
    }
}
