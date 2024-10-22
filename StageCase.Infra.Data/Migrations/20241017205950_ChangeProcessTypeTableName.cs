using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StageCase.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProcessTypeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Types_IdProcessType",
                table: "Process");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "ProcessTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessTypes",
                table: "ProcessTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_ProcessTypes_IdProcessType",
                table: "Process",
                column: "IdProcessType",
                principalTable: "ProcessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_ProcessTypes_IdProcessType",
                table: "Process");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessTypes",
                table: "ProcessTypes");

            migrationBuilder.RenameTable(
                name: "ProcessTypes",
                newName: "Types");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Types_IdProcessType",
                table: "Process",
                column: "IdProcessType",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
