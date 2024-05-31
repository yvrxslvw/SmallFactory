using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFactory.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMachines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_machines_storages_storage_id",
                table: "machines");

            migrationBuilder.RenameColumn(
                name: "storage_id",
                table: "machines",
                newName: "StorageId");

            migrationBuilder.RenameIndex(
                name: "IX_machines_storage_id",
                table: "machines",
                newName: "IX_machines_StorageId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_machines_storages_StorageId",
                table: "machines",
                column: "StorageId",
                principalTable: "storages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_machines_storages_StorageId",
                table: "machines");

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

            migrationBuilder.RenameColumn(
                name: "StorageId",
                table: "machines",
                newName: "storage_id");

            migrationBuilder.RenameIndex(
                name: "IX_machines_StorageId",
                table: "machines",
                newName: "IX_machines_storage_id");

            migrationBuilder.AddForeignKey(
                name: "FK_machines_storages_storage_id",
                table: "machines",
                column: "storage_id",
                principalTable: "storages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
