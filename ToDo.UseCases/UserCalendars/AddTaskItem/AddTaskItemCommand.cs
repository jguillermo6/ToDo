using Ardalis.Result;
using MediatR;

namespace ToDo.UseCases.UserCalendars.AddTaskItem;

public record AddTaskItemCommand(int userCalendarId, string title, TimeSpan duration, string description = "") : IRequest<Result<int>>;
