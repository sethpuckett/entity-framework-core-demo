using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using entity_framework_core_demo.DAL;

namespace entityframeworkcoredemo.Migrations
{
    [DbContext(typeof(TodoContext))]
    partial class TodoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("entity_framework_core_demo.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("entity_framework_core_demo.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("entity_framework_core_demo.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("StatusId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("entity_framework_core_demo.Models.TodoTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TagId");

                    b.Property<int?>("TodoId");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("TodoId");

                    b.ToTable("TodoTags");
                });

            modelBuilder.Entity("entity_framework_core_demo.Models.Todo", b =>
                {
                    b.HasOne("entity_framework_core_demo.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("entity_framework_core_demo.Models.TodoTag", b =>
                {
                    b.HasOne("entity_framework_core_demo.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.HasOne("entity_framework_core_demo.Models.Todo", "Todo")
                        .WithMany("TodoTags")
                        .HasForeignKey("TodoId");
                });
        }
    }
}
