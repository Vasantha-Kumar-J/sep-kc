namespace SRAF
{
    internal class Scheduler 
    {
        Dictionary<Task,HashSet<Employee>> scheduledTasks = new Dictionary<Task,HashSet<Employee>>();
        public void Schedule(List<Task>taskList,HashSet<Employee>employeeList)
        {
            foreach(var task in taskList)
            {

                List<Employee> validEmployees = FilterEmployeesByRequiredSkills(task, employeeList);

                List<Employee> addedEmployee = new();
                var currentTotalHours = 0;
                foreach(var employee in validEmployees)
                {
                    currentTotalHours += employee.workingHours;
                }

            }
        }

        private List<Employee> FilterEmployeesByRequiredSkills(Task task, HashSet<Employee> employeeList)
        {
            var result = (from employee in employeeList
                         where employee.availability.Equals(1)
                         from skill in employee.skills
                         from requiredSkill in task.skills
                         where skill.Equals(requiredSkill)
                         select employee).ToList();
            result.Sort((x, y) => x.skills.Count - y.skills.Count);
            return result;
        }


    }
}
