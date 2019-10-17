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
        /// <summary>
        /// We test if food with a regeneration health effect regenerate the health of player
        /// </summary>
        [TestMethod]
        public void TestEatingFoodWithRegenerateHealthEffect()
        {
            int expectedLife = 100;
            RegenerationEffect effect = new RegenerationEffect(RegenerationType.Health, 200);
            Food food = new Food("Steak",new Location(), effect);

            //player lost half of its life
            _player.CurrentHealth /= 2;
            //player eat food to regenerate health
            _player.Eat = true;
            _player.Eating(food);

            Assert.AreEqual(expectedLife, _player.CurrentHealth);

        }
        /// <summary>
        /// We test if food with a regeneration mana effect regenerate the mana of player
        /// </summary>
        [TestMethod]
        public void TestEatingFoodWithRegenerateManaEffect()
        {
            RegenerationEffect effect = new RegenerationEffect(RegenerationType.Mana, 10);
            Food food = new Food("Steak",new Location(), effect);

            //player lost half of its life
            _player.CurrentMana /= 2;
            //player eat food to regenerate health
            _player.Eat = true;
            _player.Eating(food);

            Assert.AreEqual(_maxMana, _player.CurrentMana);

        }
    }
}
