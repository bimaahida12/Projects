//-----------------------------------------------------------------------
// <copyright file="Engine.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------

namespace BullsAndCowsGame.GamePlay
{
    using System;
    using System.Text;
    using BullsAndCowsGame.GameObjects;
    using BullsAndCowsGame.UI;
    using BullsAndCowsGame.Intefaces;

    /// <summary>
    /// Class Engine stores the main functionality of the game
    /// </summary>
    public class Engine
    {
        #region Fields

        /// <summary>
        /// Number to be guessed in the game
        /// </summary>
        private GameNumber number { get; set; }

        /// <summary>
        /// Player profile
        /// </summary>
        private Player player { get; set; }

        /// <summary>
        /// Keeps highest scores of the game
        /// </summary>
        private ScoreBoard<Player> scoreBoard { get; set; }

        /// <summary>
        /// Keeps information about whether game should restart
        /// </summary>
        private bool restart;

        /// <summary>
        /// Keeps information about whether game should exit
        /// </summary>        
        private bool exit;

        #endregion

        #region Constructors

        public Engine()
        {
            this.scoreBoard = new ScoreBoard<Player>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Public representation of the highest scores in the game
        /// </summary>
        public IScoreBoard<IPlayer> ScoreBoard
        {
            get
            {
                ScoreBoard<IPlayer> iScoreBoard = new ScoreBoard<IPlayer>();

                foreach (var player in this.scoreBoard)
                {
                    iScoreBoard.Add((IPlayer)player);
                }

                return (IScoreBoard<IPlayer>)iScoreBoard;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// This is the method that each new game strats with. It calls several
        /// other helper methods.
        /// </summary>
        public void StartGame()
        {
            PlayerCommand enteredCommand = new PlayerCommand();

            do
            {
                UserInterface.ShowWelcomeGreeting();
                this.player = new Player("NoName");
                this.number = new GameNumber();
                
                this.restart = false;
                this.exit = false;

                do
                {
                    string playerInput = UserInterface.GetPlayerCommand(); 
                    enteredCommand = CommandParser.PlayerInputToPlayerCommand(playerInput);
                    ExecuteCommand(enteredCommand, playerInput);
                }
                while (!this.restart && !this.exit);

                UserInterface.EndOfGameMessage();
            }
            while (!this.exit);

            UserInterface.ShowFairwell();
        }

        /// <summary>
        /// Method handles entered by the player command <paramref name="enteredCommand"/>, 
        /// calling other methods each responsible for different interactions.
        /// </summary>
        /// <param name="enteredCommand">Options that the game offers to a player</param>
        /// <param name="playerInput">Command that player enters</param>
        /// <param name="player">The user that's playing at the moment</param>
        private void ExecuteCommand(PlayerCommand enteredCommand, string playerInput)
        {
            if (enteredCommand != PlayerCommand.Other)
            {
                ExecutePlayerCommand(enteredCommand);
            }
            else
            {
                CheckPlayerInput(playerInput);
            }
        }

        /// <summary>
        /// Handles execusion of player command by this engine
        /// </summary>
        /// <param name="enteredCommand">Options that the game offers to a player</param>
        private void ExecutePlayerCommand(PlayerCommand playerCommand)
        {
            switch (playerCommand)
            {
                case PlayerCommand.Top:
                    UserInterface.ShowScoreboard(this.ScoreBoard);
                    break;
                case PlayerCommand.Help:
                    if (this.number.RevealDigit(this.player.Cheats))
                    {
                        UserInterface.ShowHelp(this.number.HelpNumber.ToString());
                        this.player.Cheats++;
                    }
                    else
                    {
                        UserInterface.ShowCheatsLimitReached();
                    }
                    break;
                case PlayerCommand.Restart:
                    Restart();
                    break;
                case PlayerCommand.Exit:
                    Exit();
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Performs comparison between number to be gueesed and player input if valid 
        /// </summary>
        /// <param name="playerInput">Input entered by player</param>
        private void CheckPlayerInput(string playerInput)
        {
            if (IsValidInput(playerInput))
            {
                int bullsCount;
                int cowsCount;

                this.player.Attempts++;
                this.number.GetBullsAndCows(playerInput, this.number.Digits, out bullsCount, out cowsCount);

                if (bullsCount == GameNumber.LENGHT)
                {
                    UserInterface.ShowCongratulations(this.player.Attempts, this.player.Cheats);
                    this.FinishGame();
                }
                else
                {
                    UserInterface.ShowGuessStatistics(bullsCount, cowsCount);
                }
            }
            else
            {
                UserInterface.ShowWrongCommand();
            }
        }

        /// <summary>
        /// The method checkes if the player's input <paramref name="playerInput"/>
        /// is valid. It checks if the input is empty string, if the input lenght is
        /// correct and if the input contains digits only.
        /// </summary>
        /// <param name="playerInput">Player's input</param>
        /// <returns>Returns <see cref="System.Boolean"/> true or false
        /// according to if the input is valid or not.</returns>
        private bool IsValidInput(string playerInput)
        {
            if (playerInput == String.Empty || playerInput.Length != GameNumber.LENGHT)
            {
                return false;
            }
            for (int i = 0; i < playerInput.Length; i++)
            {
                char currentChar = playerInput[i];
                if (!Char.IsDigit(currentChar))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Adds the player to the scoreboard at the end of the game, if hasn't used cheats
        /// </summary>
        public void AddPlayerToScoreboard()
        {
            if (this.player.Cheats == 0)
            {
              player.Name = UserInterface.GetPlayerName();
              this.scoreBoard.Add(player);
            }
            else
            {
                UserInterface.ShowCheatersMessage();
            }
        }

        /// <summary>
        /// Takes care of scoreboard and user comunication at end of each game
        /// </summary>
        public void FinishGame()
        {
            AddPlayerToScoreboard();

            if (this.player.Cheats == 0)
            {
                UserInterface.ShowScoreboard(this.ScoreBoard);
            }

            Restart();
        }

        /// <summary>
        /// Sets game to be restarted
        /// </summary>
        public void Restart()
        {
            this.restart = true;
        }

        /// <summary>
        /// Sets game to be exited
        /// </summary>
        public void Exit()
        {
            this.exit = true;
        }

        #endregion
    }
}
