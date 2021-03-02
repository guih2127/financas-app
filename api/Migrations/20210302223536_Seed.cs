using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "DataCriacao", "Nome", "Status" },
                values: new object[] { 1, new DateTime(2021, 3, 2, 19, 35, 36, 415, DateTimeKind.Local).AddTicks(9964), "Pokémon TCG", 1 });

            migrationBuilder.InsertData(
                table: "Operacoes",
                columns: new[] { "Id", "CategoriaOperacaoId", "DataCriacao", "Descricao", "Nome", "Status", "TipoOperacao", "Valor" },
                values: new object[] { 1, 1, new DateTime(2021, 3, 2, 19, 35, 36, 417, DateTimeKind.Local).AddTicks(6260), null, "Cartas Pokémon TCG", 1, 2, 100.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Operacoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
