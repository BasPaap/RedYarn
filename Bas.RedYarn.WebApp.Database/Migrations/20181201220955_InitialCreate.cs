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
                    Id = table.Column<string>(nullable: false)
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
                    Id = table.Column<string>(nullable: false),
                    DiagramId = table.Column<string>(nullable: true)
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
                    Id = table.Column<string>(nullable: false),
                    DiagramId = table.Column<string>(nullable: true)
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
                    Id = table.Column<string>(nullable: false),
                    DiagramId = table.Column<string>(nullable: true)
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
                    Id = table.Column<string>(nullable: false),
                    DiagramId = table.Column<string>(nullable: true)
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
                name: "Tags",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    DiagramId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Diagrams_DiagramId",
                        column: x => x.DiagramId,
                        principalTable: "Diagrams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aliases",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    CharacterId = table.Column<string>(nullable: true),
                    DiagramId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aliases_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aliases_Diagrams_DiagramId",
                        column: x => x.DiagramId,
                        principalTable: "Diagrams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAuthor",
                columns: table => new
                {
                    LeftEntityId = table.Column<string>(nullable: false),
                    RightEntityId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAuthor", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_CharacterAuthor_Characters_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterAuthor_Authors_RightEntityId",
                        column: x => x.RightEntityId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    FirstCharacterId = table.Column<string>(nullable: false),
                    SecondCharacterId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsDirectional = table.Column<bool>(nullable: false),
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relationships_Characters_FirstCharacterId",
                        column: x => x.FirstCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relationships_Characters_SecondCharacterId",
                        column: x => x.SecondCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterStoryline",
                columns: table => new
                {
                    LeftEntityId = table.Column<string>(nullable: false),
                    RightEntityId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterStoryline", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_CharacterStoryline_Characters_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterStoryline_Storylines_RightEntityId",
                        column: x => x.RightEntityId,
                        principalTable: "Storylines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    XPosition = table.Column<float>(nullable: false),
                    YPosition = table.Column<float>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CharacterId = table.Column<string>(nullable: true),
                    PlotElementId = table.Column<string>(nullable: true),
                    StorylineId = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "StorylineAuthor",
                columns: table => new
                {
                    LeftEntityId = table.Column<string>(nullable: false),
                    RightEntityId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorylineAuthor", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_StorylineAuthor_Storylines_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalTable: "Storylines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorylineAuthor_Authors_RightEntityId",
                        column: x => x.RightEntityId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorylinePlotElement",
                columns: table => new
                {
                    LeftEntityId = table.Column<string>(nullable: false),
                    RightEntityId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorylinePlotElement", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_StorylinePlotElement_Storylines_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalTable: "Storylines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorylinePlotElement_PlotElements_RightEntityId",
                        column: x => x.RightEntityId,
                        principalTable: "PlotElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTag",
                columns: table => new
                {
                    LeftEntityId = table.Column<string>(nullable: false),
                    RightEntityId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTag", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_CharacterTag_Characters_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTag_Tags_RightEntityId",
                        column: x => x.RightEntityId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aliases_CharacterId",
                table: "Aliases",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Aliases_DiagramId",
                table: "Aliases",
                column: "DiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_DiagramId",
                table: "Authors",
                column: "DiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAuthor_RightEntityId",
                table: "CharacterAuthor",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_DiagramId",
                table: "Characters",
                column: "DiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStoryline_RightEntityId",
                table: "CharacterStoryline",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTag_RightEntityId",
                table: "CharacterTag",
                column: "RightEntityId");

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
                name: "IX_Relationships_FirstCharacterId",
                table: "Relationships",
                column: "FirstCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_SecondCharacterId",
                table: "Relationships",
                column: "SecondCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_StorylineAuthor_RightEntityId",
                table: "StorylineAuthor",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StorylinePlotElement_RightEntityId",
                table: "StorylinePlotElement",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Storylines_DiagramId",
                table: "Storylines",
                column: "DiagramId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_DiagramId",
                table: "Tags",
                column: "DiagramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliases");

            migrationBuilder.DropTable(
                name: "CharacterAuthor");

            migrationBuilder.DropTable(
                name: "CharacterStoryline");

            migrationBuilder.DropTable(
                name: "CharacterTag");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "StorylineAuthor");

            migrationBuilder.DropTable(
                name: "StorylinePlotElement");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Storylines");

            migrationBuilder.DropTable(
                name: "PlotElements");

            migrationBuilder.DropTable(
                name: "Diagrams");
        }
    }
}
