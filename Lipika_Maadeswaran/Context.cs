using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    /// <summary>
    /// Context would initialize the taskData and employeeData
    /// </summary>
    public class Context
    {
        public Context()
        {
            this.TaskData = new List<ImportTaskData>();
            this.EmployeeData = new List<ImportEmployeeData>();
        }

        /// <summary>
        /// Gets or sets the TaskData
        /// </summary>
        /// <value>TaskData</value>
        public List<ImportTaskData> TaskData { get; set; }

        /// <summary>
        /// Gets or sets the EmployeeData
        /// </summary>
        /// <value>EmployeeData</value>
        public List<ImportEmployeeData> EmployeeData { get; set; }

    }
}
