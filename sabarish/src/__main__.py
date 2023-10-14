"""Console App for Task Scheduler."""


from employee import add_employee
from employee import import_employees
from employee import export_list_of_employees
from tasks import add_task
from tasks import import_tasks
from tasks import export_list_of_tasks
from schedule import schedule
from schedule import SCHEDULE


while True:
    print("Welcome to the Task Schedular App")
    user_input = int(
        input(
            "Enter your choice "
            "\n1.Add employee "
            "\n2.Add employees from a csv file"
            "\n3.Add Task "
            "\n4.Add Tasks from a csv file"
            "\n5.Schedue Tasks"
            "\n6.Get employees"
            "\n7.Get Tasks"
            "\n8.Get Schedule"
            "\n Enter anything else to exit : "
        )
    )
    if user_input == 1:
        name = input("Enter employee name : ")
        working_hours = input("Enter employee working_hours : ")
        skills = input("Enter employee skills : ")
        availability = input("Enter employee availability : ")
        add_employee(name, working_hours, skills, availability)
    elif user_input == 2:
        file_path = input(
            "Enter a csv file path that has employee details : "
        )
        import_employees(file_path)
    elif user_input == 3:
        name = input("Enter task name : ")
        description = input("Enter task description : ")
        required_hours = input("Enter task required_hours : ")
        deadline = input("Enter task deadline : ")
        deadline = input("Enter necessary_skills for task : ")
        add_task(
            name, description, required_hours, deadline, necessary_skills
        )
    elif user_input == 4:
        file_path = input("Enter a csv file path that has tasks details : ")
        import_tasks(file_path)
    elif user_input == 5:
        print(f"Schedule created : {schedule()}")
    elif user_input == 6:
        for employee in export_list_of_employees():
            print(
                f"name:{employee.name} "
                f"working_hours:{employee.working_hours} "
                f"skills:{employee.skills} "
                f"availability:{employee.availability} "
            )
    elif user_input == 7:
        print("Scheduled Task : ")
        for task in export_list_of_tasks()["scheduled tasks"]:
            print(
                f"name:{task.name} "
                f"description:{task.description} "
                f"required_hours:{task.required_hours} "
                f"deadline:{task.deadline} "
                f"necessary_skills:{task.necessary_skills} "
            )
        print("UnScheduled Task : ")
        for task in export_list_of_tasks()["unscheduled_tasks"]:
            print(
                f"name:{task.name} "
                f"description:{task.description} "
                f"required_hours:{task.required_hours} "
                f"deadline:{task.deadline} "
                f"necessary_skills:{task.necessary_skills} "
            )
    elif user_input == 8:
        print(SCHEDULE)
    else:
        break
