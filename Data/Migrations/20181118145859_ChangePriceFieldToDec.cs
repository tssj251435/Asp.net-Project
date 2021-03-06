﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FindGavenCore.Data.Migrations
{
    public partial class ChangePriceFieldToDec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Present",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Present",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
