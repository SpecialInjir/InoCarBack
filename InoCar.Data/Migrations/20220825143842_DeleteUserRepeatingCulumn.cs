using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InoCar.Data.Migrations
{
    public partial class DeleteUserRepeatingCulumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateRequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 17, 38, 41, 636, DateTimeKind.Local).AddTicks(5653),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 17, 1, 19, 923, DateTimeKind.Local).AddTicks(3041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicDate",
                table: "DealershipFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 38, 41, 639, DateTimeKind.Utc).AddTicks(4149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 1, 19, 925, DateTimeKind.Utc).AddTicks(7515));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateRequestDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 17, 1, 19, 923, DateTimeKind.Local).AddTicks(3041),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 17, 38, 41, 636, DateTimeKind.Local).AddTicks(5653));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicDate",
                table: "DealershipFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 1, 19, 925, DateTimeKind.Utc).AddTicks(7515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 38, 41, 639, DateTimeKind.Utc).AddTicks(4149));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
