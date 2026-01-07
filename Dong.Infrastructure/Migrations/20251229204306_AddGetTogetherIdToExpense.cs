using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dong.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGetTogetherIdToExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                schema: "finance",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "GetTogetherId",
                schema: "finance",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_GetTogetherId",
                schema: "finance",
                table: "Expenses",
                column: "GetTogetherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_GetTogethers_GetTogetherId",
                schema: "finance",
                table: "Expenses",
                column: "GetTogetherId",
                principalSchema: "event",
                principalTable: "GetTogethers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                schema: "finance",
                table: "Expenses",
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
                name: "FK_Expenses_GetTogethers_GetTogetherId",
                schema: "finance",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                schema: "finance",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_GetTogetherId",
                schema: "finance",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "GetTogetherId",
                schema: "finance",
                table: "Expenses");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                schema: "finance",
                table: "Expenses",
                column: "UserId",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
