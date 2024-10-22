using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StageCase.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDescriptionInProcessTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Process_IdProcessParent",
                table: "Process");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProcessTypes",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "IdProcessParent",
                table: "Process",
                column: "IdProcessParent",
                principalTable: "Process",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "IdProcessParent",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProcessTypes");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Process_IdProcessParent",
                table: "Process",
                column: "IdProcessParent",
                principalTable: "Process",
                principalColumn: "Id");
        }
    }
}
