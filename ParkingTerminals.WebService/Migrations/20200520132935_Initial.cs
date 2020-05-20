using Microsoft.EntityFrameworkCore.Migrations;

namespace MoscowTransport.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingTerminals",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumberParkingZone = table.Column<string>(nullable: true),
                    NamePark = table.Column<string>(nullable: true),
                    AdmDistrict = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTerminals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkingTerminals",
                columns: new[] { "Id", "AdmDistrict", "District", "Location", "NamePark", "NumberParkingZone", "Street" },
                values: new object[] { 1L, "Северный административный округ", "Северный", "улица Авиаконструктора Яковлева,дом 27,корпус 2", "Паркомат № 2071", "4014", "улица Авиаконструктора Яковлева" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingTerminals");
        }
    }
}
