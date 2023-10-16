// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EmployeeTaskScheduler
{
    using System.Diagnostics.Metrics;
    using System.Threading.Tasks;
    using Utility;

    /// <summary>
    /// Main class <see cref="Program"/>.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        public static void Main()
        {
            string userOption;
            bool userFlagToExit = true;
            Utility.DisplayImportantMessage("Welcome to Employee Task Scheduler");

            while (userFlagToExit)
            {
                Console.Write("Select your option : \n1 - Employee Management\n2 - Task Management\n3 - Scheduling Algorithm\n4 - Exit\n Enter available option : ");
                userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        EmployeeFunctions.OperationInEmployeeManagement(); break;
                    case "2":
                        TaskFunctions.OperationInTaskManagement(); break;
                    case "3":
                        userFlagToExit = false; break;
                    default:
                        Utility.DisplayErrorMessage("Kindly enter a valid given options"); continue;
                }

                Console.Clear();
                Console.WriteLine("\x1b[3J");
            }

            Utility.DisplayImportantMessage(" Thank you");
        }
    }
}