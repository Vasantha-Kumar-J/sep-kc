// <copyright file="TasksDataManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;

namespace ProjectManager
{
    public class TasksDataManager
    {
        public static List<Task> TasksList = new List<Task>();
        private static StreamWriter taskWriter;

        public static void SetupTasks()
        {
            Task taskOne = new ("DesignLayout", "Design a layout for dashboard", 20, new DateOnly(2023, 10, 21), "Designing");
            Task taskTwo = new ("CODE", "Implement dynamic assebemly builder", 50, new DateOnly(2023, 10, 20), "Coding");
            Task taskThree = new ("XUnit", "write UNIT tests", 5, new DateOnly(2023, 10, 19), "Testing");
            TasksList.Add(taskOne);
            TasksList.Add(taskTwo);
            TasksList.Add(taskThree);
        }

        public static void CreateTasksDetailsFile(string filePath)
        {
            taskWriter = new StreamWriter(filePath);
            string taskInfo = string.Empty;
            foreach (Task task in TasksList)
            {
                taskInfo += "\nNAME : " + task.TaskName + "\nDESCRIPTION : " + task.TaskDescription + "\nHOURS : " + task.TaskHours.ToString() + "\nDEADLINE : " + task.TaskDeadline.ToString() + "\nSKILL : " + task.TaskSkill + "\n\n";
            }

            taskWriter.Write(taskInfo);
            taskWriter.Close();
        }

        public static void ImportTasksFromFile(string filePath)
        {
            try
            {
                string[] fileContent = File.ReadAllLines(filePath);
                foreach (string line in fileContent)
                {
                    string[] taskInfo = line.Split(' ');
                    int.TryParse(taskInfo[2], out var hours);
                    DateOnly.TryParse(taskInfo[3], out var deadline);
                    Task task = new (taskInfo[0], taskInfo[1], hours, deadline, taskInfo[4]);
                    TasksList.Add(task);
                }
            }
            catch
            {
                throw;
            }
        }

        public static void AddNewTask(string taskName, string taskDescription, int taskHours, DateOnly taskDeadline, string skills)
        {
            Task newTask = new (taskName, taskDescription, taskHours, taskDeadline, skills);
            TasksList.Add(newTask);
            Utility.DisplayMessageInSpecificColor("Task added successfully", "Green");
        }
    }
}