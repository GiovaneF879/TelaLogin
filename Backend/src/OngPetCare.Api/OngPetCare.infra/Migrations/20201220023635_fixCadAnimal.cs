using Microsoft.EntityFrameworkCore.Migrations;

namespace OngPetCare.infra.Migrations
{
    public partial class fixCadAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("Animal", null, "Animals", null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("Animals", null, "Animal", null);
        }
    }
}
