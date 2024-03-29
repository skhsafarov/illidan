using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    Attempts = table.Column<int>(type: "integer", nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    СounteragentId = table.Column<int>(type: "integer", nullable: true),
                    FromCurrency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ToCurrency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OwnedAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    RequiredAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    OwnerDestinationCard = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    СounteragentDestinationCard = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Users_СounteragentId",
                        column: x => x.СounteragentId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Queues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ImageLink = table.Column<string>(type: "text", nullable: true),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    LastAnimal = table.Column<int>(type: "integer", nullable: false),
                    LastColor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queues_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueueTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    QueueId = table.Column<int>(type: "integer", nullable: false),
                    Animal = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueueTokens_Queues_QueueId",
                        column: x => x.QueueId,
                        principalTable: "Queues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QueueTokens_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Attempts", "Code", "Expiration", "FirstName", "LastName", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, 10, null, new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8265), "John", "Doe", "+79123456789", "Admin" },
                    { 2, 10, null, new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8274), "Jane", "Smith", "+79012345678", "User" },
                    { 3, 10, null, new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8275), "Alex", "Johnson", "+79123456780", "User" },
                    { 4, 10, null, new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8275), "Sarah", "Williams", "+79012345670", "User" },
                    { 5, 10, null, new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8276), "Michael", "Brown", "+79123456760", "User" },
                    { 6, 10, null, new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8277), "Emily", "Davis", "+79012345650", "User" },
                    { 7, 10, null, new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8278), "David", "Miller", "+79123456740", "User" },
                    { 8, 10, null, new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8278), "Emma", "Anderson", "+79012345630", "User" },
                    { 9, 10, null, new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8279), "Daniel", "Wilson", "+79123456720", "User" },
                    { 10, 10, null, new DateTime(2023, 5, 20, 20, 6, 38, 850, DateTimeKind.Utc).AddTicks(8280), "Olivia", "Taylor", "+79012345610", "User" }
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "CreatedAt", "FromCurrency", "OwnedAmount", "OwnerDestinationCard", "OwnerId", "RequiredAmount", "Status", "ToCurrency", "UpdatedAt", "СounteragentDestinationCard", "СounteragentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8473), "RUB", 1000m, "1234567890123456", 1, 150000m, "Active", "UZS", new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8482), "9876543210987654", 2 },
                    { 2, new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8483), "UZS", 200000m, "9876543210987654", 2, 2000m, "Active", "RUB", new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8484), "1234567890123456", 1 },
                    { 3, new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8485), "RUB", 500m, "2345678901234567", 3, 75000m, "Active", "UZS", new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8486), null, null },
                    { 4, new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8487), "RUB", 3000m, "3456789012345678", 4, 450000m, "Active", "UZS", new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8487), "8765432109876543", 5 },
                    { 5, new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8488), "UZS", 1000000m, "8765432109876543", 5, 10000m, "Active", "RUB", new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8488), "3456789012345678", 4 },
                    { 6, new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8490), "RUB", 200m, "4567890123456789", 6, 30000m, "Active", "UZS", new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8490), null, null },
                    { 7, new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8491), "RUB", 8000m, "5678901234567890", 7, 1200000m, "Active", "UZS", new DateTime(2023, 5, 20, 23, 3, 38, 850, DateTimeKind.Local).AddTicks(8491), "7654321098765432", 8 }
                });

            migrationBuilder.InsertData(
                table: "Queues",
                columns: new[] { "Id", "Count", "ImageLink", "LastAnimal", "LastColor", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, 0, "https://is4-ssl.mzstatic.com/image/thumb/Purple113/v4/c6/87/aa/c687aa88-9688-1d00-b150-af95049dcf6b/pr_source.png/643x0w.jpg", 0, 0, "Стоматолог", 1 },
                    { 2, 0, "https://example.com/fitnes.jpg", 0, 0, "Фитнес", 2 },
                    { 3, 0, "https://example.com/parikmaherskaya.jpg", 0, 0, "Парикмахерская", 3 },
                    { 4, 0, "https://example.com/cafe.jpg", 0, 0, "Кафе", 4 },
                    { 5, 0, "https://example.com/autoservice.jpg", 0, 0, "Автосервис", 5 },
                    { 6, 0, "https://example.com/shop.jpg", 0, 0, "Магазин", 6 },
                    { 7, 0, "https://example.com/bank.jpg", 0, 0, "Банк", 7 },
                    { 8, 0, "https://example.com/pharmacy.jpg", 0, 0, "Аптека", 8 },
                    { 9, 0, "https://example.com/theater.jpg", 0, 0, "Театр", 9 },
                    { 10, 0, "https://example.com/post.jpg", 0, 0, "Почта", 10 }
                });

            migrationBuilder.InsertData(
                table: "QueueTokens",
                columns: new[] { "Id", "Animal", "Color", "OwnerId", "QueueId" },
                values: new object[,]
                {
                    { 1, 0, 0, 1, 1 },
                    { 2, 1, 1, 2, 1 },
                    { 3, 2, 2, 3, 1 },
                    { 4, 3, 3, 4, 1 },
                    { 5, 4, 4, 5, 2 },
                    { 6, 5, 5, 6, 2 },
                    { 7, 6, 6, 7, 2 },
                    { 8, 7, 7, 8, 3 },
                    { 9, 8, 8, 9, 3 },
                    { 10, 9, 9, 10, 3 },
                    { 11, 10, 10, 1, 3 },
                    { 12, 11, 0, 2, 3 },
                    { 13, 12, 1, 3, 4 },
                    { 14, 13, 2, 4, 5 },
                    { 15, 14, 3, 5, 7 },
                    { 16, 15, 4, 6, 8 },
                    { 17, 16, 5, 7, 9 },
                    { 18, 17, 6, 8, 9 },
                    { 19, 18, 7, 9, 10 },
                    { 20, 19, 8, 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_СounteragentId",
                table: "Bids",
                column: "СounteragentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_OwnerId",
                table: "Bids",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_OwnerId",
                table: "Queues",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_QueueTokens_OwnerId",
                table: "QueueTokens",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_QueueTokens_QueueId",
                table: "QueueTokens",
                column: "QueueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "QueueTokens");

            migrationBuilder.DropTable(
                name: "Queues");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
