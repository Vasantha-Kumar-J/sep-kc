"""Task Scheduler Module."""


from employee import ALL_EMPLOYEES
from tasks import UNSCHEDULED_TASKS, SCHEDULED_TASKS

SCHEDULE = []


def sorting_tasks_by_deadlines() -> None:
    """Sort the tasks by their deadline."""
    for index1 in range(len(UNSCHEDULED_TASKS)):
        for index2 in range(index1 + 1, len(UNSCHEDULED_TASKS)):
            if (
                UNSCHEDULED_TASKS[index1].deadline
                > UNSCHEDULED_TASKS[index2].deadline
            ):
                temp = UNSCHEDULED_TASKS[index1]
                UNSCHEDULED_TASKS[index1] = UNSCHEDULED_TASKS[index2]
                UNSCHEDULED_TASKS[index2] = temp


def schedule(SCHEDULE: list = SCHEDULE) -> None:
    """Schedule the tasks.

    Schedule employees according to the availabily deadlines and skill set.

    Args:
        SCHEDULE (list, optional): Schedule if already exist. Defaults to SCHEDULE.
    """
    sorting_tasks_by_deadlines()
    for task in UNSCHEDULED_TASKS:
        time_for_each_skill = task.required_hours / len(task.necessary_skills)
        skill_time_pairs = [
            (skill, time_for_each_skill) for skill in task.necessary_skills
        ]
        for skill_time_pair in skill_time_pairs:
            skill = skill_time_pair[0]
            time = skill_time_pair[1]
            temp_schedule = []
            temp_employee_availability = []
            for employee in ALL_EMPLOYEES:
                employee_availability = employee.availability.copy()
                if skill in employee.skills:
                    available_dates_before_deadline = [
                        date
                        for date in employee.availability
                        if date < task.deadline
                    ]
                    available_time_before_deadline = (
                        len(available_dates_before_deadline)
                        * employee.working_hours
                    )
                    if available_time_before_deadline > time:
                        number_of_days_used = int(
                            time / employee.working_hours
                        )
                        time = 0
                        employee.availability = employee.availability[
                            number_of_days_used:
                        ]
                        SCHEDULE.append(
                            {
                                "task": task.name,
                                "employee": employee.name,
                                "scheduled_dates": employee.availability[
                                    :number_of_days_used
                                ],
                            }
                        )
                        break
                    else:
                        temp_schedule.append(
                            {
                                "task": task.name,
                                "employee": employee.name,
                                "scheduled_dates": employee.availability,
                            }
                        )
                        time -= available_time_before_deadline
                        temp_employee_availability.append(
                            (employee.name, employee_availability)
                        )
                        employee_availability.clear()
            if time != 0:
                break
            else:
                SCHEDULE += temp_schedule
                employees_to_be_updated = [
                    employee[0] for employee in temp_employee_availability
                ]
                for employee in ALL_EMPLOYEES:
                    for updated_employee in temp_employee_availability:
                        if updated_employee[0] == employee.name:
                            employee.availability = updated_employee[1]
        else:
            SCHEDULED_TASKS.append(task)
            UNSCHEDULED_TASKS.remove(task)
