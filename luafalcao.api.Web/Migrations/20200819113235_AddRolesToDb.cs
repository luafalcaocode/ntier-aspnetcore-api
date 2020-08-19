using Microsoft.EntityFrameworkCore.Migrations;

namespace luafalcao.api.Web.Migrations
{
    public partial class AddRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b45754b2-bbad-482e-ab33-c00acdc4ed4a", "94c4377d-dbfc-4fad-a1db-da28e17b2d9f", "Administrador", "ADMINISTRADOR" },
                    { "42928885-b51b-4840-b8e1-1d820f8348f1", "9e06aee0-615d-4194-8d80-23f87d241aa2", "Comum", "Comum" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42928885-b51b-4840-b8e1-1d820f8348f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b45754b2-bbad-482e-ab33-c00acdc4ed4a");
        }
    }
}
