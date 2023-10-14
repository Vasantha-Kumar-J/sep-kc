"""TaskEmployeeManager Employee Manager."""


import logging
from evaluation.file_operations.file_operations import FileOperation
from evaluation.management.employee_manager import EmployeeManager
from evaluation.management.task_manager import TaskManager
from evaluation.models.task import Task
from evaluation.models.task_employee import TaskEmployee


class TaskEmployeeManager:
    """Task Employee Manager."""
    def __init__(self):
        """Initialize the Task Employee Manager."""
        self.file_operator = FileOperation("task_employees.csv")
        self.task_manager = TaskManager()
        self.employee_manager = EmployeeManager()

    def export_task_employees(self, file_path: str) -> str:
        """Export Task Employee to file.

        Parameters
        ----------
        file_path : str
            The file to which data to be exported
        """
        try:
            self.file_operator.export_data(file_path)
        except Exception as exception:
            logging.info(f"Unable to export TaskEmployees: {repr(exception)}")

    def import_task_employees(self, file_path: str) -> str:
        """Import task employees to file.

        Parameters
        ----------
        file_path : str
            The file to which data to be imported
        """
        try:
            self.file_operator.import_data(file_path)
        except Exception as exception:
            logging.info(f"Unable to import TaskEmployees: {repr(exception)}")

    def add_task_employees(self, task_employees: list[TaskEmployee]):
        """Add task_employees to the File.

        Parameters
        ----------
        task_employees: list[TaskEmployee]
            list of task_employees objects to be added
        """
        task_employees_data = []
        for task_employee in task_employees:
            task_employee_data = task_employee.to_csv_list()
            task_employees_data.append(task_employee_data)
        self.file_operator.add_rows(task_employees_data)

    def get_task_employees(self) -> list[TaskEmployee]:
        """Return all the tasks.

        Returns
        ----------
        list[TaskEmployee]
            Returns the list of TaskEmployee objects
        """
        task_employees_data = self.file_operator.get_rows()
        task_employees = []
        for task_employee_data in task_employees_data:
            task_employee = TaskEmployee.from_csv_list(task_employee_data)
            task_employees.append(task_employee)
        return task_employees

    def get_unassigned_tasks(self) -> list[Task]:
        """Return all the unassigned Tasks."""

        unassigned_tasks = []
        tasks = self.task_manager.get_tasks()
        task_employees_data = self.file_operator.get_rows()

        assigned_task_ids = set()
        for task_employee in task_employees_data:
            task_id = task_employee[0]
            assigned_task_ids.add(task_id)

        for task_data in tasks:
            task_id = task_data[0]
            if task_id not in assigned_task_ids:
                task = Task.from_csv_list(task_data)
                unassigned_tasks.append(task)

        return unassigned_tasks

    def get_all_available_employees_with_available_duration(self):
        employees = self.employee_manager.get_employees()
        tasks = self.task_manager.get_tasks()
        task_employees = self.get_task_employees()

        emp_id_object_dict = {}
        for employee in employees:
            emp_id_object_dict[employee.emp_id] = {"employee": employee, "engaged_duration": 0}

        task_id_object_dict = {}
        for task in tasks:
            task_id_object_dict[task.task_id] = task

        available_time_of_employees = {}
        for task_employee in task_employees:
            for emp_id in task_employee.emp_ids:
                pass
        raise Exception("Not Supported.")
            