namespace EmployeeManager
{
    /// <summary>
    /// Implements methods for file operations.
    /// </summary>
    internal static class FileOperations
    {
        /// <summary>
        /// Import tasks from a file.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <returns>Imported tasks.</returns>
        /// <exception cref="InvalidTaskFileException">The exception that is thrown when the task file is in an invalid format.</exception>
        public static List<Task> ImportTasks(string path)
        {
            List<Task> tasks = new List<Task>();
            try
            {
                using StreamReader reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(',');
                    if (values.Length != 5) 
                    {
                        throw new InvalidTaskFileException("Csv values exceeed the given range.");
                    }

                    if (!int.TryParse(values[0], out int id))
                    {
                        throw new InvalidTaskFileException($"{values[0]} is not a valid task id.");
                    }
                    string description = values[1];
                    if (!int.TryParse(values[2], out int requiredHours))
                    {
                        throw new InvalidTaskFileException($"{values[2]} is not a valid value for required hours.");
                    }

                    if (!DateTime.TryParse(values[3], out DateTime deadline))
                    {
                        throw new InvalidTaskFileException($"{values[3]} is not a valid date for deadline.");
                    }

                    string skillNeeded = values[4];
                    tasks.Add(new Task(id, description, requiredHours, deadline, skillNeeded));
                }
            }
            catch 
            {
                throw;
            }

            return tasks;
        }

        /// <summary>
        /// Imports employees from a file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Imported employees.</returns>
        /// <exception cref="InvalidEmployeeFileException">The exception that is thrown when the employee file is in an invalid format.</exception>
        public static List<Employee> ImportEmployees(string path) 
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using StreamReader reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(',');
                    if (!int.TryParse(values[0], out int id))
                    {
                        throw new InvalidEmployeeFileException($"{values[0]} is not a valid employee id.");
                    }
                    string name = values[1];

                    if (!int.TryParse(values[2], out int workingHours))
                    {
                        throw new InvalidEmployeeFileException($"{values[2]} is not a valid value for working hours of the employee.");
                    }

                    List<string> skills = values.Skip(3).ToList();

                    employees.Add(new Employee(id, name, workingHours, skills, true));
                }

            }
            catch
            {
                throw;
            }

            return employees;
        }
    }
}
