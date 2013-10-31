//-----------------------------------------------------------------------
// <copyright file="BullsAndCows.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCowsGame
{
    using System;
    using System.Linq;
    using BullsAndCowsGame.GamePlay;

    /// <summary>
    /// Bulls and Cows main class
    /// </summary>
    class BullsAndCows
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            Engine game = new Engine();
            game.StartGame();
        }
    }
}
