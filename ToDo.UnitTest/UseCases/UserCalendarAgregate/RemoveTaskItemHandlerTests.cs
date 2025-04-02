using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result;
using Moq;
using ToDo.Core.UserCalendarAgregate;
using ToDo.Kernel.Interfaces.Repository;
using ToDo.UseCases.UserCalendars.RemoveTaskItem;
using Xunit;

namespace ToDo.UnitTest.UseCases.UserCalendarAgregate;

public class RemoveTaskItemHandlerTests
{
    private readonly Mock<IRepository<UserCalendar>> _repositoryMock;
    private readonly RemoveTaskItemHandler _handler;

    public RemoveTaskItemHandlerTests()
    {
        _repositoryMock = new Mock<IRepository<UserCalendar>>();
        _handler = new RemoveTaskItemHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_UserCalendarNotFound_ReturnsNotFound()
    {
        // Arrange
        var command = new RemoveTaskItemCommand(1, 1);
        _repositoryMock.Setup(repo => repo.GetByIdAsync(command.userCalendarId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((UserCalendar)null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(ResultStatus.NotFound, result.Status);
    }

    [Fact]
    public async Task Handle_TaskItemNotFound_ReturnsNotFound()
    {
        // Arrange
        var userCalendar = new UserCalendar(1, DateOnly.FromDateTime(DateTime.Now));
        var command = new RemoveTaskItemCommand(1,1);
        _repositoryMock.Setup(repo => repo.GetByIdAsync(command.userCalendarId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(userCalendar);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(ResultStatus.NotFound, result.Status);
    }

    [Fact]
    public async Task Handle_TaskItemFound_RemovesTaskItemAndReturnsSuccess()
    {
        // Arrange
        var taskItem = new TaskItem("Test Task", TimeSpan.FromHours(1));
        taskItem.Id = 1;
        var userCalendar = new UserCalendar(1, DateOnly.FromDateTime(DateTime.Now));
        userCalendar.AddTask(taskItem);
        var command = new RemoveTaskItemCommand(1,1);
        _repositoryMock.Setup(repo => repo.GetByIdAsync(command.userCalendarId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(userCalendar);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(ResultStatus.Ok, result.Status);
        _repositoryMock.Verify(repo => repo.UpdateAsync(userCalendar, new CancellationToken()), Times.Once);

        
    }
}
