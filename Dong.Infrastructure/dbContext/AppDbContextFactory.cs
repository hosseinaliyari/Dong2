using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dong.Infrastructure.dbContext
{
    public class AppDbContextFactory
        : IDesignTimeDbContextFactory<AppDbContext>
    {
        private const string ConnectionString =
            "Data Source=194.5.195.53,31433;Initial Catalog=Hosein;User ID=hosein;Password=hosein12345678@;Encrypt=False";

        // برای Migration
        public AppDbContext CreateDbContext(string[] args)
        {
            return Create();
        }

        // 👇 برای Console / Runtime
        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            return new AppDbContext(options);
        }
    }
}

