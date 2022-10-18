using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelefonRehberi.DataAccess.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    KisiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Firma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DirectoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.KisiId);
                    table.ForeignKey(
                        name: "FK_Kisiler_Rehberler_DirectoryId",
                        column: x => x.DirectoryId,
                        principalTable: "Rehberler",
                        principalColumn: "RehberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_DirectoryId",
                table: "Kisiler",
                column: "DirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kisiler");

            migrationBuilder.DropTable(
                name: "Rehberler");
        }
    }
}
