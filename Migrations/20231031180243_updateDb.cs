using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "consistent",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "design",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "id_trademark",
                table: "products",
                type: "int",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "listImage",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "products",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Trademark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trademark", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_id_trademark",
                table: "products",
                column: "id_trademark");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Trademark_id_trademark",
                table: "products",
                column: "id_trademark",
                principalTable: "Trademark",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Trademark_id_trademark",
                table: "products");

            migrationBuilder.DropTable(
                name: "Trademark");

            migrationBuilder.DropIndex(
                name: "IX_products_id_trademark",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "products");

            migrationBuilder.DropColumn(
                name: "color",
                table: "products");

            migrationBuilder.DropColumn(
                name: "consistent",
                table: "products");

            migrationBuilder.DropColumn(
                name: "design",
                table: "products");

            migrationBuilder.DropColumn(
                name: "id_trademark",
                table: "products");

            migrationBuilder.DropColumn(
                name: "listImage",
                table: "products");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "products");

            migrationBuilder.DropColumn(
                name: "size",
                table: "products");
        }
    }
}
