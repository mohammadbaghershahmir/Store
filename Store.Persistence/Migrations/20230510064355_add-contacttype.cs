using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addcontacttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Title", "Value" },
                values: new object[] { "تلفن", "Phone" });

            migrationBuilder.UpdateData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Title", "Value" },
                values: new object[] { "ایمیل", "Email" });

            migrationBuilder.UpdateData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Title", "Value" },
                values: new object[] { "آدرس", "Address" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Title", "Value" },
                values: new object[] { "تلفن همراه", "Mobail" });

            migrationBuilder.UpdateData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Title", "Value" },
                values: new object[] { "تلفن همراه", "Mobail" });

            migrationBuilder.UpdateData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Title", "Value" },
                values: new object[] { "تلفن همراه", "Mobail" });
        }
    }
}
