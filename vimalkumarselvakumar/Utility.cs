using System.Drawing;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace SRAF
{
    public static class Utility
    {
        public static T? GetInput<T>(string instruction,Regex regex, string errorMessage="Invalid input")
            where T : notnull
        {

            PrintInColorLn(instruction);
            string input = Console.ReadLine()!;
            int invalidInputCount = 0;
            T? result = default;
            while(invalidInputCount<3 &&( string.IsNullOrEmpty(input) || ! regex.IsMatch(input)))
            {
                PrintInColorLn(errorMessage,ConsoleColor.Red);
                invalidInputCount++;
                input = Console.ReadLine()!;
            }
            if(invalidInputCount>=3)
            {
                PrintInColorLn("Multiple Invalid input has been entered ;) Revoking the operation");
            }
            try
            {
                result = (T)Convert.ChangeType(input, typeof(T));
            }
            catch (Exception ex)
            {

            }
            return result;

        }

        public static void PrintInColor(string input, ConsoleColor consoleColor = ConsoleColor.White)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintInColorLn(string input, ConsoleColor consoleColor = ConsoleColor.White)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static HashSet<TClass>? Import<TClass>(string path)
        {
            HashSet<TClass>? contents = default;
            try
            {
                 string fileContents = StreamFileReader.Read(path);
                 contents = (HashSet<TClass>)JsonSerializer.Deserialize(fileContents, typeof(HashSet<TClass>)) !;
            }
            catch
            {

            }
            return contents;
            
        }

        public static string Export<TClass>(HashSet<TClass> list, string path ="employee.json")
        {
            
            string contents = JsonSerializer.Serialize(list,
                typeof(HashSet<TClass>),
                new JsonSerializerOptions()
                {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
                });
            File.WriteAllText(path,contents);
           
            return path;

        }
        public static void PrintSkills()
        {
            PrintInColorLn("Required Skills");

            PrintInColorLn(StringFromSkills(Skills.Design), ConsoleColor.Yellow);
            PrintInColorLn(StringFromSkills(Skills.Coding), ConsoleColor.Yellow);
            PrintInColorLn(StringFromSkills(Skills.Testing), ConsoleColor.Yellow);
            PrintInColorLn(StringFromSkills(Skills.Other), ConsoleColor.Yellow);
        }
        public static string StringFromSkills(Skills c)
        {
            switch (c)
            {
                case Skills.Design:
                    return $"{(int)c})Design ";
                case Skills.Coding:
                    return $"{(int)c})Coding";
                case Skills.Testing:
                    return $"{(int)c})Testing";
                case Skills.Other:
                    return $"{(int)c})Other";
                default:
                    return "Invalid Skill";
            }
        }
        

    }
}
