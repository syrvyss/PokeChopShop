using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ManytoManyPokemonRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Order_OrderId",
                table: "Pokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_OrderId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "OrderPokemon",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "integer", nullable: false),
                    PokemonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPokemon", x => new { x.OrdersId, x.PokemonId });
                    table.ForeignKey(
                        name: "FK_OrderPokemon_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPokemon_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 9, 9, 52, 1, 364, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.CreateIndex(
                name: "IX_OrderPokemon_PokemonId",
                table: "OrderPokemon",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPokemon");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Pokemon",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonId",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderDate", "PokemonId" },
                values: new object[] { new DateTime(2023, 11, 8, 21, 23, 26, 88, DateTimeKind.Utc).AddTicks(8940), 1 });

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_OrderId",
                table: "Pokemon",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Order_OrderId",
                table: "Pokemon",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
