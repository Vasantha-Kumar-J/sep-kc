// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EmployeeTaskScheduler
{
    using System.Text.RegularExpressions;
    using Utility;

    public class GetOrValidateInputs
    {
        /// <summary>
        /// Prompts the user for an integer input and validates it.
        /// </summary>
        /// <param name="message">The message to display as a prompt.</param>
        /// <returns>The validated integer input.</returns>
        public static int GetValidInputInteger(string message)
        {
            int input;
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out input))
            {
                return input;
            }

            Utility.DisplayErrorMessage("Please enter a valid integer");
            input = GetValidInputInteger(message);
            return input;
        }

        /// <summary>
        /// Prompts the user for an integer input and validates it based on a custom condition.
        /// </summary>
        /// <param name="message">The message to display as a prompt.</param>
        /// <param name="validCondition">A custom validation function that takes an integer input and returns true if it's valid.</param>
        /// <param name="errorMessage">The error message to display if the input is invalid.</param>
        /// <returns>The validated integer input that satisfies the custom condition.</returns>
        public static int GetValidInputIntegerFromGivenCondition(string message, Func<int, bool> validCondition, string errorMessage)
        {
            int input;
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out input))
            {
                if (validCondition(input))
                {
                    return input;
                }

                Utility.DisplayErrorMessage(errorMessage);
                input = GetValidInputIntegerFromGivenCondition(message, validCondition, errorMessage);
                return input;
            }

            Utility.DisplayErrorMessage("Please enter a valid integer");
            input = GetValidInputInteger(message);
            return input;
        }

        /// <summary>
        /// Get list of skills from the user for the specific task.
        /// </summary>
        /// <returns>List of skills.</returns>
        public static List<string> GetSkills()
        {
            int skillCount;
            var skills = new List<string>();
            Console.WriteLine();
            skillCount = GetValidInputIntegerFromGivenCondition("Enter number of skills required for this task : ",
                input => input > 0,
                "Skills should be > 0");

            for (int i = 1; i <= skillCount; i++)
            {
                Console.Write($"Enter skill {i} : ");
                string skill = Console.ReadLine();
                skills.Add(skill);
            }

            return skills;
        }

        /// <summary>
        /// Get valid file path from the user.
        /// </summary>
        /// <param name="message">The message to display as a prompt.</param>
        /// <returns>Valid file path</returns>
        public static string GetValidFilePath(string message)
        {
            Console.Write($"{message}");
            string filePath = Console.ReadLine();
            var validFilePath = new Regex("^([A-Za-z/.]{1})[:]?[\\a-zA-Z0-9.]+");
            if (validFilePath.IsMatch(filePath) && File.Exists(filePath))
            {
                return filePath;
            }

            Utility.DisplayErrorMessage("Kindly, enter a valid file path.");
            return GetValidFilePath(message);
        }
    }

}