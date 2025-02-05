using Ardalis.Result;
using MediatR;
using ToDo.Core.UserCalendarAgregate;

namespace ToDo.UseCases.UserCalendars.AddTaskItem;

public record AddTaskItemCommand(int userCalendarId, string title, TimeSpan duration, string description = "") : IRequest<Result<int>>;
