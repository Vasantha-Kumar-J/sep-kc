// <copyright file="ScheduledTaskManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TaskScheduler
{
    /// <summary>
    /// Manage scheduled tasks.
    /// </summary>
    public class ScheduledTaskManager
    {
        /// <summary>
        /// Schedule task to employees
        /// </summary>
        /// <param name="employeeAndTaskManager">Employee and task manager instance.</param>
        /// <param name="list">List of scheduled tasks</param>
        /// <param name="scheduledTasks">Scheduled task.</param>
        public void Schedule(EmployeeAndTaskManager employeeAndTaskManager, List<ScheduledTasks> list, ScheduledTasks scheduledTasks)
        {
            employeeAndTaskManager.Tasks = this.SortListOfTasksByPriority(employeeAndTaskManager.Tasks);
            foreach (var item in employeeAndTaskManager.Tasks)
            {
                Console.WriteLine(item.Deadline);
            }

            foreach (Task task in employeeAndTaskManager.Tasks.Where(x => x.RequiredHours > 0))
            {
                foreach (var employee in employeeAndTaskManager.Employees.Where(x => x.WorkingHours > 0))
                {
                    if (!(task.Skills == employee.Skill))
                    {
                        continue;
                    }

                    scheduledTasks.TaskID = task.Id;
                    scheduledTasks.EmployeeIDs.Add(employee.Id);
                    if (task.RequiredHours > employee.WorkingHours)
                    {
                        employee.Availability = false;
                        task.RequiredHours -= employee.WorkingHours;
                        employee.WorkingHours = 0;
                    }
                    else
                    {
                        employee.WorkingHours -= task.RequiredHours;
                    }
                }

                list.Add(scheduledTasks);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item.TaskID);
                foreach (var employee in item.EmployeeIDs)
                {
                    Console.WriteLine(employee);
                }
            }
        }

        /// <summary>
        /// Sort list of tasks based on the deadline.
        /// </summary>
        /// <param name="tasks">Unsorted list of tasks</param>
        /// <returns>Sorted list of tasks</returns>
        public List<Task> SortListOfTasksByPriority(List<Task> tasks)
        {
            for (int iteratorOne = 0; iteratorOne < tasks.Count; iteratorOne++)
            {
                for (int iteratorTwo = iteratorOne + 1; iteratorTwo < tasks.Count; iteratorTwo++)
                {
                    if (tasks[iteratorOne].Deadline.CompareTo(tasks[iteratorTwo].Deadline) < 0 || tasks[iteratorOne].Deadline.CompareTo(tasks[iteratorTwo].Deadline) == 0)
                    {
                        continue;
                    }

                    (tasks[iteratorOne], tasks[iteratorTwo]) = (tasks[iteratorTwo], tasks[iteratorOne]);
                }
            }

            return tasks;
        }
    }
}
