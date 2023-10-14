// <copyright file="UserInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TaskScheduler
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Gets user input for whichever class.
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Gets valid input from user.
        /// </summary>
        /// <param name="messageToPrint">The message to print to the user asking for input.</param>
        /// <param name="regexToCompareWith">The regex to check the input with.</param>
        /// <returns>The valid user input.</returns>
        public static string GetValidInput(string messageToPrint, string regexToCompareWith)
        {
            string input = GetUserInput(messageToPrint);
            int retriesAllowed = 3;
            for (int i = 1; i <= retriesAllowed; i++)
            {
                if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, regexToCompareWith))
                {
                    return input;
                }

                input = GetUserInput(messageToPrint);
            }

            Console.WriteLine("More than three wrong retries please try again");
            return string.Empty;
        }

        private static string GetUserInput(string messageToPrint)
        {
            Console.WriteLine(messageToPrint);
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
