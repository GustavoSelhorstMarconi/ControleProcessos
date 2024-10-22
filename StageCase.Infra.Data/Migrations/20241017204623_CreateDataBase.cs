using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StageCase.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProcessParent = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(300)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Process_Process_IdProcessParent",
                        column: x => x.IdProcessParent,
                        principalTable: "Process",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Process_IdProcessParent",
                table: "Process",
                column: "IdProcessParent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Process");
        }
    }
}
