//-----------------------------------------------------------------------
// <copyright file="ScoreBoard.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCowsGame.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BullsAndCowsGame.Intefaces;
    using System.Text;

    /// <summary>
    /// Class that manages the score board
    /// </summary>
    public class ScoreBoard<T> : IScoreBoard<T> where T : IComparable<T>
    {
        #region Fields

        /// <summary>
        /// ScoreBoard data
        /// </summary>
        private readonly T[] data;

        /// <summary>
        /// ScoreBoard lenght
        /// </summary>
        private int count;

        /// <summary>
        /// ScoreBoard max number of inputs
        /// </summary>
        private readonly int maxCount;

        /// <summary>
        /// Current enumerator position
        /// </summary>
        private int position = -1;

        /// <summary>
        /// Default lenght of ScoreBoard. 
        /// Used for the empty constructor
        /// </summary>
        private static int defaultScoreBoardLenght = 5;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ScoreBoard class.
        /// </summary>
        public ScoreBoard()
            : this(defaultScoreBoardLenght)
        { }

        /// <summary>
        /// Initializes a new instance of the ScoreBoard class.
        /// </summary>
        /// <param name="maxCount">ScoreBoard max number of inputs</param>
        public ScoreBoard(int maxCount)
        {
            this.maxCount = maxCount;
            this.data = new T[this.maxCount];
            this.count = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of inputs in the ScoreBoard
        /// </summary>
        public int Count
        {
            get { return this.count; }
        }

        /// <summary>
        /// Gets current position
        /// </summary>
        public T Current
        {
            get { return this.data[this.position]; }
        }

        /// <summary>
        /// Gets current position
        /// </summary>
        object System.Collections.IEnumerator.Current
        {
            get { return this.data[this.position]; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds new element in ScoreBoard
        /// </summary>
        /// <param name="item">Player score</param>
        public void Add(T item)
        {
            if (item.CompareTo(this.data[this.maxCount - 1]) >= 0)
            {
                int tPointer = 0;
                while (item.CompareTo(this.data[tPointer]) < 0)
                {
                    tPointer++;
                }

                for (int i = this.maxCount - 1; i > tPointer; i--)
                {
                    this.data[i] = this.data[i - 1];
                }

                this.data[tPointer] = item;
                if (this.count < this.maxCount)
                {
                    this.count++;
                }
            }
        }

        /// <summary>
        /// Method for iteration through a collection.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through a collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        /// <summary>
        /// Method for iteration through a collection.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through a collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        /// <summary>
        /// Moves to next position in the colection
        /// </summary>
        /// <returns>Returns the next position</returns>
        public bool MoveNext()
        {
            if (this.position < this.Count - 1)
            {
                this.position++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Resets position 
        /// </summary>
        public void Reset()
        {
            this.position = -1;
        }

        /// <summary>
        /// Dispose ScoreBoard
        /// </summary>
        public void Dispose()
        {
            this.Reset();
        }

        #endregion
    }      
}
