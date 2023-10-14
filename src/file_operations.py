"""File Operations."""


import json


def read_json(filename: str) -> dict:
    """Imports a Json file and returns a dict

    Args:
        filename (str): json file path.

    Returns:
        dict : returns the dictionary from the json file
    """
    with open(filename, 'r', encoding="utf-8") as json_file:
        input_json = json.load(json_file)
        return input_json


def write_json(filename: str, key: str, write_value: dict) -> None:
    """Write the New Data to json file.

    Args:
        filename (str): json file path.
        key (str): key for the dictionary.
        write_value(dict): details for the key.
        """
    with open(filename, 'r+', encoding='utf-8') as json_file:
        # Using r+ to dump using Single Context Manager
        input_json = json.load(json_file)
        json_file.seek(0)
        json_file.truncate()
        input_json[key] = write_value
        json.dump(input_json, json_file, indent=4)


def dump_json(filename: str, dump_data: dict):
    """Dump the data to the file."""
    with open(filename, 'w', encoding="utf-8") as json_file:
        json.dump(dump_data, json_file, indent=4)


if __name__ == "__main__":
    print(read_json("tasks.json"))
