using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class add_media_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_MediaTypes_MediaTypeId",
                table: "Medias");

            migrationBuilder.DropTable(
                name: "MediaTypes");

            migrationBuilder.DropIndex(
                name: "IX_Medias_MediaTypeId",
                table: "Medias");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "5855b0d5-f9e5-4492-89c0-67f7c8c00b4c");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "8248f382-8fe6-4234-9169-dec0a77929c9");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "91060bdb-5c1b-4089-993f-f5b903b540cc");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "916ff9ec-cff4-4792-b4ba-4b482ee4d020");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2cc86fbc-68f9-429c-b194-b407ce505a3f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a07eee99-122f-49e8-bf7b-17944c15a287");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ee1e08ef-43d9-44b4-ade2-c7bcff69384e");

            migrationBuilder.DropColumn(
                name: "MediaTypeId",
                table: "Medias");

            migrationBuilder.AddColumn<int>(
                name: "MediaType",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "Medias");

            migrationBuilder.AddColumn<string>(
                name: "MediaTypeId",
                table: "Medias",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MediaTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "5855b0d5-f9e5-4492-89c0-67f7c8c00b4c", null, null, null, false, null, "تلفن", null, "Phone" },
                    { "8248f382-8fe6-4234-9169-dec0a77929c9", null, null, null, false, null, "ایمیل", null, "Email" },
                    { "91060bdb-5c1b-4089-993f-f5b903b540cc", null, null, null, false, null, "تلفن همراه", null, "Mobail" },
                    { "916ff9ec-cff4-4792-b4ba-4b482ee4d020", null, null, null, false, null, "آدرس", null, "Address" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "2cc86fbc-68f9-429c-b194-b407ce505a3f", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "a07eee99-122f-49e8-bf7b-17944c15a287", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "ee1e08ef-43d9-44b4-ade2-c7bcff69384e", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MediaTypeId",
                table: "Medias",
                column: "MediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_MediaTypes_MediaTypeId",
                table: "Medias",
                column: "MediaTypeId",
                principalTable: "MediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
