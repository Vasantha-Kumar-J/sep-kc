using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace EmployeeManagerAndTaskScheduler
{
    public static class Utility
    {
        public static T? GetInput<T>(string instruction, Regex regex, string errorMessage = "Invalid input")
            where T : notnull
        {

            PrintInColorLn(instruction);
            string input = Console.ReadLine()!;
            int invalidInputCount = 0;
            T? result = default;
            while (invalidInputCount < 3 && (string.IsNullOrEmpty(input) || !regex.IsMatch(input)))
            {
                PrintInColorLn(errorMessage, ConsoleColor.Red);
                invalidInputCount++;
                input = Console.ReadLine()!;
            }
            if (invalidInputCount >= 3)
            {
                PrintInColorLn("Multiple Invalid input has been entered ;) Revoking the operation");
            }
            try
            {
                result = (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                throw;
            }
            return result;

        }

        public static void PrintInColor(string input, ConsoleColor consoleColor = ConsoleColor.White)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintInColorLn(string input, ConsoleColor consoleColor = ConsoleColor.White)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static List<TClass>? Import<TClass>(string path)
        {
            IEnumerable<TClass>? contents = default;
            try
            {

                string fileContents = StreamFileReader.Read(path);

                contents = JsonConvert.DeserializeObject<List<TClass>>(fileContents);
            }
            catch
            {
                throw;
            }
            return contents.ToList();

        }

        public static string Export<TClass>(IEnumerable<TClass> list, string path = "details.json")
        {
            string contents = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, contents);

            return path;

        }

        public static void ViewEmployee(IEnumerable<Employee> employees)
        {
            if (employees.Count() == 0 || employees == null)
            {
                Utility.PrintInColorLn("No employee available", ConsoleColor.Red);
                return;
            }

            foreach (var employee in employees)
            {
                var employeeTable = new ConsoleTables.ConsoleTable("Id", "Employee Name", "Availability", "Skills", "Assigned Work Per day");
                employeeTable.AddRow(
                    employee.Id,
                    employee.Name,
                    employee.IsAvailable ? "Available" : "Not Available",
                    GetSkillsAsString(employee.Skills),
                    employee.WorkingHours - employee.GetAvailability());
                employeeTable.Write(ConsoleTables.Format.Minimal);
                ViewTasksOfAnEmployee(employee.AssignedTasks);

                Console.WriteLine("\n\n");
            }
        }

        public static void ViewTasksOfAnEmployee(IEnumerable<(Task, double)> tasks)
        {
            if (tasks == null || tasks.Count() == 0)
            {
                Utility.PrintInColorLn("No Tasks Assigned", ConsoleColor.Red);
                return;
            }

            var tasksTable = new ConsoleTables.ConsoleTable("Name", " Required Hours", "Due Date", "Assigned Hours");
            foreach (var task in tasks)
            {
                tasksTable.AddRow(
                    task.Item1.Name,
                    task.Item1.RequiredHours,
                    task.Item1.DueDate.ToString(),
                    task.Item2);
            }
            tasksTable.Write();
        }
        public static void PrintSkills()
        {
            PrintInColorLn("Required Skills");

            PrintInColorLn(StringFromSkills(Skills.Design), ConsoleColor.Yellow);
            PrintInColorLn(StringFromSkills(Skills.Coding), ConsoleColor.Yellow);
            PrintInColorLn(StringFromSkills(Skills.Testing), ConsoleColor.Yellow);
            PrintInColorLn(StringFromSkills(Skills.Other), ConsoleColor.Yellow);
        }

        public static string GetSkillsAsString(IEnumerable<string> skills)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var sk in skills)
            {
                stringBuilder.Append('(');
                stringBuilder.Append(sk);
                stringBuilder.Append(')');

            }
            return stringBuilder.ToString();
        }
        public static string StringFromSkills(Skills c)
        {
            switch (c)
            {
                case Skills.Design:
                    return $"Design";
                case Skills.Coding:
                    return $"Coding";
                case Skills.Testing:
                    return $"Testing";
                case Skills.Other:
                    return $"Other";
                default:
                    return "Invalid Skill";
            }
        }

        public static List<Employee> GenerateEmployee()
        {
            var employees = Enumerable.Range(1, 50).Select(i =>
            new Employee(
                id: i,
                name: "Employee " + i,
                skills: new List<string> { "Coding", "Design", "Testing" },
                workingHours: 8,
                assignedTasks: new List<(Task, double)>(),
                availability: 8,
                isAvailable: true
            )
        ).ToList();

            return employees;
        }

        public static void PrintScheduledTasks(List<Task> tasks)
        {
            foreach (var task in tasks)
            {
                if (task.IsScheduled)
                {
                    var tasksTable = new ConsoleTables.ConsoleTable("Name", " Required Hours", "Due Date");

                    tasksTable.AddRow(
                        task.Name,
                        task.RequiredHours,
                        task.DueDate.ToString());
                    tasksTable.Write(ConsoleTables.Format.Minimal);

                    Utility.PrintInColorLn("Assigned Workers", consoleColor: ConsoleColor.Green);
                    PrintEmployee(task.AssignedEmployees);
                }
            }
        }
        public static void PrintEmployee(IEnumerable<Employee> employees)
        {
            var employeeTable = new ConsoleTables.ConsoleTable("Id", "Employee Name", "Availability", "Skills", "Assigned Work Per day");
            foreach (var employee in employees)
            {
                employeeTable.AddRow(
                    employee.Id,
                    employee.Name,
                    employee.IsAvailable ? "Available" : "Not Available",
                    GetSkillsAsString(employee.Skills),
                    employee.WorkingHours - employee.GetAvailability());
            }

            employeeTable.Write();
            Console.WriteLine("\n\n");
        }

        public static void PrintUnScheduledTasks(List<Task> tasks)
        {
            var tasksTable = new ConsoleTables.ConsoleTable("Name", " Required Hours", "Due Date");
            foreach (var task in tasks)
            {
                if (!task.IsScheduled)
                {

                    tasksTable.AddRow(
                        task.Name,
                        task.RequiredHours,
                        task.DueDate.ToString());

                }
            }
            tasksTable.Write();
        }
    }
}
