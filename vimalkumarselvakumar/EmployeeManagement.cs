using System.Text.RegularExpressions;
namespace SRAF
{
    public class EmployeeManagement : IManagement
    {
        private HashSet<Employee> _employees;
        private string _filePath = "employees.json";
        public EmployeeManagement()
        {
            _employees = Utility.Import<Employee>(_filePath)!;
        }
        public EmployeeManagement(string path)
        {
            _filePath = path;
            _employees = Utility.Import<Employee>(_filePath) !;
        }
        public void Start()
        {
            AddEmployee();
            Scheduler scheduler = new Scheduler();
            scheduler.Schedule(new List<Task>()
            {
                new Task("Task1","test task",100,100,new List<string>(){ "1)Design","2)Coding"}),
            }, _employees);

            Utility.Export(_employees, _filePath);
        }

        /*private void ViewEmployee()
        {
            if(_employees == null || _employees.Count == 0)
            {
                Utility.PrintInColorLn("No employee available", ConsoleColor.Red);
                return;
            }

            foreach(var employee in _employees)
            {
                Utility.PrintInColor
            }
        }*/

        private void AddEmployee()
        {
            int noOfEmployee = Utility.GetInput<int>(
                "How many employees do you want to add ?",
                new Regex(@"^[0-9]$"),
                "Invalid Number,You can add up-to 9 employees at a time");

            if (_employees== null)
            {
                _employees = new HashSet<Employee>();
            }    
            for(int i=0;i<noOfEmployee;i++)
            {
                _employees.Add(GetEmployeeFromUser());
            }
        }

        private Employee GetEmployeeFromUser()
        {
            
            string name = Utility.GetInput<string>("Enter the name of the employee",
                new Regex(@"^\w+$"),
                 "Invalid name"
                ) !;

            int workingHours = Utility.GetInput<int>(
                "Enter working hours",
                new Regex(@"^[1-8]$"),
                "Try entering between 1 to 8");

            Utility.PrintSkills();
            int noOfSkills = Utility.GetInput<int>(
                "How many skills do you want to add",
                new Regex(@"^[1-4]$"),
                "You can add at-most 4");
            HashSet<string> skills = new (noOfSkills);
            for(int i=0;i<noOfSkills;i++)
            {
                skills.Add(GetSkillFromUser());
            }

            int availability = Utility.GetInput<int>("Enter your availability for the project in percentage", new Regex(@"^\d{1,2}$"));
            return new Employee(name, workingHours, skills, availability);
        }
        private string GetSkillFromUser()
        {
            
            int skill = Utility.GetInput<int>("Enter your skill", new Regex(@"^[1-4]$"));

            return Utility.StringFromSkills((Skills)skill);
        }
    }
}
