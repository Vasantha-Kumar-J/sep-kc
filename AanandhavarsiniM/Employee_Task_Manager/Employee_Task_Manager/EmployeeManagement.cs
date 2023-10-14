namespace Employee_Task_Manager
{
    /// <summary>
    /// Manage Employee details.
    /// </summary>
    public class EmployeeManagement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManagement"/> class.
        /// </summary>
        public EmployeeManagement()
        {
            EmployeeDetails = new List<Employee>();
        }

        /// <summary>
        /// Gets or sets list of employee details.
        /// </summary>
        /// <value>
        /// Stores list of employee details.
        /// </value>
        public List<Employee> EmployeeDetails { get; set; }

        /// <summary>
        /// Add employee detail.
        /// </summary>
        public void AddEmployee()
        {
            GetDetailFromUser getDetailfromUser = new GetDetailFromUser();
            EmployeeDetails.Add(getDetailfromUser.GetEmployeeDetail());
            Console.WriteLine("Employee detail Added!");
        }

        /// <summary>
        /// Display employee detail.
        /// </summary>
        public void DisplayEmployee()
        {
            foreach (Employee employee in EmployeeDetails)
            {
                Console.WriteLine($"{employee.EmployeeName} {employee.Availability} {employee.WorkingHours} {employee.Skill}");
            }
        }
    }
}
