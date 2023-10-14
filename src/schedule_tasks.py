"""Schedule Tasks."""

from datetime import datetime
from file_operations import read_json, dump_json

emp_data = read_json("D:\\performance_test\\src\\employee.json")
tasks = read_json("D:\\performance_test\\src\\tasks.json")


def filter_employee_skills() -> dict:
    """To filter employees based on skill.

    Returns:
    dict: Return the dict with skill as keys and list of emp id.
    """
    skill = {
        "Python": [],
        "C#": [],
        "LV": [],
        "WT": []
    }
    for emp in emp_data:
        skill[emp_data[emp]["Skills"]].append(emp)
    return skill


def filter_employee_availabilty(emp_id):
    """To find the total employee availabilty time.

    Args:
        emp_id (str): employee id to find the availability

    Returns:
        int: returns the total availability time of employee
    """
    start_date = datetime.strptime(
        emp_data[emp_id]["Availability"]["Start"],'%d/%m/%y'
        )
    end_date = datetime.strptime(
        emp_data[emp_id]["Availability"]["End"], '%d/%m/%y'
        )
    return int(emp_data[emp_id]["Working Hours"]) * (end_date-start_date).days


def assign_task():
    """Assign the Tasks to the employees."""
    for task in tasks:
        if tasks[task]["Status"] == "unscheculded":
            skill = filter_employee_skills()
            for emp_id in skill[tasks[task]["Skills"]]:
                if filter_employee_availabilty(emp_id) > tasks[task]["Required Hours"]:
                    # Assign task to employee if there is availabilty
                    tasks[task]["Status"] = "scheculded"
                    tasks[task]["assign"] = emp_id
                    emp_data[emp_id]["task"] = task

    dump_json("D:\\performance_test\\src\\employee.json", emp_data)
    dump_json("D:\\performance_test\\src\\tasks.json", tasks)
