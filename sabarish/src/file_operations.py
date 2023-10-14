import csv
import logging


def read_csv_as_dict(file_path: str):
    with open(file_path, "r") as file:
        reader = csv.DictReader(file)
        return list(reader)


def logging_operations(message, msg_type="info"):
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
