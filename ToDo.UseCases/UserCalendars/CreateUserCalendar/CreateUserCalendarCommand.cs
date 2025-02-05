using Ardalis.Result;
using MediatR;
using ToDo.Core.UserCalendarAgregate;

namespace ToDo.UseCases.UserCalendars.CreateUserCalendar;

public record CreateUserCalendarCommand(int UserId, DateOnly Date) : IRequest<Result<UserCalendar>>;
