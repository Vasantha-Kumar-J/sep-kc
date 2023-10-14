"""Task Model."""


from datetime import datetime, timedelta


class Task:
    """Task model."""

    def __init__(
        self,
        task_id: int,
        description: str,
        required_time: timedelta,
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
        required_time: timedelta
            Time required to complete the task
        deadline: datetime
            Deadline to complete the task
        required_skills: list[str]
            The list of skills to complete the task
        """
        self.task_id = task_id
        self.description = description
        self.required_time = required_time
        self.deadline = deadline
        self.required_skills = required_skills

    def to_csv_list(self) -> list:
        """Convert the task attributes to csv."""
        csv_format_list = [
            self.task_id,
            self.description,
            self.required_time.seconds,
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
            task_id = int(csv_format_list[0])
            deadline = datetime.fromisoformat(csv_format_list[3])
            required_skills = csv_format_list[4].strip("'[]").split("', '")
            required_time = timedelta(seconds=int(csv_format_list[2]))

            csv_format_list[0] = task_id
            csv_format_list[2] = required_time
            csv_format_list[3] = deadline
            csv_format_list[4] = required_skills
            return cls(*csv_format_list)
        raise ValueError(f"Invalid Task Format list: {csv_format_list}")
