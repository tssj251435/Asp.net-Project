using Microsoft.EntityFrameworkCore.Migrations;

namespace FindGavenCore.Data.Migrations
{
    public partial class AddPresentRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Present",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Present");
        }
    }
}
