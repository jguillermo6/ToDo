namespace ToDo.Core.UserCalendarAgregate;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TimeSpan Duration { get; private set; }
    public TaskItem(string title, TimeSpan duration, string description)
    {
        Title = title;
        Duration = duration;
        Description = description;
    }
    public TaskItem(string title, TimeSpan duration)
    {
        Title = title;
        Duration = duration;
    }

    public void SetTitle(string title) => Title = title;

    public void SetDescription(string description) => Description = description;

    public void SetDuration(TimeSpan duration) => Duration = duration;
}
