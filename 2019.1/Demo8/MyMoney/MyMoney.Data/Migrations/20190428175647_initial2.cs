using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMoney.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Purchases",
                type: "Decimal(2,2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(2,2)");
        }
    }
}
