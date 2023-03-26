using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC2nd.Migrations
{
    public partial class ResModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Reservations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Close", "Name", "Open", "Text" },
                values: new object[] { 4, 20, "Product 1", 11, "dsadsd sdasdasd asdasdasd adasdasda sdad" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Close", "Name", "Open", "Text" },
                values: new object[] { 2, 20, "Product 2", 10, "dsadsd sdasdasd asdasdasd adasdasda sdad" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Close", "Name", "Open", "Text" },
                values: new object[] { 3, 20, "Product 3", 9, "dsadsd sdasdasd asdasdasd adasdasda sdad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
