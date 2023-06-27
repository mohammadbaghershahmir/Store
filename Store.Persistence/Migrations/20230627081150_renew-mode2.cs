using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class renewmode2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandsId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "0b269d7b-8a0f-4b8b-a890-0831257888cd");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "5169024d-e301-40ea-a3ab-a7be4654ed0d");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "5459f1ae-8c0f-41d2-ae91-178ea9851e69");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "a162e585-e232-4c38-bca2-b4eb3fb99768");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "572a179b-b377-4fa5-8e41-54a293c15054");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9c134dad-8ef3-4d5c-94e8-86d36ed770e0");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e62fc831-0af9-4563-891e-46c4cf15c16d");

            migrationBuilder.RenameColumn(
                name: "BrandsId",
                table: "Products",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandsId",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "121b15da-94a4-468b-80a8-f7d92f2b2b52", null, null, new DateTime(2023, 6, 27, 12, 41, 49, 417, DateTimeKind.Local).AddTicks(14), false, null, "آدرس", null, "Address" },
                    { "151aa4d7-8fad-46f4-a437-21d153fb3778", null, null, new DateTime(2023, 6, 27, 12, 41, 49, 416, DateTimeKind.Local).AddTicks(9975), false, null, "تلفن", null, "Phone" },
                    { "9e0e852c-1a45-4486-96c7-7e3ab9ce3e7d", null, null, new DateTime(2023, 6, 27, 12, 41, 49, 416, DateTimeKind.Local).AddTicks(9896), false, null, "تلفن همراه", null, "Mobail" },
                    { "b9c91430-da45-4d1c-b80a-58cfec2ae1e6", null, null, new DateTime(2023, 6, 27, 12, 41, 49, 416, DateTimeKind.Local).AddTicks(9996), false, null, "ایمیل", null, "Email" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "2cad1a9f-a6a1-40d1-b453-b1dcc5386acd", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "57125ce0-7ee4-4bb8-8cab-8f5c17e006d8", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "75d8b83f-3f00-4580-920b-8a72fc3882ca", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "121b15da-94a4-468b-80a8-f7d92f2b2b52");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "151aa4d7-8fad-46f4-a437-21d153fb3778");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "9e0e852c-1a45-4486-96c7-7e3ab9ce3e7d");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "b9c91430-da45-4d1c-b80a-58cfec2ae1e6");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2cad1a9f-a6a1-40d1-b453-b1dcc5386acd");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "57125ce0-7ee4-4bb8-8cab-8f5c17e006d8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "75d8b83f-3f00-4580-920b-8a72fc3882ca");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Products",
                newName: "BrandsId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                newName: "IX_Products_BrandsId");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "0b269d7b-8a0f-4b8b-a890-0831257888cd", null, null, new DateTime(2023, 6, 27, 12, 37, 25, 251, DateTimeKind.Local).AddTicks(5587), false, null, "آدرس", null, "Address" },
                    { "5169024d-e301-40ea-a3ab-a7be4654ed0d", null, null, new DateTime(2023, 6, 27, 12, 37, 25, 251, DateTimeKind.Local).AddTicks(5091), false, null, "تلفن همراه", null, "Mobail" },
                    { "5459f1ae-8c0f-41d2-ae91-178ea9851e69", null, null, new DateTime(2023, 6, 27, 12, 37, 25, 251, DateTimeKind.Local).AddTicks(5535), false, null, "ایمیل", null, "Email" },
                    { "a162e585-e232-4c38-bca2-b4eb3fb99768", null, null, new DateTime(2023, 6, 27, 12, 37, 25, 251, DateTimeKind.Local).AddTicks(5277), false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "572a179b-b377-4fa5-8e41-54a293c15054", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "9c134dad-8ef3-4d5c-94e8-86d36ed770e0", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "e62fc831-0af9-4563-891e-46c4cf15c16d", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandsId",
                table: "Products",
                column: "BrandsId",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
