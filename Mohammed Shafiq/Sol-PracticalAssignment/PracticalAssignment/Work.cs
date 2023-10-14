namespace PracticalAssignment
{
    public class Work
    {
        public static int workId { get; set; } = 0;
        public Work() :
            this(string.Empty, 0, new List<string>(), DateOnly.MaxValue, new Dictionary<Employee, double>(), false)
        {
        }

        public Work(string description, double requiredHours, List<string> requiredSkills, DateOnly deadLine) :
            this(description, requiredHours, requiredSkills, deadLine, new Dictionary<Employee, Double>(), false)
        {

        }

        public Work (string description, double requiredHours, List<string> requiredSkills, DateOnly deadLine, Dictionary<Employee, Double> employees, bool isScheduled)
        {
            this.ID = workId++;
            this.Description = description;
            this.RequiredHours = requiredHours;
            this.RequiredSkills = requiredSkills;
            this.DeadLine = deadLine;
            this.Employees = employees;
            this.IsScheduled = isScheduled;
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public Double RequiredHours {  get; set; }

        public List<string> RequiredSkills { get; set; }

        public DateOnly DeadLine { get; set; }

        public Dictionary<Employee, Double> Employees { get; set; }

        public bool IsScheduled { get; set; }
    }
}