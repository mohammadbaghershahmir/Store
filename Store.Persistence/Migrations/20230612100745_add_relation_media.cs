using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class add_relation_media : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "097d3647-b981-4dcc-bb22-191eaaecbbb2");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "69c55220-73d0-4264-97b1-a448cc116048");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "6d75dce6-8ced-4970-8b9c-a11857bb529d");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "825c95d1-a144-4a12-ad15-ab0eae7b095c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1603076f-be68-41c4-8f5d-a492fa2c4e8f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "17053633-721e-44d3-ba87-7b60d25edf45");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "80281b7e-df06-4426-a0c4-46cd32cb45ae");

            migrationBuilder.AddColumn<string>(
                name: "ProductsId",
                table: "Medias",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "177486a2-0f96-4259-9b10-a657c88df435", null, null, null, false, null, "ایمیل", null, "Email" },
                    { "459179d7-de63-4db7-b586-04bddf8f5d48", null, null, null, false, null, "تلفن همراه", null, "Mobail" },
                    { "a4c72b18-4f6c-4111-8568-ff032c3f7406", null, null, null, false, null, "تلفن", null, "Phone" },
                    { "b55d121c-2cdd-4101-9c77-5581559c07f0", null, null, null, false, null, "آدرس", null, "Address" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "135c2084-0f5e-46bf-98ba-c03f4ff46d8a", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "5075a2dc-ef9b-4f7f-a7a0-fdd29fd4d82a", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "5e645d5b-2a28-473d-bdce-d3b10a81d893", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ProductsId",
                table: "Medias",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Products_ProductsId",
                table: "Medias",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Products_ProductsId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_ProductsId",
                table: "Medias");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "177486a2-0f96-4259-9b10-a657c88df435");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "459179d7-de63-4db7-b586-04bddf8f5d48");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "a4c72b18-4f6c-4111-8568-ff032c3f7406");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "b55d121c-2cdd-4101-9c77-5581559c07f0");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "135c2084-0f5e-46bf-98ba-c03f4ff46d8a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5075a2dc-ef9b-4f7f-a7a0-fdd29fd4d82a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5e645d5b-2a28-473d-bdce-d3b10a81d893");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Medias");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "097d3647-b981-4dcc-bb22-191eaaecbbb2", null, null, null, false, null, "تلفن", null, "Phone" },
                    { "69c55220-73d0-4264-97b1-a448cc116048", null, null, null, false, null, "تلفن همراه", null, "Mobail" },
                    { "6d75dce6-8ced-4970-8b9c-a11857bb529d", null, null, null, false, null, "آدرس", null, "Address" },
                    { "825c95d1-a144-4a12-ad15-ab0eae7b095c", null, null, null, false, null, "ایمیل", null, "Email" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "1603076f-be68-41c4-8f5d-a492fa2c4e8f", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "17053633-721e-44d3-ba87-7b60d25edf45", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "80281b7e-df06-4426-a0c4-46cd32cb45ae", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });
        }
    }
}
