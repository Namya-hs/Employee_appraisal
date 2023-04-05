using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emp_performance_appraisal.Migrations
{
    public partial class details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    DetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppraisalId = table.Column<int>(type: "int", nullable: false),
                    Comptency = table.Column<int>(type: "int", nullable: false),
                    EmpRating = table.Column<int>(type: "int", nullable: false),
                    EmpComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MgrRating = table.Column<int>(type: "int", nullable: false),
                    MgrComments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.DetailsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");
        }
    }
}
