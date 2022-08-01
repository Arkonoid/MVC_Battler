using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Battler.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combatants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Toughness = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combatants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Combatants",
                columns: new[] { "Id", "Discriminator", "HP", "Name", "Strength", "Toughness" },
                values: new object[] { 1, "Player", 100, "Jerry", 20, 10 });

            migrationBuilder.InsertData(
                table: "Combatants",
                columns: new[] { "Id", "Discriminator", "HP", "Name", "Strength", "Toughness" },
                values: new object[] { 2, "Player", 80, "Larry", 40, 5 });

            migrationBuilder.InsertData(
                table: "Combatants",
                columns: new[] { "Id", "Discriminator", "HP", "Name", "Strength", "Toughness" },
                values: new object[] { 3, "Player", 120, "Gary", 15, 12 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combatants");
        }
    }
}
