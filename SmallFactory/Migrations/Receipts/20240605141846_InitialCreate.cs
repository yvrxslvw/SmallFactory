using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmallFactory.Migrations.Receipts
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    production_type = table.Column<int>(type: "integer", nullable: false),
                    manufactured_part_id = table.Column<int>(type: "integer", nullable: false),
                    material_1_part_id = table.Column<int>(type: "integer", nullable: false),
                    material_2_part_id = table.Column<int>(type: "integer", nullable: false),
                    material_3_part_id = table.Column<int>(type: "integer", nullable: false),
                    material_4_part_id = table.Column<int>(type: "integer", nullable: false),
                    production_rate = table.Column<double>(type: "double precision", nullable: false, comment: "Per minute")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipts", x => x.id);
                    table.ForeignKey(
                        name: "FK_receipts_parts_manufactured_part_id",
                        column: x => x.manufactured_part_id,
                        principalTable: "parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receipts_parts_material_1_part_id",
                        column: x => x.material_1_part_id,
                        principalTable: "parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receipts_parts_material_2_part_id",
                        column: x => x.material_2_part_id,
                        principalTable: "parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receipts_parts_material_3_part_id",
                        column: x => x.material_3_part_id,
                        principalTable: "parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receipts_parts_material_4_part_id",
                        column: x => x.material_4_part_id,
                        principalTable: "parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shop",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    part_id = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    cooldown = table.Column<int>(type: "integer", nullable: false),
                    last_replineshment = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop", x => x.id);
                    table.ForeignKey(
                        name: "FK_shop_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_parts_name",
                table: "parts",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_receipts_manufactured_part_id",
                table: "receipts",
                column: "manufactured_part_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_material_1_part_id",
                table: "receipts",
                column: "material_1_part_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_material_2_part_id",
                table: "receipts",
                column: "material_2_part_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_material_3_part_id",
                table: "receipts",
                column: "material_3_part_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_material_4_part_id",
                table: "receipts",
                column: "material_4_part_id");

            migrationBuilder.CreateIndex(
                name: "IX_shop_part_id",
                table: "shop",
                column: "part_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receipts");

            migrationBuilder.DropTable(
                name: "shop");

            migrationBuilder.DropTable(
                name: "parts");
        }
    }
}
