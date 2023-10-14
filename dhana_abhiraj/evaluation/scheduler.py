"""Schedules the task."""


from evaluation.exceptions import TaskSchedulerError
from evaluation.management.employee_manager import EmployeeManager
from evaluation.management.task_employee_manager import TaskEmployeeManager
from evaluation.management.task_manager import TaskManager
from evaluation.models.employee import Employee
from evaluation.models.task_employee import TaskEmployee


class TaskScheduler:
    """Schedules the tasks."""

    def __init__(self):
        """Initialize the Scheduler."""
        self.task_employee_manager = TaskEmployeeManager()
        self.task_manager = TaskManager()
        self.employee_manager = EmployeeManager()

    def get_skills_mapped_employees(
        self, employees: list[Employee]
    ) -> dict[str, list[Employee]]:
        """Get skills mapped with employees."""
        skills_mapped_employees: dict[str, list] = {}

        for employee in employees:
            if employee.availability == "yes":
                for employee_skill in employee.skills:
                    if employee_skill not in skills_mapped_employees:
                        skills_mapped_employees[employee_skill] = [employee]
                    else:
                        skills_mapped_employees[employee_skill].append(employee)
        return skills_mapped_employees

    def schedule(self):
        """Schedule the tasks to the employees."""
        tasks = self.task_manager.get_tasks()
        employees = self.employee_manager.get_employees()
        skills_mapped_employees = self.get_skills_mapped_employees(employees)
        task_employees: list[TaskEmployee] = []

        for task in tasks:
            employees_alloted = []
            for required_skill in task.required_skills:
                if (
                    required_skill not in skills_mapped_employees
                    or skills_mapped_employees[required_skill] == []
                ):
                    raise TaskSchedulerError(
                        "Required skill not matched with employees"
                        f"or more employees don't have {required_skill}"
                    )
                employee = skills_mapped_employees[required_skill].pop()
                employees_alloted.append(employee)

            emp_ids = [employee.emp_id for employee in employees_alloted]
            each_emp_time = task.required_time / len(emp_ids)
            emp_alloted_timings = [
                each_emp_time for employee in employees_alloted
                ]
            task_employee = TaskEmployee(
                task.task_id,
                emp_ids,
                emp_alloted_timings
                )

            task_employees.append(task_employee)
        self.task_employee_manager.add_task_employees(task_employees)
