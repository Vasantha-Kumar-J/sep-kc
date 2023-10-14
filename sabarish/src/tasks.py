"""Task adder and exporter."""


from file_operations import read_csv_as_dict
from datetime import date
from file_operations import logging_operations
from typing import Union

SCHEDULED_TASKS = []
UNSCHEDULED_TASKS = []


class Task:
    """Tasks class."""

    def __init__(
        self,
        name: str,
        description: str,
        required_hours: Union[str, int],
        deadline: datetime,
        necessary_skills: list[str],
    ) -> None:
        """Initialize the task class

        Args:
            name (str): _description_
            description (str): _description_
            required_hours (str|int): _description_
            deadline (str): _description_
            necessary_skills (str): _description_
        """
        self.name = name
        self.description = description
        self.required_hours = int(required_hours)
        self.deadline = deadline
        self.necessary_skills = necessary_skills


def add_task(
    name: str,
    description: str,
    required_hours: Union[str, int],
    deadline: datetime,
    necessary_skills: list[str],
) -> None:
    """Add a single task to tasks.

    Args:
        name (str): _description_
        description (str): _description_
        required_hours (str|int): _description_
        deadline (str): _description_
        necessary_skills (str): _description_
    """
    new_task = Task(
        name, description, required_hours, deadline, necessary_skills
    )
    UNSCHEDULED_TASKS.append(new_task)
    logging_operations("Added 1 new task")


def import_tasks(file_path: str) -> None:
    """Impoer tasks from a csv file.

    Args:
        file_path (str): file path to import data
    """
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


def export_list_of_tasks() -> dict:
    """Export scheduled and unscheduled tasks.

    Returns:
        dict: dict of scheduled and unscheduled tasks.
    """
    return {
        "scheduled tasks": SCHEDULED_TASKS,
        "unscheduled_tasks": UNSCHEDULED_TASKS,
    }
