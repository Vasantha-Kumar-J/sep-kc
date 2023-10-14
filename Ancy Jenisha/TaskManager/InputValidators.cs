namespace TaskManager
{
    /// <summary>
    /// Has methods to validate the inputs.
    /// </summary>
    public class InputValidators
    {
        /// <summary>
        /// Validates the string input.
        /// </summary>
        /// <returns>A non-empty string</returns>
        public static string GetStringInput()
        {
            string? InputRead = Console.ReadLine();
            while (InputRead == null)
            {
                Console.WriteLine("Enter a valid input");
                InputRead = Console.ReadLine();
            }

            return InputRead;
        }

        /// <summary>
        /// Receives Integer input.
        /// </summary>
        /// <returns>Integer number</returns>
        public static int GetIntegerInput()
        {
            int integer;
            string? InputRead = Console.ReadLine();
            while (!int.TryParse(InputRead, out integer))
            {
                Console.WriteLine("Enter valid Number");
                InputRead = Console.ReadLine();
            }

            return integer;
        }

        /// <summary>
        /// Receives Double input.
        /// </summary>
        /// <returns>Double number</returns>
        public static int GetDoubleInput()
        {
            int doubleNumber;
            string? InputRead = Console.ReadLine();
            while (!int.TryParse(InputRead, out doubleNumber))
            {
                Console.WriteLine("Enter valid Number");
                InputRead = Console.ReadLine();
            }

            return doubleNumber;
        }
    }
}