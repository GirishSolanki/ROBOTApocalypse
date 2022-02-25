using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ROBOTApocalypse.DB.Migrations
{
    public partial class removeDepdency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurvivorLocation_Survivors_SurvivorId",
                table: "SurvivorLocation");

            migrationBuilder.DropIndex(
                name: "IX_SurvivorLocation_SurvivorId",
                table: "SurvivorLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SurvivorLocation_SurvivorId",
                table: "SurvivorLocation",
                column: "SurvivorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SurvivorLocation_Survivors_SurvivorId",
                table: "SurvivorLocation",
                column: "SurvivorId",
                principalTable: "Survivors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
