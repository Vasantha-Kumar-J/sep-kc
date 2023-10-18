namespace EmployeeManagerAndTaskScheduler
{
    public interface IScheduler
    {
        public void Schedule(List<Task>tasks, List<Employee>employees);
        public void UnSchedule(List<Task> tasks, List<Employee> employeeList);

        public void GenerateReport(List<Employee> employees, List<Task>tasks);
    }
}
