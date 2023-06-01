using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "9f81e55f-6c3d-4c98-a17c-a33a7e03bc52");

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "aa49e3f9-6c9b-4514-94d8-44df6d26fecc");

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "cae904a6-e16f-42ab-9d50-6d3170656f2b");

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: "cc6cb6e8-f832-4c17-8b71-0108f13dd112");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6fde81fe-6ccc-4364-92ec-759bec5bea47");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "80503d0b-faf4-432e-a922-b9c814a9a0e8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "afdce797-9ad1-402f-9305-8c66590f01ee");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "9f81e55f-6c3d-4c98-a17c-a33a7e03bc52", null, null, null, false, null, "تلفن همراه", null, "Mobail" },
                    { "aa49e3f9-6c9b-4514-94d8-44df6d26fecc", null, null, null, false, null, "آدرس", null, "Address" },
                    { "cae904a6-e16f-42ab-9d50-6d3170656f2b", null, null, null, false, null, "تلفن", null, "Phone" },
                    { "cc6cb6e8-f832-4c17-8b71-0108f13dd112", null, null, null, false, null, "ایمیل", null, "Email" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "6fde81fe-6ccc-4364-92ec-759bec5bea47", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "80503d0b-faf4-432e-a922-b9c814a9a0e8", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "afdce797-9ad1-402f-9305-8c66590f01ee", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });
        }
    }
}
