using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emp_performance_appraisal.Migrations
{
    public partial class inik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Appraisalid",
                table: "Form",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appraisalid",
                table: "Form");
        }
    }
}
