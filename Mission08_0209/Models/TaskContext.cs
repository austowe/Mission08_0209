using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_0209.Models
{
    public class TaskContext : DbContext
    {
        // constructor
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            // leave blank for now
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Category { get; set; }

        // seeded data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );
        }
    }
}
