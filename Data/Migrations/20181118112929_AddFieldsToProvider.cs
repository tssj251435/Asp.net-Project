using Microsoft.EntityFrameworkCore.Migrations;

namespace FindGavenCore.Data.Migrations
{
    public partial class AddFieldsToProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Provider",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Provider");
        }
    }
}
