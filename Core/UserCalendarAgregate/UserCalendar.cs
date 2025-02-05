using ToDo.Kernel.Interfaces.Agregate;

namespace ToDo.Core.UserCalendarAgregate
{
    public class UserCalendar : IAggregateRoot
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public DateOnly Date { get; private set; }
        private readonly List<TaskItem> _tasks = new();
        public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

        public UserCalendar(int userId, DateOnly date)
        {
            UserId = userId;
            Date = date;
        }

        public void AddTask(TaskItem task)
        {
            CheckIfTaskDurationExceedsEightHours(task);
            _tasks.Add(task);
        }

        public void RemoveTask(TaskItem task)
        {
            _tasks.Remove(task);
        }

        private void CheckIfTaskDurationExceedsEightHours(TaskItem task)
        {
            double currentDuration = _tasks.Sum(t => t.Duration.TotalHours);
            if ((currentDuration + task.Duration.TotalHours) > 8)
            {
                throw new Exception("Task duration exceeds 8 hours per day");
            }
        }
    }
}
