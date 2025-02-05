using Ardalis.Result;
using NSubstitute;
using ToDo.Core.UserCalendarAgregate;
using ToDo.Kernel.Interfaces.Repository;
using ToDo.UseCases.UserCalendars.CreateUserCalendar;
using Xunit;

namespace ToDo.UnitTest.UseCases.UserCalendarAgregate;

public class CreateUserCalendarHandlerHandle
{

    private readonly IRepository<UserCalendar> _repository = Substitute.For<IRepository<UserCalendar>>();
    private CreateUserCalendarHandler _handler;
    public CreateUserCalendarHandlerHandle()
    {
        _handler = new CreateUserCalendarHandler(_repository);
    }

    [Fact]
    public async Task Handle_WithValidRequest_ReturnsUserCalendar()
    {
        // Arrange
        var userCalendar = new UserCalendar(1, new DateOnly(2025, 1, 10));
        _repository.AddAsync(Arg.Any<UserCalendar>()).Returns(Task.FromResult(userCalendar));
        var request = new CreateUserCalendarCommand(1, new DateOnly(2025, 1, 10));
        
        // Act
        var result = await _handler.Handle(request, CancellationToken.None);
        // Assert
        Assert.True(result.IsCreated());
    }

    
}
