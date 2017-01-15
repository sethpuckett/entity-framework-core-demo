using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity_framework_core_demo.Models;
using Microsoft.EntityFrameworkCore;

namespace entity_framework_core_demo.DAL
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TodoTag> TodoTags { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public TodoContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
