using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace mission8group.Models;

public class TimeManagementContext : DbContext
{
    public TimeManagementContext(DbContextOptions<TimeManagementContext> options) : base(options) //Constructor
    {
    }
    
    public DbSet<TimeManagementForm> Tasks { get; set; }
    
    public DbSet<Category> Categories { get; set; }
}

