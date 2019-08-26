using Microsoft.EntityFrameworkCore.Migrations;

namespace R_R.Database.Migrations
{
    public partial class JoinTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogosConcepts_Characters_CharacterId",
                table: "LogosConcepts");

            migrationBuilder.DropForeignKey(
                name: "FK_MythosConcepts_Characters_CharacterId",
                table: "MythosConcepts");

            migrationBuilder.DropIndex(
                name: "IX_MythosConcepts_CharacterId",
                table: "MythosConcepts");

            migrationBuilder.DropIndex(
                name: "IX_LogosConcepts_CharacterId",
                table: "LogosConcepts");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "MythosConcepts");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "LogosConcepts");

            migrationBuilder.DropColumn(
                name: "LogosConceptId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MythosConceptId",
                table: "Characters");

            migrationBuilder.CreateTable(
                name: "CharacterLogoses",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    LogosConceptId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterLogoses", x => new { x.CharacterId, x.LogosConceptId });
                    table.ForeignKey(
                        name: "FK_CharacterLogoses_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterLogoses_LogosConcepts_LogosConceptId",
                        column: x => x.LogosConceptId,
                        principalTable: "LogosConcepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMythoses",
                columns: table => new
                {
                    MythosConceptId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMythoses", x => new { x.CharacterId, x.MythosConceptId });
                    table.ForeignKey(
                        name: "FK_CharacterMythoses_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterMythoses_MythosConcepts_MythosConceptId",
                        column: x => x.MythosConceptId,
                        principalTable: "MythosConcepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterLogoses_LogosConceptId",
                table: "CharacterLogoses",
                column: "LogosConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMythoses_MythosConceptId",
                table: "CharacterMythoses",
                column: "MythosConceptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterLogoses");

            migrationBuilder.DropTable(
                name: "CharacterMythoses");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "MythosConcepts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "LogosConcepts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LogosConceptId",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MythosConceptId",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MythosConcepts_CharacterId",
                table: "MythosConcepts",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogosConcepts_CharacterId",
                table: "LogosConcepts",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LogosConcepts_Characters_CharacterId",
                table: "LogosConcepts",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MythosConcepts_Characters_CharacterId",
                table: "MythosConcepts",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
