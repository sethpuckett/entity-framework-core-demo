using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace entityframeworkcoredemo.Migrations
{
    public partial class PopulateStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Statuses\" (\"Title\") VALUES ('New')");
            migrationBuilder.Sql("INSERT INTO \"Statuses\" (\"Title\") VALUES ('Finished')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Statuses\"");
        }
    }
}
