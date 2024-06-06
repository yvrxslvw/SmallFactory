using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFactory.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeForProductionRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "production_rate",
                table: "receipts",
                type: "integer",
                nullable: false,
                comment: "Per minute",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "Per minute");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "production_rate",
                table: "receipts",
                type: "double precision",
                nullable: false,
                comment: "Per minute",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Per minute");
        }
    }
}
