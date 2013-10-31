//-----------------------------------------------------------------------
// <copyright file="Number.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCowsGame.GameObjects
{
    using System;
    using System.Text;

    /// <summary>
    /// Static Class for that manages number generation
    /// </summary>
    public class GameNumber
    {
        #region Fields

        /// <summary>
        /// Constant representing the number of digits <see cref="System.Int32"/>
        /// for the generated number
        /// </summary>
        public const int LENGHT = 4;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GameNumber"/> class.
        /// </summary>
        public GameNumber()
        {
            this.Digits = this.GenerateNumber();
            this.HelpPattern = this.GenerateHelpPattern();
            this.HelpNumber = new StringBuilder("XXXX");
        }

        #endregion 

        #region Properties

        /// <summary>
        /// Gets or sets random generated four digit number as <see cref="System.String"/>
        /// </summary>
        public string Digits { get; private set; }

        /// <summary>
        /// Gets or sets the pattern for the order in which the help number
        /// will be revealed
        /// </summary>
        public string HelpPattern { get; private set; }

        /// <summary>
        /// Gets or sets the help number
        /// </summary>
        public StringBuilder HelpNumber { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Method for generating a random 4 digit number
        /// </summary>
        private string GenerateNumber()
        {
            StringBuilder number = new StringBuilder(4);
            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < LENGHT; i++)
            {
                int randomDigit = randomNumberGenerator.Next(9);
                number.Append(randomDigit);
            }

            return number.ToString();
        }

        /// <summary>
        /// Method that compares <paramref name="playerInput"/> with
        /// <paramref name="generatedNumber"/> and takes out the coincidental
        /// <paramref name="bullsCount"/> and <paramref name="cowsCount"/>
        /// </summary>
        /// <param name="playerInput">Four digit number represented as a string</param>
        /// <param name="generatedNumber">Random generated four digit number represented as a string</param>
        /// <param name="bullsCount">Correctly guessed by the user number of Bulls</param>
        /// <param name="cowsCount">Correctly guessed by the user number of Cows</param>
        public void GetBullsAndCows(string playerInput, string generatedNumber, out int bullsCount, out int cowsCount)
        {
            bullsCount = 0;
            cowsCount = 0;
            StringBuilder playerNumber = new StringBuilder(playerInput);
            StringBuilder number = new StringBuilder(generatedNumber);
            for (int i = 0; i < playerNumber.Length; i++)
            {
                if (playerNumber[i] == number[i])
                {
                    bullsCount++;
                    playerNumber.Remove(i, 1);
                    number.Remove(i, 1);
                    i--;
                }
            }

            for (int i = 0; i < playerNumber.Length; i++)
            {
                for (int j = 0; j < number.Length; j++)
                {
                    if (playerNumber[i] == number[j])
                    {
                        cowsCount++;
                        playerNumber.Remove(i, 1);
                        number.Remove(j, 1);
                        j--;
                        i--;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Reveals digits from number one at a time and updates HelpNumber property 
        /// </summary>
        /// <param name="cheats">Number of cheats used so far</param>
        public bool RevealDigit(int cheats)
        {
            bool reveal = false;

            if (cheats < GameNumber.LENGHT)
            {
                int digitToReveal = this.HelpPattern[cheats] - '0';
                this.HelpNumber[digitToReveal - 1] = this.Digits[digitToReveal - 1];
                return true;
            }

            return reveal;
        }

        /// <summary>
        /// Generates unique help pattern used when cheating
        /// </summary>
        private string GenerateHelpPattern()
        {
            string[] helpPaterns = {"1234", "1243", "1324", "1342", "1432", "1423",
                "2134", "2143", "2314", "2341", "2431", "2413",
                "3214", "3241", "3124", "3142", "3412", "3421",
                "4231", "4213", "4321", "4312", "4132", "4123",};

            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);
            int randomPaternNumber = randomNumberGenerator.Next(helpPaterns.Length - 1);
            return helpPaterns[randomPaternNumber];
        }

        #endregion
    }
}
