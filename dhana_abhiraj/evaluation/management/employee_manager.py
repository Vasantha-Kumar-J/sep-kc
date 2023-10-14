"""Employee Management."""

import logging

from evaluation.models.employee import Employee
from evaluation.file_operations.file_operations import FileOperation


class EmployeeManager:
    """Manage Employees."""
    def __init__(self):
        self.file_operator = FileOperation("employee.csv")

    def export_employees(self, file_path: str) -> str:
        """Export employees to file.

        Parameters
        ----------
        file_path : str
            The file to which data to be exported
        """
        try:
            self.file_operator.export_data(file_path)
        except Exception as exception:
            logging.info(f"Unable to export Employees: {repr(exception)}")

    def import_employees(self, file_path: str) -> str:
        """Import employees to file.

        Parameters
        ----------
        file_path : str
            The file to which data to be imported
        """
        try:
            self.file_operator.import_data(file_path)
        except Exception as exception:
            logging.info(f"Unable to import Employees: {repr(exception)}")

    def add_employees(self, employees: list[Employee]):
        """Add Employee to the File.

        Parameters
        ----------
        employee: list[Employee]
            list of Employee objects to be added
        """
        employees_data = []
        for employee in employees:
            employee_data = employee.to_csv_list()
            employees_data.append(employee_data)
        self.file_operator.add_rows(employees_data)

    def get_employees(self) -> list[Employee]:
        """Return all the employees.

        Returns
        ----------
        list[Employee]
            Returns the list of Employee objects
        """
        employees_data = self.file_operator.get_rows()
        employees = []
        for employee_data in employees_data:
            employee = Employee.from_csv_list(employee_data)
            employees.append(employee)
        return employees
