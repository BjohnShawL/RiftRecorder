using Microsoft.EntityFrameworkCore.Migrations;

namespace R_R.Database.Migrations
{
    public partial class nullableStoryTagIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "StoryTags",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "StoryTags",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
