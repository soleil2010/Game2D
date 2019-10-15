using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoGame
{
    [TestClass]
    public class TestEffects
    {
        #region Private attributes
        private EffectRegeneration _effect;
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
            _effect = new EffectRegeneration(Regeneration.Health,100);
            _effect.RegenerationHealth(ref character);
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
            _effect = new EffectRegeneration(Regeneration.Health,100,2);            
            _effect.RegenerationHealth(ref character);
            //when
            Assert.AreEqual(expected, character.CurrentHealth);
        }
        /// <summary>
        /// We want to give 10 Health points to character
        /// </summary>
        [TestMethod]
        public void TestEffectRegenerationManaOnPlayer()
        {
            //GIVEN
            Player player = new Player(500, 5, 5, 5, 10, 20);
            player.CurrentMana = 10;
            int expected = 20;
            //then
            _effect = new EffectRegeneration(Regeneration.Mana,10);
            _effect.RegenerationMana(ref player);
            //when

            Assert.AreEqual(expected, player.CurrentMana);
        }
        /// <summary>
        /// We want to give 5 Mana points to character each second during 2sec
        /// </summary>
        [TestMethod]
        public void TestEffectRegenerationManaOnCharacterDuring2sec()
        {
            //GIVEN
            Player player = new Player(500, 5, 5, 5, 10, 20);
            player.CurrentMana = 10;
            int expected = 20;
            //then
            _effect = new EffectRegeneration(Regeneration.Mana,10,2);
            _effect.RegenerationMana(ref player);
            //when

            Assert.AreEqual(expected, player.CurrentMana);
        }
    }
}
