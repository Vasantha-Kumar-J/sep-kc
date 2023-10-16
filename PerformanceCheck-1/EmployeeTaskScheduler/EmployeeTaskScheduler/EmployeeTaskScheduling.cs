// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EmployeeTaskScheduler
{
    using Utility;

    public class EmployeeTaskScheduling
    {
        public static void Scheduling(Dictionary<int, Task> tasks, Dictionary<int, Employee> employees)
        {
            if(tasks.Count() == 0 && employees.Count() == 0)
            {
                Utility.DisplayErrorMessage("Task and Employee details should be added before scheduling.");
                return;
            }

            var priorityTasks = tasks.Values.OrderBy(task => task.Deadline);
            
            foreach( var task in priorityTasks )
            {
                var skillsMatched = employees.Where(employee => task.NecessarySkills.Contains(employee.Value.Skill));
            }
        }
    }

}