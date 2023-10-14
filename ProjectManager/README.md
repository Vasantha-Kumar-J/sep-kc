# BACKEND ASSESSMENT 
This repository contains implementation of Task Scheduler, Resource Allocator and File Manager.

***Partially Completed***

- The `Menu` class holds a switch case to switch between adding tasks, employees, importing and exporting files, also scheduling the tasks to employees.

- Implemented `EmployeeDataManager` class that manages, List of employees, sets up default values to list, adds new employee to the list, import and export of files. `TaskDataManager` class that manages, List of tasks, sets up default values to list, adds new tasks to the list, import and export of files.

- Also includes, `Scheduler` class that performs scheduling of tasks to employees based on the availability of the employee and task criteria.

    - `ScheduleManager ` iterates each task and checks for the availability of the resources(Employees) using `IsResourceAvailable`. 
    - If the employers are available and met the criteria of deadlines in regard with total working hours then it returns true. 
    - Then the `ScheduleTaskToEmployees` schedules the task to each employee by updating the properties and task property is also updated to true.

NOTE: In progress to improve the scheduling algorithm that covers all the edge cases.
