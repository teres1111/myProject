using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class CustomMigrationTransaktion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "Accounting",
                table: "transaction",
                newName: "type");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                schema: "Accounting",
                table: "transaction",
                type: "text",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                schema: "Accounting",
                table: "transaction",
                newName: "Type");

            migrationBuilder.AlterColumn<bool>(
                name: "Type",
                schema: "Accounting",
                table: "transaction",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
