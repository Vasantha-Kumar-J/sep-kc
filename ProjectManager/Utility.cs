using System.Text.RegularExpressions;
using ConsoleTables;
namespace ProjectManager
{
    public class Utility
    {
        public static bool IsValidInput(string? input, string regex)
        {
            if (string.IsNullOrWhiteSpace(input?.ToString()) || !Regex.IsMatch(input.ToString()!, regex))
            {
                return false;
            }

            return true;
        }

        public static T? GetInput<T>(string instruction, string regexString, string format)
        {
            int invalidInputCount = 0;
            Console.Write($"{instruction} ");
            T? validInput;
            string? userInput = Console.ReadLine();
            while (invalidInputCount < 3)
            {
                if (IsValidInput(userInput, regexString))
                {
                    validInput = (T?)Convert.ChangeType(userInput, typeof(T));
                    return validInput;
                }

                invalidInputCount++;

                DisplayMessageInSpecificColor($"Warning: Invalid Input. You have only {4 - invalidInputCount} attempt(s) left. NOTE: {format}", "Yellow");
                Console.Write("Enter again: ");
                userInput = Console.ReadLine();
            }

            if (IsValidInput(userInput, regexString))
            {
                validInput = (T?)Convert.ChangeType(userInput, typeof(T));
                return validInput;
            }

            DisplayMessageInSpecificColor("\nInvalid Input entered multiple times.", "Red");
            return default;
        }

        public static void DisplayMessageInSpecificColor(string message, string messageColor)
        {
            Enum.TryParse(messageColor, out ConsoleColor color);
            Console.ForegroundColor = color;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DisplayListAsTable(IEnumerable<object> objects)
        {
            if (objects == null || !objects.Any())
            {
                Console.WriteLine("No data to display.");
                return;
            }

            var objectType = objects.First().GetType();
            var objectProperties = objectType.GetProperties();

            ConsoleTable table = new(objectProperties.Select(property => property.Name).ToArray());

            foreach (var @object in objects)
            {
                var objectInfo = objectProperties.Select(property => property.GetValue(@object)?.ToString()).ToArray();
                table.AddRow(objectInfo);
            }

            table.Write(Format.Minimal);
        }
    }
}
