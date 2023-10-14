using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class ImportTaskData
    {
        public int globalId = 5;
       public ImportTaskData()
        {
            this.TaskId = globalId;
            globalId++;

        }

        /// <summary>
        /// Gets or sets the TaskId
        /// </summary>
        /// <value>TaskId</value>
        public int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the Attributes
        /// </summary>
        /// <value>Attributes</value>
        public string Attributes { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        /// <value>Description</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the RequiredHoursOfWork
        /// </summary>
        /// <value>RequiredHoursOfWork</value>
        public int RequiredHoursOfWork { get; set; }

        /// <summary>
        /// Gets or sets the Deadline
        /// </summary>
        /// <value>Deadline</value>
        public string Deadline { get; set; }

        /// <summary>
        /// Gets or sets the RequiredSkills
        /// </summary>
        /// <value>RequiredSkills</value>
        public string RequiredSkills { get; set; }

    }
}
