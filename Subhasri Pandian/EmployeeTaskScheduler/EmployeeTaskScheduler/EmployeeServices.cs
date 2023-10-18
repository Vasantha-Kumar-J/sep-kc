using ConsoleTables;
namespace EmployeeTaskScheduler
{
    /// <summary>
    /// EmployeeServices - Contains services to perform on employee class.
    /// </summary>
    public class EmployeeServices
    {
        /// <summary>
        /// Gets details of the employee
        /// </summary>
        /// <returns>Returns employee object with all attributes assigned.</returns>
        public Employee GetEmployeeDetails()
        {
            Employee employee = new Employee();
            employee.EmployeeName = "name of the employee".GetValidName<string>("^[a-zA-Z]+($|( +([a-zA-Z])*)*$)");
            employee.WorkingHours = Utility.GetValidWorkingHours();
            employee.Skills = "skills of the employee".GetValidInput<string>();
            Console.WriteLine("Availability of the employee");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"{i+1} {employee.Availability[i]}");
            }
            Console.WriteLine("Enter 1 to specify yes 2 to specify no: ");
            int indexOnAvailabilityList = 2.GetValidUserChoice();
            employee.AvailabilityOfEmployee = employee.Availability[indexOnAvailabilityList-1];
            return employee;
        }

        /// <summary>
        /// Gets data from the file.
        /// </summary>
        public void GetFileEmployeeDetails()
        {
            using (StreamReader streamReader = new StreamReader("employee.txt"))
            {
                string[] dataLines = streamReader.ReadToEnd().Split(new char[] { '\n', '\r' });
                foreach (string line in dataLines)
                {
                    string[] dataRead = line.Split(' ');
                    Employee employee = new Employee();
                    if (dataRead.Length == 4)
                    {
                        employee.EmployeeName = dataRead[0];
                        employee.WorkingHours = (double)Convert.ChangeType(dataRead[1], typeof(double));
                        employee.Skills = dataRead[2];
                        employee.AvailabilityOfEmployee = dataRead[3];
                        Employee.Employees.Add(employee);
                    }
                }
            }
        }


        /// <summary>
        /// Compares Employees By Working hours.
        /// </summary>
        /// <param name="employee1">Employee object 1 to be compared.</param>
        /// <param name="employee2">Employee object 2 to be compared.</param>
        /// <returns></returns>
        public static int SortByWorkingHours(Employee employee1, Employee employee2)
        {
            return employee1.WorkingHours.CompareTo(employee2.WorkingHours);
        }

        /// <summary>
        /// Displays employees list provided.
        /// </summary>
        /// <param name="employees">List of employees to be displayed.</param>
        public void DisplayEmployees(List<Employee> employees)
        {
            ConsoleTable table = new ConsoleTable("Employee Name", "Working Hours", "Skills", "Availability");
            foreach (Employee employee in employees)
            {
                table.AddRow(employee.EmployeeName, employee.WorkingHours, employee.Skills, employee.AvailabilityOfEmployee);
            }
            table.Write();
        }
        public void DisplayUnAssignedEmployees(List<Employee> employees)
        {
            ConsoleTable table = new ConsoleTable("Employee Name", "Remaining Hours", "Skills", "Availability");
            foreach (Employee employee in employees)
            {
                table.AddRow(employee.EmployeeName, employee.RemainingHours, employee.Skills, employee.AvailabilityOfEmployee);
            }
            table.Write();
        }

        /// <summary>
        /// Checks Availability of employee.
        /// </summary>
        /// <returns>Return true if empty else false.</returns>
        public static bool IsEmployeeAvailable()
        {
            return Employee.Employees.Any() ? false : true;
        }
    }
}