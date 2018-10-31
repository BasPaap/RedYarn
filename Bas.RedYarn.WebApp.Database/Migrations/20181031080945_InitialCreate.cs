using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bas.RedYarn.WebApp.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagrams",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagrams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    DiagramId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Diagrams_DiagramId",
                        column: x => x.DiagramId,
                        principalTable: "Diagrams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    DiagramId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Diagrams_DiagramId",
                        column: x => x.DiagramId,
                        principalTable: "Diagrams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlotElements",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    DiagramId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlotElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlotElements_Diagrams_DiagramId",
                        column: x => x.DiagramId,
                        principalTable: "Diagrams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Storylines",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    DiagramId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storylines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storylines_Diagrams_DiagramId",
                        column: x => x.DiagramId,
                        principalTable: "Diagrams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    DiagramId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Diagrams_DiagramId",
                        column: x => x.DiagramId,
                        principalTable: "Diagrams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    XPosition = table.Column<float>(nullable: false),
                    YPosition = table.Column<float>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CharacterId = table.Column<Guid>(nullable: true),
                    PlotElementId = table.Column<Guid>(nullable: true),
                    StorylineId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_PlotElements_PlotElementId",
                        column: x => x.PlotElementId,
                        principalTable: "PlotElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_Storylines_StorylineId",
                        column: x => x.StorylineId,
                        principalTable: "Storylines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_DiagramId",
                table: "Authors",
                column: "DiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_DiagramId",
                table: "Characters",
                column: "DiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_CharacterId",
                table: "Nodes",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_PlotElementId",
                table: "Nodes",
                column: "PlotElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_StorylineId",
                table: "Nodes",
                column: "StorylineId");

            migrationBuilder.CreateIndex(
                name: "IX_PlotElements_DiagramId",
                table: "PlotElements",
                column: "DiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_Storylines_DiagramId",
                table: "Storylines",
                column: "DiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_DiagramId",
                table: "Tag",
                column: "DiagramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "PlotElements");

            migrationBuilder.DropTable(
                name: "Storylines");

            migrationBuilder.DropTable(
                name: "Diagrams");
        }
    }
}
