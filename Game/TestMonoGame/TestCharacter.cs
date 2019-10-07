using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoGame
{
    [TestClass]
    public class TestCharacter
    {
        private int _currentHealth;
        private int _maxHealth;
        private int _speed;
        private bool _squat;
        private bool _jump;
        private bool _eat;
        private int _posX;
        private int _posY;
        private Character _character;
        [TestInitialize]
        public void Init()
        {
            this._maxHealth = 100;
            this._posX = 10;
            this._posY = 0;
            this._speed = 5;
            this._character = new Character(_maxHealth);
            this._character.Speed = this._speed;
            this._character.Location = new Location(_posX,_posY);
        }
        [TestMethod]
        public void TestMaxHealth()
        {
            Assert.AreEqual(this._maxHealth, this._character.MaxHealth);
        }
        [TestMethod]
        public void TestCurrentHealth()
        {
            this._character.CurrentHealth=100;
            this._currentHealth = 100;
            Assert.AreEqual(this._currentHealth, this._character.CurrentHealth);
        }
        [TestMethod]
        public void TestSpeed()
        {
            this._character.Speed=5;
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
            this._jump = true;
            Assert.AreNotEqual(this._jump, this._character.Jump);
        }    
        [TestMethod]
        public void TestJumpSuccess()
        {
            this._character.Move(Directions.Up);
            this._jump = true;
            Assert.AreEqual(this._jump, this._character.Jump);
        } 
        [TestMethod]
        public void TestSquatFail()
        {
            this._squat = true;
            Assert.AreNotEqual(this._squat, this._character.Squat);
        }
        [TestMethod]
        public void TestSquatSuccess()
        {
            this._character.Move(Directions.Down);
            this._squat = true;
            Assert.AreEqual(this._squat, this._character.Squat);
        }
        [TestMethod]
        public void TestEatFail()
        {
            this._eat = true;
            Assert.AreNotEqual(this._eat, this._character.Eat);
        }
        [TestMethod]
        public void TestEatSuccess()
        {
            this._character.Eat=true;
            this._eat = true;
            Assert.AreEqual(this._eat, this._character.Eat);
        }
    }
}
