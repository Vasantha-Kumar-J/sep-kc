
namespace EmployeeAndTaskScheduler
{
    /// <summary>
    /// Task Class
    /// </summary>
    internal class Task
    {
        /// <summary>
        /// Initialize the Task Object
        /// </summary>
        /// <param name="description">Task Description</param>
        /// <param name="requiredHours">Hours to complete the task</param>
        /// <param name="deadLine">DeadLinen for the Task to Complete</param>
        /// <param name="necessarySkills">Skills Required for the Task</param>
        public Task(string description, string requiredHours, string deadLine, string necessarySkills) 
        {
            this.description = description;
            if (int.TryParse(requiredHours, out int value))
            {
                this.requiredHours = value;
            }
            else
            {
                Console.WriteLine($"Invalid required Hours in Task {description}");
            }
            string trimmedString = necessarySkills.Trim();
            string[] skillList = trimmedString.Substring(1, trimmedString.Length - 2).Split("/");
            this.DeadLine = DateTime.Parse(deadLine);
            this.necessarySkills = new List<string>(skillList);
        }
        /// <summary>
        /// Description about the task
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Required Hours for the task to complete
        /// </summary>
        public int requiredHours { get; set; }
        /// <summary>
        /// DeadLine of the Task to Complete
        /// </summary>
        public DateTime DeadLine { get; set; }
        /// <summary>
        /// List of necessary skills
        /// </summary>
        public List<string> necessarySkills { get; set; }
        /// <summary>
        /// Overrides the toString method in object class
        /// </summary>
        /// <returns>result to be printed</returns>
        public override string ToString()
        {
            return $"Task Description: {this.description}, Required Hours: {this.requiredHours}, DeadLine: {DeadLine}, Necessary Skills: {string.Join(",", this.necessarySkills.ToArray())}";
        }
    }
}
