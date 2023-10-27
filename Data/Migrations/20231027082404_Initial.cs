using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CardDetails = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    SocialSecurity = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PokemonId = table.Column<int>(type: "integer", nullable: false),
                    CustomerInformationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerInformation_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemon_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PokemonStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Experience = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PokemonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonStats_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CardDetails", "CustomerInformationId", "Email", "OrderDate", "PokemonId", "SocialSecurity" },
                values: new object[] { 1, "1234567891234567", 0, "a@gmail.com", new DateTime(2023, 10, 27, 8, 24, 4, 680, DateTimeKind.Utc).AddTicks(2920), 1, "1234567891" });

            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "Id", "Name", "OrderId", "Url" },
                values: new object[] { 1, "Bulbasaur", null, "https://pokeapi.co/api/v2/pokemon/1" });

            migrationBuilder.InsertData(
                table: "CustomerInformation",
                columns: new[] { "Id", "Address", "Country", "OrderId" },
                values: new object[] { 1, "etstedidanmark", "Denmark", 1 });

            migrationBuilder.InsertData(
                table: "PokemonStats",
                columns: new[] { "Id", "Description", "Experience", "Height", "PokemonId", "Weight" },
                values: new object[] { 1, "A grass and poison type Pokémon.", 64, 7, 1, 69 });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInformation_OrderId",
                table: "CustomerInformation",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_OrderId",
                table: "Pokemon",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonStats_PokemonId",
                table: "PokemonStats",
                column: "PokemonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInformation");

            migrationBuilder.DropTable(
                name: "PokemonStats");

            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
