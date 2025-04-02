using Ardalis.Result;
using MediatR;

namespace ToDo.UseCases.UserCalendars.RemoveTaskItem;

public record RemoveTaskItemCommand(int userCalendarId, int taskItemId) : IRequest<Result>;
