// <copyright file="FileWriter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TaskScheduler
{
    /// <summary>
    /// Performs all file writing.
    /// </summary>
    public class FileWriter
    {
        /// <summary>
        /// Write employee details to file.
        /// </summary>
        /// <param name="employees">List of employee details to be written to file.</param>
        public void WriteToEmployeeFile(List<Employee> employees)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Employees.txt");

            using (StreamWriter streamWriter = new (filePath))
            {
                foreach (Employee employee in employees)
                {
                    streamWriter.WriteLine("Name : " + employee.Name + " Working hours : " + employee.WorkingHours + " Availability : " + employee.Availability + " Skills : " + employee.Skill);
                }
            }
        }

        /// <summary>
        /// Write employee details to file.
        /// </summary>
        /// <param name="tasks">List of employee details to be written to file.</param>
        public void WriteToTaskFile(List<Task> tasks)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Tasks.txt");
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Task task in tasks)
                {
                    sw.WriteLine("Id : " + task.Id + " Description : " + task.Description + " Required hours : " + task.RequiredHours + " Deadline : " + task.Deadline + " Skills : " + task.Skills);
                }
            }
        }
    }
}
