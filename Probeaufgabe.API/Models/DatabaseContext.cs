using Microsoft.EntityFrameworkCore;

namespace Probeaufgabe.API.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Device> Devices { get; set; }
    }
}
