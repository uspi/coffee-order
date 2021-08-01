using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeOrderId = table.Column<long>(type: "bigint", nullable: true),
                    CoffeeType = table.Column<int>(type: "int", nullable: false),
                    CoffeeVolume = table.Column<int>(type: "int", nullable: false),
                    HasMilk = table.Column<bool>(type: "bit", nullable: false),
                    HasSugar = table.Column<bool>(type: "bit", nullable: false),
                    HasCupCap = table.Column<bool>(type: "bit", nullable: false),
                    QuantitySugarTeaspoons = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variations_Orders_CoffeeOrderId",
                        column: x => x.CoffeeOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Variations_CoffeeOrderId",
                table: "Variations",
                column: "CoffeeOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variations");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
