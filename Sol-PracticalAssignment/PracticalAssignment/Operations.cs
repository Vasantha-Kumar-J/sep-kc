namespace PracticalAssignment
{
    public class Operations
    {
        public static List<Employee> WorkingEmployees { get; set; } = new List<Employee>();

        public static List<Work> AvailableWorks { get; set; } = new List<Work>();

        public Dictionary<Employee, Double> AssignEmployee(Work work, List<Employee> employees)
        {
            double workHours = work.RequiredHours;
            SortedDictionary<Employee, double> suitableEmployees = new();
            foreach (var employee in employees)
            {
                if (workHours == 0)
                {
                    break;
                }

                if (IsEmployeeSuitable(work, employee))
                {
                    double bookedHours = GetAvaliableFreeHours(employee.Tasks);
                    suitableEmployees[employee] = bookedHours;
                }
            }

            bool isEmployeeAvaliable = true;
            while (workHours > 0 && isEmployeeAvaliable)
            {
                isEmployeeAvaliable = false;
                foreach (var employee in suitableEmployees)
                {
                    isEmployeeAvaliable = isEmployeeAvaliable | AllocateEmployeeToWork(employee.Value, employee.Key, work, workHours <= 2 ? workHours : 2);
                    workHours -= 2;
                }
            }
            if (workHours <= 0)
            {
                work.IsScheduled = true;
            }

            return work.Employees;
        }

        private bool AllocateEmployeeToWork(Double bookedHours, Employee employee, Work work, double workHours)
        {
            if (bookedHours > 40)
            {
                employee.IsAvaLiable = Availability.unAvaliable;
                return false;
            }
            if (!work.Employees.ContainsKey(employee))
            {
                work.Employees[employee] = 0;
            }
            work.Employees[employee] += workHours;
            if (!employee.Tasks.ContainsKey(work))
            {
                employee.Tasks[work] = 0;
            }
            employee.Tasks[work] += workHours;
            employee.IsAvaLiable = Availability.PartialyAvaliable;
            return true;
        }

        private double GetAvaliableFreeHours(Dictionary<Work, double> tasks)
        {
            double hours = 0;
            foreach (var task in tasks)
            {
                hours += task.Value;
            }

            return hours;
        }

        private bool IsEmployeeSuitable(Work work, Employee employee)
        {
            foreach (var skill in work.RequiredSkills)
            {
                if (employee.Skills.Contains(skill) && employee.IsAvaLiable != Availability.unAvaliable)
                {
                    return true;
                }
            }
            return false;
        }
    }
}