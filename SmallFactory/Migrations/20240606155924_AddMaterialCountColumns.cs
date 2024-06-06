using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFactory.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialCountColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "material_1_count",
                table: "receipts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "material_2_count",
                table: "receipts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "material_3_count",
                table: "receipts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "material_4_count",
                table: "receipts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "material_1_count",
                table: "receipts");

            migrationBuilder.DropColumn(
                name: "material_2_count",
                table: "receipts");

            migrationBuilder.DropColumn(
                name: "material_3_count",
                table: "receipts");

            migrationBuilder.DropColumn(
                name: "material_4_count",
                table: "receipts");
        }
    }
}
