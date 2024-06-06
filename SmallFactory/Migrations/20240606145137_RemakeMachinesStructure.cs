using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFactory.Migrations
{
    /// <inheritdoc />
    public partial class RemakeMachinesStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "input_1_count",
                table: "machines");

            migrationBuilder.DropColumn(
                name: "input_2_count",
                table: "machines");

            migrationBuilder.DropColumn(
                name: "input_3_count",
                table: "machines");

            migrationBuilder.DropColumn(
                name: "input_4_count",
                table: "machines");

            migrationBuilder.DropColumn(
                name: "output_count",
                table: "machines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "input_1_count",
                table: "machines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "input_2_count",
                table: "machines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "input_3_count",
                table: "machines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "input_4_count",
                table: "machines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "output_count",
                table: "machines",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
