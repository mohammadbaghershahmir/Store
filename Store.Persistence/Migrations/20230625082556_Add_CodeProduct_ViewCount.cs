using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class Add_CodeProduct_ViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CodeProduct",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "19205efc-2d32-4419-bbaa-b0d677449393", null, null, null, false, null, "ایمیل", null, "Email" },
                    { "2ebdb057-6498-4b0a-a5fd-63ed137f645e", null, null, null, false, null, "آدرس", null, "Address" },
                    { "7cf4db49-b1ad-497b-a696-2c6a0d926bd4", null, null, null, false, null, "تلفن همراه", null, "Mobail" },
                    { "e2b31a48-8177-4082-823c-b8768df8fbfa", null, null, null, false, null, "تلفن", null, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "13a6c507-f637-4006-8ccf-05e838058e2a", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "41446ab8-2c35-4667-8153-b9ca50416d24", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "7d620020-5a9f-4233-9e1e-917fd5f76027", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "19205efc-2d32-4419-bbaa-b0d677449393");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "2ebdb057-6498-4b0a-a5fd-63ed137f645e");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "7cf4db49-b1ad-497b-a696-2c6a0d926bd4");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "e2b31a48-8177-4082-823c-b8768df8fbfa");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "13a6c507-f637-4006-8ccf-05e838058e2a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "41446ab8-2c35-4667-8153-b9ca50416d24");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7d620020-5a9f-4233-9e1e-917fd5f76027");

            migrationBuilder.DropColumn(
                name: "CodeProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");

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
        }
    }
}
