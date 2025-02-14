using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Booking_BookingId1",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_BookingId1",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "BookingId1",
                table: "Payment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BookingId1",
                table: "Payment",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BookingId1",
                table: "Payment",
                column: "BookingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Booking_BookingId1",
                table: "Payment",
                column: "BookingId1",
                principalTable: "Booking",
                principalColumn: "BookingId");
        }
    }
}
