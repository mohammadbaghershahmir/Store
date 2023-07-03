using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class adduseraddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "033131af-eeed-423f-9855-b4fde95adcf4");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "03569d46-60c2-4934-9eaf-124d425bfd16");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "5e4ada16-1185-4165-961b-0a6bb965ac46");

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: "9253dd4c-2b93-4b99-afd7-ef72e45c70e4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5a2d723f-8502-41af-8e9c-8cb0fe63efae");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5d31031c-23d3-4600-887d-4dcb55bf16be");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fc7c8d6b-20fc-4863-a8fd-feeb9abda93c");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "CssClass", "Icon", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime", "Value" },
                values: new object[,]
                {
                    { "033131af-eeed-423f-9855-b4fde95adcf4", null, null, new DateTime(2023, 7, 3, 11, 36, 55, 199, DateTimeKind.Local).AddTicks(670), false, null, "تلفن", null, "Phone" },
                    { "03569d46-60c2-4934-9eaf-124d425bfd16", null, null, new DateTime(2023, 7, 3, 11, 36, 55, 199, DateTimeKind.Local).AddTicks(546), false, null, "تلفن همراه", null, "Mobail" },
                    { "5e4ada16-1185-4165-961b-0a6bb965ac46", null, null, new DateTime(2023, 7, 3, 11, 36, 55, 199, DateTimeKind.Local).AddTicks(756), false, null, "آدرس", null, "Address" },
                    { "9253dd4c-2b93-4b99-afd7-ef72e45c70e4", null, null, new DateTime(2023, 7, 3, 11, 36, 55, 199, DateTimeKind.Local).AddTicks(715), false, null, "ایمیل", null, "Email" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "BirthDay", "ConcurrencyStamp", "Description", "Discriminator", "InsertTime", "IsRemoved", "Name", "NormalizedName", "PersianTitle", "ProfileImage", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { "5a2d723f-8502-41af-8e9c-8cb0fe63efae", null, null, null, "Role", null, false, "Customer", "CUSTOMER", "مشتری", null, null, null },
                    { "5d31031c-23d3-4600-887d-4dcb55bf16be", null, null, null, "Role", null, false, "Admin", "ADMIN", "مدیر سایت", null, null, null },
                    { "fc7c8d6b-20fc-4863-a8fd-feeb9abda93c", null, null, null, "Role", null, false, "Operator", "OPERATOR", "اپراتور", null, null, null }
                });
        }
    }
}
