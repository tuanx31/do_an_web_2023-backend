using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace web_api.Migrations
{
    /// <inheritdoc />
    public partial class updateorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6cd4e66-150c-419e-bdf5-34d03c4f2907");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3c609f1-4c4e-416d-bc53-d8ba8a61c018");

            migrationBuilder.DropColumn(
                name: "emailCustomer",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "nameCustomer",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "phoneCustomer",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "idUser",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e7ddf17-fb65-4f86-b9ed-345b2497021c", "1", "Admin", "Admin" },
                    { "91987ca5-938f-42f8-aed5-290c8c49a7f5", "1", "User", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_idUser",
                table: "Order",
                column: "idUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_idUser",
                table: "Order",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_idUser",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_idUser",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e7ddf17-fb65-4f86-b9ed-345b2497021c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91987ca5-938f-42f8-aed5-290c8c49a7f5");

            migrationBuilder.DropColumn(
                name: "idUser",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "emailCustomer",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nameCustomer",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phoneCustomer",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e6cd4e66-150c-419e-bdf5-34d03c4f2907", "1", "User", "User" },
                    { "f3c609f1-4c4e-416d-bc53-d8ba8a61c018", "1", "Admin", "Admin" }
                });
        }
    }
}
