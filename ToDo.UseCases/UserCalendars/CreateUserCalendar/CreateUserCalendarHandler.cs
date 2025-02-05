using Ardalis.Result;
using MediatR;
using ToDo.Core.UserCalendarAgregate;
using ToDo.Kernel.Interfaces.Repository;

namespace ToDo.UseCases.UserCalendars.CreateUserCalendar;

public class CreateUserCalendarHandler : IRequestHandler<CreateUserCalendarCommand, Result<UserCalendar>>
{
    protected readonly IRepository<UserCalendar> _repository; 
    public CreateUserCalendarHandler(IRepository<UserCalendar> repository)
    {
        _repository = repository;
    }

    public async Task<Result<UserCalendar>> Handle(CreateUserCalendarCommand request, CancellationToken cancellationToken)
    {
        var userCalendar = new UserCalendar(request.UserId, request.Date);
        var response = await _repository.AddAsync(userCalendar);

        return Result<UserCalendar>.Created(response);
    }
}
