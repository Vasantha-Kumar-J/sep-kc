namespace TaskManager
{
    /// <summary>
    /// Program class has the Main method which gets inputs from user.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Gets input from user creates objects and calls methods based on the input.
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Employee Details");

            Console.WriteLine("Enter the number of Employee");
            int numberOfEmployee = InputValidators.GetIntegerInput();

            for (int i = 0; i < numberOfEmployee; i++)
            {
                Employee employee = new ();

                Console.WriteLine("Enter the name of the Employee:");
                employee.Name = InputValidators.GetStringInput();

                Console.WriteLine("Enter the Employee Id:");
                employee.EmployeeId = InputValidators.GetIntegerInput();

                Console.WriteLine("Enter the working hours of the employee:");
                employee.WorkingHours = InputValidators.GetDoubleInput();

                Console.WriteLine("Enter the skills of the Employee:");
                employee.Skills = InputValidators.GetStringInput();

                Console.WriteLine("Enter the number of days the employee will be avilable for the current month");
                employee.AvailableDays = InputValidators.GetIntegerInput();

                EmployeeManager.ListOfEmployees.Add(employee);

            }

            Console.WriteLine("Task Details");

            Console.WriteLine("Enter the number of taskDetails");
            int numberOfTasks = InputValidators.GetIntegerInput();
            for(int i = 0; i < numberOfTasks; i++)
            {
                TaskDetails taskDetails = new ();

                Console.WriteLine("Enter the Task Description:");
                taskDetails.DescriptionOfTask = InputValidators.GetStringInput();

                Console.WriteLine("Enter the hours required for the taskDetails:");
                taskDetails.RequiredHours = InputValidators.GetDoubleInput();

                Console.WriteLine("Enter the skills required for the taskDetails:");
                taskDetails.RequiredSkills = InputValidators.GetStringInput();

                Console.WriteLine("Enter the Task DeadLine:");
                taskDetails.DeadLine = InputValidators.GetIntegerInput();

                TaskListManager.ListOfTasks.Add(taskDetails);
            }
            
            // TaskListManager.ListOfTasks.Sort();

        }
    }
}