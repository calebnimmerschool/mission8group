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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "School" },
            new Category { CategoryId = 3, CategoryName = "Work" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );
    }

}

