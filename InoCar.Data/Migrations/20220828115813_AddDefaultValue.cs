using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InoCar.Data.Migrations
{
    public partial class AddDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce539a1a-8b50-4d0b-9b63-01870d916534");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateRequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 14, 58, 11, 980, DateTimeKind.Local).AddTicks(4325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 26, 15, 4, 10, 868, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicDate",
                table: "DealershipFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 11, 58, 11, 984, DateTimeKind.Utc).AddTicks(1465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 26, 12, 4, 10, 872, DateTimeKind.Utc).AddTicks(3595));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateBirth", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Patronymic", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5ef758a5-adb7-4dbb-a7d1-7a1c642bc806", 0, "Admin1", "ce172ddc-3d36-4f55-925e-b9132b1390b9", new DateTime(2022, 8, 28, 11, 58, 12, 192, DateTimeKind.Utc).AddTicks(1133), "John-old@mail.ru", true, "Admin1", false, "Admin1", true, null, "JOHN-OLD@MAIL.RU", "ADMIN1", "$2a$11$TPHr51XUyDy8HaTMqKKh3O/JsJwjxxeXaYklF/.SZmVMIwHAtSsEm", null, null, false, null, "f4ad74f5-4798-41c9-a592-7ecaad0bd610", false, "Admin1" });

            migrationBuilder.InsertData(
                table: "RemoveCarReasons",
                columns: new[] { "Id", "Description", "Type" },
                values: new object[] { 1, "Продажа авто", 0 });

            migrationBuilder.InsertData(
                table: "VisitReasons",
                columns: new[] { "Id", "Description", "Type" },
                values: new object[,]
                {
                    { 1, "Техническое обслуживание", 1 },
                    { 2, "Ремонт кузова", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ef758a5-adb7-4dbb-a7d1-7a1c642bc806");

            migrationBuilder.DeleteData(
                table: "RemoveCarReasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateRequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 26, 15, 4, 10, 868, DateTimeKind.Local).AddTicks(8020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 14, 58, 11, 980, DateTimeKind.Local).AddTicks(4325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicDate",
                table: "DealershipFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 26, 12, 4, 10, 872, DateTimeKind.Utc).AddTicks(3595),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 11, 58, 11, 984, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateBirth", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Patronymic", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce539a1a-8b50-4d0b-9b63-01870d916534", 0, "Admin1", "21087e1e-8ebd-4265-9dba-5d5ab83c2fc4", new DateTime(2022, 8, 26, 12, 4, 11, 51, DateTimeKind.Utc).AddTicks(918), "John-old@mail.ru", true, "Admin1", false, "Admin1", false, null, null, null, "$2a$11$fSsnGRqPEZk4si9S8euLV.EgNFa5fswzu7Uosyc1GRXn.OyvT6wlO", null, null, false, null, "b70fe409-e11a-4d8a-87b2-c51402f4e0b0", false, "Admin1" });
        }
    }
}
