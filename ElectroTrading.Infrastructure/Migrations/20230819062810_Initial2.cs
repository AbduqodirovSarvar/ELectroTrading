using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroTrading.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 19, 6, 28, 10, 447, DateTimeKind.Utc).AddTicks(2414));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 19, 5, 48, 45, 318, DateTimeKind.Utc).AddTicks(2784));
        }
    }
}
