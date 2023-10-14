"""Employee Model."""


from datetime import timedelta


class TaskEmployee:
    """Employee model."""

    def __init__(
        self,
        task_id: int,
        emp_ids: list[int],
        emp_alloted_timings: list[timedelta]
    ):
        """Initialize the employee with attributes.

        Parameters
        ----------
        emp_id: int
            Employee id
        """
        self.task_id = task_id
        self.emp_ids = emp_ids
        self.emp_alloted_timings = emp_alloted_timings

    def to_csv_list(self) -> list:
        """Convert the employee attributes to csv."""
        emp_alloted_timings = [
            timing.seconds for timing in self.emp_alloted_timings
        ]
        csv_format_list = [self.task_id, self.emp_ids, emp_alloted_timings]
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
        if len(csv_format_list) == 3:
            emp_ids = csv_format_list[1].strip("[]").split(", ")
            emp_alloted_timings = map(
                int,
                csv_format_list[2].strip("[]").split(", ")
            )

            csv_format_list[1] = list(map(int, emp_ids))
            csv_format_list[2] = list(map(timedelta, emp_alloted_timings))

            return cls(*csv_format_list)
        raise ValueError(f"Invalid Employee Format list: {csv_format_list}")
