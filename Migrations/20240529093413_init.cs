using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rooms_Booking.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasBookedPreviously = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelBranches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBranches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountApplied = table.Column<bool>(type: "bit", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    HotelBranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bookings_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_HotelBranches_HotelBranchID",
                        column: x => x.HotelBranchID,
                        principalTable: "HotelBranches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfChilderns = table.Column<int>(type: "int", nullable: false),
                    RoomTypeID = table.Column<int>(type: "int", nullable: false),
                    HotelBranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_HotelBranches_HotelBranchID",
                        column: x => x.HotelBranchID,
                        principalTable: "HotelBranches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingRoom",
                columns: table => new
                {
                    BookingsID = table.Column<int>(type: "int", nullable: false),
                    RoomsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRoom", x => new { x.BookingsID, x.RoomsID });
                    table.ForeignKey(
                        name: "FK_BookingRoom_Bookings_BookingsID",
                        column: x => x.BookingsID,
                        principalTable: "Bookings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRoom_Rooms_RoomsID",
                        column: x => x.RoomsID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoom_RoomsID",
                table: "BookingRoom",
                column: "RoomsID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerID",
                table: "Bookings",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelBranchID",
                table: "Bookings",
                column: "HotelBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelBranchID",
                table: "Rooms",
                column: "HotelBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeID",
                table: "Rooms",
                column: "RoomTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRoom");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "HotelBranches");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
