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

            modelBuilder.Entity<Todo>().Property<DateTime>("CreatedDate");

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
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate(); */

            // Required & Optional Values
            /* modelBuilder.Entity<Todo>()
                .Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Status>()
                .Property(s => s.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Tag>()
                .Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired(); */

            // Relationships & Foreign Keys
            /* modelBuilder.Entity<Todo>()
                .HasMany(t => t.TodoTags)
                .WithOne(t => t.Todo)
                .HasForeignKey("TodoId"); */

            // Index
            /* modelBuilder.Entity<Todo>().HasIndex(t => t.Title).HasName("IndexName");
            modelBuilder.Entity<Todo>().HasIndex(t => t.Title).IsUnique();
            modelBuilder.Entity<Todo>().HasIndex(t => new { t.Title, t.Description }); */

            // Alternate Key
            /* modelBuilder.Entity<Todo>().HasAlternateKey(t => t.Title); */
            

        }
    }
}
