using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyCatch.API.Migrations
{
    public partial class AddedPhotoUrlColumnToProductToBuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "ProductToBuy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "ProductToBuy");
        }
    }
}
