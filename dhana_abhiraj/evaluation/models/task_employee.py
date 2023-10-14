"""Employee Model."""


class TaskEmployee:
    """Employee model."""

    def __init__(
        self,
        task_id: int,
        emp_ids: list[int]
    ):
        """Initialize the employee with attributes.

        Parameters
        ----------
        emp_id: int
            Employee id
        """
        self.task_id = task_id
        self.emp_ids = emp_ids

    def to_csv_list(self) -> list:
        """Convert the employee attributes to csv."""
        csv_format_list = [
            self.task_id,
            self.emp_ids
        ]
        return csv_format_list

    @classmethod
    def from_csv_list(cls, csv_format_list: list):
        """Create Employee from CSV format.

        Parameters
        ----------
        csv_format_list: str
            The CSV format of the Employee

        Raises
        ------
        ValueError : Invalid Employee Format string
        """
        if len(csv_format_list) == 2:
            return cls(*csv_format_list)
        raise ValueError(f"Invalid Employee Format list: {csv_format_list}")
