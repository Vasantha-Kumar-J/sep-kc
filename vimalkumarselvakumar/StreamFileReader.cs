using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerAndTaskScheduler
{
    public class StreamFileReader
    {
        public static string Read(string path)
        {
            string contents = string.Empty;
            try
            {
                contents = File.ReadAllText(path);
            }
            catch(Exception ex)
            {
                Utility.PrintInColorLn(ex.Message);
            }
            return contents;
        }

    }
}
