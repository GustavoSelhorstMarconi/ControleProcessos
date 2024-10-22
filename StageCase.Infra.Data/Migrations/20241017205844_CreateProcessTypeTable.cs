using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StageCase.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateProcessTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProcessType",
                table: "Process",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Process_IdProcessType",
                table: "Process",
                column: "IdProcessType");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Types_IdProcessType",
                table: "Process",
                column: "IdProcessType",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Types_IdProcessType",
                table: "Process");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Process_IdProcessType",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "IdProcessType",
                table: "Process");
        }
    }
}
