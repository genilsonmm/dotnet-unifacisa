using Microsoft.EntityFrameworkCore.Migrations;

namespace EFAppContact.WEB.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "contacts",
                type: "varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "contacts",
                type: "varchar(60)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)");
        }
    }
}
