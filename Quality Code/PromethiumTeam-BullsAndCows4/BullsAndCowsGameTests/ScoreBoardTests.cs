using System;
using BullsAndCowsGame.GameObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCowsGameTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void ScoreBoard_AddMethod()
        {
            var pesho = new Player("Pesho");
            
            ScoreBoard<Player> scoreBoard = new ScoreBoard<Player>();
            scoreBoard.Add(pesho);

            foreach (var player in scoreBoard)
            {
                Assert.AreSame(pesho,player);
            }

        }
    }
}
