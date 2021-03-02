using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class SeedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2021, 3, 2, 20, 6, 39, 872, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "Operacoes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataCriacao", "Descricao" },
                values: new object[] { new DateTime(2021, 3, 2, 20, 6, 39, 874, DateTimeKind.Local).AddTicks(2805), "Compra de cartas avulsas de pokémon." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2021, 3, 2, 19, 35, 36, 415, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "Operacoes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataCriacao", "Descricao" },
                values: new object[] { new DateTime(2021, 3, 2, 19, 35, 36, 417, DateTimeKind.Local).AddTicks(6260), null });
        }
    }
}
