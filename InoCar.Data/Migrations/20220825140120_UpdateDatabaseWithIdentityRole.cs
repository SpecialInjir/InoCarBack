using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InoCar.Data.Migrations
{
    public partial class UpdateDatabaseWithIdentityRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Drive",
                table: "Cars",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Cars",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RemoveCarReasonId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateNumber",
                table: "Cars",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Transmission",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealerships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatorNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealerships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActivatedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RemoveCarReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemoveCarReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    SeriaCTC = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    NumberCTC = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DateCTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarCertificates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResetPasswordCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetPasswordCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResetPasswordCodes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DealershipFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealershipId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PointNumber = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PublicDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 8, 25, 14, 1, 19, 925, DateTimeKind.Utc).AddTicks(7515))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealershipFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealershipFeedbacks_Dealerships_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealerships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceConsultants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealershipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceConsultants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceConsultants_Dealerships_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealerships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitReasonId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExploitationMonths = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceWorks_VisitReasons_VisitReasonId",
                        column: x => x.VisitReasonId,
                        principalTable: "VisitReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateId = table.Column<int>(type: "int", nullable: false),
                    WarrantyEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysBeforeTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KmBeforeTO = table.Column<int>(type: "int", nullable: false),
                    MileageToTO = table.Column<int>(type: "int", nullable: false),
                    LastVisitTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReminderOfMaintenance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderOfTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndividualOffers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCampaigns = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDetails_CarCertificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "CarCertificates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceConsultantId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_ServiceConsultants_ServiceConsultantId",
                        column: x => x.ServiceConsultantId,
                        principalTable: "ServiceConsultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaintenanceWorkId = table.Column<int>(type: "int", nullable: false),
                    PersonalOfferId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_MaintenanceWorks_MaintenanceWorkId",
                        column: x => x.MaintenanceWorkId,
                        principalTable: "MaintenanceWorks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_PersonalOffers_PersonalOfferId",
                        column: x => x.PersonalOfferId,
                        principalTable: "PersonalOffers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    DealershipId = table.Column<int>(type: "int", nullable: false),
                    VisitReasonId = table.Column<int>(type: "int", nullable: false),
                    ServiceConsultantId = table.Column<int>(type: "int", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsRequestConfirm = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 8, 25, 17, 1, 19, 923, DateTimeKind.Local).AddTicks(3041)),
                    RequestPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VisitReasonPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecommendationsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PersonalOffersPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RecommendationServiceRequestId = table.Column<int>(type: "int", nullable: true),
                    PersonalOfferServiceRequestId = table.Column<int>(type: "int", nullable: true),
                    RequestType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Dealerships_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealerships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRequests_ServiceConsultants_ServiceConsultantId",
                        column: x => x.ServiceConsultantId,
                        principalTable: "ServiceConsultants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRequests_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRequests_VisitReasons_VisitReasonId",
                        column: x => x.VisitReasonId,
                        principalTable: "VisitReasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MileageLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WorkTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MileageLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MileageLevels_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonalOfferServiceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalOfferId = table.Column<int>(type: "int", nullable: false),
                    ServiceRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalOfferServiceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalOfferServiceRequests_PersonalOffers_PersonalOfferId",
                        column: x => x.PersonalOfferId,
                        principalTable: "PersonalOffers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalOfferServiceRequests_ServiceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecommendationServiceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecommendationId = table.Column<int>(type: "int", nullable: false),
                    ServiceRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationServiceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendationServiceRequests_Recommendations_RecommendationId",
                        column: x => x.RecommendationId,
                        principalTable: "Recommendations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecommendationServiceRequests_ServiceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CertificateId",
                table: "Cars",
                column: "CertificateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RemoveCarReasonId",
                table: "Cars",
                column: "RemoveCarReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarCertificates_UserId",
                table: "CarCertificates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_CertificateId",
                table: "CarDetails",
                column: "CertificateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DealershipFeedbacks_DealershipId",
                table: "DealershipFeedbacks",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceWorks_VisitReasonId",
                table: "MaintenanceWorks",
                column: "VisitReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MileageLevels_ProductId",
                table: "MileageLevels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalOfferServiceRequests_PersonalOfferId",
                table: "PersonalOfferServiceRequests",
                column: "PersonalOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalOfferServiceRequests_ServiceRequestId",
                table: "PersonalOfferServiceRequests",
                column: "ServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MaintenanceWorkId",
                table: "Products",
                column: "MaintenanceWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PersonalOfferId",
                table: "Products",
                column: "PersonalOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationServiceRequests_RecommendationId",
                table: "RecommendationServiceRequests",
                column: "RecommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationServiceRequests_ServiceRequestId",
                table: "RecommendationServiceRequests",
                column: "ServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResetPasswordCodes_UserId",
                table: "ResetPasswordCodes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceConsultants_DealershipId",
                table: "ServiceConsultants",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_CarId",
                table: "ServiceRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_DealershipId",
                table: "ServiceRequests",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ServiceConsultantId",
                table: "ServiceRequests",
                column: "ServiceConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_TimeSlotId",
                table: "ServiceRequests",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_UserId",
                table: "ServiceRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_VisitReasonId",
                table: "ServiceRequests",
                column: "VisitReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_ServiceConsultantId",
                table: "TimeSlots",
                column: "ServiceConsultantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCertificates_CertificateId",
                table: "Cars",
                column: "CertificateId",
                principalTable: "CarCertificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_RemoveCarReasons_RemoveCarReasonId",
                table: "Cars",
                column: "RemoveCarReasonId",
                principalTable: "RemoveCarReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCertificates_CertificateId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_RemoveCarReasons_RemoveCarReasonId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarDetails");

            migrationBuilder.DropTable(
                name: "DealershipFeedbacks");

            migrationBuilder.DropTable(
                name: "MileageLevels");

            migrationBuilder.DropTable(
                name: "PersonalOfferServiceRequests");

            migrationBuilder.DropTable(
                name: "RecommendationServiceRequests");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RegistrationUsers");

            migrationBuilder.DropTable(
                name: "RemoveCarReasons");

            migrationBuilder.DropTable(
                name: "ResetPasswordCodes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CarCertificates");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "MaintenanceWorks");

            migrationBuilder.DropTable(
                name: "PersonalOffers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "VisitReasons");

            migrationBuilder.DropTable(
                name: "ServiceConsultants");

            migrationBuilder.DropTable(
                name: "Dealerships");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CertificateId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RemoveCarReasonId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Drive",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EngineType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RemoveCarReasonId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "StateNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
