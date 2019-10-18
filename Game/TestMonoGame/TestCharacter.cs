using System;
using System.Collections.Generic;
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
        private Terrain _terrain;
        #endregion Private attributes

        [TestInitialize]
        public void Init()
        {
            this._maxHealth = 100;
            this._posX = 10;
            this._speed = 1;
            this._resistance = 0;
            this._defense = 10;
            this._damages = 10;
            this._character = new Character(_maxHealth, _speed,_defense,_resistance,_damages);
            this._character.Speed = this._speed;
            this._character.Location = new Location(_posX,0);
            this._terrain = new Terrain(TypeTerrain.ground);
        }
        /// <summary>
        /// we test the maximal life
        /// of our character
        /// </summary>
        [TestMethod]
        public void TestMaxHealth()
        {
            Assert.AreEqual(this._maxHealth, this._character.MaxHealth);
        }
        /// <summary>
        /// we check the current life of player
        /// after initialization
        /// </summary>
        [TestMethod]
        public void TestCurrentHealth()
        {
            int currentHealth = 100;
            Assert.AreEqual(currentHealth, this._character.CurrentHealth);
        }
        /// <summary>
        /// player has the same defense after initialization
        /// </summary>
        [TestMethod]
        public void TestDefense()
        {
            Assert.AreEqual(this._defense, this._character.Defense);
        }
        /// <summary>
        /// player has the same resistance after initialization
        /// </summary>
        [TestMethod]
        public void TestResistance()
        {
            Assert.AreEqual(this._resistance, this._character.Resistance);
        }
        /// <summary>
        /// player has the same damages after initialization
        /// </summary>
        [TestMethod]
        public void TestDamages()
        {
            Assert.AreEqual(this._damages, this._character.Damages);
        }
        /// <summary>
        /// player has the same speed after initialization
        /// </summary>
        [TestMethod]
        public void TestSpeed()
        {
            Assert.AreEqual(this._speed, this._character.Speed);
        } 
        /// <summary>
        /// position x of player increment after right move
        /// </summary>
        [TestMethod]
        public void TestMoveRight()
        {
            this._posX += this._speed;
            this._character.Move(Directions.Right);
            Assert.AreEqual(this._posX, this._character.Location.X);
        }
        /// <summary>
        /// position x of player decrement after left move
        /// </summary>
        [TestMethod]
        public void TestMoveLeft()
        {
            this._posX -= this._speed;
            this._character.Move(Directions.Left);
            Assert.AreEqual(this._posX, this._character.Location.X);
        }
        /// <summary>
        /// We not click to jump, value must be false
        /// </summary>
        [TestMethod]
        public void TestJumpFail()
        {
            Assert.IsFalse(this._character.Jump);
        }
        /// <summary>
        /// We click to jump, value must be true
        /// </summary>
        [TestMethod]
        public void TestJumpSuccess()
        {
            this._character.Move(Directions.Up);

            Assert.IsTrue( this._character.Jump);
        }
        /// <summary>
        /// We not click to squat, value must be false
        /// </summary>
        [TestMethod]
        public void TestSquatFail()
        {
            Assert.IsFalse(this._character.Squat);
        }/// <summary>
         /// We click to squat, value must be true
         /// </summary>
        [TestMethod]
        public void TestSquatSuccess()
        {
            this._character.Move(Directions.Down);
            Assert.IsTrue( this._character.Squat);
        }
        /// <summary>
        /// player start to eat
        /// </summary>
        [TestMethod]
        public void TestEatBoolValue()
        {
            this._character.Eat = true;
            Assert.IsTrue(this._character.Eat);
        }
        /// <summary>
        /// we check when player have finished to eat the eat value return to false
        /// </summary>
        [TestMethod]
        public void TestCharacterCompletedToEat()
        {
            this._character.Eat = true;
            this._character.Eating(new Food("Apple", new Location()));
            Assert.IsFalse(this._character.Eat);
        }
        /// <summary>
        /// we check when player have finished to eat the eat value return to false
        /// </summary>
        [TestMethod]
        public void TestCharacterRegenerateHealthAfterEat()
        {
            Food Steak = new Food("Steak", new Location(), new RegenerationEffect(RegenerationType.Health,100));
            
            this._character.CurrentHealth -= 100;

            this._character.Eat = true;
            this._character.Eating(Steak);

            int expected = _maxHealth;
            Assert.AreEqual(expected, this._character.CurrentHealth);
        }
        /// <summary>
        /// character can only up it we click for jump
        /// </summary>
        [TestMethod]
        public void TestEndJumping()
        {
            _character.Move(Directions.Up);//simule our click to jump
            _character.Jumping();//currently jump
            //jump ended
            Assert.IsFalse(_character.Jump);
        }
        /// <summary>
        /// after squating, we want get up.
        /// squat value must be false
        /// </summary>
        [TestMethod]
        public void TestGetUp()
        {
            _character.Squating();
            _character.GetUp();

            Assert.IsFalse(_character.Squat);
        }

        [TestMethod]
        public void TestMovementRight()
        {
            this._character.Movement(Directions.Right);
            this._character.Location.X = 0;
            Assert.AreEqual(16, this._character.Location.X * 16);
        }

        public void TestMovementLeft()
        {
        [TestMethod]
            this._character.Location.X = 0;
            this._character.Movement(Directions.Left);
            Assert.AreEqual(-16, this._character.Location.X*16);
        }
        [TestMethod]
        public void TestOnGround()

        {
            this._character.Location.X = 4;
            this._character.IsOnGround(TypeTerrain.ground, new Terrain(TypeTerrain.ground));
            this._terrain.Location.Y = 4;
            Assert.AreEqual(true, this._character.OnGround);
        }
    }
}
