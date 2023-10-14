// <copyright file="Task.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectManager
{
    public class Task
    {
        public Task(string taskName, string taskDescription, int taskHours, DateOnly taskDeadline, string skills)
        {
            this.TaskName = taskName;
            this.TaskDescription = taskDescription;
            this.TaskHours = taskHours;
            this.TaskDeadline = taskDeadline;
            this.TaskSkill = skills;
            this.Scheduled = false;
        }

        public string TaskName { get; set; }

        public string? TaskDescription { get; set; }

        public int TaskHours { get; set; }

        public DateOnly TaskDeadline { get; set; }

        public string TaskSkill { get; set; }

        public bool Scheduled { get; set; }
    }
}