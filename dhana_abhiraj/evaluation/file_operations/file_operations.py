"""File Operations."""


import csv
import os
import logging

logging.basicConfig(filename="app.log", format="%(asctime)s - %(level)s %(message)s")


class FileOperation:
    """Handle all file operations."""

    def __init__(self, file_path: str) -> None:
        """Initialize the File operations with File Path.

        Parameters
        ----------
        file_path : str
        """
        self.file_path = file_path

    def read_rows(self, file_path) -> list[list]:
        """Read the Data from the file path

        Parameters
        ----------
        file_path: str
            The file path of the data

        Returns
        -------
        list[str]
            The list of rows
        """
        with open(file_path, mode="r", encoding="utf-8", newline="") as csv_file:
            csv_reader = csv.reader(csv_file)
            rows = []
            for row in csv_reader:
                rows.append(row)
            return rows

    def write_rows(self, file_path: str, rows: list[list], mode="a"):
        """Write the Data from the file path

        Parameters
        ----------
        file_path: str
            The file path of the data
        rows: list[str]
            The list of rows
        """
        with open(file_path, mode=mode, encoding="utf-8", newline="") as csv_file:
            csv_writer = csv.writer(csv_file)
            csv_writer.writerows(rows)

    def import_data(self, external_file_path: str):
        """Import the Data

        Parameters
        ----------
        external_file_path: str
            The file path of the data to be imported
        """
        data = self.read_rows(external_file_path)
        self.write_rows(self.file_path, data)

    def export_data(self, external_file_path: str) -> None:
        """Export the Data

        Parameters
        ----------
        external_file_path: str
            The file path of the data to be exported
        """
        data = self.read_rows(self.file_path)
        self.write_rows(external_file_path, data)

    def add_rows(self, rows: list[list], mode="a"):
        """Insert the rows to the File."""
        self.write_rows(self.file_path, rows, mode)

    def get_rows(self) -> list:
        """Get all the rows from the file."""
        rows = self.read_rows(self.file_path)
        return rows
