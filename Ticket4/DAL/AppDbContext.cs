using Microsoft.EntityFrameworkCore;
using Ticket4.Models;

namespace Ticket4.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {

        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }

    }
}
