from employee_management import export_emp, add_employees
from task_management import export_task, add_tasks
from schedule_tasks import assign_task

while True:
    print("\nMenu\n1.Export Task\n2.Export Employess\n3.Run Scheduling")
    print("\n4. Add Task\n5. Add Employees\n 6. Exit")

    option = int(input("Enter Choice:"))
    if option == 1:
        print(export_task())

    elif option == 2:
        print(export_emp())

    elif option == 3:
        assign_task()

    elif option == 4:
        add_tasks()

    elif option == 5:
        add_employees()

    elif option == 6:
        break
