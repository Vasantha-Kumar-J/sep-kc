"""Employee Mangament"""

from file_operations import write_json, read_json


def add_employees():
    """Add new to employees to database"""
    emp_id = input("Enter employee ID: ")
    emp_name = input("Enter employee Name: ")
    emp_working_hours = input("Enter employee available working hours: ")
    emp_skills = input("Enter employee skills: ")
    emp_availability_start = input("Enter employee available start date: ")
    emp_availability_end = input("Enter employee available end date: ")

    new_emp = {
        "Name": emp_name,
        "Working Hours": emp_working_hours,
        "Skills": emp_skills,
        "Availability": {
            "Start": emp_availability_start,
            "End": emp_availability_end
        },
        "task": ""
    }

    write_json("D:\\performance_test\\src\\employee.json", emp_id, new_emp)


def export_emp() -> dict:
    """Returns the list of tasks as Dict."""
    return read_json("D:\\performance_test\\src\\employee.json")
