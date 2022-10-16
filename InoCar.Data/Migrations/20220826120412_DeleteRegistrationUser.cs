using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InoCar.Data.Migrations
{
    public partial class DeleteRegistrationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateRequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 26, 15, 4, 10, 868, DateTimeKind.Local).AddTicks(8020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 21, 4, 15, 747, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicDate",
                table: "DealershipFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 26, 12, 4, 10, 872, DateTimeKind.Utc).AddTicks(3595),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 18, 4, 15, 752, DateTimeKind.Utc).AddTicks(2355));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateBirth", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Patronymic", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce539a1a-8b50-4d0b-9b63-01870d916534", 0, "Admin1", "21087e1e-8ebd-4265-9dba-5d5ab83c2fc4", new DateTime(2022, 8, 26, 12, 4, 11, 51, DateTimeKind.Utc).AddTicks(918), "John-old@mail.ru", true, "Admin1", false, "Admin1", false, null, null, null, "$2a$11$fSsnGRqPEZk4si9S8euLV.EgNFa5fswzu7Uosyc1GRXn.OyvT6wlO", null, null, false, null, "b70fe409-e11a-4d8a-87b2-c51402f4e0b0", false, "Admin1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce539a1a-8b50-4d0b-9b63-01870d916534");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistrationCode",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateRequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 21, 4, 15, 747, DateTimeKind.Local).AddTicks(8268),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 26, 15, 4, 10, 868, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicDate",
                table: "DealershipFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 18, 4, 15, 752, DateTimeKind.Utc).AddTicks(2355),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 26, 12, 4, 10, 872, DateTimeKind.Utc).AddTicks(3595));

            migrationBuilder.CreateTable(
                name: "RegistrationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationUsers", x => x.Id);
                });
        }
    }
}
