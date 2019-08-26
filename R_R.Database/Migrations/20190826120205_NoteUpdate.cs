using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace R_R.Database.Migrations
{
    public partial class NoteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogosThemes_Identities_IdentityId",
                table: "LogosThemes");

            migrationBuilder.DropForeignKey(
                name: "FK_MythosThemes_Rifts_RiftId",
                table: "MythosThemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_UserId1",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Identities");

            migrationBuilder.DropTable(
                name: "Rifts");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserId1",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "RiftId",
                table: "MythosThemes",
                newName: "MythosConceptId");

            migrationBuilder.RenameIndex(
                name: "IX_MythosThemes_RiftId",
                table: "MythosThemes",
                newName: "IX_MythosThemes_MythosConceptId");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "LogosThemes",
                newName: "LogosConceptId");

            migrationBuilder.RenameIndex(
                name: "IX_LogosThemes_IdentityId",
                table: "LogosThemes",
                newName: "IX_LogosThemes_LogosConceptId");

            migrationBuilder.RenameColumn(
                name: "RiftId",
                table: "Characters",
                newName: "MythosConceptId");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "Characters",
                newName: "LogosConceptId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Notes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Mystery",
                table: "MythosThemes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Identity",
                table: "LogosThemes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LogosConcepts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogosConcepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogosConcepts_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MythosConcepts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MythosConcepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MythosConcepts_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LogosConcepts_CharacterId",
                table: "LogosConcepts",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MythosConcepts_CharacterId",
                table: "MythosConcepts",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LogosThemes_LogosConcepts_LogosConceptId",
                table: "LogosThemes",
                column: "LogosConceptId",
                principalTable: "LogosConcepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MythosThemes_MythosConcepts_MythosConceptId",
                table: "MythosThemes",
                column: "MythosConceptId",
                principalTable: "MythosConcepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogosThemes_LogosConcepts_LogosConceptId",
                table: "LogosThemes");

            migrationBuilder.DropForeignKey(
                name: "FK_MythosThemes_MythosConcepts_MythosConceptId",
                table: "MythosThemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_UserId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "LogosConcepts");

            migrationBuilder.DropTable(
                name: "MythosConcepts");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Mystery",
                table: "MythosThemes");

            migrationBuilder.DropColumn(
                name: "Identity",
                table: "LogosThemes");

            migrationBuilder.RenameColumn(
                name: "MythosConceptId",
                table: "MythosThemes",
                newName: "RiftId");

            migrationBuilder.RenameIndex(
                name: "IX_MythosThemes_MythosConceptId",
                table: "MythosThemes",
                newName: "IX_MythosThemes_RiftId");

            migrationBuilder.RenameColumn(
                name: "LogosConceptId",
                table: "LogosThemes",
                newName: "IdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_LogosThemes_LogosConceptId",
                table: "LogosThemes",
                newName: "IX_LogosThemes_IdentityId");

            migrationBuilder.RenameColumn(
                name: "MythosConceptId",
                table: "Characters",
                newName: "RiftId");

            migrationBuilder.RenameColumn(
                name: "LogosConceptId",
                table: "Characters",
                newName: "IdentityId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Notes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Notes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Identities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identities_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    Mystery = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rifts_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId1",
                table: "Notes",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Identities_CharacterId",
                table: "Identities",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rifts_CharacterId",
                table: "Rifts",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LogosThemes_Identities_IdentityId",
                table: "LogosThemes",
                column: "IdentityId",
                principalTable: "Identities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MythosThemes_Rifts_RiftId",
                table: "MythosThemes",
                column: "RiftId",
                principalTable: "Rifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_UserId1",
                table: "Notes",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
