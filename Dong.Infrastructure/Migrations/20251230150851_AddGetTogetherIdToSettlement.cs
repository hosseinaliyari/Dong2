using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dong.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGetTogetherIdToSettlement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GetTogetherId",
                schema: "finance",
                table: "Settlements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GetTogetherId",
                schema: "finance",
                table: "Settlements");
        }
    }
}
