using System.Text.RegularExpressions;
namespace EmployeeManagerAndTaskScheduler
{
    public class TaskSchedulingApplication : IManagement
    {
        private List<Employee> _employees;
        private List<Task> _tasks;
        private IScheduler _scheduler;
        public TaskSchedulingApplication(IScheduler scheduler)
        {
             _employees = Utility.Import<Employee>("EmployeeDetails.json")!;

             //_employees = Utility.GenerateEmployee();

             _tasks = Utility.Import<Task>("TaskDetails.json")!;
            _scheduler = scheduler;
        }
        public TaskSchedulingApplication(IScheduler scheduler,string employeeFilePath, string taskFilePath)
        {
            _employees = Utility.Import<Employee>(employeeFilePath) !;
            _tasks = Utility.Import<Task>(taskFilePath) !;

            _scheduler = scheduler;

        }


        public void Start()
        {
            while(true)
            {
                Console.Clear();
                Utility.PrintInColorLn(
                "1)Add an Employee\n" +
                "2)View employee details\n" +
                "3)Fire an employee ;)\n" +
                "4)Schedule Task\n" +
                "5)View Scheduled Tasks\n" +
                "6)View UnScheduled tasks\n" +
                "7)Generate Analysis Report\n" +
                "8)Exit", ConsoleColor.DarkYellow);

                int choice = Utility.GetInput<int>("Please select one of the above action", new Regex(@"^[1-8]$"));

                if (choice == 1)
                {
                    AddEmployee();
                }
                else if (choice == 2)
                {
                    Utility.ViewEmployee(_employees);
                }
                else if (choice == 3)
                {
                    Utility.ViewEmployee(_employees);
                    FireEmployee();
                }
                else if (choice == 4)
                {
                    _scheduler.Schedule(_tasks, _employees);
                    Utility.PrintInColorLn("Tasks has been scheduled :) ");
                }
                else if (choice == 5)
                {
                    Utility.PrintScheduledTasks(_tasks);
                }
                else if (choice == 6)
                {
                    Utility.PrintUnScheduledTasks(_tasks);
                }
                else if(choice == 7)
                {
                    _scheduler.GenerateReport(_employees,_tasks);
                }
                else
                {
                    _scheduler.UnSchedule(_tasks, _employees);
                    Utility.Export(_employees, "EmployeeDetails.json");
                    Utility.Export(_tasks, "TaskDetails.json");
                    return;
                }
                Utility.PrintInColorLn("Enter any key to continue", ConsoleColor.Green);
                Console.ReadKey(true);
            }
            

        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }
        private void FireEmployee()
        {
            int id = Utility.GetInput<int>("Enter the id of the employee to fire", new Regex(@"^\d+$"));

            var employeeToBeRemoved = GetEmployeeById(id)!;

            if (employeeToBeRemoved != null)
            {
                foreach(var task in employeeToBeRemoved.AssignedTasks)
                {
                    task.task.IsScheduled = false;

                }
                _employees.Remove(employeeToBeRemoved);

            }

        }

        private Employee? GetEmployeeById(int id)
        {
            foreach(var employee in _employees)
            {
                if(employee.Id == id)
                    return employee;
            }
            return  null;
        }

        private void AddEmployee()
        {
            int noOfEmployee = Utility.GetInput<int>(
                "How many employees do you want to add ?",
                new Regex(@"^[0-9]$"),
                "Invalid Number,You can add up-to 9 employees at a time");

            if (_employees== null)
            {
                _employees = new List<Employee>();
            }    
            for(int i=0;i<noOfEmployee;i++)
            {
                _employees.Add(GetEmployeeFromUser());
                Utility.PrintInColorLn("Employee added",ConsoleColor.Green);
            }
        }

        private Employee GetEmployeeFromUser()
        {
            
            string name = Utility.GetInput<string>("Enter the name of the employee",
                new Regex(@"^\w+$"),
                 "Invalid name"
                ) !;

            int workingHours = Utility.GetInput<int>(
                "Enter daily working hours",
                new Regex(@"^[1-9]$"),
                "Try entering between 1 to 9");

            Utility.PrintSkills();
            int noOfSkills = Utility.GetInput<int>(
                "How many skills do you want to add",
                new Regex(@"^[1-4]$"),
                "You can add at-most 4");
            List<string> skills = new (noOfSkills);
            for(int i=0;i<noOfSkills;i++)
            {
                skills.Add(GetSkillFromUser());
            }

            return new Employee(_employees.Count+1,name,skills,workingHours,new List<(Task,double)>(),workingHours,true);
        }
        private string GetSkillFromUser()
        {
            
            int skill = Utility.GetInput<int>("Enter your skill", new Regex(@"^[1-4]$"));

            return Utility.StringFromSkills((Skills)skill);
        }
    }
}
