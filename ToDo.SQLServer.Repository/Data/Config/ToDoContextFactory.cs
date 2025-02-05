using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ToDo.SQLServer.Repository.Data.Config;

internal class ToDoContextFactory : IDesignTimeDbContextFactory<ToDoDbContext>
{
    ToDoDbContext IDesignTimeDbContextFactory<ToDoDbContext>.CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ToDoDbContext>();
        optionsBuilder.UseSqlServer($"{args[0]}");
        //Data Source=.;Initial Catalog=ToDoDB;Integrated Security=True;Trust Server Certificate=True
        return new ToDoDbContext(optionsBuilder.Options);
    }
}
