using System.Text.RegularExpressions;
namespace SRAF
{
    public class TaskManager
    {

        public static void Run(string instruction,List<IManagement> managers)
        {
            Utility.PrintInColorLn(instruction,ConsoleColor.Green);
            int choice = Utility.GetInput<int>(
                "What do you want to perform ? ",
                new Regex(@"^[1-"+$"{managers.Count+1}]$"),
                $"Enter value between 1,{managers.Count() + 1}");
            while(choice != managers.Count+1)
            {
                managers.ElementAt(choice-1).Start();

                Console.Clear();

                Utility.PrintInColorLn(instruction, ConsoleColor.Green);
                choice = Utility.GetInput<int>(
                "What do you want to perform ? ",
                new Regex(@"^[1-" + $"{managers.Count + 1}]$"),
                $"Enter value between 1,{managers.Count() + 1}");
            }
            Utility.PrintInColorLn("Exiting...",ConsoleColor.Green);
        }
    }
}
