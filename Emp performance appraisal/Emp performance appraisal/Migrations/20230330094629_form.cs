using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emp_performance_appraisal.Migrations
{
    public partial class form : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpRatingT = table.Column<int>(type: "int", nullable: false),
                    EmpCommentsT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpRatingB = table.Column<int>(type: "int", nullable: false),
                    EmpCommentsB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MgrRatingT = table.Column<int>(type: "int", nullable: false),
                    MgrCommentsT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MgrRatingB = table.Column<int>(type: "int", nullable: false),
                    MgrCommentsB = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Form");
        }
    }
}
