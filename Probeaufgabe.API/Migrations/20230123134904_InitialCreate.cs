using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Probeaufgabe.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deviceTypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    failsafe = table.Column<bool>(type: "bit", nullable: false),
                    tempMin = table.Column<int>(type: "int", nullable: false),
                    tempMax = table.Column<int>(type: "int", nullable: false),
                    installationPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    insertInto19InchCabinet = table.Column<bool>(type: "bit", nullable: false),
                    motionEnable = table.Column<bool>(type: "bit", nullable: false),
                    siplusCatalog = table.Column<bool>(type: "bit", nullable: false),
                    simaticCatalog = table.Column<bool>(type: "bit", nullable: false),
                    rotationAxisNumber = table.Column<int>(type: "int", nullable: false),
                    positionAxisNumber = table.Column<int>(type: "int", nullable: false),
                    advancedEnvironmentalConditions = table.Column<bool>(type: "bit", nullable: true),
                    terminalElement = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
