"""Task Model."""


from datetime import datetime


class Task:
    """Task model."""

    def __init__(
        self,
        task_id: int,
        description: str,
        required_hours: int,
        deadline: datetime,
        required_skills: list[str],

    ) -> None:
        """Initialize the Task with attributes.

        Parameters
        ----------
        task_id: int
            Id if the task
        description: str
            Description of the task
        required_hours: int
            Time required to complete the task
        deadline: datetime
            Deadline to complete the task
        required_skills: list[str]
            The list of skills to complete the task
        """
        self.task_id = task_id
        self.description = description
        self.required_hours = required_hours
        self.deadline = datetime.fromisoformat(deadline)
        self.required_skills = required_skills

    def to_csv_list(self) -> list:
        """Convert the task attributes to csv."""
        csv_format_list = [
            self.task_id,
            self.description,
            self.required_hours,
            self.deadline,
            self.required_skills
        ]
        return csv_format_list

    @classmethod
    def from_csv_list(cls, csv_format_list):
        """Create Task from CSV format.

        Parameters
        ----------
        csv_format_list: str
            The CSV format of the Task

        Raises
        ------
        ValueError : Invalid Task Format string
        """
        if len(csv_format_list) == 5:
            return cls(*csv_format_list)
        raise ValueError(f"Invalid Task Format list: {csv_format_list}")
