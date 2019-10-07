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
        private bool _squad;
        private bool _jump;
        private bool _eat;
        private int _posX;
        private int _posY;
        private Character _character;

        [TestInitialize]
        public void Init()
        {
            _character = new Character();
        }
        [TestMethod]
        public void TestLocationX()
        {
            _posX = 10;
        }
    }
}
