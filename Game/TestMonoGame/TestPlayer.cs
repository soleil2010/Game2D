using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoGame
{
    [TestClass]
    public class TestPlayer
    {
        #region Private attributes
        private int _maxMana;
        private Player _player;
        #endregion Private attributes

        [TestInitialize]
        public void Init()
        {
            this._maxMana = 20;
            this._player = new Player(100, 5, 10, 0,50, _maxMana);
        }
        [TestMethod]
        public void TestMaxMana()
        {
            int MaxMana = 20;
            Assert.AreEqual(MaxMana, _player.MaxMana);
        }
        [TestMethod]
        public void TestCurrentMana_AfterInit()
        {
            int currentMana = 20;
            Assert.AreEqual(currentMana, _player.MaxMana);
        }
        [TestMethod]
        public void TestCurrentManaAfterAttack()
        {
            // -10 simulates an attack
            _player.CurrentMana=_player.MaxMana-10;
            int currentMana = 10;
            Assert.AreEqual(currentMana, _player.CurrentMana);
        }
        [TestMethod]
        public void TestEndJumping()
        {
            _player.Jumping();

            Assert.IsFalse(_player.Jump);
        }
        [TestMethod]
        public void TestSquating()
        {
            _player.Squating();

            Assert.IsTrue(_player.Squat);
        }
        [TestMethod]
        public void TestGetUp()
        {
            _player.Squating();
            _player.GetUp();

            Assert.IsFalse(_player.Squat);
        }
        [TestMethod]
        public void TestEndEating()
        {
            _player.Eating("Apple");
            Assert.IsFalse(_player.Eat);
        }
    }
}
