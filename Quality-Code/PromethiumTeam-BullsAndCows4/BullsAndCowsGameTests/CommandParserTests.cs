namespace BullsAndCowsGameTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCowsGame.UI;

    [TestClass]
    public class CommandParserTests
    {
        [TestMethod]
        public void PlayerInputToPlayerCommand_Top()
        {
            Assert.AreEqual(CommandParser.PlayerInputToPlayerCommand("top"), PlayerCommand.Top);
        }

        [TestMethod]
        public void PlayerInputToPlayerCommand_Restart()
        {
            Assert.AreEqual(CommandParser.PlayerInputToPlayerCommand("ResTart"), PlayerCommand.Restart);
        }

        [TestMethod]
        public void PlayerInputToPlayerCommand_Help()
        {
            Assert.AreEqual(CommandParser.PlayerInputToPlayerCommand("help"), PlayerCommand.Help);
        }

        [TestMethod]
        public void PlayerInputToPlayerCommand_Exit()
        {
            Assert.AreEqual(CommandParser.PlayerInputToPlayerCommand("exiT"), PlayerCommand.Exit);
        }

        [TestMethod]
        public void PlayerInputToPlayerCommand_Other()
        {
            Assert.AreEqual(CommandParser.PlayerInputToPlayerCommand(""), PlayerCommand.Other);
        }

        [TestMethod]
        public void PlayerInputToPlayerCommand_Other2()
        {
            Assert.AreEqual(CommandParser.PlayerInputToPlayerCommand("Testing "), PlayerCommand.Other);
        }
    }
}
