namespace BullsAndCowsGameTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCowsGame.GameObjects;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Player_EmptyName()
        {
            Player player = new Player("", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Player_NullArgumentForName()
        {
            Player player = new Player(null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Player_OnlySpacesForName()
        {
            Player player = new Player("  ", 10);
        }

        [TestMethod]
        public void Player_ValidNameTest()
        {
            Player player = new Player("Petyr Vasilev", 10);
            Assert.AreEqual(player.Name, "Petyr Vasilev");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Player_NegativeAttempts()
        {
            Player player = new Player("Petyr Vasilev", -10);
        }

        [TestMethod]
        public void Player_ComparePlayers_SecondWithLessAttempts()
        {
            Player player = new Player("Petyr Vasilev", 4);
            Player player2 = new Player("Ivan Ivanov", 3);
            Assert.AreEqual(player.CompareTo(player2), -1);
        }

        [TestMethod]
        public void Player_ComparePlayers_EqualAttempts()
        {
            Player player = new Player("Petyr Vasilev", 3);
            Player player2 = new Player("Ivan Ivanov", 3);
            Assert.AreEqual(player.CompareTo(player2), 0);
        }

        [TestMethod]
        public void Player_ToString()
        {
            Player player = new Player("Petyr Vasilev", 3);
            Assert.IsTrue(string.Equals(player.ToString(), "Player: \"Petyr Vasilev\", attempts: 3"));
        }
    }
}
