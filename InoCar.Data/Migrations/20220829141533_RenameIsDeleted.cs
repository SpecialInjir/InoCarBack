using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InoCar.Data.Migrations
{
    public partial class RenameIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2dc61205-7ba7-4fe4-97cd-8927ec5eadf0");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateRequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 17, 15, 32, 49, DateTimeKind.Local).AddTicks(906),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 29, 16, 18, 32, 49, DateTimeKind.Local).AddTicks(8603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicDate",
                table: "DealershipFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 14, 15, 32, 56, DateTimeKind.Utc).AddTicks(8561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 18, 32, 54, DateTimeKind.Utc).AddTicks(3937));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateBirth", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Patronymic", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d32cab1f-0689-4ba5-96f0-93cba9b0b4d8", 0, "Admin1", "c021eb05-f2cb-47cc-b852-4ce187304555", new DateTime(2022, 8, 29, 14, 15, 32, 345, DateTimeKind.Utc).AddTicks(3609), "John-old@mail.ru", true, "Admin1", false, "Admin1", true, null, "JOHN-OLD@MAIL.RU", "ADMIN1", "$2a$11$daR74tscUrYWUJq6MC8NbeeMnxYA9fBFUeq5BVsZstzj9H6Qg90ye", null, null, false, null, "06c32006-28db-4757-90dd-48e023412a60", false, "Admin1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d32cab1f-0689-4ba5-96f0-93cba9b0b4d8");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateRequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 16, 18, 32, 49, DateTimeKind.Local).AddTicks(8603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 29, 17, 15, 32, 49, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicDate",
                table: "DealershipFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 18, 32, 54, DateTimeKind.Utc).AddTicks(3937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 29, 14, 15, 32, 56, DateTimeKind.Utc).AddTicks(8561));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateBirth", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Patronymic", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2dc61205-7ba7-4fe4-97cd-8927ec5eadf0", 0, "Admin1", "5bca16cf-e7b6-4129-98aa-aabb54bab1b2", new DateTime(2022, 8, 29, 13, 18, 32, 298, DateTimeKind.Utc).AddTicks(2816), "John-old@mail.ru", true, "Admin1", false, "Admin1", true, null, "JOHN-OLD@MAIL.RU", "ADMIN1", "$2a$11$9nbkY5azeVLUJ7oltch5DO7tcbT7J4VfsIW8TDXesdJvtZRT0biEm", null, null, false, null, "465e83a1-2203-47ef-b654-97a2ff7913f8", false, "Admin1" });
        }
    }
}
