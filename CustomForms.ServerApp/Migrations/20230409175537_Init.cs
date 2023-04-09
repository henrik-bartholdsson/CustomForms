using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomForms.ServerApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlankForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlankForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dispatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlankFormId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dispatches_BlankForms_BlankFormId",
                        column: x => x.BlankFormId,
                        principalTable: "BlankForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormInputFieldDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlankFormId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placeholder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StringData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntegerData = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    MaxLength = table.Column<int>(type: "int", nullable: false),
                    MinLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormInputFieldDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormInputFieldDefinitions_BlankForms_BlankFormId",
                        column: x => x.BlankFormId,
                        principalTable: "BlankForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormInputFieldAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldDefinitionId = table.Column<int>(type: "int", nullable: false),
                    StringData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntegerData = table.Column<int>(type: "int", nullable: false),
                    DispatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormInputFieldAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormInputFieldAnswers_Dispatches_DispatchId",
                        column: x => x.DispatchId,
                        principalTable: "Dispatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dispatches_BlankFormId",
                table: "Dispatches",
                column: "BlankFormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormInputFieldAnswers_DispatchId",
                table: "FormInputFieldAnswers",
                column: "DispatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FormInputFieldDefinitions_BlankFormId",
                table: "FormInputFieldDefinitions",
                column: "BlankFormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormInputFieldAnswers");

            migrationBuilder.DropTable(
                name: "FormInputFieldDefinitions");

            migrationBuilder.DropTable(
                name: "Dispatches");

            migrationBuilder.DropTable(
                name: "BlankForms");
        }
    }
}
