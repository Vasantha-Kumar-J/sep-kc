"""Schedules the task."""


from evaluation.management.task_employee_manager import TaskEmployeeManager


class Scheduler:
    """Schedules the tasks."""

    def __init__(self):
        """Initialize the Scheduler."""
        self.task_employee_manager = TaskEmployeeManager()

    def schedule(self):
        tasks = self.task_employee_manager.get_unassigned_tasks()

        
