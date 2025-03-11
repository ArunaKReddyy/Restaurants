using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Restaurents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Restaurents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurents_OwnerId",
                table: "Restaurents",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurents_AspNetUsers_OwnerId",
                table: "Restaurents",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurents_AspNetUsers_OwnerId",
                table: "Restaurents");

            migrationBuilder.DropIndex(
                name: "IX_Restaurents_OwnerId",
                table: "Restaurents");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Restaurents");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Restaurents");
        }
    }
}
