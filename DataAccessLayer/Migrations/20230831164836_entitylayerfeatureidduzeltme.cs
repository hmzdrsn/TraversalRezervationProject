using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class entitylayerfeatureidduzeltme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Feature2ID",
                table: "Features",
                newName: "FeatureID");

            migrationBuilder.RenameColumn(
                name: "FeatureID",
                table: "Feature2s",
                newName: "Feature2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeatureID",
                table: "Features",
                newName: "Feature2ID");

            migrationBuilder.RenameColumn(
                name: "Feature2ID",
                table: "Feature2s",
                newName: "FeatureID");
        }
    }
}
