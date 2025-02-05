using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDo.Core.UserCalendarAgregate;

namespace ToDo.SQLServer.Repository.Data;

/// <summary>
/// Represents the database context for the ToDo application.
/// </summary>
internal class ToDoDbContext : DbContext
{
    /// <summary>
    /// Gets the DbSet of UserCalendar entities.
    /// </summary>
    public DbSet<UserCalendar> UserCalendars => Set<UserCalendar>();

    /// <summary>
    /// Initializes a new instance of the <see cref="ToDoDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
