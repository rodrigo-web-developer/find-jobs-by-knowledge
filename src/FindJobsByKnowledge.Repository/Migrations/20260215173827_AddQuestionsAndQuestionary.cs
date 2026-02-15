using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobsByKnowledge.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionsAndQuestionary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tags = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tag = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Options = table.Column<string>(type: "text", nullable: false),
                    CorrectOptionIndex = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Tag = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DeterminedLevel = table.Column<int>(type: "integer", nullable: false),
                    CorrectPercentage = table.Column<double>(type: "double precision", nullable: false),
                    PercentagePerLevel = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagResults_Questionaries_QuestionaryId",
                        column: x => x.QuestionaryId,
                        principalTable: "Questionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionaryItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    SelectedOptionIndex = table.Column<int>(type: "integer", nullable: true),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionaryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionaryItems_Questionaries_QuestionaryId",
                        column: x => x.QuestionaryId,
                        principalTable: "Questionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionaryItems_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaryItems_QuestionaryId",
                table: "QuestionaryItems",
                column: "QuestionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaryItems_QuestionId",
                table: "QuestionaryItems",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Tag_Level",
                table: "Questions",
                columns: new[] { "Tag", "Level" });

            migrationBuilder.CreateIndex(
                name: "IX_TagResults_QuestionaryId",
                table: "TagResults",
                column: "QuestionaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionaryItems");

            migrationBuilder.DropTable(
                name: "TagResults");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Questionaries");
        }
    }
}
