namespace EmployeeManager
{
    /// <summary>
    /// Implements method for employee operations.
    /// </summary>
    internal class EmployeeOperations
    {
        /// <summary>
        /// List of employees.
        /// </summary>
        private readonly List<Employee> _employees;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeOperations"/> class with no employees.
        /// </summary>
        public EmployeeOperations()
        {
            _employees = new List<Employee>();
        }

        /// <summary>
        /// Adds an employee to the collection.
        /// </summary>
        /// <param name="employee">Employee.</param>
        /// <returns><see langword="true"/>, if the employee Id is unique and added successfully; otherwise <see langword="false"/>.</returns>
        public bool AddEmployee(Employee employee)
        {
            if (IsIdAlreadyPresent(employee.Id))
            {
                return false;
            }

            _employees.Add(employee);
            return true;
        }

        /// <summary>
        /// Removes an employee from the collection, if present.
        /// </summary>
        /// <param name="employeeId">Employee id.</param>
        /// <returns><see langword="true"/>, if the employee is successfully removed; otherwise, <see langword="false"/>.</returns>
        public bool TryRemoveEmployee(int employeeId)
        {
            foreach (Employee employee in _employees)
            {
                if (employee.Id == employeeId)
                {
                    return _employees.Remove(employee);
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether the employee id is already present.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public bool IsIdAlreadyPresent(int employeeId)
        {
            foreach(Employee employee in _employees)
            {
                if (employee.Id == employeeId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the employees collection.
        /// </summary>
        /// <returns>Employees.</returns>
        public IEnumerable<Employee> GetEmployees()
        {
            return _employees.ToList();
        }
    }
}
