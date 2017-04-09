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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Setup additional mapping rules here */
            /* https://docs.microsoft.com/en-us/ef/core/modeling/relationships */

            // Ignore Class
            modelBuilder.Ignore<ValidationTracker>();
            // Ignore Property
            modelBuilder.Entity<Todo>().Ignore(t => t.Processing);
            // Set Primary Key
            /* modelBuilder.Entity<Todo>().HasKey(t => t.Title); */

            // Set Composite Key
            /* modelBuilder.Entity<Todo>().HasKey(t => new { t.Title, t.Description }); */
            /* Unfortunately, this doesn't work yet :( - https://github.com/aspnet/EntityFramework/issues/246 */
            /* modelBuilder.Entity<TodoTag>().HasKey(t => new { TodoId = t.Todo.Id, TagId = t.Tag.Id }); */
        
            // Generated Value
            /* modelBuilder.Entity<Todo>()
                .Property(t => t.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate(); */
        }
    }
}
