using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Core.UserCalendarAgregate;

namespace ToDo.SQLServer.Repository.Data.Config;

internal class UserCalendarConfiguration : IEntityTypeConfiguration<UserCalendar>
{
    public void Configure(EntityTypeBuilder<UserCalendar> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

        builder.HasMany(x => x.Tasks).WithOne().HasForeignKey("UserCalendarId").IsRequired();
    }
}
