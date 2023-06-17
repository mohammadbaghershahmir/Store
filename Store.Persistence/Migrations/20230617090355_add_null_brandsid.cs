using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class add_null_brandsid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandsId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "2f6eaf26-e32c-40b8-b005-f15cecef5ce9");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "4304db1e-1b17-4e86-95f4-ec6bc38d702c");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "7c5169f2-16a2-4e63-a3e7-421a289900d8");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "dff39468-54b0-44b9-a410-ec5536fa3ec1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0f0da3bd-ada0-47cb-904f-e1991585b347");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c984f1f-3d10-47f9-b35f-28a9627a6bc3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "83df86e8-272c-4417-92f3-34fa9ca07b50");

            migrationBuilder.AlterColumn<string>(
                name: "BrandsId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "3807978c-c477-4f8f-a30b-cac4af4dfcf2", null, null, null, false, null, "تلفن", null, "Phone" },
                    { "5c714ff8-cbfd-4962-83b2-2ea1f744bfa3", null, null, null, false, null, "آدرس", null, "Address" },
                    { "7ac2d33a-be25-459c-9781-6ed7faae84f8", null, null, null, false, null, "تلفن همراه", null, "Mobail" },
                    { "bd490f0b-4261-4102-8358-7b17da0aeab2", null, null, null, false, null, "ایمیل", null, "Email" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "2dbee74b-5a72-467a-bc38-db2b636c9b24", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "8d57532c-0930-471b-89e0-3aaf316ad5bd", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "ec9cbad1-2f13-4fd6-9bed-b2b0e261f3e4", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandsId",
                table: "Products",
                column: "BrandsId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandsId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "3807978c-c477-4f8f-a30b-cac4af4dfcf2");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "5c714ff8-cbfd-4962-83b2-2ea1f744bfa3");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "7ac2d33a-be25-459c-9781-6ed7faae84f8");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "bd490f0b-4261-4102-8358-7b17da0aeab2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2dbee74b-5a72-467a-bc38-db2b636c9b24");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8d57532c-0930-471b-89e0-3aaf316ad5bd");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ec9cbad1-2f13-4fd6-9bed-b2b0e261f3e4");

            migrationBuilder.AlterColumn<string>(
                name: "BrandsId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "2f6eaf26-e32c-40b8-b005-f15cecef5ce9", null, null, null, false, null, "ایمیل", null, "Email" },
                    { "4304db1e-1b17-4e86-95f4-ec6bc38d702c", null, null, null, false, null, "تلفن همراه", null, "Mobail" },
                    { "7c5169f2-16a2-4e63-a3e7-421a289900d8", null, null, null, false, null, "تلفن", null, "Phone" },
                    { "dff39468-54b0-44b9-a410-ec5536fa3ec1", null, null, null, false, null, "آدرس", null, "Address" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "0f0da3bd-ada0-47cb-904f-e1991585b347", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "2c984f1f-3d10-47f9-b35f-28a9627a6bc3", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "83df86e8-272c-4417-92f3-34fa9ca07b50", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandsId",
                table: "Products",
                column: "BrandsId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
