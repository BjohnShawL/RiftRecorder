using Microsoft.EntityFrameworkCore.Migrations;

namespace R_R.Database.Migrations
{
    public partial class nullablePowerTagIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MythosThemeId",
                table: "PowerTags",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LogosThemeId",
                table: "PowerTags",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MythosThemeId",
                table: "PowerTags",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LogosThemeId",
                table: "PowerTags",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
