using Microsoft.EntityFrameworkCore.Migrations;

namespace Sageon.Migrations
{
    public partial class sopclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alerts_Sop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Artifact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occurance = table.Column<int>(type: "int", nullable: false),
                    IOC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIEM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reviewed_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Added_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Procedure = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alerts_Sop", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alerts_Sop");
        }
    }
}
