using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class UpdateSupplierTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Suppliers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonFirstName",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonLastName",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Suppliers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonFullName",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[ContactPersonLastName] + ', ' + [ContactPersonFirstName]");

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[Name] + ' (' + [Description] + ')'",
                stored: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPersonFullName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ContactPersonFirstName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ContactPersonLastName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Suppliers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Suppliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
