using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelefonRehberi.DataAccess.Migrations
{
    public partial class CreateInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kisiler_Rehberler_DirectoryId",
                table: "Kisiler");

            migrationBuilder.DropTable(
                name: "Rehberler");

            migrationBuilder.DropIndex(
                name: "IX_Kisiler_DirectoryId",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "DirectoryId",
                table: "Kisiler");

            migrationBuilder.CreateTable(
                name: "Bilgiler",
                columns: table => new
                {
                    BilgiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    BilgiTuru = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilgiler", x => x.BilgiId);
                    table.ForeignKey(
                        name: "FK_Bilgiler_Kisiler_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Kisiler",
                        principalColumn: "KisiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilgiler_PersonId",
                table: "Bilgiler",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilgiler");

            migrationBuilder.AddColumn<Guid>(
                name: "DirectoryId",
                table: "Kisiler",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Rehberler",
                columns: table => new
                {
                    RehberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rehberler", x => x.RehberId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_DirectoryId",
                table: "Kisiler",
                column: "DirectoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kisiler_Rehberler_DirectoryId",
                table: "Kisiler",
                column: "DirectoryId",
                principalTable: "Rehberler",
                principalColumn: "RehberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
