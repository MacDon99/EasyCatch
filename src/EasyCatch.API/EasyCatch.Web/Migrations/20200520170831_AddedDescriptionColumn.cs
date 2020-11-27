using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyCatch.API.Migrations
{
    public partial class AddedDescriptionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductToBuy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductToBuy");
        }
    }
}
