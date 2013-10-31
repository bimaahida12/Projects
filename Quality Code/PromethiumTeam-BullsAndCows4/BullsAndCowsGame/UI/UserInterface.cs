//-----------------------------------------------------------------------
// <copyright file="UserInterface.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCowsGame.UI
{
    using System;
    using System.Linq;
    using System.Text;
    using BullsAndCowsGame.Intefaces;
    using System.Collections.Generic;

    /// <summary>
    /// Public Static Class that manages the user interface
    /// </summary>
    public static class UserInterface
    {
        #region Fields

        /// <summary>
        /// Constant representing the welcome message, when starting the game
        /// </summary>
        private const string WELCOME_MESSAGE = "Welcome to “Bulls and Cows” game. " +
            "Please try to guess my secret 4-digit number." +
            "Use 'top' to view the top scoreboard, 'restart' " +
            "to start a new game and 'help' to cheat and 'exit' to quit the game.";

        /// <summary>
        /// Constant representing the warning message, when something goes wrong
        /// </summary>
        private const string WRONG_COMMAND_MESSAGE = "Incorrect guess or command!";

        #endregion

        #region Methods

        /// <summary>
        /// Prints welcome message from constant WELCOME_MESSAGE on the console
        /// </summary>        
        public static void ShowWelcomeGreeting()
        {
            Console.WriteLine(WELCOME_MESSAGE);
        }

        /// <summary>
        /// Prints wrong command message from constant WRONG_COMMAND_MESSAGE on the console
        /// </summary>        
        public static void ShowWrongCommand()
        {
            Console.WriteLine(WRONG_COMMAND_MESSAGE);
        }

        /// <summary>
        /// Prints greetings message, including summery of the game 
        /// </summary>
        /// <param name="attempts">Number of guess attempts during the game</param>
        /// <param name="cheats">Number of cheats used during the game</param>
        public static void ShowCongratulations(int attempts, int cheats)
        {
            Console.Write("Congratulations! You guessed the secret number in {0} attempts", attempts);
            if (cheats == 0)
            {
                Console.WriteLine(".");
            }
            else
            {
                Console.WriteLine(" and {0} cheats.", cheats);
            }
        }

        /// <summary>
        /// Prints the scoreboard on the console
        /// </summary>
        /// <param name="scoreBoardString">Given scoreboard to be printed</param>
        public static void ShowScoreboard(IScoreBoard<IPlayer> scoreBoard)
        {
            if (scoreBoard.Count != 0)
            {
                StringBuilder sb = new StringBuilder("Scoreboard:");
                sb.Append(Environment.NewLine);
                int i = 1;
                foreach (IPlayer player in scoreBoard)
                {
                    sb.AppendFormat("{0}. {1} --> {2} guess" + ((player.Attempts == 1) ? "" : "es"), i++, player.Name, player.Attempts);
                    sb.Append(Environment.NewLine);
                }

                Console.WriteLine(sb.ToString().Trim());
            }
            else
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
        }

        /// <summary>
        /// Prints help number for cheat on the console
        /// </summary>
        /// <param name="helpNumber">Help number to cheat</param>
        public static void ShowHelp(string helpNumber)
        {
            Console.WriteLine("The number looks like {0}.", helpNumber);
        }

        /// <summary>
        /// Prints message that cheat limit is reached on the console
        /// </summary>
        public static void ShowCheatsLimitReached()
        {

            Console.WriteLine("You are not allowed to ask for more help!");
        }

        /// <summary>
        /// Prints results of the last guess on the console
        /// </summary>
        /// <param name="bullsCount">Shows the correctly guessed bulls</param>
        /// <param name="cowsCount">Shows the correctly guessed cows</param>
        public static void ShowGuessStatistics(int bullsCount, int cowsCount)
        {
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
        }

        /// <summary>
        /// Prints message on the console for the players, who used help
        /// </summary>
        public static void ShowCheatersMessage()
        {
            Console.WriteLine("You are not allowed to enter the top scoreboard.");
        }

        /// <summary>
        /// Prints message on the console at end of each game
        /// </summary>
        public static void EndOfGameMessage()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Prints message on the console for goodbye
        /// </summary>
        public static void ShowFairwell()
        {
            Console.WriteLine("Good bye!");
        }

        /// <summary>
        /// Asks user to enter next command and returns it as text
        /// </summary>
        /// <returns>Returns player input as text</returns>
        public static string GetPlayerCommand()
        {
            Console.Write("Enter your guess or command: ");
            string playerInput = Console.ReadLine();

            return playerInput;
        }

        /// <summary>
        /// Asks user to enter his name on the console and returns it as text
        /// </summary>
        /// <returns>Returns player's name as text</returns>
        public static string GetPlayerName()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string playerName = Console.ReadLine();

            return playerName;
        }

        #endregion
    }
}
