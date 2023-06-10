using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class Add_media : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "3295469d-e90f-4e32-8801-787d7b1aaa78");

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "772b648c-4d4b-467f-93ef-b681fc13b6bd");

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "a8804956-6244-4cdc-8e43-6f1ee6bdb842");

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "b5f2d1b5-e4ae-4d35-9b39-2610ead11393");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "79a679be-401d-48fb-a523-22eb81b2d732");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "92925b16-a406-4ddd-b455-b9e8aae5d7da");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9adb37af-ca67-4fcb-8b56-37ec6263c68f");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "18ac7eb9-c614-42a0-9da8-072ac5a8936e", null, null, null, false, null, "ایمیل", null, "Email" },
                    { "6b55489e-0a87-4663-a8b3-c3d42cc1545a", null, null, null, false, null, "تلفن", null, "Phone" },
                    { "72d328ac-f978-4ddf-8409-17b70578a7a7", null, null, null, false, null, "تلفن همراه", null, "Mobail" },
                    { "9a03b184-14ad-46a8-8a77-61be53d6a663", null, null, null, false, null, "آدرس", null, "Address" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "247ea559-3f7e-4703-9b52-6f8fb6182368", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "44f16b75-5373-4149-a9af-14fed3fbca80", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "7b1c0c00-2b04-4afa-a2c9-6d9cc391e132", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "18ac7eb9-c614-42a0-9da8-072ac5a8936e");

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "6b55489e-0a87-4663-a8b3-c3d42cc1545a");

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "72d328ac-f978-4ddf-8409-17b70578a7a7");

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "9a03b184-14ad-46a8-8a77-61be53d6a663");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "247ea559-3f7e-4703-9b52-6f8fb6182368");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "44f16b75-5373-4149-a9af-14fed3fbca80");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7b1c0c00-2b04-4afa-a2c9-6d9cc391e132");

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "3295469d-e90f-4e32-8801-787d7b1aaa78", null, null, null, false, null, "آدرس", null, "Address" },
                    { "772b648c-4d4b-467f-93ef-b681fc13b6bd", null, null, null, false, null, "ایمیل", null, "Email" },
                    { "a8804956-6244-4cdc-8e43-6f1ee6bdb842", null, null, null, false, null, "تلفن همراه", null, "Mobail" },
                    { "b5f2d1b5-e4ae-4d35-9b39-2610ead11393", null, null, null, false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "79a679be-401d-48fb-a523-22eb81b2d732", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "92925b16-a406-4ddd-b455-b9e8aae5d7da", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "9adb37af-ca67-4fcb-8b56-37ec6263c68f", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });
        }
    }
}
