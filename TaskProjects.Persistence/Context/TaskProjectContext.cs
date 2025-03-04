using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskProjects.Domain.Entities;

namespace TaskProjects.Persistence.Context
{
    public class TaskProjectContext : DbContext
    {
        public TaskProjectContext(DbContextOptions<TaskProjectContext> options) : base(options)
        { }


        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}