namespace BullsAndCowsGameTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCowsGame.UI;
    using System.IO;

    [TestClass]
    public class UserInterfaceTests
    {
        #region ShowCongratulations

        [TestMethod]
        public void ShowCongratulations_WithoutCheats()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                UserInterface.ShowCongratulations(5, 0);

                string expected = string.Format("Congratulations! You guessed the secret number in 5 attempts.{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void ShowCongratulations_WithCheats()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                UserInterface.ShowCongratulations(5, 2);

                string expected = string.Format("Congratulations! You guessed the secret number in 5 attempts and 2 cheats.{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        #endregion
    }
}
