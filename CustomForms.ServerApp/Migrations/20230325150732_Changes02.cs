using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomForms.ServerApp.Migrations
{
    /// <inheritdoc />
    public partial class Changes02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sent",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Submited",
                table: "Dispatches");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Dispatches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Dispatches");

            migrationBuilder.AddColumn<bool>(
                name: "Sent",
                table: "Dispatches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Submited",
                table: "Dispatches",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
