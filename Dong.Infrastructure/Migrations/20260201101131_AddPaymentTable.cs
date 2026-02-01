using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dong.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GetTogetherId = table.Column<int>(type: "int", nullable: false),
                    FromUserId = table.Column<int>(type: "int", nullable: false),
                    ToUserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_GetTogethers_GetTogetherId",
                        column: x => x.GetTogetherId,
                        principalSchema: "event",
                        principalTable: "GetTogethers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_GetTogetherId",
                schema: "finance",
                table: "Settlements",
                column: "GetTogetherId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FromUserId",
                table: "Payments",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GetTogetherId",
                table: "Payments",
                column: "GetTogetherId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ToUserId",
                table: "Payments",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_GetTogethers_GetTogetherId",
                schema: "finance",
                table: "Settlements",
                column: "GetTogetherId",
                principalSchema: "event",
                principalTable: "GetTogethers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_GetTogethers_GetTogetherId",
                schema: "finance",
                table: "Settlements");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_GetTogetherId",
                schema: "finance",
                table: "Settlements");
        }
    }
}
