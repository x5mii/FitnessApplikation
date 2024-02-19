using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApplikation.Migrations
{
    /// <inheritdoc />
    public partial class FitnessDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainingsplan",
                columns: table => new
                {
                    TrainingsplanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainingsplan", x => x.TrainingsplanID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainingsplan");
        }
    }
}
