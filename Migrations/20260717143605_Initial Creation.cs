using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniProjectWeek29.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceDollar = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Country", "CurrencyCode", "Name" },
                values: new object[,]
                {
                    { 1, "USA", "USD", "Austin" },
                    { 2, "Sweden", "SEK", "Sundsvall" },
                    { 3, "Germany", "EUR", "Görlitz" },
                    { 4, "USA", "USD", "Raleigh" },
                    { 5, "UAE", "AED", "Sharjah" },
                    { 6, "Japan", "JPY", "Sendai" }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "Brand", "Discriminator", "Model", "OfficeId", "PriceDollar", "PurchaseDate", "SerialNumber" },
                values: new object[,]
                {
                    { 1, "Lenovo", "Computer", "ThinkPad T14 Gen 5", 1, 1399, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "C001" },
                    { 2, "Apple", "Computer", "MacBook Air M3 13-inch", 2, 1099, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "C002" },
                    { 3, "HP", "Computer", "EliteBook 840 G11", 3, 1499, new DateTime(2026, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "C003" },
                    { 4, "Dell", "Computer", "Latitude 5450", 4, 1249, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "C004" },
                    { 5, "Microsoft", "Computer", "Surface Laptop 7", 5, 1299, new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "C005" },
                    { 6, "ASUS", "Computer", "Zenbook 14 OLED", 6, 1199, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "C006" },
                    { 7, "Acer", "Computer", "TravelMate P4", 1, 999, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "C007" },
                    { 8, "Lenovo", "Computer", "ThinkPad X1 Carbon Gen 12", 2, 1799, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "C008" },
                    { 9, "Apple", "Computer", "MacBook Pro M4 14-inch", 3, 1599, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "C009" },
                    { 10, "HP", "Computer", "ProBook 450 G10", 4, 949, new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "C010" },
                    { 11, "Dell", "Computer", "XPS 13 9340", 5, 1399, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "C011" },
                    { 12, "ASUS", "Computer", "ExpertBook B5", 6, 1099, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "C012" },
                    { 13, "Microsoft", "Computer", "Surface Pro 11", 1, 1199, new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "C013" },
                    { 14, "Acer", "Computer", "Swift Go 14", 2, 899, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "C014" },
                    { 15, "Lenovo", "Computer", "ThinkCentre M90q Gen 5", 3, 1049, new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "C015" },
                    { 16, "Apple", "Computer", "Mac mini M4", 4, 599, new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "C016" },
                    { 17, "HP", "Computer", "ZBook Firefly 14 G11", 5, 1699, new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "C017" },
                    { 18, "Dell", "Computer", "Precision 3590", 6, 1549, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "C018" },
                    { 19, "ASUS", "Computer", "ROG Zephyrus G14", 1, 1599, new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "C019" },
                    { 20, "Lenovo", "Computer", "ThinkPad E14 Gen 5", 2, 849, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "C020" },
                    { 21, "Dell", "Computer", "OptiPlex 7010", 3, 899, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "C021" },
                    { 22, "HP", "Computer", "EliteDesk 800 G6", 4, 1099, new DateTime(2021, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "C022" },
                    { 23, "Apple", "Computer", "MacBook Pro M1 13-inch", 5, 1299, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "C023" },
                    { 24, "Acer", "Computer", "Aspire 5", 6, 699, new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "C024" },
                    { 25, "Microsoft", "Computer", "Surface Laptop Studio 2", 1, 1999, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "C025" },
                    { 26, "Apple", "Smartphone", "iPhone 16", 1, 799, new DateTime(2025, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "S001" },
                    { 27, "Samsung", "Smartphone", "Galaxy S25", 2, 799, new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "S002" },
                    { 28, "Google", "Smartphone", "Pixel 8", 3, 699, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "S003" },
                    { 29, "OnePlus", "Smartphone", "OnePlus 13", 4, 899, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "S004" },
                    { 30, "Sony", "Smartphone", "Xperia 1 VI", 5, 1299, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "S005" },
                    { 31, "Samsung", "Smartphone", "Galaxy A55", 6, 449, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "S006" },
                    { 32, "Apple", "Smartphone", "iPhone 15", 1, 699, new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "S007" },
                    { 33, "Google", "Smartphone", "Pixel 8a", 2, 499, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "S008" },
                    { 34, "Motorola", "Smartphone", "Edge 50 Pro", 3, 649, new DateTime(2023, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "S009" },
                    { 35, "Samsung", "Smartphone", "Galaxy Z Flip6", 4, 1099, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "S010" },
                    { 36, "Apple", "Smartphone", "iPhone 16 Pro", 5, 999, new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "S011" },
                    { 37, "OnePlus", "Smartphone", "OnePlus 12", 6, 799, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "S012" },
                    { 38, "Sony", "Smartphone", "Xperia 5 V", 1, 999, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "S013" },
                    { 39, "Google", "Smartphone", "Pixel 7 Pro", 2, 899, new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "S014" },
                    { 40, "Samsung", "Smartphone", "Galaxy S23", 3, 799, new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "S015" },
                    { 41, "Motorola", "Smartphone", "Moto G85", 4, 399, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "S016" },
                    { 42, "Apple", "Smartphone", "iPhone 14", 5, 699, new DateTime(2021, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "S017" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_OfficeId",
                table: "Assets",
                column: "OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
