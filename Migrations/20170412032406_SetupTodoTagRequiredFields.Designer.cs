using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using entity_framework_core_demo.DAL;

namespace entityframeworkcoredemo.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20170412032406_SetupTodoTagRequiredFields")]
    partial class SetupTodoTagRequiredFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

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

                    b.Property<int?>("TagId")
                        .IsRequired();

                    b.Property<int?>("TodoId")
                        .IsRequired();

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
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("entity_framework_core_demo.Models.Todo", "Todo")
                        .WithMany("TodoTags")
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
