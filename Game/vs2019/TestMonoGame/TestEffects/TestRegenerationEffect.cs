using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoGame
{
    [TestClass]
    public class TestRegenerationEffect
    {
        #region Private attributes
        private RegenerationEffect _regenerationEffect;
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
            //then we give effect to character
            _regenerationEffect = new RegenerationEffect(RegenerationType.Health,100);
            _regenerationEffect.RegenerationHealth(character);
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
            //then we give regeneration effect with a total value of 100 at to distribut in a duration of 2sc
            _regenerationEffect = new RegenerationEffect(RegenerationType.Health,100,2);            
            _regenerationEffect.RegenerationHealth(character);
            //when
            Assert.AreEqual(expected, character.CurrentHealth);
        }
        /// <summary>
        /// We want to give 100 Health points to player
        /// </summary>
        [TestMethod]
        public void TestEffectRegenerationHealthOnPlayer()
        {
            //GIVEN
            Player player = new Player(500, 5, 5, 5, 10, 50);
            player.CurrentHealth = 300;
            int expected = 400;
            //then we give effect to player
            _regenerationEffect = new RegenerationEffect(RegenerationType.Health, 100);
            _regenerationEffect.RegenerationHealth((Character)player);
            //when
            Assert.AreEqual(expected, player.CurrentHealth);
        }
        /// <summary>
        /// We want to give 50 Health points to player each second during 2 secons
        /// </summary>
        [TestMethod]
        public void TestEffectRegenerationHealthOnPlayerDuring2sec()
        {
            //GIVEN
            Player player = new Player(500, 5, 5, 5, 10, 50);
            player.CurrentHealth = 300;
            int expected = 400;
            //then we give effect to character
            _regenerationEffect = new RegenerationEffect(RegenerationType.Health, 100,2);
            _regenerationEffect.RegenerationHealth((Character)player);
            //when
            Assert.AreEqual(expected, player.CurrentHealth);
        }

        /// <summary>
        /// We want to give 10 Mana points to character
        /// </summary>
        [TestMethod]
        public void TestEffectRegenerationManaOnPlayer()
        {
            //GIVEN
            Player player = new Player(500, 5, 5, 5, 10, 20);
            player.CurrentMana = 10;
            int expected = 20;
            //then
            _regenerationEffect = new RegenerationEffect(RegenerationType.Mana,10);
            _regenerationEffect.RegenerationMana(player);
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
            _regenerationEffect = new RegenerationEffect(RegenerationType.Mana,10,2);
            _regenerationEffect.RegenerationMana(player);
            //when

            Assert.AreEqual(expected, player.CurrentMana);
        }
    }
}
