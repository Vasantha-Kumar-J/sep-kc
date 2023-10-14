"""Task Manager."""


import logging
from evaluation.file_operations.file_operations import FileOperation
from evaluation.models.task import Task


class TaskManager:
    """Manage Tasks."""
    def __init__(self):
        self.file_operator = FileOperation("task.csv")

    def export_tasks(self, file_path: str) -> str:
        """Export tasks to file.

        Parameters
        ----------
        file_path : str
            The file to which data to be exported
        """
        try:
            self.file_operator.export_data(file_path)
        except Exception as exception:
            logging.info(f"Unable to export tasks: {repr(exception)}")

    def import_tasks(self, file_path: str) -> str:
        """Import tasks to file.

        Parameters
        ----------
        file_path : str
            The file to which data to be imported
        """
        try:
            self.file_operator.import_data(file_path)
        except Exception as exception:
            logging.info(f"Unable to import tasks: {repr(exception)}")

    def add_tasks(self, tasks: list[Task]):
        """Add task to the File.

        Parameters
        ----------
        task: list[task]
            list of task objects to be added
        """
        tasks_data = []
        for task in tasks:
            task_data = task.to_csv_list()
            tasks_data.append(task_data)
        self.file_operator.add_rows(tasks_data)

    def get_tasks(self) -> list[Task]:
        """Return all the tasks.

        Returns
        ----------
        list[task]
            Returns the list of task objects
        """
        tasks_data = self.file_operator.get_rows()
        tasks = []
        for task_data in tasks_data:
            task = Task.from_csv_list(task_data)
            tasks.append(task)
        return tasks
