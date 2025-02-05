using Ardalis.Result;
using MediatR;
using ToDo.Core.UserCalendarAgregate;
using ToDo.Kernel.Interfaces.Repository;

namespace ToDo.UseCases.UserCalendars.AddTaskItem;

public class AddTaskItemHandler : IRequestHandler<AddTaskItemCommand, Result<int>>
{
    protected readonly IRepository<UserCalendar> _repository;
    public AddTaskItemHandler(IRepository<UserCalendar> repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(AddTaskItemCommand request, CancellationToken cancellationToken)
    {
        var userCalendar = await  _repository.GetByIdAsync(request.userCalendarId);

        if (userCalendar == null)
        {
            return Result.NotFound();
        }

        var taskItem = new TaskItem(request.title, request.duration, request.description);
        userCalendar.AddTask(taskItem);

        await _repository.UpdateAsync(userCalendar);

        return Result<int>.Success(taskItem.Id);
    }
}
