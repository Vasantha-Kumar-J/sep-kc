from file_operations import read_csv_as_dict
from datetime import date
from file_operations import logging_operations

ALL_EMPLOYEES = []


class Employee:
    def __init__(self, name, working_hours, skills, availability):
        self.name = name
        self.working_hours = int(working_hours)
        self.skills = skills
        availability.sort()
        self.availability = availability


def add_employee(name, working_hours, skills, availability):
    new_employee = Employee(name, working_hours, skills, availability)
    ALL_EMPLOYEES.append(new_employee)
    logging_operations("Added 1 new employee")


def import_employees(file_path):
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


def export_list_of_employees():
    return ALL_EMPLOYEES


if __name__ == "__main__":
    import_employees("employee.csv")
    print(ALL_EMPLOYEES[0].skills)
