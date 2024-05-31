using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFactory.Migrations
{
    /// <inheritdoc />
    public partial class MakeUniqueFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_production_chains_name",
                table: "production_chains",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_parts_name",
                table: "parts",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_factories_name",
                table: "factories",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_production_chains_name",
                table: "production_chains");

            migrationBuilder.DropIndex(
                name: "IX_parts_name",
                table: "parts");

            migrationBuilder.DropIndex(
                name: "IX_factories_name",
                table: "factories");
        }
    }
}
