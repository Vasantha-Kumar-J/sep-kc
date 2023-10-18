namespace EmployeeManagerAndTaskScheduler
{
    public class Scheduler : IScheduler
    {
        public void Schedule(List<Task>taskList,List<Employee>employeeList)
        {
            UnSchedule(taskList,employeeList);

            foreach(var task in taskList)
            {
                int availableDays = task.DueDate.DayOfYear -  DateTime.Now.Date.DayOfYear;
                double requiredHoursPerDay = (double)task.RequiredHours/(double)availableDays;
                requiredHoursPerDay = Math.Round(requiredHoursPerDay,2);

                List<Employee> validEmployees = FilterEmployeesByRequiredSkillsAndAvailability(task, employeeList);

                if(IsSchedulable(requiredHoursPerDay,validEmployees))
                {
                    List<Employee> addedEmployees = new List<Employee>();
                    int employeeCount = 0;
                    foreach(Employee emp in validEmployees)
                    {
                        var allocatedHours = emp.SetAvailability(requiredHoursPerDay);
                        employeeCount++;
                        addedEmployees.Add(emp);
                        requiredHoursPerDay -= allocatedHours;
                        emp.AssignedTasks.Add((task,allocatedHours));
                        task.AssignedEmployees.Add(emp);
                        if(requiredHoursPerDay <=0)
                        {
                            break;
                        }
                    }
                    task.IsScheduled =true;
                }
            }
        }


        private List<Employee> FilterEmployeesByRequiredSkillsAndAvailability(Task task, List<Employee> employeeList)
        {
            var availableEmployee = new List<Employee>();

            foreach(var employee in employeeList)
            {
                if(employee.IsAvailable)
                {
                    int count = task.Skills.Count;
                    foreach(var skill in task.Skills)
                    {
                        if(employee.Skills.Contains(skill))
                        {
                            count--;
                        }
                    }
                    if(count<=0)
                    {
                        availableEmployee.Add(employee);
                    }
                }
            }

            availableEmployee.Sort((x, y) => x.Skills.Count - y.Skills.Count);
            availableEmployee.Sort((x, y) => (int)(y.GetAvailability() - x.GetAvailability()));
            return availableEmployee;
        }

        private bool IsSchedulable(double requiredHoursPerDay,List<Employee> employeeList)
        {
            double availableHours = 0;
            foreach(var employee in employeeList)
            {
                availableHours += employee.GetAvailability();
            }
            return availableHours > requiredHoursPerDay;
        }
        public void UnSchedule(List<Task> tasks,List<Employee> employeeList)
        {
            foreach(var task in tasks)
            {
                task.IsScheduled = false;
                task.AssignedEmployees.Clear();
            }

            foreach(var employee in employeeList)
            {
                employee.AssignedTasks.Clear();
                employee.RemainingHoursPerDay = employee.WorkingHours;
                employee.IsAvailable = true;
            }
        }

        public void GenerateReport(List<Employee> employees, List<Task> tasks)
        {
            Utility.PrintInColorLn("Scheduled Tasks", ConsoleColor.Red);
            Utility.PrintScheduledTasks(tasks);
            Utility.PrintInColorLn("UnScheduled Tasks", ConsoleColor.Red);
            Utility.PrintUnScheduledTasks(tasks);

            employees.Sort((x, y) => (int)(x.GetAvailability() - y.GetAvailability()));
            Utility.PrintEmployee(employees);
        }
    }
}
