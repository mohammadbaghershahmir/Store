using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class Insert_Data_to_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "NameRole", "Title" },
                values: new object[] { 1L, "مدیر سایت", "Admin", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "NameRole", "Title" },
                values: new object[] { 2L, "مدیر سایت", "Admin", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "NameRole", "Title" },
                values: new object[] { 3L, "مدیر سایت", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
