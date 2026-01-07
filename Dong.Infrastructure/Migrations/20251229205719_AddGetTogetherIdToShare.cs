using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dong.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGetTogetherIdToShare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shares_Users_UserId",
                schema: "finance",
                table: "Shares");

            migrationBuilder.AddColumn<int>(
                name: "GetTogetherId",
                schema: "finance",
                table: "Shares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shares_GetTogetherId",
                schema: "finance",
                table: "Shares",
                column: "GetTogetherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_GetTogethers_GetTogetherId",
                schema: "finance",
                table: "Shares",
                column: "GetTogetherId",
                principalSchema: "event",
                principalTable: "GetTogethers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_Users_UserId",
                schema: "finance",
                table: "Shares",
                column: "UserId",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shares_GetTogethers_GetTogetherId",
                schema: "finance",
                table: "Shares");

            migrationBuilder.DropForeignKey(
                name: "FK_Shares_Users_UserId",
                schema: "finance",
                table: "Shares");

            migrationBuilder.DropIndex(
                name: "IX_Shares_GetTogetherId",
                schema: "finance",
                table: "Shares");

            migrationBuilder.DropColumn(
                name: "GetTogetherId",
                schema: "finance",
                table: "Shares");

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_Users_UserId",
                schema: "finance",
                table: "Shares",
                column: "UserId",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
