using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewVersionV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_storeUsers_Stores_lojaId",
                table: "storeUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_storeUsers_Usuarios_userId",
                table: "storeUsers");

            migrationBuilder.DropColumn(
                name: "IdLoja",
                table: "storeUsers");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "storeUsers");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "storeUsers",
                newName: "IdUserId");

            migrationBuilder.RenameColumn(
                name: "lojaId",
                table: "storeUsers",
                newName: "IdLojaId");

            migrationBuilder.RenameIndex(
                name: "IX_storeUsers_userId",
                table: "storeUsers",
                newName: "IX_storeUsers_IdUserId");

            migrationBuilder.RenameIndex(
                name: "IX_storeUsers_lojaId",
                table: "storeUsers",
                newName: "IX_storeUsers_IdLojaId");

            migrationBuilder.AddForeignKey(
                name: "FK_storeUsers_Stores_IdLojaId",
                table: "storeUsers",
                column: "IdLojaId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_storeUsers_Usuarios_IdUserId",
                table: "storeUsers",
                column: "IdUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_storeUsers_Stores_IdLojaId",
                table: "storeUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_storeUsers_Usuarios_IdUserId",
                table: "storeUsers");

            migrationBuilder.RenameColumn(
                name: "IdUserId",
                table: "storeUsers",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "IdLojaId",
                table: "storeUsers",
                newName: "lojaId");

            migrationBuilder.RenameIndex(
                name: "IX_storeUsers_IdUserId",
                table: "storeUsers",
                newName: "IX_storeUsers_userId");

            migrationBuilder.RenameIndex(
                name: "IX_storeUsers_IdLojaId",
                table: "storeUsers",
                newName: "IX_storeUsers_lojaId");

            migrationBuilder.AddColumn<int>(
                name: "IdLoja",
                table: "storeUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "storeUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_storeUsers_Stores_lojaId",
                table: "storeUsers",
                column: "lojaId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_storeUsers_Usuarios_userId",
                table: "storeUsers",
                column: "userId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
