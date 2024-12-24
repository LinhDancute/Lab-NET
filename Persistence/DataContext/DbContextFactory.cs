using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence.DataContext
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {         
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = "Data Source=DELL\\SQLEXPRESS;Initial Catalog=LapDBBook;TrustServerCertificate=True;Encrypt=False;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
