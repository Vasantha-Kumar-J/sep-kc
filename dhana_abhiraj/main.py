"""Starter Program."""


import logging
from evaluation.exceptions import TaskSchedulerError
from evaluation.management.employee_manager import EmployeeManager
from evaluation.management.task_employee_manager import TaskEmployeeManager
from evaluation.management.task_manager import TaskManager
from evaluation.models.employee import Employee
from evaluation.models.task import Task
from evaluation.models.task_employee import TaskEmployee
from evaluation.scheduler import TaskScheduler


def print_tasks(tasks: list[Task]):
    """Print the Tasks."""
    print("-----------------------------------------------")
    print("Tasks")
    print("-----------------------------------------------")
    print("Task Id | Description | Required Hours "
          "| Deadline | Required Skills |")
    for task in tasks:
        print(
            f"{task.task_id} {task.description} {task.required_time}"
            f"{task.deadline} {task.required_skills}"
        )


def print_employees(employees: list[Employee]):
    """Print the employees."""
    print("-----------------------------------------------")
    print("Employees")
    print("-----------------------------------------------")
    print("|Emp id | name | workhours | skills | availablility |")

    for employee in employees:
        print(
            f"{employee.emp_id} {employee.name} {employee.work_hours}"
            f"{employee.skills} {employee.availability}"
        )


def print_task_employees(task_employees: list[TaskEmployee]):
    """Print the Tasks assigned to employees."""
    print("-----------------------------------------------")
    print("Task Employees")
    print("-----------------------------------------------")
    print("| Task id | Employee ids | Duration |")

    for task_employee in task_employees:
        print(
            f"{task_employee.task_id} {task_employee.emp_ids}"
            f"{task_employee.emp_alloted_timings}"
        )


if __name__ == "__main__":
    task_manager = TaskManager()
    employee_manager = EmployeeManager()
    task_employee_manager = TaskEmployeeManager()
    tasks = task_manager.get_tasks()
    print_tasks(tasks)
    employees = employee_manager.get_employees()
    print_employees(employees)
    while True:
        print("Select your Choice")
        choice = input(
            "\n1.Export Tasks\n2.Import Tasks"
            "\n3.Export Employees\n4.Import Employees"
            "\n5.Schedule Tasks\n6.Get Report\n7.quit\n"
            "Enter your Choice : "
        )

        choice = int(choice)
        if choice == 1:
            file_path = input("Enter file path to export tasks: ")
            task_manager.export_tasks(file_path)
        elif choice == 2:
            file_path = input("Enter the File to import tasks: ")
            task_manager.import_tasks(file_path)
        elif choice == 3:
            file_path = input("Enter file path to export employees: ")
            employee_manager.export_employees(file_path)
        elif choice == 4:
            file_path = input("Enter the File to import employees: ")
            employee_manager.import_employees(file_path)
        elif choice == 5:
            task_scheduler = TaskScheduler()
            try:
                task_scheduler.schedule()
            except TaskSchedulerError as task_scheduler_exception:
                print(task_scheduler_exception)
                logging.info(task_scheduler_exception)
            else:
                print("Task Scheduled")
        elif choice == 6:
            task_employees = task_employee_manager.get_task_employees()
            print_task_employees(task_employees)
        elif choice == 7:
            print("Good Bye")
            break
        else:
            print("invalid Choice")
