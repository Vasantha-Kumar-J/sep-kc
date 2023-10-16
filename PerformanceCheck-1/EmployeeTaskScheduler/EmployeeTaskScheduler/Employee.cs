// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EmployeeTaskScheduler
{
    public class Employee
    {
        public string Name { get; set; }

        public int WorkingHours { get; set; }

        public string Skill { get; set; }

        public int AvailableDays { get; set; }

        /// <summary>
        /// Get and Set the property of Employee class from the user.
        /// </summary>
        public void SetEmployeeDetails()
        {
            Console.Write("Enter Employee Name : ");
            Name = Console.ReadLine();
            WorkingHours = GetOrValidateInputs.GetValidInputIntegerFromGivenCondition("Enter Working Hours (in numbers) : ",
                input => input > 0 && input < 24,
                "Working hours should be > 0 and < 24 hours");

            Console.Write("Enter Employee Skill : ");
            Skill = Console.ReadLine();

            AvailableDays = GetOrValidateInputs.GetValidInputIntegerFromGivenCondition("Enter Available Days (in numbers) : ",
                input => input > 0 && input < 365,
                "Available days should be > 0 and < 365 days");
        }
    }
}