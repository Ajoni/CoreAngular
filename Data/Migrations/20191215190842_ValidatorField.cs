using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ValidatorField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validators_Fields_FieldId",
                table: "Validators");

            migrationBuilder.DropIndex(
                name: "IX_Validators_FieldId",
                table: "Validators");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "Validators");

            migrationBuilder.CreateTable(
                name: "ValidatorField",
                columns: table => new
                {
                    FieldId = table.Column<int>(nullable: false),
                    ValidatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidatorField", x => new { x.FieldId, x.ValidatorId });
                    table.ForeignKey(
                        name: "FK_ValidatorField_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValidatorField_Validators_ValidatorId",
                        column: x => x.ValidatorId,
                        principalTable: "Validators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValidatorField_ValidatorId",
                table: "ValidatorField",
                column: "ValidatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValidatorField");

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "Validators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Validators_FieldId",
                table: "Validators",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Validators_Fields_FieldId",
                table: "Validators",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
