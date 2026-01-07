using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dong.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSettlementUserNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Settlements_FromUserId",
                schema: "finance",
                table: "Settlements",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_ToUserId",
                schema: "finance",
                table: "Settlements",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Users_FromUserId",
                schema: "finance",
                table: "Settlements",
                column: "FromUserId",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Users_ToUserId",
                schema: "finance",
                table: "Settlements",
                column: "ToUserId",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Users_FromUserId",
                schema: "finance",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Users_ToUserId",
                schema: "finance",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_FromUserId",
                schema: "finance",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_ToUserId",
                schema: "finance",
                table: "Settlements");
        }
    }
}
