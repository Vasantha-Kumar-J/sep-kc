using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class TaskManager
    {
        public Context Data { get; set; } = new Context();

        public void AddingEmployees()
        {
            this.Data.EmployeeData.Add(new ImportEmployeeData { Availablity = "Available", EmployeeAttributes = "Employee2", Name = "Soliton", Skills = "c#", WorkingHours = 8 });
            this.Data.EmployeeData.Add(new ImportEmployeeData { Availablity = "Available", EmployeeAttributes = "Employee4", Name = "Lipika", Skills = "webtech", WorkingHours = 2 });
            this.Data.EmployeeData.Add(new ImportEmployeeData { Availablity = "Available", EmployeeAttributes = "Employee5", Name = "Preetz", Skills = "c#", WorkingHours = 6 });
            this.Data.EmployeeData.Add(new ImportEmployeeData { Availablity = "Available", EmployeeAttributes = "Employee7", Name = "Solin", Skills = "webtech", WorkingHours = 8 });
            this.Data.EmployeeData.Add(new ImportEmployeeData { Availablity = "Available", EmployeeAttributes = "Employee8", Name = "UNito", Skills = "c#", WorkingHours = 6 });
            this.Data.EmployeeData.Add(new ImportEmployeeData { Availablity = "Available", EmployeeAttributes = "Employee9", Name = "ral", Skills = "webtech", WorkingHours = 9 });
        }

        public void AddingTasks()
        {
            this.Data.TaskData.Add(new ImportTaskData { TaskId = 1, Attributes = "Task1 Attributes", Deadline = "8", Description = "Task1 Description", RequiredHoursOfWork = 6, RequiredSkills = "c#" });
            this.Data.TaskData.Add(new ImportTaskData { TaskId = 2, Attributes = "Task2 Attributes", Deadline = "12", Description = "Task2 Description", RequiredHoursOfWork = 10, RequiredSkills = "webtech" });
            this.Data.TaskData.Add(new ImportTaskData { TaskId = 3, Attributes = "Task3 Attributes", Deadline = "9", Description = "Task3 Description", RequiredHoursOfWork = 7, RequiredSkills = "c#" });
            this.Data.TaskData.Add(new ImportTaskData { TaskId = 4, Attributes = "Task4 Attributes", Deadline = "24", Description = "Task4 Description", RequiredHoursOfWork = 22, RequiredSkills = "webtech" });

        }


        public void AddTaskDataFromFile()
        {
            string taskData = @"D:\CSharp\src\TaskScheduler\Task.txt";
            string patternForAttributes = "<attributes>(.*?)</attributes>";
            string patternForDescription = "<description>(.*?)</description>";
            string patternForRequiredHours = "<requiredhours>(.*?)</requiredhours>";
            string patternForDeadline = "<deadline>(.*?)</deadline>";
            string patternForSkills = "<skills>(.*?)</skills>";

            using (FileStream fileStream = new FileStream(taskData, FileMode.Open))
            {
                StreamReader sr = new StreamReader(fileStream);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadToEnd()!;
                    var resultForAttributes = ExtractingTaskData<string>(line, patternForAttributes);
                    var resultForDescription = ExtractingTaskData<string>(line, patternForDescription);
                    var resultForRequiredHours = ExtractingTaskData<int>(line, patternForRequiredHours);
                    var resultForDeadline = ExtractingTaskData<string>(line, patternForDeadline);
                    var resultForSkills = ExtractingTaskData<string>(line, patternForSkills);


                    this.Data.TaskData.Add(new ImportTaskData { Attributes = resultForAttributes, Description = resultForDescription, RequiredHoursOfWork = resultForRequiredHours, Deadline = resultForDeadline, RequiredSkills = resultForSkills });
                }
                fileStream.Close();
                sr.Close();
            }
        }

        public T ExtractingTaskData<T>(string line, string pattern)
        {
            string value = string.Empty;
            Match match = Regex.Match(line!, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                string title = match.Groups[1].Value;
                value = title;

            }
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public void AddEmployeeDataFromFile()
        {
            string taskData = @"D:\CSharp\src\TaskScheduler\EmployeeData.txt";
            string patternForAttributes = "<attributes>(.*?)</attributes>";
            string patternForName = "<name>(.*?)</name>";
            string patternForWorkingHours = "<workinghours>(.*?)</workinghours>";
            string patternForAvailablity = "<availability>(.*?)</availability>";
            string patternForSkills = "<skills>(.*?)</skills>";

            using (FileStream fileStream = new FileStream(taskData, FileMode.Open))
            {
                StreamReader sr = new StreamReader(fileStream);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadToEnd()!;
                    var resultForName = ExtractingTaskData<string>(line, patternForName);
                    var resultForAttributes = ExtractingTaskData<string>(line, patternForAttributes);
                    var resultForWorkingHours = ExtractingTaskData<int>(line, patternForWorkingHours);
                    var resultForSkills = ExtractingTaskData<string>(line, patternForSkills);
                    var resultForAvailablity = ExtractingTaskData<string>(line, patternForAvailablity);

                    this.Data.EmployeeData.Add(new ImportEmployeeData { Name = resultForName, EmployeeAttributes = resultForAttributes, WorkingHours = resultForWorkingHours, Skills = resultForSkills, Availablity = resultForAvailablity });

                }
                fileStream.Close();
                sr.Close();
            }
        }

        public void DisplayAvailablity()
        {

            Console.WriteLine("Available Employees");
            foreach (var employee in this.Data.EmployeeData)
            {
                Console.WriteLine($"Name : {employee.Name} \nAttributes : {employee.EmployeeAttributes} \nWorking Hours : {employee.WorkingHours} \nSkills : {employee.Skills} \nAvailablity : {employee.Availablity}");
            }
            Console.WriteLine("Available Task");
            foreach (var task in this.Data.TaskData)
            {
                Console.WriteLine($"Id : {task.TaskId} \nAttributes : {task.Attributes} \nDescription : {task.Description} \nRequiredHours : {task.RequiredHoursOfWork} \nDeadline : {task.Deadline} \nSkills : {task.RequiredSkills}");
            }
        }

        public void AddTaskFromUser()
        {
            string addTaskChoice = "yes";
            int globalId = this.Data.TaskData.Count + 1;
            do
            {
                addTaskChoice = Utility.GetValidInput<string>(new Regex(@"^[(.|\s)*\S(.|\s)*]"), "\nThere are Tasks available, Do you wish to add Task ? \nChoose (yes/no) :").ToLower();
                if (addTaskChoice != "no")
                {
                    string attributes = Utility.GetValidInput<string>(new Regex(@"^[A-Za-z]+[ ]?[A-Za-z ]*$"), "Enter Attributes :");
                    string description = Utility.GetValidInput<string>(new Regex(@"^[A-Za-z]+[ ]?[A-Za-z ]*$"), "Enter Description :");
                    int requiredHours = Utility.GetValidInput<int>(new Regex(@"^[1-9][0-9]{0,7}$"), "Enter Required Hours :");
                    string deadline = Utility.GetValidInput<string>(new Regex(@"^[1-9][0-9]{0,7}$$"), "Enter Deadline :");
                    string skills = Utility.GetValidInput<string>(new Regex(@"^[A-Za-z#]+[ ]?[A-Za-z ]*$"), "Enter Skills :");


                    this.Data.TaskData.Add(new ImportTaskData
                    {
                        TaskId = globalId,
                        Attributes = attributes,
                        Description = description,
                        RequiredHoursOfWork = requiredHours,
                        Deadline = deadline,
                        RequiredSkills = skills
                    });
                    Console.WriteLine("Task added successfully !");
                }

                globalId++;
            }
            while (addTaskChoice != "no");
        }

        public void AddEmployeeDataFromUser()
        {
            string Choice = "yes";
            int globalId = this.Data.TaskData.Count + 1;
            do
            {
                Choice = Utility.GetValidInput<string>(new Regex(@"^[(.|\s)*\S(.|\s)*]"), "\nThere are Employees available, Do you wish to add Employees ? \nChoose (yes/no) :").ToLower();
                if (Choice != "no")
                {
                    string attributes = Utility.GetValidInput<string>(new Regex(@"^[A-Za-z]+[ ]?[A-Za-z ]*$"), "Enter Attributes :");
                    string name = Utility.GetValidInput<string>(new Regex(@"^[A-Za-z]+[ ]?[A-Za-z ]*$"), "Enter Name :");
                    int requiredHours = Utility.GetValidInput<int>(new Regex(@"^[1-9][0-9]{0,7}$"), "Enter Working Hours :");
                    string availablity = Utility.GetValidInput<string>(new Regex(@"^[1-9][0-9]{0,7}$$"), "Enter Availablity :");
                    string skills = Utility.GetValidInput<string>(new Regex(@"^[A-Za-z#]+[ ]?[A-Za-z ]*$"), "Enter Skills :");


                    this.Data.EmployeeData.Add(new ImportEmployeeData
                    {
                        EmployeeId = globalId,
                        Name = name,
                        EmployeeAttributes = attributes,
                        WorkingHours = requiredHours,
                        Availablity = availablity,
                        Skills = skills
                    });
                    Console.WriteLine("Employee added successfully !");
                }

                globalId++;
            }
            while (Choice != "no");
        }
        public void AssignTaskToEmployee()
        {
            Dictionary<int, string> taskIdAndEmployeeName = new Dictionary<int, string>();
            foreach(var task in this.Data.TaskData)
            {
                int.TryParse(task.Deadline, out int deadline);
                foreach(var employee in this.Data.EmployeeData)
                {
                    if(task.RequiredSkills.Equals(employee.Skills) && employee.Availablity== "Available" && employee.WorkingHours <= deadline)
                    {

                        var query = this.Data.EmployeeData.SingleOrDefault(p => p.Availablity == "Available" && p.Name == employee.Name && p.EmployeeId == employee.EmployeeId );
                        if (query != null)
                        {
                            query.Availablity = "Busy";
                        }
                        if (!taskIdAndEmployeeName.ContainsKey(task.TaskId) && !taskIdAndEmployeeName.ContainsValue(employee.Name) )
                        {
                            taskIdAndEmployeeName.Add(task.TaskId, employee.Name);
                            taskIdAndEmployeeName[task.TaskId] = employee.Name;
                            Console.WriteLine($"The task {task.TaskId} is assigned to {employee.Name}");

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Task is already assigned to our employee");
                        }
                    }
                }
            }
        }
    }
}