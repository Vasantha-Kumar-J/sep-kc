using System.Text.RegularExpressions;

namespace PracticalAssignment
{
    public class FileHandler
    {
        public Employee GetEmployeeDetails(string path)
        {
            StreamReader fileStream = new StreamReader(path);
            string content = fileStream.ReadToEnd().ToLower();
            Regex regexName = new Regex(@"name[\s]?:[\s]?[\w\s]{3,30}\n");
            Match match = regexName.Match(content);
            string name = GetContent(match.Value);
            Regex regexSkills = new Regex(@"skill[s]?[\s]?:[\s]?[\w\s#,]*(\n|$)");
            match = regexSkills.Match(content);
            List<string> skills = GetSkills(match.Value);
            return new Employee(name, skills);
        }

        public List<Work> GetWorks(string path)
        {
            StreamReader fileStream = new StreamReader(path);
            string content = fileStream.ReadToEnd().ToLower();
            int index = 0;
            var tasks = new List<Work>();
            while (index < content.Length)
            {
                Regex regexName = new Regex(@"description[\s]?:[\s]?[\w\s]{3,200}\n");
                Match match = regexName.Match(content, index);
                if (match.Value == string.Empty)
                {
                    break;
                }

                string description = GetContent(match.Value);
                Regex regexNumber = new Regex(@"required hours[\s]?:[\s]?[0-9]+");
                match = regexNumber.Match(content, index);
                double requiredHours = Convert.ToDouble(GetContent(match.Value));
                Regex regexSkills = new Regex(@"skill[s]?[\s]?:[\s]?[\w\s#,]*\n");
                match = regexSkills.Match(content, index);
                List<string> skills = GetSkills(match.Value);
                Regex regexDate = new Regex(@"deadline[\s]?:[\s]?[\d]{1,2}/[\d]{1,2}/[\d]{2,4}");
                match = regexDate.Match(content, index);
                DateOnly deadline;
                try
                {
                    deadline = GetDate(match.Value);
                }
                catch (Exception ex)
                {
                    Operations.LogErrors("Message/error.txt", ex.Message);
                    throw new InValidDateException(ex);
                }

                var work = new Work(description, requiredHours, skills, deadline);
                tasks.Add(work);
                index = match.Index + match.Value.Length - 1;
            }
            return tasks;
        }

        private DateOnly GetDate(string content)
        {
            int index = content.IndexOf(":");
            if (index < 0)
            {
                throw new InvalidOperationException();
            }

            string name = content.Substring(index + 1);
            string[] strings = name.Split("/");
            int date = Convert.ToInt32(strings[0].Trim());
            int month = Convert.ToInt32(strings[1].Trim());
            int year = Convert.ToInt32(strings[2].Trim());
            if(year < 24)
            {
                year += 2000;
            }
            else if (year < 100)
            {
                year += 1000;
            }

            return new DateOnly(year, month, date);
        }

        private List<string> GetSkills(string content)
        {
            int index = content.IndexOf(":");
            if (index < 0)
            {
                throw new InvalidOperationException();
            }

            string name = content.Substring(index + 1);
            string[] skills = name.Split(",");
            return skills.Select((skill) => skill.Trim()).ToList();
        }

        private string GetContent(string content)
        {
            int index = content.IndexOf(":");
            if(index < 0)
            {
                throw new InvalidOperationException();
            }

            string name = content.Substring(index + 1);
            return name.Trim();
        }
    }
}