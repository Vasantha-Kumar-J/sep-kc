"""Employee Model."""


class Employee:
    """Employee model."""

    def __init__(
        self,
        emp_id: int,
        name: str,
        work_hours: int,
        skills: list[str],
        availabilty: bool,
    ):
        """Initialize the employee with attributes.

        Parameters
        ----------
        emp_id: int
            Employee id
        name: str
            Name of the Employee
        work_hours: int
            The Working hours of an employee
        skills: list[str]
            The list of skills of the employee
        availabilty: bool
            The Availablity of the Employee
        """
        self.emp_id = emp_id
        self.name = name
        self.work_hours = work_hours
        self.skills = skills
        self.availabilty = availabilty

    def to_csv_list(self) -> list:
        """Convert the employee attributes to csv."""
        csv_format_list = [
            self.emp_id,
            self.name,
            self.work_hours,
            self.skills,
            self.availabilty,
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
        if len(csv_format_list) == 5:
            return cls(*csv_format_list)
        raise ValueError(f"Invalid Employee Format list: {csv_format_list}")
