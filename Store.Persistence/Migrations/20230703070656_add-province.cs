using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class addprovince : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParrentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    DeliverDay = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Provinces_ParrentId",
                        column: x => x.ParrentId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_ParrentId",
                table: "Provinces",
                column: "ParrentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provinces");

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
    }
}
