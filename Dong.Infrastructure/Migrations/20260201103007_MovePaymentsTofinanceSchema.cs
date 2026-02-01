using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dong.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovePaymentsTofinanceSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_GetTogethers_GetTogetherId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_FromUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_ToUserId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment",
                newSchema: "finance");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_ToUserId",
                schema: "finance",
                table: "Payment",
                newName: "IX_Payment_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_GetTogetherId",
                schema: "finance",
                table: "Payment",
                newName: "IX_Payment_GetTogetherId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_FromUserId",
                schema: "finance",
                table: "Payment",
                newName: "IX_Payment_FromUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                schema: "finance",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_GetTogethers_GetTogetherId",
                schema: "finance",
                table: "Payment",
                column: "GetTogetherId",
                principalSchema: "event",
                principalTable: "GetTogethers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Users_FromUserId",
                schema: "finance",
                table: "Payment",
                column: "FromUserId",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Users_ToUserId",
                schema: "finance",
                table: "Payment",
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
                name: "FK_Payment_GetTogethers_GetTogetherId",
                schema: "finance",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Users_FromUserId",
                schema: "finance",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Users_ToUserId",
                schema: "finance",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                schema: "finance",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                schema: "finance",
                newName: "Payments");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_ToUserId",
                table: "Payments",
                newName: "IX_Payments_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_GetTogetherId",
                table: "Payments",
                newName: "IX_Payments_GetTogetherId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_FromUserId",
                table: "Payments",
                newName: "IX_Payments_FromUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_GetTogethers_GetTogetherId",
                table: "Payments",
                column: "GetTogetherId",
                principalSchema: "event",
                principalTable: "GetTogethers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_FromUserId",
                table: "Payments",
                column: "FromUserId",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_ToUserId",
                table: "Payments",
                column: "ToUserId",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
