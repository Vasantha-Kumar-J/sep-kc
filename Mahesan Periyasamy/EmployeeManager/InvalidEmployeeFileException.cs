namespace EmployeeManager
{
    /// <summary>
    /// The exception that is thrown when the employee file is in an invalid format.
    /// </summary>
    internal class InvalidEmployeeFileException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="InvalidEmployeeFileException"/> with an error message.
        /// </summary>
        /// <param name="message">Message.</param>
        public InvalidEmployeeFileException(string message) 
            : base(message) 
        {
        }
    }
}
