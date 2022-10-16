using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InoCar.Data.Migrations
{
    public partial class AddIsDeletedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ef758a5-adb7-4dbb-a7d1-7a1c642bc806");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VisitReasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TimeSlots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateRequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 16, 18, 32, 49, DateTimeKind.Local).AddTicks(8603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 14, 58, 11, 980, DateTimeKind.Local).AddTicks(4325));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ServiceConsultants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RemoveCarReasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Recommendations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PersonalOffers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MaintenanceWorks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Dealerships",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicDate",
                table: "DealershipFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 18, 32, 54, DateTimeKind.Utc).AddTicks(3937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 11, 58, 11, 984, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateBirth", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Patronymic", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2dc61205-7ba7-4fe4-97cd-8927ec5eadf0", 0, "Admin1", "5bca16cf-e7b6-4129-98aa-aabb54bab1b2", new DateTime(2022, 8, 29, 13, 18, 32, 298, DateTimeKind.Utc).AddTicks(2816), "John-old@mail.ru", true, "Admin1", false, "Admin1", true, null, "JOHN-OLD@MAIL.RU", "ADMIN1", "$2a$11$9nbkY5azeVLUJ7oltch5DO7tcbT7J4VfsIW8TDXesdJvtZRT0biEm", null, null, false, null, "465e83a1-2203-47ef-b654-97a2ff7913f8", false, "Admin1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2dc61205-7ba7-4fe4-97cd-8927ec5eadf0");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VisitReasons");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ServiceConsultants");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RemoveCarReasons");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PersonalOffers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MaintenanceWorks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Dealerships");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateRequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 14, 58, 11, 980, DateTimeKind.Local).AddTicks(4325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 29, 16, 18, 32, 49, DateTimeKind.Local).AddTicks(8603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicDate",
                table: "DealershipFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 11, 58, 11, 984, DateTimeKind.Utc).AddTicks(1465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 18, 32, 54, DateTimeKind.Utc).AddTicks(3937));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateBirth", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Patronymic", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5ef758a5-adb7-4dbb-a7d1-7a1c642bc806", 0, "Admin1", "ce172ddc-3d36-4f55-925e-b9132b1390b9", new DateTime(2022, 8, 28, 11, 58, 12, 192, DateTimeKind.Utc).AddTicks(1133), "John-old@mail.ru", true, "Admin1", false, "Admin1", true, null, "JOHN-OLD@MAIL.RU", "ADMIN1", "$2a$11$TPHr51XUyDy8HaTMqKKh3O/JsJwjxxeXaYklF/.SZmVMIwHAtSsEm", null, null, false, null, "f4ad74f5-4798-41c9-a592-7ecaad0bd610", false, "Admin1" });
        }
    }
}
