using System.Text.Json.Serialization;

namespace EmployeeManagerAndTaskScheduler
{
    public enum Skills : int
    {
        Design = 1 ,
        Coding,
        Testing,
        Other
    }
    public class Employee 
    {
        public Employee(int id,
            string name,
            List<string>skills,
            int workingHours,
            List<(Task task,double assignedHour)> assignedTasks,
            double availability,
            bool isAvailable = true)
        {
            Id = id;
            Name = name;
            Skills = skills;
            WorkingHours = workingHours;
            AssignedTasks = assignedTasks;
            RemainingHoursPerDay = availability;
            IsAvailable = isAvailable;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkingHours { get; set; }

        public List<string> Skills { get; set; }

        [JsonIgnore]
        public List<(Task task, double assignedHour)> AssignedTasks { get; init; }

        public double RemainingHoursPerDay;

        public double SetAvailability(double hoursPerDay)
        {
            if(RemainingHoursPerDay >= hoursPerDay)
            {
                RemainingHoursPerDay -= hoursPerDay;
                IsAvailable = RemainingHoursPerDay > 0.0;
                return hoursPerDay;
            }
            else
            {
                var allocatedHours = RemainingHoursPerDay;
                RemainingHoursPerDay = 0;
                IsAvailable = false;
                return allocatedHours;
            }
        }

        public double GetAvailability()
        {
            return RemainingHoursPerDay;
        }

        public bool IsAvailable {  get; set; }

    }
    
    
}
