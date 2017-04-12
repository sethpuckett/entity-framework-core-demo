using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace entityframeworkcoredemo.Migrations
{
    public partial class SetupTodoTagRequiredFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTags_Tags_TagId",
                table: "TodoTags");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTags_Todos_TodoId",
                table: "TodoTags");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "TodoTags",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "TodoTags",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTags_Tags_TagId",
                table: "TodoTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTags_Todos_TodoId",
                table: "TodoTags",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTags_Tags_TagId",
                table: "TodoTags");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTags_Todos_TodoId",
                table: "TodoTags");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "TodoTags",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "TodoTags",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTags_Tags_TagId",
                table: "TodoTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTags_Todos_TodoId",
                table: "TodoTags",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
