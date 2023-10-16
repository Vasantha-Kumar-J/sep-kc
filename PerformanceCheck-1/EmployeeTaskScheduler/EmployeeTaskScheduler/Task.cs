// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EmployeeTaskScheduler
{
    public class Task
    {
        public string Description { get; set; }

        public int RequiredHours { get; set; }

        public List<string> NecessarySkills { get; set; }

        public int Deadline { get; set; }

        public List<string> AssignedEmployees { get; set; }

        /// <summary>
        /// Get and Set the property of Task class from the user.
        /// </summary>
        public void SetTaskDetails()
        {
            Console.Write("Enter Task Description : ");
            Description = Console.ReadLine();
            RequiredHours = GetOrValidateInputs.GetValidInputIntegerFromGivenCondition("Enter Required Hours (in numbers) : ",
                input => input > 0,
                "Required hours should be > 0 hours");

            NecessarySkills = GetOrValidateInputs.GetSkills();

            Deadline = GetOrValidateInputs.GetValidInputIntegerFromGivenCondition("Enter number of days to complete within : ",
                input => input > 0,
                "Deadline days should be > 0 days");
        }
    }

}