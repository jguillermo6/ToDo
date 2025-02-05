using Ardalis.Specification;

namespace ToDo.Core.UserCalendarAgregate.Specifications;

public class UserCalendarByDateSpec : Specification<UserCalendar>
{
    public UserCalendarByDateSpec(DateOnly date)
    {
        Query.Where(x => x.Date == date);
    }
}
