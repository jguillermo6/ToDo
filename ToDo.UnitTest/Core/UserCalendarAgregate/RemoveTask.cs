using ToDo.Core.UserCalendarAgregate;
using Xunit;

namespace ToDo.UnitTest.Core.UserCalendarAgregate;

public class RemoveTask
{

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


}
