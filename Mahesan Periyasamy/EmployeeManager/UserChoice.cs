namespace EmployeeManager
{
    /// <summary>
    /// Maps user choice to the employee manager operations.
    /// </summary>
    public enum UserChoice
    {
        /// <summary>
        /// Exits the application.
        /// </summary>
        Exit,

        /// <summary>
        /// Add an employee.
        /// </summary>
        AddEmployee,

        /// <summary>
        /// Remove an employee.
        /// </summary>
        RemoveEmployee,

        /// <summary>
        /// Add a task.
        /// </summary>
        AddTask,

        /// <summary>
        /// Remove a task.
        /// </summary>
        RemoveTask,

        /// <summary>
        /// Schedule tasks.
        /// </summary>
        ScheduleTasks,

        /// <summary>
        /// Print the employees.
        /// </summary>
        PrintEmployees,

        /// <summary>
        /// Print the tasks.
        /// </summary>
        PrintTasks,

        /// <summary>
        /// Import employees from file.
        /// </summary>
        ImportEmployees,

        /// <summary>
        /// Import tasks from file.
        /// </summary>
        ImportTasks,
    }
}