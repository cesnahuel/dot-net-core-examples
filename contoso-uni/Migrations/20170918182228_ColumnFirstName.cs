using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace contosouni.Migrations
{
    public partial class ColumnFirstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "students",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "students",
                newName: "FirstMidName");
        }
    }
}
