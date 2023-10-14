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
    while True:
        print("Select your Choice")
        choice = input(
            "1.Export Tasks\n2.Import Tasks"
            "\n3.Export Employees\n4.Import Employees"
            "\n5.Schedule Tasks\6.Get Report\7.quit"
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
            print("Scheduling not Suppported for now.")
        elif choice == 6:
            print("Report Generation not suppported")
        elif choice == 7:
            print("Good Bye")
            break
        else:
            print("invalid Choice")
