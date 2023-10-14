namespace EmployeeManager
{
    /// <summary>
    /// The exception that is thrown when the task file is in an invalid format.
    /// </summary>
    internal class InvalidTaskFileException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="InvalidTaskFileException"/> with an error message.
        /// </summary>
        /// <param name="message">Message.</param>
        public InvalidTaskFileException(string message) 
            : base(message) 
        {
        }
    }
}
