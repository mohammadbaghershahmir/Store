using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class renewmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductsId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Products_ProductsId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTags_Products_ProductsId",
                table: "ItemTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Products_ProductsId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Products_ProductsId",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductsId",
                table: "CartItems");

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

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "Rates",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_ProductsId",
                table: "Rates",
                newName: "IX_Rates_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "Medias",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_ProductsId",
                table: "Medias",
                newName: "IX_Medias_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ItemTags",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTags_ProductsId",
                table: "ItemTags",
                newName: "IX_ItemTags_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "Features",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Features_ProductsId",
                table: "Features",
                newName: "IX_Features_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "Comments",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ProductsId",
                table: "Comments",
                newName: "IX_Comments_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Products_ProductId",
                table: "Features",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTags_Products_ProductId",
                table: "ItemTags",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Products_ProductId",
                table: "Medias",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Products_ProductId",
                table: "Rates",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Products_ProductId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTags_Products_ProductId",
                table: "ItemTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Products_ProductId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Products_ProductId",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

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
                name: "ProductId",
                table: "Rates",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_ProductId",
                table: "Rates",
                newName: "IX_Rates_ProductsId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Medias",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_ProductId",
                table: "Medias",
                newName: "IX_Medias_ProductsId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ItemTags",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTags_ProductId",
                table: "ItemTags",
                newName: "IX_ItemTags_ProductsId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Features",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_Features_ProductId",
                table: "Features",
                newName: "IX_Features_ProductsId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Comments",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                newName: "IX_Comments_ProductsId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ProductsId",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductsId",
                table: "CartItems",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductsId",
                table: "CartItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductsId",
                table: "Comments",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Products_ProductsId",
                table: "Features",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTags_Products_ProductsId",
                table: "ItemTags",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Products_ProductsId",
                table: "Medias",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Products_ProductsId",
                table: "Rates",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
