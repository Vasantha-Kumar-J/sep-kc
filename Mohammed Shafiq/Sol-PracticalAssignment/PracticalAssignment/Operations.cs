using System.Runtime.Serialization.Formatters.Binary;

namespace PracticalAssignment
{
    public class Operations
    {
        public static List<Employee> WorkingEmployees { get; set; } = new List<Employee>();

        public static List<Work> AvailableWorks { get; set; } = new List<Work>();

        internal static void LogErrors(string path, string errorMessage)
        {
            File.WriteAllLines(path, new string[] { errorMessage, "\n" });
        }

        public void SerilizeObject<T>(List<T> objects, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            foreach (T obj in objects)
            {
                formatter.Serialize(File.OpenWrite(path), obj);
            }
        }
        public Dictionary<Employee, Double> AssignEmployee(Work work, List<Employee> employees)
        {
            if (work.IsScheduled)
            {
                return work.Employees;
            }

            double workHours = work.RequiredHours - GetOccupiedHours<Employee>(work.Employees);
            Dictionary<Employee, double> suitableEmployees = new();
            foreach (var employee in employees)
            {

                if (workHours == 0)
                {
                    break;
                }

                if (IsEmployeeSuitable(work, employee))
                {
                    double bookedHours = GetOccupiedHours<Work>(employee.Tasks);
                    suitableEmployees[employee] = bookedHours;
                }
            }
            var sortedEmployees = suitableEmployees.OrderBy(x => x.Key);

            bool isEmployeeAvaliable = true;
            while (workHours > 0 && isEmployeeAvaliable)
            {
                isEmployeeAvaliable = false;
                foreach (var employee in sortedEmployees)
                {
                    if (workHours <= 0)
                    {
                        break;
                    }

                    bool isAllocated = AllocateEmployeeToWork(GetOccupiedHours<Work>(employee.Key.Tasks), employee.Key, work, workHours <= 2 ? workHours : 2);
                    isEmployeeAvaliable = isEmployeeAvaliable || isAllocated;
                    workHours -= 2;
                }
            }

            if (workHours <= 0)
            {
                work.IsScheduled = true;
            }
            FindThePossibilityToComplete(work);
            return work.Employees;
        }

        public bool AssignEmployeeToAllTasks(List<Work> tasks, List<Employee> employees)
        {
            var sortedTasks = tasks.OrderBy(x => x.DeadLine);
            foreach (var task in sortedTasks)
            {
                try
                {
                    this.AssignEmployee(task, employees);
                }
                catch (Exception ex)
                {
                    LogErrors("./Message/error.txt", ex.Message);
                }
            }
            return true;
        }

        public bool FindThePossibilityToComplete(Work work)
        {
            DateOnly requiredTime = DateOnly.FromDateTime(DateTime.Now);
            int days = 0;
            while(work.DeadLine > requiredTime)
            {
                days++;
                requiredTime = requiredTime.AddDays(1);
            }

            double workingHours = 0;
            foreach( var pair in work.Employees)
            {
                workingHours += pair.Value;
            }

            if (workingHours >= work.RequiredHours && (days*8) >= workingHours)
            {
                work.IsPossibleToComplete = true;
                return true;
            }

            return false;
        }

        private bool AllocateEmployeeToWork(Double bookedHours, Employee employee, Work work, double workHours)
        {
            if (bookedHours + workHours > 40)
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

        private double GetOccupiedHours<T>(Dictionary<T, double> tasks)
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