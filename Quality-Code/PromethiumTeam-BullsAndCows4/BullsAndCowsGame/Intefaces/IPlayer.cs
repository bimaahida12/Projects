//-----------------------------------------------------------------------
// <copyright file="IPlayer.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCowsGame.Intefaces
{
    using System;

    /// <summary>
    /// Interface for Bulls and Cows player
    /// </summary>
    public interface IPlayer : IComparable<IPlayer>
    {
        /// <summary>
        /// Player's name
        /// </summary>
        string Name { get; set; }
        
        /// <summary>
        /// Player's attempts
        /// </summary>
        int Attempts { get; set; }
    }
}
