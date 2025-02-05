using System;
using ToDo.Core.UserCalendarAgregate;
using Xunit;

namespace ToDo.UnitTest.Core.UserCalendarAgregate;

public class RemoveTask
{

    private readonly UserCalendar _userCalendar = new UserCalendar(1, new DateOnly(2025, 1, 10));

    [Fact]
    public void RemoveTask_Success()
    {
        // Arrange
        var userCalendar = new UserCalendar(1, new DateOnly(2025, 1, 10));
        var task = new TaskItem("Task 1", TimeSpan.FromHours(1), "Description 1");
        userCalendar.AddTask(task);
        // Act
        userCalendar.RemoveTask(task);
        // Assert
        Assert.DoesNotContain<TaskItem>(task, userCalendar.Tasks);
    }

    private void SetData(){
        var task1 = new TaskItem("Task 1", TimeSpan.FromHours(1), "Description 1");
        var task2 = new TaskItem("Task 2", TimeSpan.FromHours(2), "Description 2");
        var task3 = new TaskItem("Task 3", TimeSpan.FromHours(3), "Description 3");
        var task4 = new TaskItem("Task 4", TimeSpan.FromHours(4), "Description 4");
        var task5 = new TaskItem("Task 5", TimeSpan.FromHours(5), "Description 5");
        _userCalendar.AddTask(task1);
        _userCalendar.AddTask(task2);
        _userCalendar.AddTask(task3);
        _userCalendar.AddTask(task4);
        _userCalendar.AddTask(task5);
    }

}
