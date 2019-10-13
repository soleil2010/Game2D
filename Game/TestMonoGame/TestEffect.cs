using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoGame
{
    [TestClass]
    public class TestEffects
    {
        #region Private attributes
        private int _time;
        private string _name;
        private Effect _effect;
        #endregion Private attributes
        /// <summary>
        /// We want to give 100 Health points to character
        /// </summary>
        [TestMethod]
        public void TestEffectRegenerationHealthOnCharacter()
        {
            //GIVEN
            Character character = new Character(500, 5, 5, 5, 10);
            character.CurrentHealth = 300;
            int expected = 400;
            //then
            _effect = new Effect(Type.Regeneration, "Health");
            _effect.Regeneration(value => character.CurrentHealth += value, 100);
            //when

            Assert.AreEqual(expected, character.CurrentHealth);
        }
        /// <summary>
        /// We want to give 50 Health points to character each second during 2sec
        /// </summary>
        [TestMethod]
        public void TestEffectRegenerationHealthOnCharacterDuring2sec()
        {
            //GIVEN
            Character character = new Character(500, 5, 5, 5, 10);
            character.CurrentHealth = 300;
            int expected = 400;
            //then
            _effect = new Effect(Type.Regeneration, "Health");
            _effect.Regeneration(value => character.CurrentHealth += value, 100,2);
            //when

            Assert.AreEqual(expected, character.CurrentHealth);
        }
    }
}
