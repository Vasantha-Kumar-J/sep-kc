"""File Handling module."""


import csv
import logging


def read_csv_as_dict(file_path: str) -> list:
    """Read the csv file as dictionary.

    Args:
        file_path (str): file path to read

    Returns:
        list: list of dictionaries from the csv
    """
    with open(file_path, "r") as file:
        reader = csv.DictReader(file)
        return list(reader)


def logging_operations(message: str, msg_type: str = "info"):
    """Log all the operations

    Args:
        message (str): log message
        msg_type (str, optional): message type. Defaults to "info".
    """
    logging_format = "%(asctime)s  %(levelname)s:%(message)s"
    logging.basicConfig(
        filename="operations.log",
        encoding="utf-8",
        format=logging_format,
        level=logging.DEBUG,
    )
    if msg_type == "error":
        logging.error(message)
    else:
        logging.info(message)


if __name__ == "__main__":
    read_csv_as_dict("tasks.csv")
    logging_operations("read tasks.csv file", msg_type="warning")
