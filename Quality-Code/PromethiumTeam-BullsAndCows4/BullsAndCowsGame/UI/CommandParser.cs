//-----------------------------------------------------------------------
// <copyright file="CommandParser.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------

namespace BullsAndCowsGame.UI
{
    using System;
    using System.Linq;

    /// <summary>
    /// Static class responsible for player's commands
    /// </summary>
    public static class CommandParser
    {
        #region Methods

        /// <summary>
        /// Method which handles player's commands
        /// </summary>
        /// <param name="playerInput">The input that a player enters on the console</param>
        /// <returns>Returned value tells the game what to do next</returns>
        public static PlayerCommand PlayerInputToPlayerCommand(string playerInput)
        {
            if (playerInput.ToLower() == "top")
            {
                return PlayerCommand.Top;
            }
            else if (playerInput.ToLower() == "restart")
            {
                return PlayerCommand.Restart;
            }
            else if (playerInput.ToLower() == "help")
            {
                return PlayerCommand.Help;
            }
            else if (playerInput.ToLower() == "exit")
            {
                return PlayerCommand.Exit;
            }
            else
            {
                return PlayerCommand.Other;
            }
        }

        #endregion
    }
}
