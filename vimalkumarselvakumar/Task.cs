using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerAndTaskScheduler
{
    public class Task
    {
        public Task(string name, string description, int requiredHours, DateOnly dueDate, List<string> skills, List<Employee> assignedEmployees)
        {
            Name = name;
            Description = description;
            RequiredHours = requiredHours;
            DueDate = dueDate;
            Skills = skills;
            IsScheduled = false;
            AssignedEmployees = new List<Employee>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double RequiredHours { get; set; }

        public DateOnly DueDate { get; set; }

        public List<string> Skills { get; init; }

        [JsonIgnore]
        public List<Employee> AssignedEmployees
        {
            get;
        }
        public bool IsScheduled { get; set; }
    }
}