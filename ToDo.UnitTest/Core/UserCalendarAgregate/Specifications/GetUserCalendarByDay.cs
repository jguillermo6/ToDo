using ToDo.Core.UserCalendarAgregate;
using ToDo.Core.UserCalendarAgregate.Specifications;
using Xunit;

namespace ToDo.UnitTest.Core.UserCalendarAgregate.Specifications;

public class GetUserCalendarByDay
{
    [Theory]
    [InlineData(2025, 1, 10)]
    [InlineData(2025, 1, 11)]
    [InlineData(2025, 1, 9)]
    public void Filter_WithDateStored_ReturnsUserCalendars(int year, int month, int day)
    {
        // Arrange
        var dateToTest = new DateOnly(year, month, day);
        
        var userCalendars = GetUserCalendarsDataSet();

        var spec = new UserCalendarByDateSpec(dateToTest);

        // Act
        var result = spec.Evaluate(userCalendars);

        // Assert
        Assert.All(result, x => Assert.Equal(dateToTest, x.Date));
    }

    [Theory]
    [InlineData(2025, 1, 8)]
    [InlineData(2025, 1, 12)]
    public void Filter_WithDateNotStored_ReturnsEmptyCollection(int year, int month, int day)
    {
        // Arrange
        var dateToTest = new DateOnly(year, month, day);

        var userCalendars = GetUserCalendarsDataSet();
        var spec = new UserCalendarByDateSpec(dateToTest);
        // Act
        var result = spec.Evaluate(userCalendars);
        // Assert
        Assert.Empty(result);
    }

    private List<UserCalendar> GetUserCalendarsDataSet()
    {
        var userCalendars = new List<UserCalendar>();
        var userCalendar = new UserCalendar(1, new DateOnly(2025, 1, 10));
        var task1 = new TaskItem("Task 1", TimeSpan.FromHours(1), "Description 1");
        var task2 = new TaskItem("Task 2", TimeSpan.FromHours(2), "Description 2");
        var task3 = new TaskItem("Task 3", TimeSpan.FromHours(3), "Description 3");
        userCalendar.AddTask(task1);
        userCalendar.AddTask(task2);
        userCalendar.AddTask(task3);
        userCalendars.Add(userCalendar);

        var userCalendar2 = new UserCalendar(1, new DateOnly(2025, 1, 11));
        var task4 = new TaskItem("Task 4", TimeSpan.FromHours(1), "Description 4");
        userCalendar2.AddTask(task4);
        userCalendars.Add(userCalendar2);

        var userCalendar3 = new UserCalendar(1, new DateOnly(2025, 1, 9));
        var task5 = new TaskItem("Task 5", TimeSpan.FromHours(1), "Description 4");
        userCalendar3.AddTask(task5);
        userCalendars.Add(userCalendar3);

        return userCalendars;
    }
}
