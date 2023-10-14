from file_operations import read_csv_as_dict
from datetime import date
from file_operations import logging_operations


SCHEDULED_TASKS = []
UNSCHEDULED_TASKS = []


class Task:
    def __init__(
        self, name, description, required_hours, deadline, necessary_skills
    ):
        self.name = name
        self.description = description
        self.required_hours = int(required_hours)
        self.deadline = deadline
        self.necessary_skills = necessary_skills


def add_task(name, description, required_hours, deadline, necessary_skills):
    new_task = Task(
        name, description, required_hours, deadline, necessary_skills
    )
    UNSCHEDULED_TASKS.append(new_task)
    logging_operations("Added 1 new task")


def import_tasks(file_path):
    tasks = read_csv_as_dict(file_path)
    for task in tasks:
        add_task(
            task["name"],
            task["description"],
            task["required_hours"],
            date.fromisoformat(task["deadline"]),
            task["necessary_skills"].split(" "),
        )
    logging_operations(f"Added {len(tasks)} tasks from a file")


def export_list_of_tasks():
    return {
        "scheduled tasks": SCHEDULED_TASKS,
        "unscheduled_tasks": UNSCHEDULED_TASKS,
    }


if __name__ == "__main__":
    import_tasks("tasks.csv")
    print(UNSCHEDULED_TASKS[0].necessary_skills)
    print(export_list_of_tasks())
