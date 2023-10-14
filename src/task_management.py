"""Task Management."""

from file_operations import write_json, read_json


def add_tasks():
    task_id = input("Enter the Task ID: ")
    task_name = input("Enter the Task Name: ")
    task_desc = input("Enter the Task Description: ")
    task_req_hours = input("Enter the Required Hours: ")
    task_deadline = input("Enter the Deadline for the task: ")
    task_skills = input("Enter the Skills for the Task: ")

    new_task = {
        "Name": task_name,
        "Description": task_desc,
        "Required Hours": task_req_hours,
        "Deadline": task_deadline,
        "Skills": task_skills,
        "Status": "",
        "assign": ""
    }

    write_json("D:\\performance_test\\src\\tasks.json", task_id, new_task)


def export_task() -> dict:
    """Returns the list of tasks as Dict."""
    return read_json("D:\\performance_test\\src\\tasks.json")
