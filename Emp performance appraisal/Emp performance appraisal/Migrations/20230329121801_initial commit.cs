using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emp_performance_appraisal.Migrations
{
    public partial class initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BCompany",
                table: "Appraisal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BCompany",
                table: "Appraisal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
