using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emp_performance_appraisal.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.CreateTable(
                name: "Appraisal",
                columns: table => new
                {
                    AppraisalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCompetency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BCompetency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objectives = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appraisal", x => x.AppraisalId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appraisal");

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    DetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppraisalId = table.Column<int>(type: "int", nullable: false),
                    Comptency = table.Column<int>(type: "int", nullable: false),
                    EmpComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpRating = table.Column<int>(type: "int", nullable: false),
                    MgrComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MgrRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.DetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    AppraisalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpID = table.Column<int>(type: "int", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.AppraisalID);
                });
        }
    }
}
