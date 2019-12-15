using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class form : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class1s");

            migrationBuilder.CreateTable(
                name: "DataTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasedOnId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataTemplates_DataTemplates_BasedOnId",
                        column: x => x.BasedOnId,
                        principalTable: "DataTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DataTemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_DataTemplates_DataTemplateId",
                        column: x => x.DataTemplateId,
                        principalTable: "DataTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataTemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormDatas_DataTemplates_DataTemplateId",
                        column: x => x.DataTemplateId,
                        principalTable: "DataTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Validators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    FieldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Validators_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldId = table.Column<int>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    FormDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldValues_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldValues_FormDatas_FormDataId",
                        column: x => x.FormDataId,
                        principalTable: "FormDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataTemplates_BasedOnId",
                table: "DataTemplates",
                column: "BasedOnId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_DataTemplateId",
                table: "Fields",
                column: "DataTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValues_FieldId",
                table: "FieldValues",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValues_FormDataId",
                table: "FieldValues",
                column: "FormDataId");

            migrationBuilder.CreateIndex(
                name: "IX_FormDatas_DataTemplateId",
                table: "FormDatas",
                column: "DataTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Validators_FieldId",
                table: "Validators",
                column: "FieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldValues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Validators");

            migrationBuilder.DropTable(
                name: "FormDatas");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "DataTemplates");

            migrationBuilder.CreateTable(
                name: "Class1s",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class1s", x => x.id);
                });
        }
    }
}
