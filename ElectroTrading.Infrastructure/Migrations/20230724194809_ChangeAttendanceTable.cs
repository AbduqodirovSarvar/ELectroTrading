using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroTrading.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAttendanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExtraWork",
                table: "Attendances");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 19, 48, 9, 304, DateTimeKind.Utc).AddTicks(8565));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExtraWork",
                table: "Attendances",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 16, 43, 0, 180, DateTimeKind.Utc).AddTicks(3265));
        }
    }
}
