using Microsoft.EntityFrameworkCore.Migrations;

namespace luafalcao.api.Web.Migrations
{
    public partial class ChangingUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42928885-b51b-4840-b8e1-1d820f8348f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b45754b2-bbad-482e-ab33-c00acdc4ed4a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c72faf9-1d5a-4673-a0be-94d72d4badf0", "90a11652-caea-4baa-9eaf-255b30e97fba", "Administrador", "ADMINISTRADOR" },
                    { "86264df8-83d0-4b65-8079-8254cb75f5f8", "c2bcad75-dd4d-4d81-9388-0f9a8a25adeb", "Comum", "Comum" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c72faf9-1d5a-4673-a0be-94d72d4badf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86264df8-83d0-4b65-8079-8254cb75f5f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b45754b2-bbad-482e-ab33-c00acdc4ed4a", "94c4377d-dbfc-4fad-a1db-da28e17b2d9f", "Administrador", "ADMINISTRADOR" },
                    { "42928885-b51b-4840-b8e1-1d820f8348f1", "9e06aee0-615d-4194-8d80-23f87d241aa2", "Comum", "Comum" }
                });
        }
    }
}
