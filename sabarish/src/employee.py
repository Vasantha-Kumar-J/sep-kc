"""Employee module."""


from file_operations import read_csv_as_dict
from datetime import date
from file_operations import logging_operations
from typing import Union

ALL_EMPLOYEES = []


class Employee:
    """Employee class."""

    def __init__(
        self,
        name: str,
        working_hours: Union[str, int],
        skills: list,
        availability: list[datetime],
    ) -> None:
        """Initialize the Employee class.

        Args:
            name (str): name of the employee
            working_hours (Union[str, int]): employee's working hours
            skills (list): skills of the employee
            availability (list[datetime]): available dates of the employee.
        """
        self.name = name
        self.working_hours = int(working_hours)
        self.skills = skills
        availability.sort()
        self.availability = availability


def add_employee(
    name: str,
    working_hours: Union[str, int],
    skills: list,
    availability: list[datetime],
):
    """Add a single employee to employees.

    Args:
        name (str): name of the employee
        working_hours (Union[str, int]): employee's working hours
        skills (list): skills of the employee
        availability (list[datetime]): available dates of the employee.
    """
    new_employee = Employee(name, working_hours, skills, availability)
    ALL_EMPLOYEES.append(new_employee)
    logging_operations("Added 1 new employee")


def import_employees(file_path: str) -> None:
    """Impoer Employees from a csv file.

    Args:
        file_path (str): file path to import data
    """
    employees = read_csv_as_dict(file_path)
    for employee in employees:
        availability = list(
            map(date.fromisoformat, employee["availability"].split(" "))
        )
        add_employee(
            employee["name"],
            employee["working_hours"],
            employee["skills"].split(" "),
            availability,
        )
    logging_operations(f"Added {len(employees)} employees from a file")


def export_list_of_employees() -> list:
    """Export list of all employees.

    Returns:
        list: list of all employees
    """
    return ALL_EMPLOYEES


if __name__ == "__main__":
    import_employees("employee.csv")
    print(ALL_EMPLOYEES[0].skills)
