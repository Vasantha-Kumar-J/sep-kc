namespace Utility
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Display the error message given as input.
        /// </summary>
        /// <param name="message">Custom error message.</param>
        public static void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Display the success message given as input.
        /// </summary>
        /// <param name="message">Custom success message.</param>
        public static void DisplaySuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Display the important message given as input.
        /// </summary>
        /// <param name="message">Custom important message.</param>
        public static void DisplayImportantMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{message}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}