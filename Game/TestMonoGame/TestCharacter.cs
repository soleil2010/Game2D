using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoGame
{
    [TestClass]
    public class TestCharacter
    {
        #region Private attributes
        private int _maxHealth;
        private int _speed;
        private int _defense;
        private int _resistance;
        private int _damages;
        private int _posX;
        private Character _character;
        #endregion Private attributes

        [TestInitialize]
        public void Init()
        {
            this._maxHealth = 100;
            this._posX = 10;
            this._speed = 5;
            this._resistance = 0;
            this._defense = 10;
            this._damages = 10;
            this._character = new Character(_maxHealth, _speed,_defense,_resistance,_damages);
            this._character.Speed = this._speed;
            this._character.Location = new Location(_posX,0);
        }
        [TestMethod]
        public void TestMaxHealth()
        {
            Assert.AreEqual(this._maxHealth, this._character.MaxHealth);
        }
        [TestMethod]
        public void TestCurrentHealth()
        {
            int currentHealth = 100;
            Assert.AreEqual(currentHealth, this._character.CurrentHealth);
        }
        [TestMethod]
        public void TestDefense()
        {
            Assert.AreEqual(this._defense, this._character.Defense);
        }
        [TestMethod]
        public void TestResistance()
        {
            Assert.AreEqual(this._resistance, this._character.Resistance);
        }
        [TestMethod]
        public void TestDamages()
        {
            Assert.AreEqual(this._damages, this._character.Damages);
        }
        [TestMethod]
        public void TestSpeed()
        {
            Assert.AreEqual(this._speed, this._character.Speed);
        } 
        [TestMethod]
        public void TestMoveRight()
        {
            this._posX += this._speed;
            this._character.Move(Directions.Right);
            Assert.AreEqual(this._posX, this._character.Location.X);
        }      
        [TestMethod]
        public void TestMoveLeft()
        {
            this._posX -= this._speed;
            this._character.Move(Directions.Left);
            Assert.AreEqual(this._posX, this._character.Location.X);
        }          
        [TestMethod]
        public void TestJumpFail()
        {
            Assert.IsFalse(this._character.Jump);
        }    
        [TestMethod]
        public void TestJumpSuccess()
        {
            this._character.Move(Directions.Up);

            Assert.IsTrue( this._character.Jump);
        } 
        [TestMethod]
        public void TestSquatFail()
        {
            Assert.IsFalse(this._character.Squat);
        }
        [TestMethod]
        public void TestSquatSuccess()
        {
            this._character.Move(Directions.Down);
            Assert.IsTrue( this._character.Squat);
        }
        [TestMethod]
        public void TestEatFail()
        {
            Assert.IsFalse(this._character.Eat);
        }
        [TestMethod]
        public void TestEatSuccess()
        {
            this._character.Eat=true;
            Assert.IsTrue(this._character.Eat);
        }
    }
}
