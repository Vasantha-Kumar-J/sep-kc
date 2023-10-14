using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class Utility
    {
        /// <summary>
        /// GetValidInput would check for valid inputs
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="regex">Regex for validations</param>
        /// <param name="aboutMessage">message</param>
        /// <param name="errorMessage">error message for invalid inputs</param>
        /// <returns>valid inputs</returns>
        public static T GetValidInput<T>(Regex regex, string aboutMessage = "Enter input : ", string errorMessage = "Invalid input ! ")
        {
            Console.Write(aboutMessage);

            string? input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input) || !regex.IsMatch(input))
            {
                Console.Write($"{errorMessage}\nTry again : ");

                input = Console.ReadLine();
            }

            return (T)Convert.ChangeType(input, typeof(T));
        }
    }
}
