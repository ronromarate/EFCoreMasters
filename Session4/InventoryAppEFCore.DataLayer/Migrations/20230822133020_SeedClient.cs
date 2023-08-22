using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class SeedClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientKey", "IsDeleted", "Name" },
                values: new object[] { 1, false, "Client 1" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientKey", "IsDeleted", "Name" },
                values: new object[] { 2, false, "Client 2" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientKey", "IsDeleted", "Name" },
                values: new object[] { 3, true, "Client 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientKey",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientKey",
                keyValue: 3);
        }
    }
}
