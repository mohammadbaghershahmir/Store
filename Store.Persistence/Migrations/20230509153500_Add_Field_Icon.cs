using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class Add_Field_Icon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "ContactTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "Title", "Value" },
                values: new object[,]
                {
                    { 1L, null, null, "تلفن همراه", "Mobail" },
                    { 2L, null, null, "تلفن همراه", "Mobail" },
                    { 3L, null, null, "تلفن همراه", "Mobail" },
                    { 4L, null, null, "تلفن همراه", "Mobail" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "ContactTypes");
        }
    }
}
