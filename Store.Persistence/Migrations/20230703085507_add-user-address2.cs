using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class adduseraddress2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "39560af1-e7b0-4b6b-a456-6a32c5fe945e");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "4bae7a26-fe0f-44ab-9e9d-9ba103f6091d");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "b9354703-4299-40d8-b8b0-dc5d0d9c4e59");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "eb30ebf3-6831-4f99-9692-57a08e1a4d74");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "003862ad-89e0-42c9-a30b-5e8d94ab38b7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2404e0be-c668-4d58-b82f-808703e1e1fe");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fec8d88d-1035-49e1-940d-6890341e5da0");

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Provinces_CityId",
                        column: x => x.CityId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "40a238ec-64b1-4a4c-aeda-9360f318e49d", null, null, new DateTime(2023, 7, 3, 13, 25, 6, 393, DateTimeKind.Local).AddTicks(7528), false, null, "ایمیل", null, "Email" },
                    { "7096a42e-e3bd-4cfd-8e74-d7ebe43ec9f5", null, null, new DateTime(2023, 7, 3, 13, 25, 6, 393, DateTimeKind.Local).AddTicks(7306), false, null, "تلفن همراه", null, "Mobail" },
                    { "8423e2d5-85b8-48bd-8e59-f7d176693f55", null, null, new DateTime(2023, 7, 3, 13, 25, 6, 393, DateTimeKind.Local).AddTicks(7401), false, null, "تلفن", null, "Phone" },
                    { "f280eaba-58cc-46f0-abe4-fa0e7004bc6d", null, null, new DateTime(2023, 7, 3, 13, 25, 6, 393, DateTimeKind.Local).AddTicks(7561), false, null, "آدرس", null, "Address" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "1781abb6-66f4-4e71-b311-c1c52d483f5c", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "8029a060-291f-43eb-ab39-ebc2ee4d312a", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "e290e060-0b85-4527-9799-c0ff883a3418", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_CityId",
                table: "UserAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "40a238ec-64b1-4a4c-aeda-9360f318e49d");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "7096a42e-e3bd-4cfd-8e74-d7ebe43ec9f5");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "8423e2d5-85b8-48bd-8e59-f7d176693f55");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "f280eaba-58cc-46f0-abe4-fa0e7004bc6d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1781abb6-66f4-4e71-b311-c1c52d483f5c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8029a060-291f-43eb-ab39-ebc2ee4d312a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e290e060-0b85-4527-9799-c0ff883a3418");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "39560af1-e7b0-4b6b-a456-6a32c5fe945e", null, null, new DateTime(2023, 7, 3, 13, 23, 10, 319, DateTimeKind.Local).AddTicks(5300), false, null, "تلفن", null, "Phone" },
                    { "4bae7a26-fe0f-44ab-9e9d-9ba103f6091d", null, null, new DateTime(2023, 7, 3, 13, 23, 10, 319, DateTimeKind.Local).AddTicks(5330), false, null, "ایمیل", null, "Email" },
                    { "b9354703-4299-40d8-b8b0-dc5d0d9c4e59", null, null, new DateTime(2023, 7, 3, 13, 23, 10, 319, DateTimeKind.Local).AddTicks(5347), false, null, "آدرس", null, "Address" },
                    { "eb30ebf3-6831-4f99-9692-57a08e1a4d74", null, null, new DateTime(2023, 7, 3, 13, 23, 10, 319, DateTimeKind.Local).AddTicks(5231), false, null, "تلفن همراه", null, "Mobail" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "003862ad-89e0-42c9-a30b-5e8d94ab38b7", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null },
                    { "2404e0be-c668-4d58-b82f-808703e1e1fe", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "fec8d88d-1035-49e1-940d-6890341e5da0", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null }
                });
        }
    }
}
