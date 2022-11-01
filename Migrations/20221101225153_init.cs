using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafe.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

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
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "BookingForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guests = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Cuisine = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Plates = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Checked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Table = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "BookingFormExtraService",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    ExtrasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingFormExtraService", x => new { x.BookingsId, x.ExtrasId });
                    table.ForeignKey(
                        name: "FK_BookingFormExtraService_BookingForms_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "BookingForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingFormExtraService_ExtraServices_ExtrasId",
                        column: x => x.ExtrasId,
                        principalTable: "ExtraServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GalleryImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryImages_Galleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuSubCats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuCategoryId = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSubCats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuSubCats_MenuCategories_MenuCategoryId",
                        column: x => x.MenuCategoryId,
                        principalTable: "MenuCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingFormVenue",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    VenuesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingFormVenue", x => new { x.BookingsId, x.VenuesId });
                    table.ForeignKey(
                        name: "FK_BookingFormVenue_BookingForms_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "BookingForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingFormVenue_Venues_VenuesId",
                        column: x => x.VenuesId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenueImages_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuSubCatId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuSubCats_MenuSubCatId",
                        column: x => x.MenuSubCatId,
                        principalTable: "MenuSubCats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "About",
                columns: new[] { "Id", "Description", "Motto", "Name", "URL" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse mi tellus, volutpat sit amet efficitur id, venenatis et metus. Mauris laoreet eros eget est consequat, ut rhoncus tortor accumsan. Vivamus purus dui, porta eget blandit consequat, semper sed nulla. Morbi suscipit dolor sem, placerat congue sem fermentum eu. Nam mi nulla, ullamcorper et enim non, maximus cursus nunc. Nunc suscipit gravida varius. Interdum et malesuada fames ac ante ipsum primis in faucibus.\r\n\r\nQuisque metus dui, malesuada vitae libero sit amet, ullamcorper blandit risus. Nam vitae est tincidunt, luctus risus sed, lobortis turpis. Sed in dictum orci. Nullam sed neque nec lacus ultrices fringilla quis eu nibh. Duis tempor mauris eu sem egestas lobortis. Vivamus pellentesque sapien non orci facilisis, in accumsan lorem porttitor. Aliquam erat volutpat. In a scelerisque eros. Ut sit amet ante massa. Nulla turpis metus, tincidunt eget tortor sit amet, euismod venenatis lorem. Duis libero ipsum, mattis vel quam eget, porta iaculis justo. Proin nulla lacus, mollis vitae malesuada quis, pulvinar eget risus. Curabitur euismod elit tristique, commodo enim at, facilisis est.\r\n\r\nInteger tincidunt dapibus lorem, nec varius lorem sodales quis. Curabitur nec nulla tempor, molestie augue a, dignissim nunc. Aenean pretium volutpat urna, id varius mi laoreet sit amet. Donec mi lacus, mollis et turpis ac, fringilla cursus orci. Mauris vestibulum lectus consequat ligula ultrices, eu elementum turpis imperdiet. Mauris sed condimentum ligula, non ornare quam. Curabitur laoreet nunc non odio euismod, eu ultrices quam laoreet. Morbi at faucibus neque", "Motto", "Om  Café", "https://picsum.photos/id/1060/5598/3732.jpg" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e452e-3b0e-446f-86af-483d56fd7210", "c78d7e51-f6f4-4afe-a936-8fdb7c4ad5d1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e973922-a44d-4543-a6c6-9814d048cdb9", 0, "14496603-853c-4ea2-8d1c-43af2b78cbe3", "e@mail.com", true, "FirstName", "LastName", false, null, "E@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEPyEvC/uSODgqdEAYZLLt2ZKX5dOy7/Lxp1rgYa8CHAu7DTkn9FVA7Ec8r045RjSOg==", null, true, "0db6f357-89b3-4476-bc7e-ddb3f95389ee", false, "admin" });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "Checked", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, "Dekoration", 0.0 },
                    { 2, false, "Städning", 0.0 },
                    { 3, false, "Utkörning", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "Description", "Name", "TimeStamp" },
                values: new object[,]
                {
                    { 1, "", "Galleri1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", "Galleri2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Förrätter" },
                    { 2, "Huvudrätter" },
                    { 3, "Drycker" },
                    { 4, "Efterrätter" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "_address", "Street, Zip, City" },
                    { 2, "_phone", "Phone" },
                    { 3, "_email", "e@mail.com" },
                    { 4, "_opening1", "Sön-Tor: 17:00-01:00" },
                    { 5, "_opening2", "Fre-Lör: 17:00-02:00" },
                    { 6, "homeSlide", "https://picsum.photos/id/100/2500/1656.jpg" },
                    { 7, "homeSlide", "https://picsum.photos/id/1002/4312/2868.jpg" },
                    { 8, "homeSlide", "https://picsum.photos/id/1016/3844/2563.jpg" },
                    { 9, "homeSlide", "https://picsum.photos/id/102/4320/3240.jpg" },
                    { 10, "homeSlide", "https://picsum.photos/id/1020/4288/2848.jpg" },
                    { 11, "venueSlide", "https://picsum.photos/id/1022/6000/3376.jpg" },
                    { 12, "venueSlide", "https://picsum.photos/id/1021/2048/1206.jpg" },
                    { 13, "venueSlide", "https://picsum.photos/id/1031/5446/3063.jpg" },
                    { 14, "venueSlide", "https://picsum.photos/id/1029/4887/2759.jpg" },
                    { 15, "venueSlide", "https://picsum.photos/id/1033/2048/1365.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Policy",
                columns: new[] { "Id", "CreateDate", "Description", "EditDate", "Lead", "Name" },
                values: new object[] { 1, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse mi tellus, volutpat sit amet efficitur id, venenatis et metus. Mauris laoreet eros eget est consequat, ut rhoncus tortor accumsan. Vivamus purus dui, porta eget blandit consequat, semper sed nulla. Morbi suscipit dolor sem, placerat congue sem fermentum eu. Nam mi nulla, ullamcorper et enim non, maximus cursus nunc. Nunc suscipit gravida varius. Interdum et malesuada fames ac ante ipsum primis in faucibus.\r\n\r\nQuisque metus dui, malesuada vitae libero sit amet, ullamcorper blandit risus. Nam vitae est tincidunt, luctus risus sed, lobortis turpis. Sed in dictum orci. Nullam sed neque nec lacus ultrices fringilla quis eu nibh. Duis tempor mauris eu sem egestas lobortis. Vivamus pellentesque sapien non orci facilisis, in accumsan lorem porttitor. Aliquam erat volutpat. In a scelerisque eros. Ut sit amet ante massa. Nulla turpis metus, tincidunt eget tortor sit amet, euismod venenatis lorem. Duis libero ipsum, mattis vel quam eget, porta iaculis justo. Proin nulla lacus, mollis vitae malesuada quis, pulvinar eget risus. Curabitur euismod elit tristique, commodo enim at, facilisis est.\r\n\r\nInteger tincidunt dapibus lorem, nec varius lorem sodales quis. Curabitur nec nulla tempor, molestie augue a, dignissim nunc. Aenean pretium volutpat urna, id varius mi laoreet sit amet. Donec mi lacus, mollis et turpis ac, fringilla cursus orci. Mauris vestibulum lectus consequat ligula ultrices, eu elementum turpis imperdiet. Mauris sed condimentum ligula, non ornare quam. Curabitur laoreet nunc non odio euismod, eu ultrices quam laoreet. Morbi at faucibus neque", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead", "Integritetspolicy" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Area", "Description", "Equipment", "Guests", "Name", "Other", "Price", "Table" },
                values: new object[,]
                {
                    { 1, "Area", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse mi tellus, volutpat sit amet efficitur id, venenatis et metus. Mauris laoreet eros eget est consequat, ut rhoncus tortor accumsan.", "Utrustning", "Gäster", "Sal 1", "Övrigt", 0.0, "Bord" },
                    { 2, "Area", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse mi tellus, volutpat sit amet efficitur id, venenatis et metus. Mauris laoreet eros eget est consequat, ut rhoncus tortor accumsan.", "Utrustning", "Gäster", "Sal 2", "Övrigt", 0.0, "Bord" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e452e-3b0e-446f-86af-483d56fd7210", "8e973922-a44d-4543-a6c6-9814d048cdb9" });

            migrationBuilder.InsertData(
                table: "GalleryImages",
                columns: new[] { "Id", "Description", "GalleryId", "TimeStamp", "URL" },
                values: new object[,]
                {
                    { 1, "", 1, new DateTime(2022, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/id/1060/5598/3732.jpg" },
                    { 2, "", 1, new DateTime(2022, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/id/1059/7360/4912.jpg" },
                    { 3, "", 1, new DateTime(2022, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/id/1068/7117/4090.jpg" },
                    { 4, "", 2, new DateTime(2022, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/id/113/4168/2464.jpg" },
                    { 5, "", 2, new DateTime(2022, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/id/117/1544/1024.jpg" }
                });

            migrationBuilder.InsertData(
                table: "MenuSubCats",
                columns: new[] { "Id", "MenuCategoryId", "Name", "URL" },
                values: new object[,]
                {
                    { 1, 1, "Varm meza", "/image/menu/VarmMeza.jpg" },
                    { 2, 1, "Kall meza", "/image/menu/KallMeza.jpg" },
                    { 3, 2, "Sallad och kyckling", "/image/menu/SalladOchKyckling.jpg" },
                    { 4, 2, "Burgare och pizza", "/image/menu/BurgareOchPizza.jpg" },
                    { 5, 3, "Färsk juice", "/image/menu/FreshJuice.jpg" },
                    { 6, 3, "Kalla drycker", "/image/menu/KallaDrycker.jpg" },
                    { 7, 3, "Varma drycker", "/image/menu/VarmaDrycker.jpg" },
                    { 8, 4, "Tårtor", "/image/menu/Tartor.jpg" }
                });

            migrationBuilder.InsertData(
                table: "VenueImages",
                columns: new[] { "Id", "URL", "VenueId" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/id/1060/5598/3732.jpg", 1 },
                    { 2, "https://picsum.photos/id/1059/7360/4912.jpg", 1 },
                    { 3, "https://picsum.photos/id/1068/7117/4090.jpg", 1 },
                    { 4, "https://picsum.photos/id/113/4168/2464.jpg", 1 },
                    { 5, "https://picsum.photos/id/117/1544/1024.jpg", 2 },
                    { 6, "https://picsum.photos/id/119/3264/2176.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "MenuSubCatId", "Name", "Price", "URL" },
                values: new object[,]
                {
                    { 101, "Kycklingkryddor och salt.", 1, "Kycklingvingar", 45.0, "/image/menu/kycklingvingar.jpg" },
                    { 102, "Bulgur, köttfärs, röd paprika, blandade kryddor, salt, lök, morot, persilja.", 1, "Kubba Tarabulsi", 65.0, "/image/menu/kibbeh.jpg" },
                    { 103, "Mozzarella.", 1, "Mozzarella chips", 73.0, "/image/menu/mozzarella-sticks.jpg" },
                    { 104, "Chili cheese 6st.", 1, "Chili cheese", 73.0, "/image/menu/chili-cheese.jpg" },
                    { 105, "Pommes.", 1, "Pommes", 73.0, "/image/menu/french-fries.jpg" },
                    { 106, "Kycklinglever (Sauda Djaj).", 1, "Kycklinglever (Sauda Djaj)", 73.0, "/image/menu/chicken-liver.jpg" },
                    { 107, "Lökringar 8st.", 1, "Lökringar", 73.0, "/image/menu/lokringar.jpg" },
                    { 108, "Ostrullar 6st.", 1, "Ostrullar", 73.0, "/image/menu/ostrullar.jpg" },
                    { 201, "Persilja, färska tomater, lök, olivolja, bulgurvete, pressad citron och kryddor.", 2, "Tabouleh", 45.0, "/image/menu/tabbouleh-salad.jpg" },
                    { 202, "Gurka, tomater, rödlök, rädisor, persilja, mynta, olivolja, citron, sumak, salt.", 2, "Fatoush", 65.0, "/image/menu/fatoush.jpg" },
                    { 203, "Valnötter, paprika, ströbröd, vitlök, spiskummin, chili, granatäppelsirap, olivolja, citronsaft, kryddor.", 2, "Muhammara", 73.0, "/image/menu/muhammara.jpg" },
                    { 204, "Aubergin, tahini, vitlök, citronjuice, salt.", 2, "Baba ghanoush (Matbal)", 73.0, "/image/menu/baba-ghanoush.jpg" },
                    { 205, "Gurka, yoghurt, vitlök, salt, svartpeppar.", 2, "Tzatziki", 73.0, "/image/menu/tzatziki.jpg" },
                    { 206, "Gurka, rödlök, tomater, vitost, oregano, oliver, olivolja, rödvinsvinäger, svartpeppar.", 2, "Grekisk sallad", 73.0, "/image/menu/grekisk-sallad.jpg" },
                    { 207, "Chips.", 2, "Chips", 73.0, "/image/menu/chips.jpg" },
                    { 208, "Nötter.", 2, "Nötter", 73.0, "/image/menu/nuts.jpg" },
                    { 209, "Kikärtor, tahini, citronjuice, vitlök, olivolja, kummin, persilja, peppar, chili, salt.", 2, "Hummus Beiruti", 73.0, "/image/menu/hummus.jpg" },
                    { 210, "Kyckling, potatis, saltgurka, gröna ärtor, lök, majonnäs, ägg, oliver, persilja.", 2, "Sallad Olivier", 73.0, "/image/menu/olivier-sallad.jpg" },
                    { 211, "Labneh.", 2, "Labneh", 73.0, "/image/menu/labneh.jpg" },
                    { 212, "Fetaost.", 2, "Fetaost", 73.0, "/image/menu/feta.jpg" },
                    { 301, "Pasta, olivolja, mozzarella, soltorkade tomater, paprika, rödlök, rucola, salt, svartpeppar.", 3, "Pastasallad", 120.0, "/image/menu/pastasallad.jpg" },
                    { 302, "Kycklingfilé, olivolja, soja, vinäger, tomatpuré, vitlök.", 3, "Kycklingspett", 135.0, "/image/menu/kycklingspett.jpg" },
                    { 303, "Kyckling Crispy (med pommes).", 3, "Kyckling Crispy", 255.0, "/image/menu/kyckling-crispy.jpg" },
                    { 304, "Kyckling Shawarma (med pommes eller ris).", 3, "Kyckling Shawarma", 255.0, "/image/menu/shawarma.jpg" },
                    { 305, "Halv kyckling (med pommes eller ris).", 3, "Halv kyckling", 255.0, "/image/menu/halv-kyckling.jpg" },
                    { 401, "Hamburgare 150gr (med pommes).", 4, "Hamburgare", 120.0, "/image/menu/burgare-pommes.jpg" },
                    { 402, "Quzy med ris.", 4, "Quzy med ris", 135.0, "/image/menu/quzy.jpg" },
                    { 403, "Falafeltallrik.", 4, "Falafeltallrik", 255.0, "/image/menu/falafel.jpg" },
                    { 404, "Kebabpizza.", 4, "Kebabpizza", 255.0, "/image/menu/kebab-pizza.jpg" },
                    { 405, "Kycklingpizza.", 4, "Kycklingpizza", 255.0, "/image/menu/kyckling-pizza.jpg" },
                    { 406, "Havanapizza.", 4, "Havanapizza", 255.0, "/image/menu/havana-pizza.jpg" },
                    { 407, "Kebabtallrik (med pommes).", 4, "Kebabtallrik", 255.0, "/image/menu/kebab-fries4.jpg" },
                    { 501, "Mango.", 5, "Mango", 120.0, "/image/menu/Mango2.jpg" },
                    { 502, "Banan.", 5, "Banan", 135.0, "/image/menu/banana.jpg" },
                    { 503, "Hallon.", 5, "Hallon", 255.0, "/image/menu/hallon.jpg" },
                    { 504, "Jordgubb.", 5, "Jordgubb", 120.0, "/image/menu/jordgubb.jpg" },
                    { 505, "Apelsin.", 5, "Apelsin", 135.0, "/image/menu/apelsin.jpg" },
                    { 506, "Havana (cocktail).", 5, "Havana (cocktail)", 255.0, "/image/menu/havana.jpg" },
                    { 601, "Pepsi.", 6, "Pepsi", 120.0, "/image/menu/pepsi.jpg" },
                    { 602, "Fanta.", 6, "Fanta", 135.0, "/image/menu/fanta.jpg" },
                    { 603, "Powerking.", 6, "Powerking", 255.0, "/image/menu/powerking.jpg" },
                    { 604, "Lemon.", 6, "Lemon", 135.0, "/image/menu/lemon.jpg" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "MenuSubCatId", "Name", "Price", "URL" },
                values: new object[,]
                {
                    { 605, "Ayran.", 6, "Ayran", 255.0, "/image/menu/ayran.jpg" },
                    { 701, "Tea.", 7, "Tea", 120.0, "/image/menu/Tea.jpg" },
                    { 702, "Kaffe.", 7, "Kaffe", 135.0, "/image/menu/Kaffe.jpg" },
                    { 703, "Cappuccino.", 7, "Cappuccino", 255.0, "/image/menu/Cappuccino.jpg" },
                    { 801, "Kunafa.", 8, "Kunafa", 120.0, "/image/menu/Kunafa.jpg" },
                    { 802, "Chokladtårta.", 8, "Chokladtårta", 135.0, "/image/menu/chokladtarta.jpg" },
                    { 803, "Daimtårta.", 8, "Daimtårta", 255.0, "/image/menu/daimtarta.jpg" }
                });

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
                name: "IX_BookingFormExtraService_ExtrasId",
                table: "BookingFormExtraService",
                column: "ExtrasId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingFormVenue_VenuesId",
                table: "BookingFormVenue",
                column: "VenuesId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryImages_GalleryId",
                table: "GalleryImages",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuSubCatId",
                table: "MenuItems",
                column: "MenuSubCatId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSubCats_MenuCategoryId",
                table: "MenuSubCats",
                column: "MenuCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueImages_VenueId",
                table: "VenueImages",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

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
                name: "BookingFormExtraService");

            migrationBuilder.DropTable(
                name: "BookingFormVenue");

            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.DropTable(
                name: "GalleryImages");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "VenueImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ExtraServices");

            migrationBuilder.DropTable(
                name: "BookingForms");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "MenuSubCats");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "MenuCategories");
        }
    }
}
