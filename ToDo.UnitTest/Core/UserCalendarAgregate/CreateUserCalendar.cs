using ToDo.Core.UserCalendarAgregate;
using Xunit;

namespace ToDo.UnitTest.Core.UserCalendarAgregate;

public class CreateUserCalendar
{
    [Fact]
    public void InitializesConstructor()
    {
        // Arrange
        int userId = 1;
        DateOnly date = new DateOnly(2025, 1, 10);
        var userCalendar = new UserCalendar(userId, date);
        // Act
        var result = userCalendar;
        // Assert
        Assert.NotNull(result);
    }
}
