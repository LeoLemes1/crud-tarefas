using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasCRUD.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoDataCriacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CriacaoAt",
                table: "Tarefas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriacaoAt",
                table: "Tarefas");
        }
    }
}
