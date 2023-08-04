using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroTrading.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhotoTableImproved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 20, 0, 58, 527, DateTimeKind.Utc).AddTicks(4232));

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 4, 20, 51, 137, DateTimeKind.Utc).AddTicks(7145));

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId");
        }
    }
}
