using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Battler.Migrations
{
    public partial class CharacterSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "HP", "Name", "Strength" },
                values: new object[] { 1, 50, "Jerry", 50 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "HP", "Name", "Strength" },
                values: new object[] { 2, 25, "Larry", 75 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "HP", "Name", "Strength" },
                values: new object[] { 3, 75, "Gary", 25 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
