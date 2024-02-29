using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewVersionV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "storeUsers");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Stores");

            migrationBuilder.CreateTable(
                name: "storeUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLojaId = table.Column<int>(type: "int", nullable: false),
                    IdUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storeUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_storeUsers_Stores_IdLojaId",
                        column: x => x.IdLojaId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_storeUsers_Usuarios_IdUserId",
                        column: x => x.IdUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_storeUsers_IdLojaId",
                table: "storeUsers",
                column: "IdLojaId");

            migrationBuilder.CreateIndex(
                name: "IX_storeUsers_IdUserId",
                table: "storeUsers",
                column: "IdUserId");
        }
    }
}
