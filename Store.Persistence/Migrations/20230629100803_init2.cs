using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "11095e41-6b82-4d9f-9f35-a5b73abe49e4");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "6ab2173f-0d06-4199-8e99-b922f58254b9");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "934d85fb-480b-478d-8b1e-9b94904fa196");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "ed803172-798e-4eaf-9e73-4186625eb3d4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "58f81d0a-a86e-4b96-8db5-2efa122f691c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "660fb1f2-a37c-41fa-9901-55566ddd3755");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "df9012c7-75b9-406c-9c2f-18d8c6f976ed");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "07c57ae5-a459-41b8-b091-1e86537e68ed", null, null, new DateTime(2023, 6, 29, 14, 38, 3, 350, DateTimeKind.Local).AddTicks(1202), false, null, "ایمیل", null, "Email" },
                    { "868070d3-8067-42a6-9c0a-2b0919027e0e", null, null, new DateTime(2023, 6, 29, 14, 38, 3, 350, DateTimeKind.Local).AddTicks(1109), false, null, "تلفن همراه", null, "Mobail" },
                    { "8b874685-a507-44c6-9a73-312b3e903ce4", null, null, new DateTime(2023, 6, 29, 14, 38, 3, 350, DateTimeKind.Local).AddTicks(1220), false, null, "آدرس", null, "Address" },
                    { "cab2217a-a15f-4cd5-b2bd-82041e42e563", null, null, new DateTime(2023, 6, 29, 14, 38, 3, 350, DateTimeKind.Local).AddTicks(1182), false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "08d1b85c-3a56-4d97-8065-a9f3e4b8da1b", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "8dc9ab5f-b403-491f-8d27-025457d4256c", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "de9f45bd-e8f4-4b73-894b-a9baddd31be6", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "07c57ae5-a459-41b8-b091-1e86537e68ed");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "868070d3-8067-42a6-9c0a-2b0919027e0e");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "8b874685-a507-44c6-9a73-312b3e903ce4");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "cab2217a-a15f-4cd5-b2bd-82041e42e563");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "08d1b85c-3a56-4d97-8065-a9f3e4b8da1b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8dc9ab5f-b403-491f-8d27-025457d4256c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "de9f45bd-e8f4-4b73-894b-a9baddd31be6");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "11095e41-6b82-4d9f-9f35-a5b73abe49e4", null, null, new DateTime(2023, 6, 29, 14, 22, 12, 297, DateTimeKind.Local).AddTicks(5602), false, null, "آدرس", null, "Address" },
                    { "6ab2173f-0d06-4199-8e99-b922f58254b9", null, null, new DateTime(2023, 6, 29, 14, 22, 12, 297, DateTimeKind.Local).AddTicks(5566), false, null, "ایمیل", null, "Email" },
                    { "934d85fb-480b-478d-8b1e-9b94904fa196", null, null, new DateTime(2023, 6, 29, 14, 22, 12, 297, DateTimeKind.Local).AddTicks(5410), false, null, "تلفن همراه", null, "Mobail" },
                    { "ed803172-798e-4eaf-9e73-4186625eb3d4", null, null, new DateTime(2023, 6, 29, 14, 22, 12, 297, DateTimeKind.Local).AddTicks(5528), false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "58f81d0a-a86e-4b96-8db5-2efa122f691c", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "660fb1f2-a37c-41fa-9901-55566ddd3755", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "df9012c7-75b9-406c-9c2f-18d8c6f976ed", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });
        }
    }
}
