using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using ToDo.Core.UserCalendarAgregate;
using Xunit;

namespace ToDo.UnitTest.Core.UserCalendarAgregate;

public class AddTask
{
    private readonly UserCalendar _userCalendar = new UserCalendar(1, new DateOnly(2025, 1, 10));

    [Fact]
    public void AddTaskToUserCalendar()
    {
        // Arrange
        var task = new TaskItem("Task 1", TimeSpan.FromHours(1), "Description 1");
        // Act
        _userCalendar.AddTask(task);
        // Assert
        Assert.Contains<TaskItem>(task, _userCalendar.Tasks);
    }


    [Theory]
    [MemberData(nameof(GetExceedingEightHoursPerDayData))]
    public void AddTaskToUserCalendar_ExceedingEightHoursPerDay_ThrowException(TaskItem[] tasks, TimeSpan time)
    {
        // Arrange
        foreach (var task in tasks)
        {
            _userCalendar.AddTask(task);
        }
        var newTask = new TaskItem("Exception Task", time, "Exception Task");

        // Act
        Action act = () => _userCalendar.AddTask(newTask);

        // Assert
        Assert.Throws<Exception>(act);
    }

    public static IEnumerable<object[]> GetExceedingEightHoursPerDayData()
    {
        yield return new object[] { new TaskItem[] { new TaskItem("Task 1", TimeSpan.FromHours(8), "Description 1") }, 
                                    TimeSpan.FromHours(1) };

        yield return new object[] { new TaskItem[] { new TaskItem("Task 1", TimeSpan.FromHours(4), "Description 1") }, 
                                    TimeSpan.FromHours(5) };
        
        yield return new object[] { new TaskItem[] { new TaskItem("Task 1", TimeSpan.FromHours(8), "Description 1") }, 
                                    TimeSpan.FromSeconds(1) };
        
        yield return new object[] { new TaskItem[] { new TaskItem("Task 1", TimeSpan.FromHours(2), "Description 1"), 
                                    new TaskItem("Task 2", TimeSpan.FromHours(3), "Description 2") }, 
                                    TimeSpan.FromHours(4) };
    }
}
