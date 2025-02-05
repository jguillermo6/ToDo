using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Core.UserCalendarAgregate;

namespace ToDo.SQLServer.Repository.Data.Config;

internal class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500);
    }
}
