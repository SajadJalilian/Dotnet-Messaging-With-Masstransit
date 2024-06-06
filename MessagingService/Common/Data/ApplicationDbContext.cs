using Microsoft.EntityFrameworkCore;

namespace MessagingService.Common.Data;

class ApplicationDbContext : DbContext
{
    internal ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    // DbSet<Holiday> Holidays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}