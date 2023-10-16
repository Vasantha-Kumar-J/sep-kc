// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics;

namespace PerformanceAssessment_1
{
    internal class Scheduler
    {
        public delegate void MyTimer();
        public event MyTimer myTimer;

        Loggers logger = new Loggers();
        public void AllocatePersons(Tasks task)
        {
            List<Employee> employeesAvailable = Program.employees.Where(emp => emp.Availability == true).ToList();
            if(employeesAvailable.Count <= 0)
            {
                return;
            }
            List<Employee> aptPersons = employeesAvailable.Where(employee =>
            {
                bool result = false;

                foreach (var item in task.SkillsRequired)
                {
                    result |= employee.Skills.Contains(item, StringComparison.OrdinalIgnoreCase);
                }

                return result;
            }).ToList();

            aptPersons.Sort((emp1, emp2) => emp1.WorkingHours.CompareTo(emp2.WorkingHours));

            int timeNeeded = task.RequiredHours;
            int i = 0;

            while (timeNeeded >= 0)
            {
                if(i == aptPersons.Count)
                {
                    logger.Log("Persons are insufficient", 1);
                    return;
                }
                timeNeeded -= aptPersons[i].WorkingHours;
                aptPersons[i].Availability = false;
                aptPersons[i].allocatedTime = Math.Min(timeNeeded, aptPersons[i].WorkingHours);
                logger.Log($"{aptPersons[i].Name} is assigned to the {task.TaskName}", 0);
                i++;
            }

            if (timeNeeded <= 0)
            {
                Program.tasks.Remove(task);
            }
        }

        public void Timer()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (true)
            {
                if (stopwatch.ElapsedMilliseconds > 2000)
                {
                    stopwatch.Restart();
                    myTimer.Invoke();
                }
            }
        }
    }
}