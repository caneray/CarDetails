using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDetails.DL.Migrations
{
    public partial class packagename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PackegeName",
                table: "Car",
                newName: "PackageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PackageName",
                table: "Car",
                newName: "PackegeName");
        }
    }
}
