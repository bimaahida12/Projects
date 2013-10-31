namespace BullsAndCowsGameTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCowsGame.GameObjects;

    [TestClass]
    public class GameNumberTests
    {
        #region GenerateNumber

        [TestMethod]
        public void GenerateNumber_Valid_4digits()
        {
            GameNumber number = new GameNumber();
            Assert.IsTrue(number.Digits.Length == 4);
        }

        [TestMethod]
        public void GenerateNumber_Valid_InRange()
        {
            GameNumber number = new GameNumber();
            int parsedNumber = int.Parse(number.Digits);
            Assert.IsTrue(parsedNumber >= 0 && parsedNumber <= 9999);
        }

        #endregion

        #region GetBullsAndCows

        [TestMethod]
        public void GetBullsAndCows_Valid_CowsTest()
        {
            GameNumber number = new GameNumber();

            string userInput = "4199";
            string genNumber = "1400";
            int cows = 0;
            int bulls = 0;
            number.GetBullsAndCows(userInput, genNumber, out bulls, out cows);
            Assert.IsTrue(cows == 2 && bulls == 0);
        }

        [TestMethod]
        public void GetBullsAndCows_Valid_CowsTest2()
        {
            GameNumber number = new GameNumber();

            string userInput = "4194";
            string genNumber = "9400";
            int cows = 0;
            int bulls = 0;
            number.GetBullsAndCows(userInput, genNumber, out bulls, out cows);
            Assert.IsTrue(cows == 2 && bulls == 0);
        }

        [TestMethod]
        public void GetBullsAndCows_Valid_CowsBullsTestZero()
        {
            GameNumber number = new GameNumber();

            string userInput = "4194";
            string genNumber = "0358";
            int cows = 0;
            int bulls = 0;
            number.GetBullsAndCows(userInput, genNumber, out bulls, out cows);
            Assert.IsTrue(cows == 0 && bulls == 0);
        }

        [TestMethod]
        public void GetBullsAndCows_Valid_Bulls_OneBull()
        {
            GameNumber number = new GameNumber();

            string userInput = "4194";
            string genNumber = "0158";
            int cows = 0;
            int bulls = 0;
            number.GetBullsAndCows(userInput, genNumber, out bulls, out cows);
            Assert.IsTrue(cows == 0 && bulls == 1);
        }

        [TestMethod]
        public void GetBullsAndCows_Valid_Bulls_TwoBulls()
        {
            GameNumber number = new GameNumber();

            string userInput = "4194";
            string genNumber = "0154";
            int cows = 0;
            int bulls = 0;
            number.GetBullsAndCows(userInput, genNumber, out bulls, out cows);
            Assert.IsTrue(cows == 0 && bulls == 2);
        }

        [TestMethod]
        public void GetBullsAndCows_Valid_Bulls_FourBulls()
        {
            GameNumber number = new GameNumber();

            string userInput = "4194";
            string genNumber = "4194";
            int cows = 0;
            int bulls = 0;
            number.GetBullsAndCows(userInput, genNumber, out bulls, out cows);
            Assert.IsTrue(cows == 0 && bulls == 4);
        }

        [TestMethod]
        public void GetBullsAndCows_Valid_TwoBullsAndTwoCows()
        {
            GameNumber number = new GameNumber();

            string userInput = "4194";
            string genNumber = "4914";
            int cows = 0;
            int bulls = 0;
            number.GetBullsAndCows(userInput, genNumber, out bulls, out cows);
            Assert.IsTrue(cows == 2 && bulls == 2);
        }

        [TestMethod]
        public void GetBullsAndCows_Valid_TwoBullsAndTwoCows2()
        {
            GameNumber number = new GameNumber();

            string userInput = "0101";
            string genNumber = "1001";
            int cows = 0;
            int bulls = 0;
            number.GetBullsAndCows(userInput, genNumber, out bulls, out cows);
            Assert.IsTrue(cows == 2 && bulls == 2);
        }

        #endregion

        #region RevealDigit

        [TestMethod]
        public void RevealDigit_isTrue()
        {
            GameNumber number = new GameNumber();

            Assert.IsTrue(number.RevealDigit(1));
        }

        [TestMethod]
        public void RevealDigit_isFalse()
        {
            GameNumber number = new GameNumber();

            Assert.IsFalse(number.RevealDigit(4));
        }

        #endregion
    }
}
