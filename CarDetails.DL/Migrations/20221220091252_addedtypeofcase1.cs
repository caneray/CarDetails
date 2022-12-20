using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDetails.DL.Migrations
{
    public partial class addedtypeofcase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfCase",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "CaseTypeId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Car_CaseTypeId",
                table: "Car",
                column: "CaseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_CaseType_CaseTypeId",
                table: "Car",
                column: "CaseTypeId",
                principalTable: "CaseType",
                principalColumn: "CaseTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_CaseType_CaseTypeId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_CaseTypeId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "CaseTypeId",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfCase",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
