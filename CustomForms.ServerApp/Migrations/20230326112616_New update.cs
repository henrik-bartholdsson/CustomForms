using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomForms.ServerApp.Migrations
{
    /// <inheritdoc />
    public partial class Newupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Dispatches_BlankFormId",
                table: "Dispatches",
                column: "BlankFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispatches_BlankForms_BlankFormId",
                table: "Dispatches",
                column: "BlankFormId",
                principalTable: "BlankForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispatches_BlankForms_BlankFormId",
                table: "Dispatches");

            migrationBuilder.DropIndex(
                name: "IX_Dispatches_BlankFormId",
                table: "Dispatches");
        }
    }
}
