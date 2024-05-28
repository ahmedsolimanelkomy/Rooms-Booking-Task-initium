using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rooms_Booking.Migrations
{
    public partial class editBookingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Bookings",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ApplicationUserId",
                table: "Bookings",
                newName: "IX_Bookings_ApplicationUserID");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationUserID",
                table: "Bookings",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationUserID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Bookings",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ApplicationUserID",
                table: "Bookings",
                newName: "IX_Bookings_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                table: "Bookings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
