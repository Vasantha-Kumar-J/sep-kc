// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PerformanceAssessment_1
{
    /// <summary>
    /// Class that contains the additional supporting functions for validation.
    /// </summary>
    internal class Utility
    {
        /// <summary>
        /// Method to get the integer from the user.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        /// <returns>Returns the integer.</returns>
        public int GetInteger(string message)
        {
            Console.WriteLine($"Enter the {message}: ");
            string input = Console.ReadLine();

            if (!IsNumber(input))
            {
                PrintMessageInRed("Please Enter only the numbers.");
                GetInteger(message);
            }

            int.TryParse(input, out int result);

            return result;
        }

        /// <summary>
        /// Method to validate that the input contains only numbers.
        /// </summary>
        /// <param name="input">Input message form the user.</param>
        /// <returns>Return true if it is a number.</returns>
        public bool IsNumber(string? input)
        {
            foreach (char ch in input)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method to print the console message in the green.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void PrintMessageInGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Method to print the Error message in the red.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void PrintMessageInRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal void PrintMessageInOrange(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        internal void PrintMessageInOrangeBackground(string message)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black ;
        }
    }
}