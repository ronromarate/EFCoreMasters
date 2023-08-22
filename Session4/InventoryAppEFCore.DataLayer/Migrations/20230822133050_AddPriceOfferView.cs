using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class AddPriceOfferView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddViewViaSql<PriceOffer>("PriceOfferView", "PriceOffers", "NewPrice > 300");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
