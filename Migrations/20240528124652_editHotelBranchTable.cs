using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rooms_Booking.Migrations
{
    public partial class editHotelBranchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelBranchID",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelBranchID",
                table: "Rooms",
                column: "HotelBranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HotelBranches_HotelBranchID",
                table: "Rooms",
                column: "HotelBranchID",
                principalTable: "HotelBranches",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HotelBranches_HotelBranchID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelBranchID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HotelBranchID",
                table: "Rooms");
        }
    }
}
