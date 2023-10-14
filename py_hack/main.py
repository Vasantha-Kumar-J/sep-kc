"""Task scheduling for employees.

adding employees
adding tasks
scheduling the task to employees based on the attributes
"""


from ast import Dict
import json

task_count = 3
employee_count = 3


def get_employees() -> Dict:
    """Get emp details.

    Returns:
        Dict: employee dictionary
    """
    try:
        file_path = "D:\\python\\hack_2024\\py_hack\\py_hack\\employee.json"
        with open(file=file_path, mode="r") as employee_file:
            emp_details = json.load(employee_file)
            return emp_details
    except Exception as e:
        print("Exception raised : ", e.__name__)


def get_tasks() -> Dict:
    """Get task details.

    Returns:
        Dict: employee dictionary
    """
    try:
        file_path = "D:\\python\\hack_2024\\py_hack\\py_hack\\task.json"
        with open(file=file_path, mode="r") as employee_file:
            task_details = json.load(employee_file)
            return task_details
    except Exception as e:
        print("Exception raised : ", e.__name__)


def add_employee():
    """Scheduling tasks to the employees based on the attributes."""
    employee_details = get_employees()
    global employee_count
    name = input("Enter the employee name : ")
    working_hours = input("Enter the employee working hours : ")
    skills = list(input("Enter the employee skills : ").split(" "))
    availability = input(
        "Enter the employee availability status (Available / Not Available): "
    )
    task = ""
    employee_details[f"employee{employee_count}"] = {
        "employee_name": name,
        "working_hours": working_hours,
        "skills": skills,
        "availability": availability,
        "task": task,
    }
    json_object = json.dump(employee_details)
    try:
        file_path = "D:\\python\\hack_2024\\py_hack\\py_hack\\employee.json"
        with open(file=file_path, mode="w") as employee_file:
            employee_file.write(json_object)
    except Exception as e:
        print("Exception raised : ", e.__name__)
    employee_count += 1


def add_task():
    task_details = get_tasks()
    global task_count
    task_name = input("Enter the task name : ")
    description = input("Enter the task description : ")
    requires_hours = input("Enter the task working_hours : ")
    necessary_skills = input("Enter the task skills : ")
    deadline = input("Enter the task deadline : ")
    max_employees = input("Enter the max employees needed : ")
    task_details[f"task{task_count}"] = {
        "task_name": task_name,
        "description": description,
        "required_hours": requires_hours,
        "necessary_skills": necessary_skills,
        "deadline": deadline,
        "employees_working": [],
        "max_employees": max_employees,
    }
    json_object = json.dump(task_details)
    try:
        file_path = "D:\\python\\hack_2024\\py_hack\\py_hack\\task.json"
        with open(file=file_path, mode="w") as task_file:
            task_file.write(json_object)
    except Exception as e:
        print("Exception raised : ", e.__name__)
    task_count += 1


def schedule_task():
    emp_details: Dict = get_employees()
    task_details: Dict = get_tasks()
    for _, employee in emp_details.items():
        skills = employee["skills"]
        for _, task in task_details.items():
            # checking max count reached
            if len(task["employees_working"]) == task["max_employees"]:
                continue
            # iterating through each skill, checking with matching required skill
            for skill in skills:
                if (
                    task["required_hours"] <= employee["working_hours"]
                ):  # check work hour match
                    if task["necessary_skills"] == skill:  # check skill match
                        employee["task"].append(
                            task["task_name"]
                        )  # updating employee task details
                        employee["working_hours"] -= task[
                            "required_hours"
                        ]  # reducing working hour of the employee
                        task["employees_working"].append(
                            employee["employee_name"]
                        )  # updating task details
                        print(
                            f'{employee["employee_name"]} is assigned with {task["task_name"]} for working hour of {task["required_hours"]}'
                        )
                        break
                else:
                    break
    print("\n\n")
    print("Employee details : ", emp_details)
    print("\n\n")
    print("Task details : ", task_details)
    # not handled cases :


def main():
    while True:
        print("1. Add employee\n2. Add task\n3. schedule tasks\n4.Quit")
        choice = int(input("Enter the choice : "))
        if choice == 1:
            add_employee()
            print("Employee added")
        elif choice == 2:
            add_task()
            print("Task added")
        elif choice == 3:
            schedule_task()
        elif choice == 4:
            break
        else:
            print("Enter the valid choice")


if __name__ == "__main__":
    main()
