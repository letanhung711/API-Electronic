using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Electronic.Migrations
{
    public partial class UpdateUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
