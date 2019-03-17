using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Craftsmen",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfEmployment = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    SubjectArea = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Craftsmen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToolBoxes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Purchased = table.Column<DateTime>(nullable: false),
                    CraftsmanId = table.Column<long>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolBoxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolBoxes_Craftsmen_CraftsmanId",
                        column: x => x.CraftsmanId,
                        principalTable: "Craftsmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Purchased = table.Column<DateTime>(nullable: false),
                    Product = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ToolBoxId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tools_ToolBoxes_ToolBoxId",
                        column: x => x.ToolBoxId,
                        principalTable: "ToolBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToolBoxes_CraftsmanId",
                table: "ToolBoxes",
                column: "CraftsmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ToolBoxId",
                table: "Tools",
                column: "ToolBoxId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "ToolBoxes");

            migrationBuilder.DropTable(
                name: "Craftsmen");
        }
    }
}
