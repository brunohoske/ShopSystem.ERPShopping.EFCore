using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStoreUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Usuarios ON");


            migrationBuilder. Sql("SET IDENTITY_INSERT dbo.Usuarios OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
