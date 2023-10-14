"""Starter Program."""


from evaluation.management.employee_manager import EmployeeManager
from evaluation.management.task_employee_manager import TaskEmployeeManager
from evaluation.management.task_manager import TaskManager
from evaluation.models.employee import Employee
from evaluation.models.task import Task
from evaluation.models.task_employee import TaskEmployee


def print_tasks(tasks: list[Task]):
    print("-----------------------------------------------")
    print("Tasks")
    print("-----------------------------------------------")
    print("Task Id | Description | Required Hours | Deadline | Required Skills |")
    for task in tasks:
        print(f"{task.task_id} {task.description} {task.required_hours} {task.deadline} {task.required_skills}")


def print_employees(employees: list[Employee]):
    print("-----------------------------------------------")
    print("Employees")
    print("-----------------------------------------------")
    print("|Emp id | name | workhours | skills | availablility |")

    for employee in employees:
        print(f"{employee.emp_id} {employee.name} {employee.work_hours} {employee.skills} {employee.availabilty}")


def print_task_employees(task_employees: list[TaskEmployee]):
    print("-----------------------------------------------")
    print("Task Employees")
    print("-----------------------------------------------")
    print("| Task id | Employee ids")

    for task_employee in task_employees:
        print(f"{task_employee.task_id} {task_employee.emp_ids}")


if __name__ == "__main__":
    task_manager = TaskManager()
    employee_manager = EmployeeManager()
    task_employee_manager = TaskEmployeeManager()
    tasks = task_manager.get_tasks()
    print_tasks(tasks)
    employees = employee_manager.get_employees()
    print_employees(employees)
    task_employees = task_employee_manager.get_task_employees()
    print_task_employees(task_employees)
