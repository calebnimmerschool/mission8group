using Microsoft.EntityFrameworkCore;
using mission8group.Models;  // Reference your models (e.g., Task, Category, etc.)

namespace mission8group  // Your project namespace
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext  // Rename it to your class name
    {
        // Constructor that accepts DbContextOptions and passes it to the base class
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        // DbSet properties represent your database tables
        public DbSet<Task> Tasks { get; set; }  // Represents the "Tasks" table
        public DbSet<Category> Categories { get; set; }  // Represents the "Categories" table
    }
}