using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "03b5338f-0cdc-493f-b131-ae11b639224e");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "08ecbc46-648d-4f3b-9858-26e32081c408");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "09c03aa3-6ae6-40d4-a82d-4c15ee2f83b5");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "e4a87cf7-7c4a-441f-80dc-f55f191405e7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "483780cb-6ea0-4aea-bbfb-199b0783dec9");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6185c1c8-530e-4717-9c9b-68fadad275ca");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e300bba9-c93c-440b-918a-c7e19a8a7072");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "33783912-9ca0-4c48-9e15-32f069d41bbf", null, null, new DateTime(2023, 6, 27, 12, 20, 36, 646, DateTimeKind.Local).AddTicks(3464), false, null, "تلفن همراه", null, "Mobail" },
                    { "47e0426a-20b4-4615-9c90-c8e27be1ff14", null, null, new DateTime(2023, 6, 27, 12, 20, 36, 646, DateTimeKind.Local).AddTicks(3631), false, null, "آدرس", null, "Address" },
                    { "773eafe9-1e01-444c-9417-0dabb2f73fc9", null, null, new DateTime(2023, 6, 27, 12, 20, 36, 646, DateTimeKind.Local).AddTicks(3604), false, null, "ایمیل", null, "Email" },
                    { "809895d5-5497-4523-bc24-5cd20f043d32", null, null, new DateTime(2023, 6, 27, 12, 20, 36, 646, DateTimeKind.Local).AddTicks(3568), false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "ad47c9ea-508d-4ade-b57c-65f4c1a8959e", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "be9f2c13-905b-4b26-9fe8-a483e1b39743", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "ff674d4b-c6bd-4f36-bee7-3ac99bd7b82d", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "33783912-9ca0-4c48-9e15-32f069d41bbf");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "47e0426a-20b4-4615-9c90-c8e27be1ff14");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "773eafe9-1e01-444c-9417-0dabb2f73fc9");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "809895d5-5497-4523-bc24-5cd20f043d32");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ad47c9ea-508d-4ade-b57c-65f4c1a8959e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "be9f2c13-905b-4b26-9fe8-a483e1b39743");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ff674d4b-c6bd-4f36-bee7-3ac99bd7b82d");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "03b5338f-0cdc-493f-b131-ae11b639224e", null, null, new DateTime(2023, 6, 27, 12, 18, 45, 3, DateTimeKind.Local).AddTicks(1050), false, null, "تلفن همراه", null, "Mobail" },
                    { "08ecbc46-648d-4f3b-9858-26e32081c408", null, null, new DateTime(2023, 6, 27, 12, 18, 45, 3, DateTimeKind.Local).AddTicks(1246), false, null, "تلفن", null, "Phone" },
                    { "09c03aa3-6ae6-40d4-a82d-4c15ee2f83b5", null, null, new DateTime(2023, 6, 27, 12, 18, 45, 3, DateTimeKind.Local).AddTicks(1296), false, null, "ایمیل", null, "Email" },
                    { "e4a87cf7-7c4a-441f-80dc-f55f191405e7", null, null, new DateTime(2023, 6, 27, 12, 18, 45, 3, DateTimeKind.Local).AddTicks(1333), false, null, "آدرس", null, "Address" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "483780cb-6ea0-4aea-bbfb-199b0783dec9", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "6185c1c8-530e-4717-9c9b-68fadad275ca", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "e300bba9-c93c-440b-918a-c7e19a8a7072", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null }
                });
        }
    }
}
