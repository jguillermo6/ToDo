using Ardalis.Result;
using MediatR;
using ToDo.Core.UserCalendarAgregate;
using ToDo.Kernel.Interfaces.Repository;

namespace ToDo.UseCases.UserCalendars.RemoveTaskItem;

public class RemoveTaskItemHandler : IRequestHandler<RemoveTaskItemCommand, Result>
{
    protected readonly IRepository<UserCalendar> _repository;
    public RemoveTaskItemHandler(IRepository<UserCalendar> repository)
    {
        _repository = repository;
    }
    public async Task<Result> Handle(RemoveTaskItemCommand request, CancellationToken cancellationToken)
    {
        var userCalendar = await _repository.GetByIdAsync(request.userCalendarId);

        if (userCalendar == null)
        {
            return Result.NotFound();
        }
        var taskItem = userCalendar.Tasks.FirstOrDefault(t => t.Id == request.taskItemId);

        if (taskItem == null)
        {
            return Result.NotFound();
        }

        userCalendar.RemoveTask(taskItem);

        await _repository.UpdateAsync(userCalendar);
        return Result.Success();
    }
}