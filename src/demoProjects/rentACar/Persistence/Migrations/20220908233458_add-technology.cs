using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addtechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingTechologiess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    TechnologyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnologyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingTechologiess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingTechologiess_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingTechologiess",
                columns: new[] { "Id", "ProgrammingLanguageId", "TechnologyDescription", "TechnologyName" },
                values: new object[] { 1, 4, "JavaScript", "Web Sitelerinde dinamiklik için kullanılır." });

            migrationBuilder.InsertData(
                table: "ProgrammingTechologiess",
                columns: new[] { "Id", "ProgrammingLanguageId", "TechnologyDescription", "TechnologyName" },
                values: new object[] { 2, 3, "JavaScript", "Web Sitelerinde dinamiklik için kullanılır." });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTechologiess_ProgrammingLanguageId",
                table: "ProgrammingTechologiess",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingTechologiess");
        }
    }
}
