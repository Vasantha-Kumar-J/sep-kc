"""Exceptions in Custom Scheduler."""


class TaskSchedulerError(Exception):
    """Task Scheduler."""
    def __init__(self, message="Unable to Schedule Tasks"):
        """Initialize the Task SchedulerError."""
        self.message = message
        super().__init__(message)

    def __str__(self):
        return f"TaskSchedulerError: {self.message}"
