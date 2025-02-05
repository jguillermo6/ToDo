using Ardalis.Result;
using MediatR;
using NSubstitute;
using ToDo.Core.UserCalendarAgregate;
using ToDo.Kernel.Interfaces.Repository;
using ToDo.UseCases.UserCalendars.AddTaskItem;
using Xunit;

namespace ToDo.UnitTest.UseCases.UserCalendarAgregate;

public class AddTaskItemHandlerHandle
{
    private readonly IRepository<UserCalendar> _repository = Substitute.For<IRepository<UserCalendar>>();
    private AddTaskItemHandler _handler;

    public AddTaskItemHandlerHandle()
    {
        _handler = new AddTaskItemHandler(_repository);
    }

    [Fact]
    public async Task Handle_WithValidRequest_Successful()
    {
        // Arrange
        int userCalendarId = 1;
        _repository.GetByIdAsync(userCalendarId).Returns(Task.FromResult(new UserCalendar(1, new DateOnly(2025, 1, 10))));
        _repository.UpdateAsync(Arg.Any<UserCalendar>()).Returns(Task.CompletedTask);
        var request = new AddTaskItemCommand(userCalendarId, "Test ToDo", TimeSpan.FromHours(2));

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);
        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task Handle_WithInvalidUserCalendarId_ErrorNotFound()
    {
        // Arrange
        int userCalendarId = 1;
        _repository.GetByIdAsync(userCalendarId).Returns(Task.FromResult<UserCalendar>(null));
        var request = new AddTaskItemCommand(userCalendarId, "Test ToDo", TimeSpan.FromHours(2));
        // Act
        var result = await _handler.Handle(request, CancellationToken.None);
        // Assert
        Assert.True(result.IsNotFound());
    }
}
