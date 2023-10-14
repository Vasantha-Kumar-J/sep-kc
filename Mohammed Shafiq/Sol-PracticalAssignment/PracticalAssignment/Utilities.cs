using System.Text.RegularExpressions;

namespace PracticalAssignment
{
    internal partial class Program
    {
        public class Utilities
        {
            public static T GetValidInput<T> (string regex, string message, string errorMessage)
            {
                Regex inputRegex = new Regex (regex);
                Console.Write(message);
                string input = Console.ReadLine() !;
                while(!inputRegex.IsMatch(input))
                {
                    Console.Write($"{errorMessage}\nTry again : ");
                    input = Console.ReadLine() !;
                }

                return (T)Convert.ChangeType(input, typeof(T));
            }

            public static string GetValidFilePath()
            {
                string path = GetValidInput<string>(@"[.]*", "Enter the file Path :", "Enter a valid path");
                while (!File.Exists(path))
                {
                    path = GetValidInput<string>(@"[.]*", "Enter the valid file Path :", "Enter a valid path");
                    if(path.ToLower() == "exit")
                    {
                        return string.Empty;
                    }
                }

                return path;
            }
        }
    }
}