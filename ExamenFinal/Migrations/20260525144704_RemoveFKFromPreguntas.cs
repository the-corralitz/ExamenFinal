using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenFinal.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFKFromPreguntas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preguntas_Respuestas_RespuestaId",
                table: "Preguntas");

            migrationBuilder.DropIndex(
                name: "IX_Preguntas_RespuestaId",
                table: "Preguntas");

            migrationBuilder.DropColumn(
                name: "RespuestaId",
                table: "Preguntas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RespuestaId",
                table: "Preguntas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_RespuestaId",
                table: "Preguntas",
                column: "RespuestaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Preguntas_Respuestas_RespuestaId",
                table: "Preguntas",
                column: "RespuestaId",
                principalTable: "Respuestas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
