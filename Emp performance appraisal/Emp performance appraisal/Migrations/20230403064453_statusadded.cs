using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emp_performance_appraisal.Migrations
{
    public partial class statusadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Appraisal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Appraisal");
        }
    }
}
