using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace OngPetCare.infra.Migrations
{
    public partial class cadAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
             * -ID do animal/int
                -Nome do animal/string
                -Raça do animal/string
                -Data de chegada/date
                -Obersavações/string(textarea)
            */
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(maxLength: 256, nullable: true),
                    Raca = table.Column<string>(maxLength: 256, nullable: true),
                    DataChegada = table.Column<DateTime>(nullable: true),
                    Observacoes = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalId", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");
        }
    }
}
