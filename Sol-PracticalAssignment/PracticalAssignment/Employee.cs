namespace PracticalAssignment
{
    public class Employee : IComparable<Employee>
    {
        public Employee() :
            this(string.Empty, 8, new List<string>(), new Dictionary<Work, double>(), Availability.Avaliable)
        {
        }

        public Employee(string name) : 
            this(name, 8, new List<string>(), new Dictionary<Work, double>(), Availability.Avaliable)
        {
        }

        public Employee(string name, List<string> skills) :
            this(name, 8, skills, new Dictionary<Work, double>(), Availability.Avaliable)
        {
        }

        public Employee(string name, double workingHours, List<string> skills, Dictionary<Work, double> tasks
            , Availability isAvaLiable)
        {
            this.ID = EmployeeID++;
            this.Name = name;
            this.WorkingHours = workingHours;
            this.Skills = skills;
            this.Tasks = tasks;
            this.IsAvaLiable = isAvaLiable;
        }

        public static int EmployeeID = 0;
        public int ID {  get; private set; }
        public string Name { get; set; }

        public double WorkingHours { get; set; }

        public List<string> Skills { get; set; }

        public Dictionary<Work, double> Tasks { get; set; }

        public Availability IsAvaLiable { get; set; }

        public int CompareTo(Employee? other)
        {
            return this.ID == other?.ID ? 0 : -1;
        }
    }
}