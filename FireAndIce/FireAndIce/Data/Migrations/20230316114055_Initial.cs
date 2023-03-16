using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FireAndIce.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teches",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teches_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    TechId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Teches_TechId",
                        column: x => x.TechId,
                        principalTable: "Teches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e0ff732f-a85f-4074-98c5-586da377a133", "d5237cb9-9485-4c28-bd3c-801e40c0cc77", "Customer", "Customer" },
                    { "2da50d31-cc41-49ab-a803-751081216e59", "a9788190-f9f2-44b7-a7a5-bc545c19258c", "Tech", "Tech" },
                    { "6af7f330-deef-4a6d-becd-1223c011f425", "be5a1d3b-85fb-48ec-b20a-81731ae4916d", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f08d3a41-71b2-4e08-baba-85d6c51e8fb2", 0, "c171e85b-387c-43c7-b56e-81e2619aeb78", "customer96@abv.bg", false, "John", "Alexandrov", false, null, "customer96@abv.bg", "customer96@abv.bg", "AQAAAAEAACcQAAAAEFovydtLB1ZdtXIMUK66oIqpS6w5/5un23weUA0Pis19sh5kyClBuO9/R9FXZHJZ+g==", null, false, "", false, "customer96@abv.bg" },
                    { "2c225781-430b-427f-9587-79f8232b27db", 0, "b0fa3da2-2190-4b90-8ac1-787b78c2139b", "customer97@abv.bg", false, "Jane", "Johnson", false, null, "customer97@abv.bg", "customer97@abv.bg", "AQAAAAEAACcQAAAAEKicWjJ0zPd5zuiOgyddIllBg7Vmp2TQeZjpLuWxAay5HMTwJkk6nP5n8sNcb5mTgQ==", null, false, "", false, "customer97@abv.bg" },
                    { "69bb2b20-2fca-4feb-b6b0-7164bbb7f5eb", 0, "578940c2-bac1-49d3-92ea-0ea707aab428", "customer98@abv.bg", false, "Alex", "Alexandrov", false, null, "customer98@abv.bg", "customer98@abv.bg", "AQAAAAEAACcQAAAAEOG0tavJ7MC583d2ncZYz2wdZfFu2L7ncUv3yzrBGBYrLed3diY6yWvPiWD9OLusTA==", null, false, "", false, "customer98@abv.bg" },
                    { "a1479f93-a9a9-4b03-a032-36fc72c328d8", 0, "252d4a08-1846-4f08-9b49-07ed0f6b4eff", "customer99@abv.bg", false, "Alex", "Alexandrov", false, null, "customer99@abv.bg", "customer99@abv.bg", "AQAAAAEAACcQAAAAEIY7kFGmCT+EbECRd5XL5AJb+Gd7yfDpI2wfxZODZgeJR7KzR/s6gQe1laIajCGKAA==", null, false, "", false, "customer99@abv.bg" },
                    { "948a1f8e-52a2-4c78-b17d-9766db3bdf79", 0, "adf3cddd-8d04-4031-955b-fad66d1125c4", "tech0@abv.bg", false, "John", "Johnson", false, null, "tech0@abv.bg", "tech0@abv.bg", "AQAAAAEAACcQAAAAEB1jWCfcYp4BXIRjOTXuMkmB8V3UnXg2vkS0o+kibqtXXvnMi2usDNH6VMNE5Jf5qw==", null, false, "", false, "tech0@abv.bg" },
                    { "9f6dd3de-3513-495a-a21a-a90b784f29cd", 0, "b7773bd6-acc3-4e8f-bc9a-b7c6be297170", "tech1@abv.bg", false, "Jane", "Alexandrov", false, null, "tech1@abv.bg", "tech1@abv.bg", "AQAAAAEAACcQAAAAEPuSOpSRDC4oKvUqExcIq5k35K/4XXZrs1/Jf4ZzR1si9TvF1qCiV4TV/DoxNCqydw==", null, false, "", false, "tech1@abv.bg" },
                    { "d0883347-e216-4f3b-8ac4-804aced8fd00", 0, "8495dd62-43b7-461d-a08e-fcbcdcfc66aa", "tech2@abv.bg", false, "Alex", "Alexandrov", false, null, "tech2@abv.bg", "tech2@abv.bg", "AQAAAAEAACcQAAAAECdsJfQAV2UdKuf67lIhLhe6jM76ivCqQT9yTJ0anyXed8BugJYiWhoHasDTeB43tA==", null, false, "", false, "tech2@abv.bg" },
                    { "194018b2-90b9-4149-b85c-4e340e116989", 0, "f3d9426b-cc3c-4022-8a46-5f981dc90265", "tech3@abv.bg", false, "Jane", "Alexandrov", false, null, "tech3@abv.bg", "tech3@abv.bg", "AQAAAAEAACcQAAAAEC7Q6jh7uevcZ0W3rACN3ZAzDF7cE8C2QmKoW/gdW9p5w9uOpFVbws21J04ufTAjFw==", null, false, "", false, "tech3@abv.bg" },
                    { "89cff433-559c-41ad-b4ea-4dbd21a9e77e", 0, "25b7729f-5611-4089-88f5-e365d371198d", "tech4@abv.bg", false, "Jack", "Alexandrov", false, null, "tech4@abv.bg", "tech4@abv.bg", "AQAAAAEAACcQAAAAEGwR4GrT28UBS698wz2nMY1xJYFEaaGWyW+tdApDb6VvEg8II6YUrm3KEO7Nyd1cYA==", null, false, "", false, "tech4@abv.bg" },
                    { "7578a95e-1b98-45cf-812d-477224b13c8a", 0, "e11b3cad-c508-4828-b261-f406e49ace45", "tech5@abv.bg", false, "Alex", "Alexandrov", false, null, "tech5@abv.bg", "tech5@abv.bg", "AQAAAAEAACcQAAAAELiXI1T4XlLzmn2nK/O/uVYYYXKVJiZNlkidgMwsFpz3JDwgRZi3267cQNbjIhQxww==", null, false, "", false, "tech5@abv.bg" },
                    { "ac94f58b-95a4-485e-bc8a-7b35f59484b7", 0, "b9825417-d34a-400a-bd21-bdcec3bb3812", "tech6@abv.bg", false, "Jack", "Johnson", false, null, "tech6@abv.bg", "tech6@abv.bg", "AQAAAAEAACcQAAAAEI5Br40QOBN3FQDeVK9yjwofroJqvnaEiEvWYRzCEdwp6uQ9KysVuiAmCagl8vDBFQ==", null, false, "", false, "tech6@abv.bg" },
                    { "c314e5ba-8d94-49e8-aeeb-fba0646af9fe", 0, "36262fb6-e33c-4412-88e8-146183a3315c", "tech7@abv.bg", false, "Alex", "Alexandrov", false, null, "tech7@abv.bg", "tech7@abv.bg", "AQAAAAEAACcQAAAAEKMZRxiYlG1nm0Xrwl6MorBqHzpJUxmijaa7wEioXzqLf/5Sw59GtZfCoMDQ4AjoZg==", null, false, "", false, "tech7@abv.bg" },
                    { "e770ba82-94ee-4917-b97b-89365749f507", 0, "5c56e8bb-258f-47d4-ab03-019d37e4f03c", "tech8@abv.bg", false, "Alex", "Johnson", false, null, "tech8@abv.bg", "tech8@abv.bg", "AQAAAAEAACcQAAAAEJZ3bMK1IqpoGdU3RyOgN9IQIFczrdeduI5BY665BWPG7l1teq4edmQ52lFMrsl9lQ==", null, false, "", false, "tech8@abv.bg" },
                    { "362c7ba2-2051-4534-9a90-26e9fdc20289", 0, "5eb4a717-23fe-4e23-a9db-ef9624d85765", "tech9@abv.bg", false, "Jane", "Alexandrov", false, null, "tech9@abv.bg", "tech9@abv.bg", "AQAAAAEAACcQAAAAELmFvXoUey35tuUfTfhRTZi0pfB+FyUM4sezydQ3uMBjIrOvEq6l8qGt0v6f7PCJxQ==", null, false, "", false, "tech9@abv.bg" },
                    { "a28cd914-ca3b-4eb0-b4b1-4523ca3bc97c", 0, "7c4ac84f-bd76-4a77-b925-7b89541c3564", "tech10@abv.bg", false, "Jane", "Alexandrov", false, null, "tech10@abv.bg", "tech10@abv.bg", "AQAAAAEAACcQAAAAEJpGGxAxEPR5NowI7iO03F/B9fyFY6iWxNgbgAj2NuXhPLOddw+ioVcD8MzS/q0A2A==", null, false, "", false, "tech10@abv.bg" },
                    { "11dd66f1-b9ed-494e-8bbf-f29a5249cb8c", 0, "651f7b25-be49-47ec-902d-d193fbb26780", "customer95@abv.bg", false, "John", "Alexandrov", false, null, "customer95@abv.bg", "customer95@abv.bg", "AQAAAAEAACcQAAAAEL5ejsZP5ZDEotbSFf/r3xpI8sJLim2GjvaMwigQ4XFUOKplxPkiYQdjZgUyDGldNw==", null, false, "", false, "customer95@abv.bg" },
                    { "5801da1c-78f5-4a60-9b26-69e495b8a7c0", 0, "3eb94134-da0b-4c06-9105-3174a28de215", "tech11@abv.bg", false, "John", "Johnson", false, null, "tech11@abv.bg", "tech11@abv.bg", "AQAAAAEAACcQAAAAEIeiIYM3sgjGfqcGxw/4hlaoyvv5mTKW3yC4cI2FOjiLkoCa1Tki/174WkwwEkdqvA==", null, false, "", false, "tech11@abv.bg" },
                    { "fed71958-d8e9-4c46-9cf5-028e8e321dc1", 0, "9d269dc5-33fe-4c4b-82a9-7f64274b5505", "customer94@abv.bg", false, "Alex", "Johnson", false, null, "customer94@abv.bg", "customer94@abv.bg", "AQAAAAEAACcQAAAAEH+gA84RlVqGQ/Az1rtLeguYkVrKP9zUOHoa/X2zADpWbcR6ifUtEnWjW6Jy1H5Sxg==", null, false, "", false, "customer94@abv.bg" },
                    { "8143e151-7b7b-4534-a569-5de07accb4f2", 0, "9258ff13-2056-41f8-90eb-908a3ed20b0a", "customer92@abv.bg", false, "Jane", "Johnson", false, null, "customer92@abv.bg", "customer92@abv.bg", "AQAAAAEAACcQAAAAEEVmmer3BoPTiPnF3FWhnnSl9RgkgUx7mcrJ2NIa5a1VDmQGEU87NLaEAKomTZbcbQ==", null, false, "", false, "customer92@abv.bg" },
                    { "aeef8940-7ed5-44ba-9ec3-189c0b1a335e", 0, "4b05a089-d4a5-46d8-b078-354a67c6bf8c", "customer77@abv.bg", false, "John", "Johnson", false, null, "customer77@abv.bg", "customer77@abv.bg", "AQAAAAEAACcQAAAAEOulBLGwaLYPPVTDiKEr/P7gwIpoWzD1bggs7m6kAAPIRM/KwOuAZ5iyLUuBO7w+2g==", null, false, "", false, "customer77@abv.bg" },
                    { "91f210ec-2391-4f1d-a946-481d1bd7921c", 0, "cf52080c-31ef-4af7-855f-068009c0d90d", "customer78@abv.bg", false, "John", "Johnson", false, null, "customer78@abv.bg", "customer78@abv.bg", "AQAAAAEAACcQAAAAEENdvlrO8MLLzv//Hh/WOxVsArb2t+JoNN6JiJBSCDBQz+LThFSOYenG2B4AQV9pvQ==", null, false, "", false, "customer78@abv.bg" },
                    { "a85794d2-af47-40ee-b6ca-3e96235cb0f6", 0, "966af1ba-b220-415b-8822-1bd6b74b3b40", "customer79@abv.bg", false, "John", "Alexandrov", false, null, "customer79@abv.bg", "customer79@abv.bg", "AQAAAAEAACcQAAAAEJem6CGWFd+QhR3hBQvfaCyF3YMAtd61aYU3r6khpkkzy3ykHY6EDyFXbCneTnt96g==", null, false, "", false, "customer79@abv.bg" },
                    { "576763d2-ff5b-47b2-a264-1b549f8ac44e", 0, "d8a4cd2d-e150-4403-9c37-050bfec5c29e", "customer80@abv.bg", false, "Jane", "Alexandrov", false, null, "customer80@abv.bg", "customer80@abv.bg", "AQAAAAEAACcQAAAAEHncx+veFASw98kFYA+ytKgwjQPW76jW5Lek0FjQvsjk2YWoKycQPva2SJmAyRAd5w==", null, false, "", false, "customer80@abv.bg" },
                    { "82df2054-bafe-4490-9870-ddea23c743c7", 0, "389389cc-c504-4c58-ab9a-9b1bb5b7f7f5", "customer81@abv.bg", false, "Jane", "Johnson", false, null, "customer81@abv.bg", "customer81@abv.bg", "AQAAAAEAACcQAAAAEFKj5V59qlYrcrVYx91NNLEmRP/cZiCf0/EeR5e+L5JCgl0U7Hh/2vLsiSvMmnBiOg==", null, false, "", false, "customer81@abv.bg" },
                    { "fb316f26-fa22-48cc-870d-8cfeeeac14f7", 0, "9ff59210-15a8-455d-9ab0-8688df9eeebd", "customer82@abv.bg", false, "Alex", "Alexandrov", false, null, "customer82@abv.bg", "customer82@abv.bg", "AQAAAAEAACcQAAAAEL0ilGCs0qeQb8X6IKVYkZwZ8CJ7HCiKMVwPQv3ykA0Ly6HBCPg9H9kfjaOmnpEyqw==", null, false, "", false, "customer82@abv.bg" },
                    { "965c2777-3078-4080-ae35-e23f85842774", 0, "dedd267b-c181-4e7b-ada3-b18e82843877", "customer83@abv.bg", false, "Alex", "Johnson", false, null, "customer83@abv.bg", "customer83@abv.bg", "AQAAAAEAACcQAAAAEMBx1QIiWiJMs0Ctwom+UZP/2bJD1YLnWcf/kit6UggpcZo9OW12DbJMKwyGOSlV6Q==", null, false, "", false, "customer83@abv.bg" },
                    { "25fd9fb7-39bb-414d-8af8-a55d00dd6326", 0, "03e0b6ba-89ca-4de4-af54-9dfce5dbfa42", "customer84@abv.bg", false, "Alex", "Alexandrov", false, null, "customer84@abv.bg", "customer84@abv.bg", "AQAAAAEAACcQAAAAEIcesxMTazB9UvJp+H15kKUgqHPFis2m/YrjeHW9BsiMKEp2XbnSGBx/uqYiWy/DBQ==", null, false, "", false, "customer84@abv.bg" },
                    { "e26d393c-d3ca-4855-b98e-081285afe8f3", 0, "82f60736-54ce-42e3-88da-072f6287083e", "customer85@abv.bg", false, "Alex", "Alexandrov", false, null, "customer85@abv.bg", "customer85@abv.bg", "AQAAAAEAACcQAAAAECeLpfYdXebvSyBChdPDUDdA8kWKk+vbMqepareKYb8TZdOh0iOttzpwlFGt4lUlGg==", null, false, "", false, "customer85@abv.bg" },
                    { "f0b23caa-2cd5-4202-8f93-8bf03f7b4b5c", 0, "8d5c93ed-9d66-4857-9a15-32199c589738", "customer86@abv.bg", false, "Jack", "Alexandrov", false, null, "customer86@abv.bg", "customer86@abv.bg", "AQAAAAEAACcQAAAAEA0xN2SJdrLyEz2u0dke9rBWIkNQ7cHJwIyNxWoqoixlB9dhmNkkuOGxno1c4oIblQ==", null, false, "", false, "customer86@abv.bg" },
                    { "312bc9e8-a6b8-4922-ab32-7ef2dca803bb", 0, "153c8a4f-4627-4330-ab35-32cf6d1a2040", "customer87@abv.bg", false, "Jane", "Johnson", false, null, "customer87@abv.bg", "customer87@abv.bg", "AQAAAAEAACcQAAAAECpw6c8K7syIE8MSEEkeNDn1Krf4G0Nb29knDY9R3aL/zi19/cSwbcJ2v3/lJDVr2w==", null, false, "", false, "customer87@abv.bg" },
                    { "c807c283-0793-4862-9bb7-6da63def57c1", 0, "7d75c880-5e2a-42f6-8a92-01325dc91536", "customer88@abv.bg", false, "Jane", "Alexandrov", false, null, "customer88@abv.bg", "customer88@abv.bg", "AQAAAAEAACcQAAAAECdwS9QWOa36bkBGOAoEjcDJJ8acPDe0wb8q7NiCP5N4jh4AR/faQn1hw4yHTTUSiQ==", null, false, "", false, "customer88@abv.bg" },
                    { "29664f76-e7e8-4d27-8926-0fbde88b0757", 0, "a5952527-a6db-4ea7-b7d6-b42fd68832f1", "customer89@abv.bg", false, "Jane", "Alexandrov", false, null, "customer89@abv.bg", "customer89@abv.bg", "AQAAAAEAACcQAAAAEFN1/nqfYGurv3QW8UgS8RD+HOx01KYCLjtWBjUFkmRgY2M4J8yJY+dekSt43SD1zA==", null, false, "", false, "customer89@abv.bg" },
                    { "df0ad0c9-0f6f-4fee-9f00-0a307be29e80", 0, "01e1346d-ef93-4c0a-bd51-1c2673156d1a", "customer90@abv.bg", false, "Alex", "Johnson", false, null, "customer90@abv.bg", "customer90@abv.bg", "AQAAAAEAACcQAAAAEJ26IfskGMxj7AUWpnXvjh+rOjRDKg0v8LIN3cnQHL2mrG1RAPhkMvQXomEU0f8SwQ==", null, false, "", false, "customer90@abv.bg" },
                    { "d0f866f3-44a8-4044-a3b8-f44e2875ead4", 0, "c7873039-e81d-4f24-bf03-9a976502b63b", "customer91@abv.bg", false, "John", "Johnson", false, null, "customer91@abv.bg", "customer91@abv.bg", "AQAAAAEAACcQAAAAEAO8dV+eN80Yzg29hZfx4ftNeyuSe+dfTvbjlBi2k2d08AhgQgdlG0TWBL5cvXFCjA==", null, false, "", false, "customer91@abv.bg" },
                    { "a9da5fb2-e385-4a98-8b2a-173ebbdfacfd", 0, "ef63c5d9-9bb0-47fd-94a1-b26df0cdf360", "customer93@abv.bg", false, "Jack", "Johnson", false, null, "customer93@abv.bg", "customer93@abv.bg", "AQAAAAEAACcQAAAAEIq5tlDbWMspi25gYmE6+p8c3lJ6otm5rNM230QmFKKIyH+AgK+BZatcs/Zfq3qoEw==", null, false, "", false, "customer93@abv.bg" },
                    { "2a6a7295-5bbf-4fd7-a4f3-4159b011d085", 0, "6bb44839-3460-4514-885b-9ba2cb1799e2", "tech49@abv.bg", false, "Jack", "Alexandrov", false, null, "tech49@abv.bg", "tech49@abv.bg", "AQAAAAEAACcQAAAAEEwDoTkY/1dZH1Xebcznba3+jm6OGD8MkhhTmKgL7Cz/E2gJyIfVgATVzmrnGmbKzQ==", null, false, "", false, "tech49@abv.bg" },
                    { "7007925a-e9f9-48fb-a435-2097ba605ebf", 0, "3e252e86-87b2-45e4-a17f-997b56b71eed", "tech12@abv.bg", false, "John", "Johnson", false, null, "tech12@abv.bg", "tech12@abv.bg", "AQAAAAEAACcQAAAAEKp5LUxLyku7EI9KCbuM7rDKxZLp786PvqJvjfSP/Zhpf7e7i0EO9kLeOBeiQdqH3Q==", null, false, "", false, "tech12@abv.bg" },
                    { "9b5daa53-d39f-4a04-bbf1-a08693d821a7", 0, "6b198296-6ff7-4430-a137-9310ebd7b432", "tech14@abv.bg", false, "Alex", "Johnson", false, null, "tech14@abv.bg", "tech14@abv.bg", "AQAAAAEAACcQAAAAEHDg7yn3Wr5FeI2y5VLHnfG6IUBBUJfTJYj/Eli/imdyIf836esMYmEmMYAUyw2QFQ==", null, false, "", false, "tech14@abv.bg" },
                    { "cc8188ee-bce7-402a-a404-978be49cb2cf", 0, "5fe4f698-6509-4325-a38f-9a666a5a822e", "tech34@abv.bg", false, "Jack", "Johnson", false, null, "tech34@abv.bg", "tech34@abv.bg", "AQAAAAEAACcQAAAAEFMiMvSSZWTuAf5ZaxIUI3ytmzFsACKesAXFSiB52IN7g9TD5YZte/15LqMRlt6nBQ==", null, false, "", false, "tech34@abv.bg" },
                    { "9c25a871-ce26-4614-96b0-36fe3d858c35", 0, "4055bb9b-1af0-42b5-9c38-2f374baee506", "tech35@abv.bg", false, "Jane", "Alexandrov", false, null, "tech35@abv.bg", "tech35@abv.bg", "AQAAAAEAACcQAAAAEPDOl8h309tuIRT45xvn6Bl/U5ladN4/r4UxNCWHhtX+wMiIMcb0EqjE/CLT8OfYYg==", null, false, "", false, "tech35@abv.bg" },
                    { "3b6294de-004c-4471-ba99-bb24ff19a4f3", 0, "5f45d689-69c7-455c-8ab0-686efa926891", "tech36@abv.bg", false, "John", "Alexandrov", false, null, "tech36@abv.bg", "tech36@abv.bg", "AQAAAAEAACcQAAAAEGfj/bJRAODK+u8qdY0TXPip63MDQQ5Aa+lBjmnQjMyZ5yFYzARznABMcHvwx6DwwA==", null, false, "", false, "tech36@abv.bg" },
                    { "77fbd7a8-1599-42f9-b162-37f6b4ed2be7", 0, "c0fb68ab-6833-4c7c-8f42-54e21e55c534", "tech37@abv.bg", false, "Jane", "Alexandrov", false, null, "tech37@abv.bg", "tech37@abv.bg", "AQAAAAEAACcQAAAAEMP1aSdZCBqX7B5bvfvIQSf5oxqfRAz7NbJ9FASZDicwmyFosh8U0Rr5Jbqqc2+aNw==", null, false, "", false, "tech37@abv.bg" },
                    { "c761eae0-6481-4de5-80b3-a1bf017a1f5a", 0, "8318e37c-eb49-4df3-94c6-c680dfcf13a3", "tech38@abv.bg", false, "Alex", "Johnson", false, null, "tech38@abv.bg", "tech38@abv.bg", "AQAAAAEAACcQAAAAEArgY1f73hVIHPTFkaeY/2ZumfkHcoyGYKIom3vXtfWB0a+SXnt2gw3NgRyM4tMnGQ==", null, false, "", false, "tech38@abv.bg" },
                    { "7bc058c0-8c0a-4fb7-a42c-4cb0548ce56d", 0, "8185fb33-81a0-47f2-a382-692f57d048b3", "tech39@abv.bg", false, "Jane", "Alexandrov", false, null, "tech39@abv.bg", "tech39@abv.bg", "AQAAAAEAACcQAAAAENZMBrM6Aw9zMw2nyVgXoovW2mxv75pF9v2zLQVS/wn2uZalRBF5lp5plFyuBoElaw==", null, false, "", false, "tech39@abv.bg" },
                    { "d743b620-268c-4a3b-ba8e-60e86db2afda", 0, "d537d7aa-bc64-4f29-b9de-f7ee85d81e9c", "tech40@abv.bg", false, "John", "Johnson", false, null, "tech40@abv.bg", "tech40@abv.bg", "AQAAAAEAACcQAAAAEIYlb28MfkzbgSt6eToMFY8YWt1QlyPZ1XS6TaUni3Q4XovpC227wipuuY6d0bdzYA==", null, false, "", false, "tech40@abv.bg" },
                    { "7277146f-8e69-4d3f-99d0-ffa0d6c2eef9", 0, "aa6f6134-0698-4ad7-b4ad-9b64823a75eb", "tech41@abv.bg", false, "John", "Alexandrov", false, null, "tech41@abv.bg", "tech41@abv.bg", "AQAAAAEAACcQAAAAEO5q5YfJrM/PjdJLxTwtSOTerZSAe0ddO6FUxX9gMVrkDI9axRyfbnEcINT2Px5NKQ==", null, false, "", false, "tech41@abv.bg" },
                    { "df7ddce7-56ff-4c5e-bc5a-723ab7fffe32", 0, "0d08558d-8cbf-4a17-a5b6-292502f37825", "tech42@abv.bg", false, "John", "Alexandrov", false, null, "tech42@abv.bg", "tech42@abv.bg", "AQAAAAEAACcQAAAAEAk4BzXpov8DFAR8yqsbcTvi4uPBnQk1QVLGYssEpedJ/1ENVik54bT1vMVuKI2QLQ==", null, false, "", false, "tech42@abv.bg" },
                    { "5c464220-b2e4-44de-83b5-b534a3e12bbf", 0, "1c2fea26-a8fb-48af-8d07-0737c9425d05", "tech43@abv.bg", false, "Jane", "Alexandrov", false, null, "tech43@abv.bg", "tech43@abv.bg", "AQAAAAEAACcQAAAAEH36vJ77h65du2SZoNCeZocVSRtkF+RCwfiSEXWsdB6VWdN66s1hHrTxPMTmmUzeKg==", null, false, "", false, "tech43@abv.bg" },
                    { "a591b7f3-65f0-4af2-bf2a-6e137e632405", 0, "b2a2116c-812e-4ef4-bb4c-077c107ad330", "tech44@abv.bg", false, "Jack", "Alexandrov", false, null, "tech44@abv.bg", "tech44@abv.bg", "AQAAAAEAACcQAAAAEAdOjTsuJrWMfScXHQ5/4gbUbGEEvIuqbPdgndakOLUhbYS84XV9AiSvHBTgD4Xy9w==", null, false, "", false, "tech44@abv.bg" },
                    { "7cd5e764-2447-4510-ba5e-d599de72171b", 0, "2c0e7687-86c4-4cc0-a061-c69ab9befd4d", "tech45@abv.bg", false, "Jack", "Alexandrov", false, null, "tech45@abv.bg", "tech45@abv.bg", "AQAAAAEAACcQAAAAEDTC2HxUgEzIVcf8WNTuYPWTkkoSmevNz7j+RvJqbcMfLKZHbMoZflxvE4PVymOkug==", null, false, "", false, "tech45@abv.bg" },
                    { "9fafec2e-71ed-4e85-bb4e-b875c0680d47", 0, "a7eeaa3b-5652-434e-8df0-65a9d733a1e6", "tech46@abv.bg", false, "Jane", "Alexandrov", false, null, "tech46@abv.bg", "tech46@abv.bg", "AQAAAAEAACcQAAAAEFUjPvGCsuEj0WrC3wD9OyyrEtJpaALFrTHfQM8CJsQyy34L+XdgvJIh2nq9a8EG7w==", null, false, "", false, "tech46@abv.bg" },
                    { "533c9cfb-e2ef-49b7-82db-5c673ec9aff4", 0, "443aacb9-b7cd-4ad6-9e11-dbad8262d433", "tech47@abv.bg", false, "Jack", "Alexandrov", false, null, "tech47@abv.bg", "tech47@abv.bg", "AQAAAAEAACcQAAAAEGy9Z+g9UgheHFNQoWwrb+lgUt+gsnS5zBrG7kyptMOZ5nZ9GgvcpEj8fOiWZiLT4g==", null, false, "", false, "tech47@abv.bg" },
                    { "f05ec093-c375-4585-8c38-96f101714846", 0, "13a12f7a-437e-43d9-aea1-70a4af0ab2b2", "tech48@abv.bg", false, "John", "Alexandrov", false, null, "tech48@abv.bg", "tech48@abv.bg", "AQAAAAEAACcQAAAAEGPL4O1SYQD/e6DG9mUzBHw+726h0Ph1RsDzDlAwzW7fc1OxH6OWI7BmgkmRc/s9Hg==", null, false, "", false, "tech48@abv.bg" },
                    { "d5dae05b-719f-492d-922f-766e4d932a95", 0, "a0ac2827-06d0-40c4-bb64-ba3221016a62", "tech33@abv.bg", false, "Alex", "Johnson", false, null, "tech33@abv.bg", "tech33@abv.bg", "AQAAAAEAACcQAAAAELmzSpEVAqs4pcXnY1/SUdtGtMjT+RGhHfpKhu7XTPkSfDrRDPl2N2+cTWfS6i6CqA==", null, false, "", false, "tech33@abv.bg" },
                    { "31dc6d7f-6cf4-479f-baea-ed867fd593ed", 0, "059af3a0-38ca-4822-bdb9-8925c0bc7922", "customer76@abv.bg", false, "Jane", "Alexandrov", false, null, "customer76@abv.bg", "customer76@abv.bg", "AQAAAAEAACcQAAAAECI68anMkaNhJHoLsx6aoZsbQu+cA7ES+BwKO1LHbUPWc1h3uLHN6ZPpIQ9xqWE/pQ==", null, false, "", false, "customer76@abv.bg" },
                    { "a6695c20-ebd6-4200-a370-284c0e9ba040", 0, "cf3d2979-a6ce-4db4-a961-aeca130766af", "tech32@abv.bg", false, "Alex", "Johnson", false, null, "tech32@abv.bg", "tech32@abv.bg", "AQAAAAEAACcQAAAAEEpJ8UpDL6vyzM+GARYkEsJAVcFxJdzGJ30hGCAl+j/N7KOMTybVmu9oiZOdS15wSA==", null, false, "", false, "tech32@abv.bg" },
                    { "322c2a1f-647f-41ee-ac2e-86d5657a4ef0", 0, "9b942efd-590c-405d-b18b-7ea29ea5cd8e", "tech30@abv.bg", false, "Alex", "Johnson", false, null, "tech30@abv.bg", "tech30@abv.bg", "AQAAAAEAACcQAAAAEO5d6UAYtkcfbnTfJrW3lOCULNmflkE2NrpztWCBNV8P/45We8Mfpkb08gpZ8OtV9Q==", null, false, "", false, "tech30@abv.bg" },
                    { "c32106af-ded9-4fe7-9fcc-00523f1c816c", 0, "2fe9bbba-e010-4f62-86f4-3dc523baf32a", "tech15@abv.bg", false, "John", "Johnson", false, null, "tech15@abv.bg", "tech15@abv.bg", "AQAAAAEAACcQAAAAEDTGvOlY4q9vTPb4UtQLuLnt5YDHDYbeLxyLV84kZYePusuwT/HwNZDhwuOvKc++rQ==", null, false, "", false, "tech15@abv.bg" },
                    { "71e2263a-b524-433c-9ec1-626a37b6758c", 0, "ea6c061c-75a9-48bd-bf3a-b0c293eb56cb", "tech16@abv.bg", false, "Jack", "Alexandrov", false, null, "tech16@abv.bg", "tech16@abv.bg", "AQAAAAEAACcQAAAAEDL7IqH0Bezl1gXWrlVTJTGD5eHrmhASyVFSsXVmq+A/+2RzunUNBNZcotdq9TCAbw==", null, false, "", false, "tech16@abv.bg" },
                    { "32235ffc-9426-4539-b7fa-d6cf629e80b2", 0, "6fee6c74-5186-4942-8b6c-fd175906e597", "tech17@abv.bg", false, "Alex", "Alexandrov", false, null, "tech17@abv.bg", "tech17@abv.bg", "AQAAAAEAACcQAAAAEEBk417mARzZ3WysqTK4X9tF2PCyf/48aljnJCpkVdG1XsiCPSTLyGLYkURm4Slcqw==", null, false, "", false, "tech17@abv.bg" },
                    { "5914cc79-7378-4b4b-9eb1-c4eef0de6e0b", 0, "d7cf21ba-d6df-4a8f-b70c-56335ffac969", "tech18@abv.bg", false, "Jane", "Alexandrov", false, null, "tech18@abv.bg", "tech18@abv.bg", "AQAAAAEAACcQAAAAEKuBmSaXTjt0r2BiDcCWvvIYx2XR7NDiJFH+zla6Tocshdp3GxWR9Y06lChvVrxccg==", null, false, "", false, "tech18@abv.bg" },
                    { "b588a55b-20cc-4f66-8d70-568faa047f60", 0, "8e19765d-d773-491b-85cc-31258c328fde", "tech19@abv.bg", false, "Jane", "Alexandrov", false, null, "tech19@abv.bg", "tech19@abv.bg", "AQAAAAEAACcQAAAAEC+RV7irlYaWLP5F3QOGy7e+enNnq1QdDBdG6g/9n6la/WMY58BTj9ovfhOv+RbodQ==", null, false, "", false, "tech19@abv.bg" },
                    { "7633c82c-9291-4f02-9fca-78a5f383a0e4", 0, "7a32c84e-ba76-49b5-b4b4-5b1c8f0ab91d", "tech20@abv.bg", false, "Jane", "Johnson", false, null, "tech20@abv.bg", "tech20@abv.bg", "AQAAAAEAACcQAAAAEGRnsAEc3h8Oeb72yeM8v5y6qEQy6YzKycHZ4TyKyarhkSfcBr1LBxAqtk6x/FKpYA==", null, false, "", false, "tech20@abv.bg" },
                    { "97709b32-b137-4aeb-ac14-04a93d8665ae", 0, "2ec53acc-2605-4225-8b7b-6c4a88a523ee", "tech21@abv.bg", false, "Jack", "Johnson", false, null, "tech21@abv.bg", "tech21@abv.bg", "AQAAAAEAACcQAAAAEGXzc3e4ilw8f7495/UMGi8PMiBYX1Rg8C1Nd9i1EZISEuChc754y7nPBi9iVyicrg==", null, false, "", false, "tech21@abv.bg" },
                    { "40de74c1-1e6f-4fe2-9787-acd369b9985b", 0, "4d6bc034-4888-4f11-bea6-2b48ccdca59e", "tech22@abv.bg", false, "Jane", "Johnson", false, null, "tech22@abv.bg", "tech22@abv.bg", "AQAAAAEAACcQAAAAEEweobOmjxPURrlg425VavG6+wl2wis2FJr1VSoYL8/fmOJH42R4IdUTYNPFpuEx6A==", null, false, "", false, "tech22@abv.bg" },
                    { "7d2b6bf3-b2d2-480d-96d1-10e95f5311e7", 0, "d6a88e46-7078-40ae-aee8-4b66bb5f3fdd", "tech23@abv.bg", false, "Alex", "Johnson", false, null, "tech23@abv.bg", "tech23@abv.bg", "AQAAAAEAACcQAAAAECVWu9ROZcJKpNTtPUjJ4RLQVARaiqD2ER74wn4S+TvMmlzx2w46uPCNv576IkTb3g==", null, false, "", false, "tech23@abv.bg" },
                    { "64c059b6-7db2-4be7-b2b3-916c37809f62", 0, "d7bb1910-b11c-47ed-ae4e-ad0efadc167e", "tech24@abv.bg", false, "Jack", "Alexandrov", false, null, "tech24@abv.bg", "tech24@abv.bg", "AQAAAAEAACcQAAAAEFQKWBOoNsbjEkjtUxy5kLUWQEP5vg9GLjeBr9BhqZunKUkBjF5zTVdjUmdI5pyHSA==", null, false, "", false, "tech24@abv.bg" },
                    { "4f34bbaa-13a7-4c5f-b44f-4aeb97533abf", 0, "28978837-814d-42ca-b6c0-172e0a82b853", "tech25@abv.bg", false, "Alex", "Johnson", false, null, "tech25@abv.bg", "tech25@abv.bg", "AQAAAAEAACcQAAAAEIABdCjGSRllXOWdWzE538WMER5bSJJJqLTNFkWkdRJzS4gWjuVHj/WdD6P63e3lVA==", null, false, "", false, "tech25@abv.bg" },
                    { "1cc81c48-381f-4af1-a936-c5f627ba4bbd", 0, "35f7cc6f-8c47-41d6-88dd-cf2e5cc1a61d", "tech26@abv.bg", false, "Alex", "Johnson", false, null, "tech26@abv.bg", "tech26@abv.bg", "AQAAAAEAACcQAAAAEPU3zQ2azxpbUQ84h//SYvl0g9p49owoGxF44kHl1dReNX3BCsxJBncYobfRnnWBFw==", null, false, "", false, "tech26@abv.bg" },
                    { "521fc235-3fc3-4339-94c3-d3d07d50636a", 0, "a3e8a77e-1087-497a-a454-08fb32a8f5a0", "tech27@abv.bg", false, "Alex", "Alexandrov", false, null, "tech27@abv.bg", "tech27@abv.bg", "AQAAAAEAACcQAAAAEBtOApnx1t35FVRa6DJ9bxz9xACXYshw7gYfoVceApOZEQt9lZFJyrXqY2tIVLZzBw==", null, false, "", false, "tech27@abv.bg" },
                    { "d8f4796f-eb1f-4498-97ca-fc539ac770a2", 0, "64e6cf05-0ba6-46d0-9222-3178e657fe70", "tech28@abv.bg", false, "Alex", "Johnson", false, null, "tech28@abv.bg", "tech28@abv.bg", "AQAAAAEAACcQAAAAEFhtz+tj7oD9ZM/sbzE7zX+bMqfPl5dDOypsRO6b9LUFWobtNXCEWJZgsOzVJ0zURw==", null, false, "", false, "tech28@abv.bg" },
                    { "9039ac7a-31f4-40aa-960b-4d85235e2a17", 0, "0b383663-987e-430b-a25a-f882ce95f4bc", "tech29@abv.bg", false, "Jane", "Alexandrov", false, null, "tech29@abv.bg", "tech29@abv.bg", "AQAAAAEAACcQAAAAEHBg2Qzzlh3NygCDoMHGcnZvc2j0d5r5Vp/S4+ylvG4eQ4Bx8AXRTaC0gxlrI15sLQ==", null, false, "", false, "tech29@abv.bg" },
                    { "502b93f2-f52a-4ebf-a99d-8abfd4cfb272", 0, "d983e965-86da-4634-8d00-9369aa27faf7", "tech31@abv.bg", false, "Jane", "Johnson", false, null, "tech31@abv.bg", "tech31@abv.bg", "AQAAAAEAACcQAAAAEEcZpNNXwO4FFq+ylaH4ghyiDlNT1ojwHtagWLOJgd2ryl6Kook3dpSmmB2UrMTRYQ==", null, false, "", false, "tech31@abv.bg" },
                    { "850b3094-1933-49c1-a6ef-f71be3f52442", 0, "2d676a85-44bf-4750-8cce-e330f8411ce9", "tech13@abv.bg", false, "Jane", "Alexandrov", false, null, "tech13@abv.bg", "tech13@abv.bg", "AQAAAAEAACcQAAAAEGbfDBKOWh3HPimRRXAXh5+UOa5Nx8BmBQPkHYysJr2r2R8On3wy0AlwHA8LL024Hg==", null, false, "", false, "tech13@abv.bg" },
                    { "c1cb22a0-cb65-4a3a-af3e-01e0095f2add", 0, "eeef5bec-c3fb-4dc6-bd0f-38f4c131f884", "customer75@abv.bg", false, "Jane", "Johnson", false, null, "customer75@abv.bg", "customer75@abv.bg", "AQAAAAEAACcQAAAAEHkfwE5h9GqJDL2a15Eflz2eoYZoeXKtbITAZY415INGDfHod1aijLur96jb4W7q5g==", null, false, "", false, "customer75@abv.bg" },
                    { "40d5823e-cfa6-488c-8c6e-3aca2de1973e", 0, "b2e775f3-b946-4701-bba0-0b1b97310b01", "customer73@abv.bg", false, "Jack", "Alexandrov", false, null, "customer73@abv.bg", "customer73@abv.bg", "AQAAAAEAACcQAAAAEJETzZY8kNr6tmt1mVcKGJWsDylV7/Jd9tfuTAMpHgRNlTUUFgpW2r+2hsfwm7r8+w==", null, false, "", false, "customer73@abv.bg" },
                    { "b9500b41-fb45-4d1a-8e3e-6573789dc6b8", 0, "5b863076-4a32-4cec-8fc3-33ec4cd9803f", "customer19@abv.bg", false, "John", "Alexandrov", false, null, "customer19@abv.bg", "customer19@abv.bg", "AQAAAAEAACcQAAAAEHUsehrrNYafBJP6FR/CtUExFs9uecQMvJT51hBTuPQz+BrHYZZ4wr+v6DBlkCXyVw==", null, false, "", false, "customer19@abv.bg" },
                    { "0dd15d3e-5355-45ad-a001-542996dd4573", 0, "1a4c17f7-b65d-4c81-9d05-e5c16d0e4e6f", "customer20@abv.bg", false, "John", "Alexandrov", false, null, "customer20@abv.bg", "customer20@abv.bg", "AQAAAAEAACcQAAAAENJLzb/orYfGKm3UN25ebyXWPAbTa0QeaohB3aIeDJ2Rv/CY5Ml0cdshjDQMVvukSA==", null, false, "", false, "customer20@abv.bg" },
                    { "93a9bffa-db86-43d1-a513-1cb62388cd3d", 0, "b7bd2ca6-aa4f-46fa-8254-95278df46de3", "customer21@abv.bg", false, "John", "Alexandrov", false, null, "customer21@abv.bg", "customer21@abv.bg", "AQAAAAEAACcQAAAAEN++hArUvHu2V/+7B//aM+LWrOXPfHpeVeiEPJc4snp3c6LjIJdJzY2rLr1+c/ObdA==", null, false, "", false, "customer21@abv.bg" },
                    { "62b06123-99ca-4c85-96ef-26e7e293566d", 0, "61b0961a-8286-40d2-9686-5fc3444af93e", "customer22@abv.bg", false, "John", "Johnson", false, null, "customer22@abv.bg", "customer22@abv.bg", "AQAAAAEAACcQAAAAEFljXMO+4JkPZxRQ09EPP1wOg2H6kTl/20yx/OyrLpJwj58LP1dVr0gQkgEAMAHaKw==", null, false, "", false, "customer22@abv.bg" },
                    { "13fc052a-0b35-4554-bd7b-3aa5845f8569", 0, "6c511c51-bbea-4697-b73b-8cc8ba87f8d5", "customer23@abv.bg", false, "John", "Johnson", false, null, "customer23@abv.bg", "customer23@abv.bg", "AQAAAAEAACcQAAAAEAdaIx5LUUEvTzOFaZ1bx3WdFxFV4rp9BRk7ZnIrY59h6sdrxtrSGexRHZkxNsr8FA==", null, false, "", false, "customer23@abv.bg" },
                    { "1cbb7f54-6d2a-4a13-89a1-cedc03173719", 0, "80d979e8-648e-4135-9d04-bc8cef8a6633", "customer24@abv.bg", false, "Alex", "Alexandrov", false, null, "customer24@abv.bg", "customer24@abv.bg", "AQAAAAEAACcQAAAAELrzs3CbXoD8xss3jADFJqNFkRct9eKR3c9Btb+Sxsu9Dt3qZuokmg++dqRHlRY3hQ==", null, false, "", false, "customer24@abv.bg" },
                    { "fd722557-110f-4548-b9a8-d74e11b6a6fd", 0, "6bce0bf0-900c-41f1-a2b4-dc5fbff53a8e", "customer25@abv.bg", false, "Alex", "Alexandrov", false, null, "customer25@abv.bg", "customer25@abv.bg", "AQAAAAEAACcQAAAAEK+lYzzXz/2xU6YnCJ5THzhhJM6TOOq5fGvBXkUU4Vu3Zvjx/33oLnXpihODeHqbwg==", null, false, "", false, "customer25@abv.bg" },
                    { "eaeb2821-926c-4f0c-8dc7-740adaef2df8", 0, "1db67ec6-9c4e-4661-ba27-003eef537d22", "customer26@abv.bg", false, "Jane", "Johnson", false, null, "customer26@abv.bg", "customer26@abv.bg", "AQAAAAEAACcQAAAAEGNwNy7eJrFp85YJG5/u50auxSS9MToFRTQAu0HAzEKG5UdSfSTCA6t48+G88jWhnw==", null, false, "", false, "customer26@abv.bg" },
                    { "6e1f03cd-68e7-42cb-8968-28fa491c1837", 0, "6ae56907-5b33-48b0-9114-fbe30352c237", "customer27@abv.bg", false, "John", "Alexandrov", false, null, "customer27@abv.bg", "customer27@abv.bg", "AQAAAAEAACcQAAAAEG1FLELpL/KPXMqAyJ8UYPJ2Uvuby7NZSo+2Yi6k+GftT+IfwxQz3z9SW5VGOMkVdQ==", null, false, "", false, "customer27@abv.bg" },
                    { "2aa90e6b-6a73-4a4a-8a87-3d8248690e51", 0, "23eae2fb-1356-4cd5-bec6-b175240d3e34", "customer28@abv.bg", false, "Jane", "Johnson", false, null, "customer28@abv.bg", "customer28@abv.bg", "AQAAAAEAACcQAAAAEOyU9nTZrdJdkPtt31e45SkLskt4XqRyEpAjXJ4h4FhWe/HJXsTrhiNpcq8XG6IqfA==", null, false, "", false, "customer28@abv.bg" },
                    { "4b92d384-8570-48cc-ab0c-421c4688787c", 0, "50fbaabb-ac7f-4ab2-b6d2-9197aa9c1ad2", "customer29@abv.bg", false, "Jane", "Alexandrov", false, null, "customer29@abv.bg", "customer29@abv.bg", "AQAAAAEAACcQAAAAEN/rkoWm99HccTRRr88F2RAcMwkbJOiIz2qrcxeF6PP+Z5OdDC5gcDkYYyI3TMWaJw==", null, false, "", false, "customer29@abv.bg" },
                    { "1fa27583-f1f0-4b5f-86e5-28f6f73b757a", 0, "55e0dba9-7955-4a20-91dd-414bcd62295b", "customer30@abv.bg", false, "John", "Johnson", false, null, "customer30@abv.bg", "customer30@abv.bg", "AQAAAAEAACcQAAAAEE2e864qHOz+DWq/To1YowjGbLfH5D5PV9tG1dhHvAsBz9QYD/Nvgv7Wpe6Xj3rIpg==", null, false, "", false, "customer30@abv.bg" },
                    { "a212bb39-5362-4bbf-9f99-f7adc7e3e2b3", 0, "7c232127-d4d0-432c-8a2b-c08afd622b5f", "customer31@abv.bg", false, "Jack", "Alexandrov", false, null, "customer31@abv.bg", "customer31@abv.bg", "AQAAAAEAACcQAAAAEFySiveoFl6nPCeh51ljf4enjZxRxwkHqX1hNRLkd0ib0ZkAJXDt+r10zpEdDsvAeQ==", null, false, "", false, "customer31@abv.bg" },
                    { "6ef008f8-3be5-430e-87f0-40e387d481b4", 0, "c6c3d0c1-4ca4-4760-8c9d-6c24ab5df707", "customer32@abv.bg", false, "Jane", "Johnson", false, null, "customer32@abv.bg", "customer32@abv.bg", "AQAAAAEAACcQAAAAEKJHd/1pjjcDYiCfpKW11AVl0sCle9BgDAJ6jdIvdHvi0PInFybGVH5bw/W/Jt+TOQ==", null, false, "", false, "customer32@abv.bg" },
                    { "a310fd19-6001-4d79-9d63-3d1f9c4f4ecf", 0, "f04ad860-d9f1-48f0-ad4e-6904fecd50ec", "customer33@abv.bg", false, "Alex", "Johnson", false, null, "customer33@abv.bg", "customer33@abv.bg", "AQAAAAEAACcQAAAAEAS7+PgrDUg5pfoaxTj0NUGVACoO0n4GgTJckffisQcP4l6eK42Xk6Ql8m9S2swv+g==", null, false, "", false, "customer33@abv.bg" },
                    { "85e5cdb1-e14a-442d-a876-b4e27e92b651", 0, "adef2cdb-f77e-41c9-8056-cc44ae5443b1", "customer18@abv.bg", false, "Jane", "Johnson", false, null, "customer18@abv.bg", "customer18@abv.bg", "AQAAAAEAACcQAAAAEGYVVL+wJKawuFnu4F/VVEOBhBrDDpqnUSwwV3i/UaErU3ngJRZlnFWGuvi+8y8b/w==", null, false, "", false, "customer18@abv.bg" },
                    { "86af8660-bb8a-4412-a6a1-22ea7637cbfb", 0, "f2dedb50-bd35-4ace-a490-808c37b4978a", "customer34@abv.bg", false, "Alex", "Johnson", false, null, "customer34@abv.bg", "customer34@abv.bg", "AQAAAAEAACcQAAAAEBvPWkYtLQ6dlMhg+yaViwSag3UpNkUaUO/lyapMgcAbIlZQ4RuM5+yvXWHNNa5pdg==", null, false, "", false, "customer34@abv.bg" },
                    { "08423c78-cd4f-48ed-ab86-cb30117d151a", 0, "c1f142bc-8e3e-402d-bf22-f3d29e03b483", "customer17@abv.bg", false, "Jack", "Johnson", false, null, "customer17@abv.bg", "customer17@abv.bg", "AQAAAAEAACcQAAAAEDoJqvyHft9Hn58MJJVgZ7J/ctYWk7Jc/Fs6BMVCmxZ0hWzUBa+oIq7Ey9DFgqei7Q==", null, false, "", false, "customer17@abv.bg" },
                    { "4119e9bf-b571-431d-ac8b-f6cb5503288d", 0, "437076ee-ba3a-4ec2-8824-1f4052eeab14", "customer15@abv.bg", false, "John", "Johnson", false, null, "customer15@abv.bg", "customer15@abv.bg", "AQAAAAEAACcQAAAAEE+19vXqyr0EjNIPjQNPstZBK3Sd5poPmACZcPPoDum322PwkLVuQ0yRnfg6Dt7baQ==", null, false, "", false, "customer15@abv.bg" },
                    { "a1e6cbc5-cee7-42ea-8e29-671673a9053b", 0, "3da6060c-12e4-4ae9-b57d-e24b5629bc05", "customer0@abv.bg", false, "Jane", "Alexandrov", false, null, "customer0@abv.bg", "customer0@abv.bg", "AQAAAAEAACcQAAAAENuSi+PWUeT4uae0HebhlvjwNVOx3UkBuMmO7OKFjhIMPQyS3wjUjN0rIVXJSPKwug==", null, false, "", false, "customer0@abv.bg" },
                    { "681b5575-da7a-47a1-8f32-8e51f4174863", 0, "f74418bd-f3f9-4422-8186-32f4faa6ad39", "customer1@abv.bg", false, "Jack", "Johnson", false, null, "customer1@abv.bg", "customer1@abv.bg", "AQAAAAEAACcQAAAAEC/N73kOK8iSMT2iCMfd3s2c8at8/lauxNUcqDKCkVDg/CtEkgA/aUwWML9+RP/HaQ==", null, false, "", false, "customer1@abv.bg" },
                    { "30d99250-8ed0-44d3-8bc8-085a3318d798", 0, "459385a9-e4eb-442f-abc6-eeea953c5df6", "customer2@abv.bg", false, "John", "Alexandrov", false, null, "customer2@abv.bg", "customer2@abv.bg", "AQAAAAEAACcQAAAAEMFWrrdKW32caWz8YNSDGM3ZNOM6TrS1EtCZKefaglwjhnT6H7N8+K6Aq66IG1OTbw==", null, false, "", false, "customer2@abv.bg" },
                    { "dbd3c4d2-7d14-4517-91f3-1bda2973cca3", 0, "09562032-af31-4233-bd19-51d42fe1520d", "customer3@abv.bg", false, "Jack", "Johnson", false, null, "customer3@abv.bg", "customer3@abv.bg", "AQAAAAEAACcQAAAAEHE0SQ+RX5koX+qEESW28zOWRjgUbdUz42WgIhwhC6LoV/Z35OZmVtuJsEj3z2usfg==", null, false, "", false, "customer3@abv.bg" },
                    { "bea14fa9-943d-4793-9e50-5c9aa99446d4", 0, "88967954-976b-4a2b-86a5-d31ce7f8a1c7", "customer4@abv.bg", false, "Jack", "Alexandrov", false, null, "customer4@abv.bg", "customer4@abv.bg", "AQAAAAEAACcQAAAAEBmaxzwuW1lepMmm0e6GwjQMVdgqWJy7eUK/STsk4JpnlOARbn67vN/Sc5YO0CB2PA==", null, false, "", false, "customer4@abv.bg" },
                    { "974517b9-04fd-448a-897d-4ab48ec9b13b", 0, "8e6cca88-75b4-4daf-9a61-a1165a18abe5", "customer5@abv.bg", false, "John", "Johnson", false, null, "customer5@abv.bg", "customer5@abv.bg", "AQAAAAEAACcQAAAAEL6qrEi053IG+uGiWtjZVJIydTTy2NudvDRtYdl6ATuZCpAb8RFOjV7Djra0Zsee9Q==", null, false, "", false, "customer5@abv.bg" },
                    { "bc642b6d-2363-4d87-874b-3d1c02e99da2", 0, "8e023ea0-72c8-4890-ac8f-b5471c38c313", "customer6@abv.bg", false, "Jack", "Alexandrov", false, null, "customer6@abv.bg", "customer6@abv.bg", "AQAAAAEAACcQAAAAEEUdsgjcKF3ezDIcauaSUv+Ts324lux8Bwx3ySVyjimx0eZA8nnhztlAzpnhMho8QQ==", null, false, "", false, "customer6@abv.bg" },
                    { "cb949aa9-355d-4e15-b247-dea281099490", 0, "0a1f2762-ba8c-410f-82c3-ad8f9ed4fc78", "customer7@abv.bg", false, "Jack", "Alexandrov", false, null, "customer7@abv.bg", "customer7@abv.bg", "AQAAAAEAACcQAAAAEOVqUo7URaB1bS0tbDTaPVVLXxGcLqCyOSE+WrpStxaNGddiD5RKOiTGRz+MAE+qpA==", null, false, "", false, "customer7@abv.bg" },
                    { "117d364c-a995-4cf4-8e7f-9525f1a22546", 0, "432b3cfe-27d9-42f5-b258-ffa171f16d36", "customer8@abv.bg", false, "Jack", "Alexandrov", false, null, "customer8@abv.bg", "customer8@abv.bg", "AQAAAAEAACcQAAAAEJ0QcQWAeMQ5zkkgoPwmWoSaL82GWsLngZkmczviw8PipqyA9AmxDlNiZKpePOJFAQ==", null, false, "", false, "customer8@abv.bg" },
                    { "fec8e098-3ba3-4a70-8d70-002538762b56", 0, "36401a54-81fb-448a-b282-426ce27a7b71", "customer9@abv.bg", false, "Jane", "Johnson", false, null, "customer9@abv.bg", "customer9@abv.bg", "AQAAAAEAACcQAAAAEMR6JrZNBqEoicw/0hAqD8A/+vGaM1X5/eDGshycUum/9vGyIAHJHe9Vyru+Ol7Rkw==", null, false, "", false, "customer9@abv.bg" },
                    { "d1c80d6c-5100-4879-a777-d030cca84746", 0, "17b8df7b-082a-4437-8c10-87fceb22cde8", "customer10@abv.bg", false, "John", "Johnson", false, null, "customer10@abv.bg", "customer10@abv.bg", "AQAAAAEAACcQAAAAEGiLqq7wZ+xTjMVPTEIJB/0rQL7rPPdjWgy2blPiZvjbB5jWOtLSAit5BbTo8zdt3Q==", null, false, "", false, "customer10@abv.bg" },
                    { "f4084a44-e0cd-40db-9505-64a7469a2c50", 0, "75b4366e-ff04-4c86-94ed-38486c62f69a", "customer11@abv.bg", false, "Jane", "Johnson", false, null, "customer11@abv.bg", "customer11@abv.bg", "AQAAAAEAACcQAAAAEEIpF8I6Y7C8dnTSLjgxzOdtim3zZ6J3W7h7rl+2iePAefqXs+F+GStDhchHiLMUGg==", null, false, "", false, "customer11@abv.bg" },
                    { "d4336be6-3df2-417d-853b-9fa51553182c", 0, "fd862eac-dc37-49a9-a0b2-47f34df604fd", "customer12@abv.bg", false, "John", "Alexandrov", false, null, "customer12@abv.bg", "customer12@abv.bg", "AQAAAAEAACcQAAAAELCH6qzTyKr1IGi/4wsO0FNJdQoDCeJzkU7b8Aw7of6vGgG1/b89LTrYVWCGHDZkbA==", null, false, "", false, "customer12@abv.bg" },
                    { "2b4d6a31-de60-4aec-bf93-dcee5a12414b", 0, "d3fff648-f478-4ec7-b6ea-9b3fa6506c58", "customer13@abv.bg", false, "Jane", "Johnson", false, null, "customer13@abv.bg", "customer13@abv.bg", "AQAAAAEAACcQAAAAEHrqtylmjdVGglbyEKE4X+lhHS/eg4MrkYjYaK7r8WvQM6AW6CAYCbReNQzbv1i9Wg==", null, false, "", false, "customer13@abv.bg" },
                    { "69ddf6f5-d7fd-4fc7-887f-05753e6cf674", 0, "513ff50f-4245-4c32-91dd-1bf061270978", "customer14@abv.bg", false, "John", "Alexandrov", false, null, "customer14@abv.bg", "customer14@abv.bg", "AQAAAAEAACcQAAAAEAD0He0OpUW3GSGwmGVinDpXW6xwNESlW/xXEd14fVj3/emf2R26v0t/iUyNHK4rWw==", null, false, "", false, "customer14@abv.bg" },
                    { "cbe52ec6-39cd-4fad-b086-aea8175e3d4e", 0, "d294887a-44cc-45bf-b4f0-c5073648dff0", "customer16@abv.bg", false, "Jane", "Johnson", false, null, "customer16@abv.bg", "customer16@abv.bg", "AQAAAAEAACcQAAAAEK60Ji5i7XC4iK6pAE0kK0MBx/m+V/o1Hi/JiHHQLIIqxSUY3SxNgwdUxHU/yx52mA==", null, false, "", false, "customer16@abv.bg" },
                    { "6c1dfe26-b1a3-4635-b026-e0e5a76b1dd9", 0, "e4793729-f273-4cd0-a81f-8ecb05f0e86c", "customer35@abv.bg", false, "Alex", "Johnson", false, null, "customer35@abv.bg", "customer35@abv.bg", "AQAAAAEAACcQAAAAEMfLsix47pRbg0WttvUzfi7PamhK+fsNS26wCQgxhW3GkPwotuyjtFd1ab9UdqXaUQ==", null, false, "", false, "customer35@abv.bg" },
                    { "67473ecd-7543-4b7d-991f-b83623a391cf", 0, "c729db1c-ee77-4277-b28f-653563230276", "customer36@abv.bg", false, "John", "Alexandrov", false, null, "customer36@abv.bg", "customer36@abv.bg", "AQAAAAEAACcQAAAAEDDmCa4MuZAQ8/cT2ynt0x1EjsK7BWe/Ywf0Zliaaf3GcT32ws/5CcCq2TsIMIQQ+g==", null, false, "", false, "customer36@abv.bg" },
                    { "99aedd8f-b760-4492-a1c4-9b18a83fd6d1", 0, "a2822806-7eec-43ca-9037-8888b2ffd524", "customer37@abv.bg", false, "Jack", "Johnson", false, null, "customer37@abv.bg", "customer37@abv.bg", "AQAAAAEAACcQAAAAEDnSa2yStnCv/0iKdO51YdFi1Ty4k3YxORQlaDJnfC7WXCsvH9z8m69kKo1yky6oRA==", null, false, "", false, "customer37@abv.bg" },
                    { "2ea694e8-365b-44e9-b9bc-521fb66caa66", 0, "4f241847-cfa6-4c49-8751-888ee3161b54", "customer58@abv.bg", false, "John", "Alexandrov", false, null, "customer58@abv.bg", "customer58@abv.bg", "AQAAAAEAACcQAAAAEIr94O1fXxINe2O75Xg457clJdugQhSMTFbs6gEP+VoYGmvV1ISQMklJWLByJ6kZ+A==", null, false, "", false, "customer58@abv.bg" },
                    { "e9ba0669-38f7-4d2c-af73-e6a66feee4cf", 0, "710f1a02-79d5-4007-8aba-29461793dae0", "customer59@abv.bg", false, "John", "Alexandrov", false, null, "customer59@abv.bg", "customer59@abv.bg", "AQAAAAEAACcQAAAAECAaNSbmHaj52qlXP9W/bGzQW1Z0njL0yQe134lhgtX93bHUX5XpsVqcVexu1LPrOA==", null, false, "", false, "customer59@abv.bg" },
                    { "3bfacaee-4f69-47db-bded-b88c5ea5f490", 0, "85db9283-8d72-44a9-a8da-d205cfa7bc88", "customer60@abv.bg", false, "John", "Alexandrov", false, null, "customer60@abv.bg", "customer60@abv.bg", "AQAAAAEAACcQAAAAEChkWJz30L53UsK1XkMp6gSCzTw+dNuKX05227g/Ew/HgK0YYMU6t+rkKHuojMTgGw==", null, false, "", false, "customer60@abv.bg" },
                    { "49ee6add-339f-435e-b9f4-fdf67745b992", 0, "928d274f-9a30-480f-83a3-360ec9a097a3", "customer61@abv.bg", false, "Jane", "Alexandrov", false, null, "customer61@abv.bg", "customer61@abv.bg", "AQAAAAEAACcQAAAAEHsFjN3bF0quHEpT6NUgIYv+SzpUSmSWt/GOYTHs6SzoaZg3zTxdAuElQxOrEx/fRQ==", null, false, "", false, "customer61@abv.bg" },
                    { "53a30961-09dc-4a71-b578-4d5394b24629", 0, "acffb13c-a986-4c6c-92be-1a2ae5c6ed44", "customer62@abv.bg", false, "John", "Johnson", false, null, "customer62@abv.bg", "customer62@abv.bg", "AQAAAAEAACcQAAAAEJlzvZPBzhRf7uozzcl4nRMDgG2WjwbwTIt3lnI+3r0Ocywl0/nvY2Iol4R80VQvaA==", null, false, "", false, "customer62@abv.bg" },
                    { "ef59ed5a-aab1-4e56-b0b3-7bf0f74de590", 0, "092bcb51-ca86-4b48-88bd-9232c85189cd", "customer63@abv.bg", false, "John", "Alexandrov", false, null, "customer63@abv.bg", "customer63@abv.bg", "AQAAAAEAACcQAAAAEL/qMQXMaNszzPjqZeHRHu9k74SgPSPq5nsRw4WMX1/ZXP23d6+vi/5Fel1aoxmYWA==", null, false, "", false, "customer63@abv.bg" },
                    { "8c7209c3-fc1d-4867-83d9-609c87ff4824", 0, "e345290a-c73b-47f5-9e87-77b3abd1a70a", "customer64@abv.bg", false, "John", "Alexandrov", false, null, "customer64@abv.bg", "customer64@abv.bg", "AQAAAAEAACcQAAAAEAZjhNsHT91yEciPYSo9ofalefuOG2PpjIeBfLMwDoR7sc4AeG4VJvnGh7ZCytNWaQ==", null, false, "", false, "customer64@abv.bg" },
                    { "23e057df-2475-4083-bd74-b7f3d42962be", 0, "9531d80b-590c-4c29-8d1c-9759a5c2b013", "customer65@abv.bg", false, "Jack", "Johnson", false, null, "customer65@abv.bg", "customer65@abv.bg", "AQAAAAEAACcQAAAAEPVGi6QwrNZZ8I3RNqHc3DWMjL323Z0Gwt+lnrrs7XUsZRntwFSeZu9ZyI1phOcjxw==", null, false, "", false, "customer65@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8dfe7e93-2a48-408d-9df9-a1107264d7eb", 0, "92dbb94a-7a25-432e-bf8c-021a61d44d4a", "customer66@abv.bg", false, "Jack", "Johnson", false, null, "customer66@abv.bg", "customer66@abv.bg", "AQAAAAEAACcQAAAAEPuZRYUxHfPytHrLWz7FeFkkSZ/2p50FALIrNxk4epDK3FgD0VP/TBoYNhj12DQdrw==", null, false, "", false, "customer66@abv.bg" },
                    { "e3b9edfe-9969-4232-8849-54639398de31", 0, "997b25b1-a7e4-4111-a2ad-e719e77594c5", "customer67@abv.bg", false, "Jane", "Johnson", false, null, "customer67@abv.bg", "customer67@abv.bg", "AQAAAAEAACcQAAAAEI6gYdvLgH39zdvkwPIbp/7bTD7FO3Q4pFdw16Owyf60tsSmUXyO9xXTfWnDVyJr1Q==", null, false, "", false, "customer67@abv.bg" },
                    { "1e778f13-ff1d-4e4c-9d84-1c662811512e", 0, "d304ef2b-3423-477e-bda0-22b15307a63c", "customer68@abv.bg", false, "John", "Alexandrov", false, null, "customer68@abv.bg", "customer68@abv.bg", "AQAAAAEAACcQAAAAEGPVkKcs1ECn2T5I3KobLjDh11I7mLDVigsWY/iqt8vWy8RTIY/i/iVT0cz2zJwplQ==", null, false, "", false, "customer68@abv.bg" },
                    { "133fcbc8-1024-4963-bcf0-6e290dcc7e6b", 0, "c59cf974-be5a-4343-ab6b-21e19af2f406", "customer69@abv.bg", false, "Jane", "Johnson", false, null, "customer69@abv.bg", "customer69@abv.bg", "AQAAAAEAACcQAAAAEH3wTR1pg1rCkk2DUIitVhmaoBKko0k6b1ZJUoUgPQxaa4w7lLJeEGXiPqAYIkyU+g==", null, false, "", false, "customer69@abv.bg" },
                    { "cdae3185-31fc-4e3f-a81d-c67b7d5ee965", 0, "71da2748-cb95-4dd1-91c5-a2fd0f1fdfba", "customer70@abv.bg", false, "Jane", "Alexandrov", false, null, "customer70@abv.bg", "customer70@abv.bg", "AQAAAAEAACcQAAAAEH61+xa8F1iZaG2NZ1G9220SfvVY/ZhL3d0dlpnHAlIXgmtJ++tH+kyRfJJQxHaI1g==", null, false, "", false, "customer70@abv.bg" },
                    { "81947c36-7e87-43a2-bb74-68f7cca8e4d3", 0, "6ae97e90-23cb-4b65-bb9b-51eca26f6a40", "customer71@abv.bg", false, "Alex", "Alexandrov", false, null, "customer71@abv.bg", "customer71@abv.bg", "AQAAAAEAACcQAAAAEAuXdh0PxeaaNv8jraqlYWPwNwJzpGXYmuvkXxCqDZ8SoxfMkSmzg3xcwVB1b34nqQ==", null, false, "", false, "customer71@abv.bg" },
                    { "c0ab5dbe-fa4f-4926-b377-2308a46d1c0c", 0, "5cd2a800-cbe6-4364-adce-5d326b6f2c90", "customer72@abv.bg", false, "Alex", "Alexandrov", false, null, "customer72@abv.bg", "customer72@abv.bg", "AQAAAAEAACcQAAAAEE5S4PiEc0avhq3YtaLZ1jnfBzk+J8OI2dwm45Yr9QG63a+USMmIVtkP/sHR5jmgMA==", null, false, "", false, "customer72@abv.bg" },
                    { "21404434-22f1-42c4-9b19-f12252d2f8c6", 0, "f48e2256-e053-467a-972a-f616f4e605f3", "customer57@abv.bg", false, "Jack", "Johnson", false, null, "customer57@abv.bg", "customer57@abv.bg", "AQAAAAEAACcQAAAAEGL3EpOAXEOgjbH5iMInPx862nnMKqrN93B/zYmBPuixJuKn2BxVnEnKoUG1ZgwvPg==", null, false, "", false, "customer57@abv.bg" },
                    { "fca2b9cd-0da1-4a06-bfc4-7744a257634c", 0, "d45d236c-41d0-4f88-8f18-58c2264c1a21", "customer56@abv.bg", false, "Jane", "Alexandrov", false, null, "customer56@abv.bg", "customer56@abv.bg", "AQAAAAEAACcQAAAAENfTSuVoaZF1xsUFYGow04A81XJzYQUgQ9Ctv6OZbvE2jgRlkOERhrTv78p2frBHPQ==", null, false, "", false, "customer56@abv.bg" },
                    { "4760b16a-ad3b-4f28-9161-487e1d902e5c", 0, "bf02386b-2178-48d8-acec-b21d7a8b23e1", "customer55@abv.bg", false, "Alex", "Johnson", false, null, "customer55@abv.bg", "customer55@abv.bg", "AQAAAAEAACcQAAAAEMemZGnC75gkfca7qjZWLCN1SRh5Yt41c4bxb+5TlnnWXmz8ieAofBcdYT1P8RJ8yQ==", null, false, "", false, "customer55@abv.bg" },
                    { "3f52056c-6c79-4ad1-b6df-0388d2f7bba1", 0, "95a419a3-5bfd-48b6-b894-2371efadfe9b", "customer54@abv.bg", false, "Jane", "Johnson", false, null, "customer54@abv.bg", "customer54@abv.bg", "AQAAAAEAACcQAAAAEJ42PSpjc9RaU1+5X9Yz4+395mfHQWQhoIQO1a/kdXjVyxQasnKW1kzx6g1tdcHB6A==", null, false, "", false, "customer54@abv.bg" },
                    { "8798e821-c75b-4dde-acc8-4aed9ac610b5", 0, "14062807-9c62-4d05-b0b9-53ddd3d47800", "customer38@abv.bg", false, "Alex", "Johnson", false, null, "customer38@abv.bg", "customer38@abv.bg", "AQAAAAEAACcQAAAAEMaheBTTwQ6+8ZLuQ/CHXEnGpBRCHVriVlzk/3qxbumql3Gs7ZkcGGwgKe0uSdfXSQ==", null, false, "", false, "customer38@abv.bg" },
                    { "b8f4b248-954c-4f7c-991e-bf6086187445", 0, "eee1d35b-9689-47a0-b98f-9bfce6ae6a99", "customer39@abv.bg", false, "Jane", "Johnson", false, null, "customer39@abv.bg", "customer39@abv.bg", "AQAAAAEAACcQAAAAEGEEocoEE/iIbhSHe6gf/wsT1ABDDKMfeoEPwgg9krd9tj/KJIMjkicA7+sKwGp9Kw==", null, false, "", false, "customer39@abv.bg" },
                    { "79fe7f0a-5187-4aba-ba25-df0eefbcfb28", 0, "b7bb19c5-7ca0-4c67-963b-e09e43e9ce20", "customer40@abv.bg", false, "Jack", "Alexandrov", false, null, "customer40@abv.bg", "customer40@abv.bg", "AQAAAAEAACcQAAAAEHeUvQZH2+9btutB4E76Gt/bcsoIAc3jZehxU+ud1NdA0ET/gpBiqZEQJMdbzrmUrA==", null, false, "", false, "customer40@abv.bg" },
                    { "0db9f492-8f92-4851-a7aa-aa331e9f9263", 0, "711cf29e-677f-4792-827d-a4be1b688a55", "customer41@abv.bg", false, "Alex", "Johnson", false, null, "customer41@abv.bg", "customer41@abv.bg", "AQAAAAEAACcQAAAAEFXXqMqfdBUDtaqLvZ3m682rrbw687/ufcofk4Lb1bvsQEoLy+Gx+3eWW6vTb8s4+Q==", null, false, "", false, "customer41@abv.bg" },
                    { "9fd8c2ec-117d-4e0a-acd6-1b6786f68fff", 0, "a54e5be6-4ea3-4f9d-abe4-dae99aacbcff", "customer42@abv.bg", false, "John", "Johnson", false, null, "customer42@abv.bg", "customer42@abv.bg", "AQAAAAEAACcQAAAAEIMEHtQwpNd6HYQPxc0bPhf8C0ZEGK7KCozdXb3rLvbXor8jLhGgy83mwyJ0VrqTKA==", null, false, "", false, "customer42@abv.bg" },
                    { "2973ffe0-ef65-441c-8372-c3eb0b23d06d", 0, "7784d415-eaaa-4ddf-9b88-945154af502c", "customer43@abv.bg", false, "Jack", "Alexandrov", false, null, "customer43@abv.bg", "customer43@abv.bg", "AQAAAAEAACcQAAAAEFWVzLPW1BcITVSkrbldO+oRAeIpMkuFMQnipdub+wS5vx/aLrPaGrGitgGQs5QgtQ==", null, false, "", false, "customer43@abv.bg" },
                    { "56a388f2-b6df-417e-ad0c-022582da173a", 0, "a2c3d9c3-773e-4180-9464-c3374daf57b8", "customer44@abv.bg", false, "Jane", "Johnson", false, null, "customer44@abv.bg", "customer44@abv.bg", "AQAAAAEAACcQAAAAECWuXcEX0oC9UojLTrVfORONB9WVK/AtfOoyadZuSLFNb6TJTCO8hPaV8sjZreRyAg==", null, false, "", false, "customer44@abv.bg" },
                    { "a0e6d68a-1e11-4d8b-be7c-a0899f1c23ce", 0, "2cd5eb64-e1ca-41fd-b62d-fd9ca93fc914", "customer74@abv.bg", false, "John", "Alexandrov", false, null, "customer74@abv.bg", "customer74@abv.bg", "AQAAAAEAACcQAAAAEPay65rbXp+8gcOmKiuGA9OVcKd7xM2gbmU1YT7AHXYH5GeawAis8Y/1dzm2bLXwSw==", null, false, "", false, "customer74@abv.bg" },
                    { "44673eba-f052-49c1-b7bf-9e8cc191db28", 0, "e2d2cfec-7e98-4ec4-8f0e-423dbc045147", "customer45@abv.bg", false, "John", "Alexandrov", false, null, "customer45@abv.bg", "customer45@abv.bg", "AQAAAAEAACcQAAAAEAr9oM4HdTgwBB5R0zxYUTTT2UfbC2w6idYcEtLodTcWarCT9dBWjGofHelfB8YlJQ==", null, false, "", false, "customer45@abv.bg" },
                    { "c6c7fee1-e05c-410b-b38c-3f35f456aea2", 0, "39632b4f-3d59-40ec-822b-8a7f67a454bc", "customer47@abv.bg", false, "Jack", "Alexandrov", false, null, "customer47@abv.bg", "customer47@abv.bg", "AQAAAAEAACcQAAAAEHwA6gRI2l7g1L9Ygk8AB9O+ajoV1D+Ch3zg+omMRxGvtUMUhmZ9x1rzW3bGwU9mLw==", null, false, "", false, "customer47@abv.bg" },
                    { "7686051f-03e5-4794-a9cd-03f9231d78b0", 0, "9890d1a3-aed5-4973-95dc-b192b2b41ac9", "customer48@abv.bg", false, "Alex", "Alexandrov", false, null, "customer48@abv.bg", "customer48@abv.bg", "AQAAAAEAACcQAAAAEAbjkHqsVcFA8nNWaWMaznvXOWNNGdA+AClyPMZDItUMe/bRVb1mfoyZ/kt3FH8fPw==", null, false, "", false, "customer48@abv.bg" },
                    { "836407c5-c4d6-4a5f-983d-ad307aee1e09", 0, "5a085209-4fcf-485d-9e72-a1a219eb70e1", "customer49@abv.bg", false, "Jack", "Alexandrov", false, null, "customer49@abv.bg", "customer49@abv.bg", "AQAAAAEAACcQAAAAEDpi/Btzw4xC0g6C8id/znGaBJoaqV78Zr4U9R3WneP87jYMc6xbB4l/ntCEY5AlEw==", null, false, "", false, "customer49@abv.bg" },
                    { "c77e4292-bd3c-4bbf-980d-2dd611f3311a", 0, "db62ef27-8c27-42b8-8cc6-700561219e0b", "customer50@abv.bg", false, "Jack", "Johnson", false, null, "customer50@abv.bg", "customer50@abv.bg", "AQAAAAEAACcQAAAAENrS5ySWQaTjFqsA1fVhQ7H4nTR2EZDVKZ2mRgUqEF3M8xS/rwG49jUUbCiM0x7Zqw==", null, false, "", false, "customer50@abv.bg" },
                    { "8c2fc71d-c5b6-45c9-9b97-b2282e3b3166", 0, "3d5621c8-21b2-4b1a-9614-5cad0f29c68e", "customer51@abv.bg", false, "Jane", "Alexandrov", false, null, "customer51@abv.bg", "customer51@abv.bg", "AQAAAAEAACcQAAAAELMmDGEXuMsuQB5MuOnXhDbI0mSi7XSLCkYQ4Yk8hbrtBihv1QdMN2FBD98Sh+/4Og==", null, false, "", false, "customer51@abv.bg" },
                    { "fb97c0dc-eea0-4ac8-b245-e2ef07623595", 0, "ed3bd17f-1eea-456e-a23d-9bc915a8acb0", "customer52@abv.bg", false, "Jane", "Alexandrov", false, null, "customer52@abv.bg", "customer52@abv.bg", "AQAAAAEAACcQAAAAEPzRIx52ws5gkHQOIuj39+uzbPSS1POqNv6DHRnTRU5vFsJV0Epi3LHnMqGR48prYw==", null, false, "", false, "customer52@abv.bg" },
                    { "ee3ec73c-f4aa-4f9a-8057-9197a3125a55", 0, "c2c0bc1f-8634-454e-b717-10099f570779", "customer53@abv.bg", false, "Jane", "Johnson", false, null, "customer53@abv.bg", "customer53@abv.bg", "AQAAAAEAACcQAAAAEA3tYsYcJxxTQhDus8uwscptrBf0F+5wnPk8zXvTEiOHWtlwfhqwcG2Iee4gg67d6Q==", null, false, "", false, "customer53@abv.bg" },
                    { "cc3e1343-9540-4401-84e1-6b301535b3da", 0, "702d96a2-78cd-4a0e-907f-63e023e5fa4f", "customer46@abv.bg", false, "Jane", "Johnson", false, null, "customer46@abv.bg", "customer46@abv.bg", "AQAAAAEAACcQAAAAEFe0I5LpIdWbXpkdC/h7gbG1/aF+72L/CXaNQeQEFbpAIcwlE3Orfrz9tVCf1nQtfQ==", null, false, "", false, "customer46@abv.bg" },
                    { "d002b7bb-146a-41bb-80ee-98cdc17a0ae2", 0, "0a7dcf6e-bc17-41e2-8881-842d59fa23d0", "admin@abv.bg", false, "John", "Alexandrov", false, null, "admin@abv.bg", "admin@abv.bg", "AQAAAAEAACcQAAAAEGGYbmJymGW/EhVf1r7cvOqDfUoQO0SFrLd+mgEV/19jULdDX1hLlo1/lzCcehMBAQ==", null, false, "", false, "admin@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "d002b7bb-146a-41bb-80ee-98cdc17a0ae2", "6af7f330-deef-4a6d-becd-1223c011f425" },
                    { "30d99250-8ed0-44d3-8bc8-085a3318d798", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "681b5575-da7a-47a1-8f32-8e51f4174863", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "a1e6cbc5-cee7-42ea-8e29-671673a9053b", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "2a6a7295-5bbf-4fd7-a4f3-4159b011d085", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "f05ec093-c375-4585-8c38-96f101714846", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "533c9cfb-e2ef-49b7-82db-5c673ec9aff4", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "dbd3c4d2-7d14-4517-91f3-1bda2973cca3", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "9fafec2e-71ed-4e85-bb4e-b875c0680d47", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "a591b7f3-65f0-4af2-bf2a-6e137e632405", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "5c464220-b2e4-44de-83b5-b534a3e12bbf", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "df7ddce7-56ff-4c5e-bc5a-723ab7fffe32", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "7277146f-8e69-4d3f-99d0-ffa0d6c2eef9", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "d743b620-268c-4a3b-ba8e-60e86db2afda", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "7bc058c0-8c0a-4fb7-a42c-4cb0548ce56d", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "7cd5e764-2447-4510-ba5e-d599de72171b", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "bea14fa9-943d-4793-9e50-5c9aa99446d4", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "974517b9-04fd-448a-897d-4ab48ec9b13b", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "bc642b6d-2363-4d87-874b-3d1c02e99da2", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "93a9bffa-db86-43d1-a513-1cb62388cd3d", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "0dd15d3e-5355-45ad-a001-542996dd4573", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "b9500b41-fb45-4d1a-8e3e-6573789dc6b8", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "85e5cdb1-e14a-442d-a876-b4e27e92b651", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "08423c78-cd4f-48ed-ab86-cb30117d151a", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "cbe52ec6-39cd-4fad-b086-aea8175e3d4e", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "4119e9bf-b571-431d-ac8b-f6cb5503288d", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "69ddf6f5-d7fd-4fc7-887f-05753e6cf674", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "2b4d6a31-de60-4aec-bf93-dcee5a12414b", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "d4336be6-3df2-417d-853b-9fa51553182c", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "f4084a44-e0cd-40db-9505-64a7469a2c50", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "d1c80d6c-5100-4879-a777-d030cca84746", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "fec8e098-3ba3-4a70-8d70-002538762b56", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "117d364c-a995-4cf4-8e7f-9525f1a22546", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "cb949aa9-355d-4e15-b247-dea281099490", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "c761eae0-6481-4de5-80b3-a1bf017a1f5a", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "77fbd7a8-1599-42f9-b162-37f6b4ed2be7", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "3b6294de-004c-4471-ba99-bb24ff19a4f3", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "9c25a871-ce26-4614-96b0-36fe3d858c35", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "c32106af-ded9-4fe7-9fcc-00523f1c816c", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "9b5daa53-d39f-4a04-bbf1-a08693d821a7", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "850b3094-1933-49c1-a6ef-f71be3f52442", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "7007925a-e9f9-48fb-a435-2097ba605ebf", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "5801da1c-78f5-4a60-9b26-69e495b8a7c0", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "a28cd914-ca3b-4eb0-b4b1-4523ca3bc97c", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "362c7ba2-2051-4534-9a90-26e9fdc20289", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "e770ba82-94ee-4917-b97b-89365749f507", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "c314e5ba-8d94-49e8-aeeb-fba0646af9fe", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "ac94f58b-95a4-485e-bc8a-7b35f59484b7", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "7578a95e-1b98-45cf-812d-477224b13c8a", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "89cff433-559c-41ad-b4ea-4dbd21a9e77e", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "194018b2-90b9-4149-b85c-4e340e116989", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "d0883347-e216-4f3b-8ac4-804aced8fd00", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "9f6dd3de-3513-495a-a21a-a90b784f29cd", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "71e2263a-b524-433c-9ec1-626a37b6758c", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "62b06123-99ca-4c85-96ef-26e7e293566d", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "32235ffc-9426-4539-b7fa-d6cf629e80b2", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "b588a55b-20cc-4f66-8d70-568faa047f60", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "cc8188ee-bce7-402a-a404-978be49cb2cf", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "d5dae05b-719f-492d-922f-766e4d932a95", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "a6695c20-ebd6-4200-a370-284c0e9ba040", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "502b93f2-f52a-4ebf-a99d-8abfd4cfb272", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "322c2a1f-647f-41ee-ac2e-86d5657a4ef0", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "9039ac7a-31f4-40aa-960b-4d85235e2a17", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "d8f4796f-eb1f-4498-97ca-fc539ac770a2", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "521fc235-3fc3-4339-94c3-d3d07d50636a", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "1cc81c48-381f-4af1-a936-c5f627ba4bbd", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "4f34bbaa-13a7-4c5f-b44f-4aeb97533abf", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "64c059b6-7db2-4be7-b2b3-916c37809f62", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "7d2b6bf3-b2d2-480d-96d1-10e95f5311e7", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "40de74c1-1e6f-4fe2-9787-acd369b9985b", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "97709b32-b137-4aeb-ac14-04a93d8665ae", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "7633c82c-9291-4f02-9fca-78a5f383a0e4", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "5914cc79-7378-4b4b-9eb1-c4eef0de6e0b", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "13fc052a-0b35-4554-bd7b-3aa5845f8569", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "1cbb7f54-6d2a-4a13-89a1-cedc03173719", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "fd722557-110f-4548-b9a8-d74e11b6a6fd", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "91f210ec-2391-4f1d-a946-481d1bd7921c", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "aeef8940-7ed5-44ba-9ec3-189c0b1a335e", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "31dc6d7f-6cf4-479f-baea-ed867fd593ed", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "c1cb22a0-cb65-4a3a-af3e-01e0095f2add", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "a0e6d68a-1e11-4d8b-be7c-a0899f1c23ce", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "40d5823e-cfa6-488c-8c6e-3aca2de1973e", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "c0ab5dbe-fa4f-4926-b377-2308a46d1c0c", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "81947c36-7e87-43a2-bb74-68f7cca8e4d3", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "cdae3185-31fc-4e3f-a81d-c67b7d5ee965", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "133fcbc8-1024-4963-bcf0-6e290dcc7e6b", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "1e778f13-ff1d-4e4c-9d84-1c662811512e", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "e3b9edfe-9969-4232-8849-54639398de31", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "8dfe7e93-2a48-408d-9df9-a1107264d7eb", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "23e057df-2475-4083-bd74-b7f3d42962be", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "8c7209c3-fc1d-4867-83d9-609c87ff4824", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "a85794d2-af47-40ee-b6ca-3e96235cb0f6", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "ef59ed5a-aab1-4e56-b0b3-7bf0f74de590", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "576763d2-ff5b-47b2-a264-1b549f8ac44e", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "fb316f26-fa22-48cc-870d-8cfeeeac14f7", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "2c225781-430b-427f-9587-79f8232b27db", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "f08d3a41-71b2-4e08-baba-85d6c51e8fb2", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "11dd66f1-b9ed-494e-8bbf-f29a5249cb8c", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "fed71958-d8e9-4c46-9cf5-028e8e321dc1", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "a9da5fb2-e385-4a98-8b2a-173ebbdfacfd", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "8143e151-7b7b-4534-a569-5de07accb4f2", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "d0f866f3-44a8-4044-a3b8-f44e2875ead4", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "df0ad0c9-0f6f-4fee-9f00-0a307be29e80", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "29664f76-e7e8-4d27-8926-0fbde88b0757", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "c807c283-0793-4862-9bb7-6da63def57c1", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "312bc9e8-a6b8-4922-ab32-7ef2dca803bb", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "f0b23caa-2cd5-4202-8f93-8bf03f7b4b5c", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "e26d393c-d3ca-4855-b98e-081285afe8f3", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "25fd9fb7-39bb-414d-8af8-a55d00dd6326", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "965c2777-3078-4080-ae35-e23f85842774", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "82df2054-bafe-4490-9870-ddea23c743c7", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "948a1f8e-52a2-4c78-b17d-9766db3bdf79", "2da50d31-cc41-49ab-a803-751081216e59" },
                    { "53a30961-09dc-4a71-b578-4d5394b24629", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "3bfacaee-4f69-47db-bded-b88c5ea5f490", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "79fe7f0a-5187-4aba-ba25-df0eefbcfb28", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "b8f4b248-954c-4f7c-991e-bf6086187445", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "8798e821-c75b-4dde-acc8-4aed9ac610b5", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "99aedd8f-b760-4492-a1c4-9b18a83fd6d1", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "67473ecd-7543-4b7d-991f-b83623a391cf", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "6c1dfe26-b1a3-4635-b026-e0e5a76b1dd9", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "86af8660-bb8a-4412-a6a1-22ea7637cbfb", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "a310fd19-6001-4d79-9d63-3d1f9c4f4ecf", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "6ef008f8-3be5-430e-87f0-40e387d481b4", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "a212bb39-5362-4bbf-9f99-f7adc7e3e2b3", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "1fa27583-f1f0-4b5f-86e5-28f6f73b757a", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "4b92d384-8570-48cc-ab0c-421c4688787c", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "2aa90e6b-6a73-4a4a-8a87-3d8248690e51", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "6e1f03cd-68e7-42cb-8968-28fa491c1837", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "eaeb2821-926c-4f0c-8dc7-740adaef2df8", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "0db9f492-8f92-4851-a7aa-aa331e9f9263", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "49ee6add-339f-435e-b9f4-fdf67745b992", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "9fd8c2ec-117d-4e0a-acd6-1b6786f68fff", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "56a388f2-b6df-417e-ad0c-022582da173a", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "e9ba0669-38f7-4d2c-af73-e6a66feee4cf", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "2ea694e8-365b-44e9-b9bc-521fb66caa66", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "21404434-22f1-42c4-9b19-f12252d2f8c6", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "fca2b9cd-0da1-4a06-bfc4-7744a257634c", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "4760b16a-ad3b-4f28-9161-487e1d902e5c", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "3f52056c-6c79-4ad1-b6df-0388d2f7bba1", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "ee3ec73c-f4aa-4f9a-8057-9197a3125a55", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "fb97c0dc-eea0-4ac8-b245-e2ef07623595", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "8c2fc71d-c5b6-45c9-9b97-b2282e3b3166", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "c77e4292-bd3c-4bbf-980d-2dd611f3311a", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "836407c5-c4d6-4a5f-983d-ad307aee1e09", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "7686051f-03e5-4794-a9cd-03f9231d78b0", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "c6c7fee1-e05c-410b-b38c-3f35f456aea2", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "cc3e1343-9540-4401-84e1-6b301535b3da", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "44673eba-f052-49c1-b7bf-9e8cc191db28", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "2973ffe0-ef65-441c-8372-c3eb0b23d06d", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "69bb2b20-2fca-4feb-b6b0-7164bbb7f5eb", "e0ff732f-a85f-4074-98c5-586da377a133" },
                    { "a1479f93-a9a9-4b03-a032-36fc72c328d8", "e0ff732f-a85f-4074-98c5-586da377a133" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "UserId" },
                values: new object[,]
                {
                    { "23e5655b-f08b-4ffd-b01a-b6d7cf3f8758", "Street 4", "a0e6d68a-1e11-4d8b-be7c-a0899f1c23ce" },
                    { "a4bb2c56-b110-490f-8a46-042211093a9b", "Street 89", "fb97c0dc-eea0-4ac8-b245-e2ef07623595" },
                    { "a84e7841-bd43-46c8-a436-5845baf22927", "Street 265", "8c2fc71d-c5b6-45c9-9b97-b2282e3b3166" },
                    { "90e0aa4c-3a92-4773-b8b7-cc68aea01e57", "Street 387", "c77e4292-bd3c-4bbf-980d-2dd611f3311a" },
                    { "dd6b3186-15b5-4265-b0e2-f9c22f69ab3f", "Street 92", "836407c5-c4d6-4a5f-983d-ad307aee1e09" },
                    { "4f472c8e-4056-411f-9a22-cc5fb19092f3", "Street 100", "7686051f-03e5-4794-a9cd-03f9231d78b0" },
                    { "ce761ee8-8e58-4462-badf-8c7472b64ef4", "Street 121", "c6c7fee1-e05c-410b-b38c-3f35f456aea2" },
                    { "2bee5ea2-fbe3-4f20-a400-f2e8a3d15fa1", "Street 436", "ee3ec73c-f4aa-4f9a-8057-9197a3125a55" },
                    { "2fe9bd06-6ba8-4083-97e8-db59a9dd3b82", "Street 432", "cc3e1343-9540-4401-84e1-6b301535b3da" },
                    { "6da2849a-cd1b-4ccb-ad65-0948601a13be", "Street 200", "56a388f2-b6df-417e-ad0c-022582da173a" },
                    { "8fd5cd6f-d61b-40b7-bfc2-c3d96af0d39f", "Street 34", "2973ffe0-ef65-441c-8372-c3eb0b23d06d" },
                    { "00d7eeb0-32e2-4cd6-9a77-d023edfb6ea2", "Street 57", "9fd8c2ec-117d-4e0a-acd6-1b6786f68fff" },
                    { "94091820-a611-458d-94cf-f58fca80d2a7", "Street 38", "0db9f492-8f92-4851-a7aa-aa331e9f9263" },
                    { "de6d61da-36fa-432a-a33b-e53284925e5c", "Street 144", "79fe7f0a-5187-4aba-ba25-df0eefbcfb28" },
                    { "f33a2dcf-f1e5-4bff-a50e-4cb61ab07fc3", "Street 179", "b8f4b248-954c-4f7c-991e-bf6086187445" },
                    { "d496abfa-d456-48b9-9668-eff10f193b96", "Street 390", "44673eba-f052-49c1-b7bf-9e8cc191db28" },
                    { "3f9c3b09-363c-46de-9b4d-52c981b52831", "Street 381", "3f52056c-6c79-4ad1-b6df-0388d2f7bba1" },
                    { "2d9bbe4a-c581-48e3-9282-ea69ca625e23", "Street 218", "4760b16a-ad3b-4f28-9161-487e1d902e5c" },
                    { "a3eef568-26fb-400a-93f1-cf6e4ff4dc0f", "Street 90", "fca2b9cd-0da1-4a06-bfc4-7744a257634c" },
                    { "d6d4aa32-0bf1-45de-9e1a-995f47413d63", "Street 102", "81947c36-7e87-43a2-bb74-68f7cca8e4d3" },
                    { "077bc86a-fc0a-40b5-8e46-c82845bcdf84", "Street 322", "cdae3185-31fc-4e3f-a81d-c67b7d5ee965" },
                    { "73a34a2e-92c3-44bc-a30e-0fb1ad5ea9cf", "Street 175", "133fcbc8-1024-4963-bcf0-6e290dcc7e6b" },
                    { "f317dfda-2585-4e39-ac6e-7d574277fff7", "Street 1", "1e778f13-ff1d-4e4c-9d84-1c662811512e" },
                    { "4debaf33-e745-474f-9b20-f71c380c7400", "Street 128", "e3b9edfe-9969-4232-8849-54639398de31" },
                    { "f275a195-1e3d-4ea3-98e9-b067238d921b", "Street 258", "8dfe7e93-2a48-408d-9df9-a1107264d7eb" },
                    { "5a3b64a1-9489-40e1-8803-360f375b9593", "Street 307", "23e057df-2475-4083-bd74-b7f3d42962be" },
                    { "490b089d-1b18-4852-8f6f-24378130bbeb", "Street 161", "8c7209c3-fc1d-4867-83d9-609c87ff4824" },
                    { "c79079e2-2a7d-4831-8369-e721545e0d4b", "Street 408", "ef59ed5a-aab1-4e56-b0b3-7bf0f74de590" },
                    { "b4712ca1-38c6-421b-ad26-06e2883886a8", "Street 368", "53a30961-09dc-4a71-b578-4d5394b24629" },
                    { "b8ef36ff-5146-42f4-8137-a745f9d4b5aa", "Street 449", "49ee6add-339f-435e-b9f4-fdf67745b992" },
                    { "17dcf00d-59dd-4dd1-ab3a-2860f307c0d9", "Street 154", "3bfacaee-4f69-47db-bded-b88c5ea5f490" },
                    { "ec33b2ca-f911-423f-a8f9-c9422ad299e0", "Street 38", "e9ba0669-38f7-4d2c-af73-e6a66feee4cf" },
                    { "0f0f6164-1963-4e32-8260-a656157cc9b7", "Street 208", "2ea694e8-365b-44e9-b9bc-521fb66caa66" },
                    { "c02c4565-c48d-44ca-91af-0e60deb610a4", "Street 170", "21404434-22f1-42c4-9b19-f12252d2f8c6" },
                    { "1d0a2fce-3f39-4c94-81af-74e1286d68f7", "Street 322", "8798e821-c75b-4dde-acc8-4aed9ac610b5" },
                    { "7d9a0de5-63c8-43e7-96eb-65d0b3ed5104", "Street 422", "99aedd8f-b760-4492-a1c4-9b18a83fd6d1" },
                    { "5c163638-9029-4d2c-b52a-eb7c4b6f51a5", "Street 178", "67473ecd-7543-4b7d-991f-b83623a391cf" },
                    { "4af80c67-88e3-400b-af06-a4acfadfedcc", "Street 95", "6c1dfe26-b1a3-4635-b026-e0e5a76b1dd9" },
                    { "9ca355ac-b4b3-4fa8-aef0-68c0c05f2c01", "Street 51", "4119e9bf-b571-431d-ac8b-f6cb5503288d" },
                    { "4e8b3218-3819-4256-b8e9-4e0d666bfcef", "Street 269", "69ddf6f5-d7fd-4fc7-887f-05753e6cf674" },
                    { "65d9227c-ff27-47cd-a57c-efdf0604a51a", "Street 442", "2b4d6a31-de60-4aec-bf93-dcee5a12414b" },
                    { "1e6a1e48-be34-4444-b709-e0beaad1dff8", "Street 369", "d4336be6-3df2-417d-853b-9fa51553182c" },
                    { "0994ca99-aa0d-4024-8739-1ccaace75fe7", "Street 345", "f4084a44-e0cd-40db-9505-64a7469a2c50" },
                    { "95f83791-df95-49a1-bd3b-840f130bd400", "Street 242", "d1c80d6c-5100-4879-a777-d030cca84746" },
                    { "a3bc744a-b41f-4497-80e1-ddb91738de63", "Street 353", "fec8e098-3ba3-4a70-8d70-002538762b56" },
                    { "4aaed31e-8c23-41fa-a97e-2cad33e13cb2", "Street 172", "117d364c-a995-4cf4-8e7f-9525f1a22546" },
                    { "0a8e45b0-e261-4fe0-89ca-dd73d909978a", "Street 61", "cb949aa9-355d-4e15-b247-dea281099490" },
                    { "3834bf95-743c-4413-8fc0-2e4e4594a077", "Street 166", "bc642b6d-2363-4d87-874b-3d1c02e99da2" },
                    { "d70ace91-b77c-4858-8170-0360246faa97", "Street 251", "974517b9-04fd-448a-897d-4ab48ec9b13b" },
                    { "269d97ff-6035-484b-b68e-344599c23a04", "Street 130", "bea14fa9-943d-4793-9e50-5c9aa99446d4" },
                    { "14ebe1e1-1bea-4a21-a1b4-d9db648e32b8", "Street 89", "dbd3c4d2-7d14-4517-91f3-1bda2973cca3" },
                    { "049c381f-74cd-4f8e-b1ab-f3f7052aa3c7", "Street 86", "30d99250-8ed0-44d3-8bc8-085a3318d798" },
                    { "de8f7d1f-50a6-42cb-b262-4145c679928d", "Street 58", "681b5575-da7a-47a1-8f32-8e51f4174863" },
                    { "775f3814-00d5-4291-8341-eb02e92f678d", "Street 74", "cbe52ec6-39cd-4fad-b086-aea8175e3d4e" },
                    { "3c81fb8f-5250-49bb-a710-ebf433e0f18d", "Street 282", "c0ab5dbe-fa4f-4926-b377-2308a46d1c0c" },
                    { "e9451d81-136d-4ca4-b30d-e0decc5ba0bb", "Street 154", "08423c78-cd4f-48ed-ab86-cb30117d151a" },
                    { "d68ad710-d183-4690-b4c7-c4ee531abef7", "Street 148", "b9500b41-fb45-4d1a-8e3e-6573789dc6b8" },
                    { "35c4885c-eb73-42a0-b13c-d589cd52740e", "Street 441", "86af8660-bb8a-4412-a6a1-22ea7637cbfb" },
                    { "77266b26-b72d-4b8c-83c6-20c621abb897", "Street 241", "a310fd19-6001-4d79-9d63-3d1f9c4f4ecf" },
                    { "e4caa1ef-86d8-442a-8003-01ae9b2fc4b2", "Street 88", "6ef008f8-3be5-430e-87f0-40e387d481b4" },
                    { "a8cc1686-e9d4-40df-a296-ff5b555c042d", "Street 384", "a212bb39-5362-4bbf-9f99-f7adc7e3e2b3" },
                    { "dcdcbc6d-50c3-4c1e-bad5-445c5dc5653d", "Street 192", "1fa27583-f1f0-4b5f-86e5-28f6f73b757a" },
                    { "ba7744be-7c4d-4dbd-a725-e6c71e4f856a", "Street 213", "4b92d384-8570-48cc-ab0c-421c4688787c" },
                    { "04772073-c3f4-4801-a16a-359116bab830", "Street 143", "2aa90e6b-6a73-4a4a-8a87-3d8248690e51" },
                    { "05881c84-3592-41d0-9f52-ca4d648bbb26", "Street 167", "6e1f03cd-68e7-42cb-8968-28fa491c1837" },
                    { "295df7c5-0fdf-4b01-b2cf-661b75657182", "Street 97", "eaeb2821-926c-4f0c-8dc7-740adaef2df8" },
                    { "e7b310a6-9abe-409e-a368-cbc858d87ceb", "Street 93", "fd722557-110f-4548-b9a8-d74e11b6a6fd" },
                    { "df13809e-476f-4f0b-b0f7-a13ccd0a1081", "Street 331", "1cbb7f54-6d2a-4a13-89a1-cedc03173719" },
                    { "f8d4e6a6-4633-4521-bba8-88874d80837b", "Street 365", "13fc052a-0b35-4554-bd7b-3aa5845f8569" },
                    { "66336b40-22c0-475c-b810-67c92d2fa911", "Street 417", "62b06123-99ca-4c85-96ef-26e7e293566d" },
                    { "7b378e5a-13e1-4402-aabf-431c83e6eab7", "Street 261", "93a9bffa-db86-43d1-a513-1cb62388cd3d" },
                    { "a1413915-b423-45c8-aacc-c4096587407c", "Street 274", "0dd15d3e-5355-45ad-a001-542996dd4573" },
                    { "ae98e3ff-169d-4c09-b5ab-5ddf4eeed248", "Street 414", "85e5cdb1-e14a-442d-a876-b4e27e92b651" },
                    { "7bc6177e-492a-4cd2-9b1d-293b214cc72d", "Street 236", "40d5823e-cfa6-488c-8c6e-3aca2de1973e" },
                    { "353f45b0-98fe-4590-b250-8c70688f9928", "Street 30", "a1e6cbc5-cee7-42ea-8e29-671673a9053b" },
                    { "02cdce48-ed3c-4c95-a589-c1ccec7da17e", "Street 237", "c1cb22a0-cb65-4a3a-af3e-01e0095f2add" },
                    { "6f4c9113-538e-4431-8721-71aff775cee2", "Street 322", "69bb2b20-2fca-4feb-b6b0-7164bbb7f5eb" },
                    { "e4597311-3aad-4046-9612-caa7b7a4a90d", "Street 98", "2c225781-430b-427f-9587-79f8232b27db" },
                    { "e5208d1c-ef4c-4358-902c-7b89023977f1", "Street 120", "f08d3a41-71b2-4e08-baba-85d6c51e8fb2" },
                    { "362bf0a6-7a49-4ce5-816f-10a8c8926cf0", "Street 145", "11dd66f1-b9ed-494e-8bbf-f29a5249cb8c" },
                    { "47e85a8d-ad00-4ac9-be80-4ff45addad99", "Street 25", "fed71958-d8e9-4c46-9cf5-028e8e321dc1" },
                    { "6d536226-f832-40b4-9cd9-8229e7670f73", "Street 284", "a9da5fb2-e385-4a98-8b2a-173ebbdfacfd" },
                    { "d1708f91-d581-4bb5-9e35-c1b5b1b1815a", "Street 214", "8143e151-7b7b-4534-a569-5de07accb4f2" },
                    { "de17ca25-db05-4145-be05-c64672141a06", "Street 8", "d0f866f3-44a8-4044-a3b8-f44e2875ead4" },
                    { "211dee96-e503-4c1e-8745-f4b0a9e1c40b", "Street 6", "df0ad0c9-0f6f-4fee-9f00-0a307be29e80" },
                    { "b2307753-dcb3-4ed9-90fc-3984605fadec", "Street 223", "29664f76-e7e8-4d27-8926-0fbde88b0757" },
                    { "87c60281-80b7-498f-861e-681d3f135184", "Street 310", "c807c283-0793-4862-9bb7-6da63def57c1" },
                    { "683d5a6f-2743-478a-ae36-ef3d013e62c6", "Street 343", "a1479f93-a9a9-4b03-a032-36fc72c328d8" },
                    { "97be39aa-ac73-4361-aa97-395c5d175543", "Street 296", "f0b23caa-2cd5-4202-8f93-8bf03f7b4b5c" },
                    { "03e286e9-3e8a-44b6-9ba5-7183e0b5a08b", "Street 376", "e26d393c-d3ca-4855-b98e-081285afe8f3" },
                    { "13ca9561-1a5d-4b5f-81e5-e3fbbc676e85", "Street 275", "25fd9fb7-39bb-414d-8af8-a55d00dd6326" },
                    { "150e31a4-2ead-4414-930c-7c4af6727544", "Street 51", "965c2777-3078-4080-ae35-e23f85842774" },
                    { "6d534984-c7cc-4360-bb23-678a0cf4fc55", "Street 68", "fb316f26-fa22-48cc-870d-8cfeeeac14f7" },
                    { "1b45b446-443a-42cb-a37f-f678a097c16e", "Street 426", "82df2054-bafe-4490-9870-ddea23c743c7" },
                    { "9fb03a2f-b820-4dd0-b70b-a2c9ee3b4d8b", "Street 111", "576763d2-ff5b-47b2-a264-1b549f8ac44e" },
                    { "e212c040-3c4a-4b26-882f-e5a4f10f2403", "Street 390", "a85794d2-af47-40ee-b6ca-3e96235cb0f6" },
                    { "ac8237d5-1c0c-4ad6-8aff-fb46219e8b23", "Street 165", "91f210ec-2391-4f1d-a946-481d1bd7921c" },
                    { "81c1da0e-424a-4737-b937-b623fb2a4211", "Street 384", "aeef8940-7ed5-44ba-9ec3-189c0b1a335e" },
                    { "8ff70af2-821e-43a0-ac08-be64f5720d5f", "Street 205", "31dc6d7f-6cf4-479f-baea-ed867fd593ed" },
                    { "109ce307-8afe-4c4d-a38f-5f81609d8b7f", "Street 102", "312bc9e8-a6b8-4922-ab32-7ef2dca803bb" }
                });

            migrationBuilder.InsertData(
                table: "Teches",
                columns: new[] { "Id", "Salary", "UserId" },
                values: new object[,]
                {
                    { "ad561be9-29a0-49c0-980d-e33dd0da370f", 1712.48037028708m, "cc8188ee-bce7-402a-a404-978be49cb2cf" },
                    { "6973f75c-b000-4bbd-8886-f4e675685497", 1809.34883924636m, "d5dae05b-719f-492d-922f-766e4d932a95" },
                    { "c9cbf485-f568-421e-8cef-69ba860b0268", 413.226382067998m, "a6695c20-ebd6-4200-a370-284c0e9ba040" },
                    { "1fa281d9-030b-42e1-97ff-4dab0e512787", 716.050631234446m, "502b93f2-f52a-4ebf-a99d-8abfd4cfb272" },
                    { "e3d4e99b-3f31-451d-a09c-37c3563d4211", 2250.02767809202m, "1cc81c48-381f-4af1-a936-c5f627ba4bbd" },
                    { "cdf6f92e-5cb8-4e48-85b7-ee945807a675", 2063.64799340425m, "9039ac7a-31f4-40aa-960b-4d85235e2a17" },
                    { "c43299e6-fcbf-4ae6-8e38-62b702bca8ad", 1410.65965565418m, "d8f4796f-eb1f-4498-97ca-fc539ac770a2" },
                    { "4727259b-23ff-488b-a4de-246d8518733c", 2982.95209183495m, "521fc235-3fc3-4339-94c3-d3d07d50636a" },
                    { "b162eafd-d618-410f-8f64-187160144739", 1712.27105460701m, "9c25a871-ce26-4614-96b0-36fe3d858c35" },
                    { "1b6fd871-d5c7-41af-8987-93e49e9e1a25", 781.621783404435m, "322c2a1f-647f-41ee-ac2e-86d5657a4ef0" },
                    { "5479db90-dd60-420d-9f3e-1ab92eaef40e", 2047.14823097323m, "3b6294de-004c-4471-ba99-bb24ff19a4f3" },
                    { "8bf2e429-80d3-4ec2-a31a-ec69ed02b8af", 793.844588936234m, "df7ddce7-56ff-4c5e-bc5a-723ab7fffe32" },
                    { "71d61bb0-2049-48ff-9f58-a68fbcd1853d", 1874.10703761229m, "c761eae0-6481-4de5-80b3-a1bf017a1f5a" },
                    { "95b6a730-ffde-44d4-9d6c-8329a19f5b95", 2926.52138971096m, "7bc058c0-8c0a-4fb7-a42c-4cb0548ce56d" },
                    { "6019cb98-76a7-421f-9cdf-5b846bf02efd", 2617.02659987706m, "d743b620-268c-4a3b-ba8e-60e86db2afda" },
                    { "91422607-74e1-4062-97e4-b7867b1ee7eb", 2958.0963179274m, "7277146f-8e69-4d3f-99d0-ffa0d6c2eef9" },
                    { "84a036ad-d17d-4344-9ed6-6c6122494545", 1101.77296870471m, "5c464220-b2e4-44de-83b5-b534a3e12bbf" },
                    { "77a04636-b6d6-4a12-a814-8b259ce0d4dd", 1400.73140170459m, "a591b7f3-65f0-4af2-bf2a-6e137e632405" },
                    { "02fe152e-76ec-44a9-82f3-bc1e56cd2b30", 1996.64843920462m, "7cd5e764-2447-4510-ba5e-d599de72171b" },
                    { "1e0c0092-f47f-4b2c-a10e-83cabaf142d3", 15.9681052975208m, "9fafec2e-71ed-4e85-bb4e-b875c0680d47" },
                    { "9d990cd8-884a-4b86-978d-64ec79c04f8b", 2642.63472922269m, "533c9cfb-e2ef-49b7-82db-5c673ec9aff4" },
                    { "2c44de85-b17e-4b1d-a43a-b141b4ba0afa", 2094.43083875553m, "4f34bbaa-13a7-4c5f-b44f-4aeb97533abf" },
                    { "887edfbd-f986-42c5-a39c-1acfa901ddce", 952.722272813656m, "77fbd7a8-1599-42f9-b162-37f6b4ed2be7" },
                    { "055dd46d-3f47-4c2d-942a-d9e8cd6b2048", 1128.34761251153m, "64c059b6-7db2-4be7-b2b3-916c37809f62" },
                    { "7c625529-9a73-4725-b1cc-81dfdfc423dc", 36.6399893707782m, "7007925a-e9f9-48fb-a435-2097ba605ebf" },
                    { "d64ce2d9-79b6-4307-9b57-3cc7f99a71f0", 1786.55722215146m, "40de74c1-1e6f-4fe2-9787-acd369b9985b" },
                    { "c3c1fc8c-4230-4346-9579-0f5d9fcd63be", 887.447469815354m, "948a1f8e-52a2-4c78-b17d-9766db3bdf79" },
                    { "4679fde5-ad6f-4a29-8ecf-b097a766bd1d", 2027.00986900693m, "9f6dd3de-3513-495a-a21a-a90b784f29cd" },
                    { "bf4616a4-38e8-47e5-b359-0ec8e4bf04b0", 797.980599942608m, "d0883347-e216-4f3b-8ac4-804aced8fd00" },
                    { "82231074-a3cb-42c2-a8c0-b8dba66b2005", 2498.33585438241m, "194018b2-90b9-4149-b85c-4e340e116989" },
                    { "47a471a9-69aa-4c8b-a304-750d9dd2f407", 1465.93830430225m, "89cff433-559c-41ad-b4ea-4dbd21a9e77e" },
                    { "55702fd1-cae9-40b4-ae7e-58b9726f4479", 1906.67731962478m, "7578a95e-1b98-45cf-812d-477224b13c8a" },
                    { "25a01773-7d08-4cf2-bef3-358be757f4a1", 2890.25480434776m, "ac94f58b-95a4-485e-bc8a-7b35f59484b7" },
                    { "d28586db-a0ec-4bc6-94ed-fcbc5c371c5c", 2017.25479216187m, "c314e5ba-8d94-49e8-aeeb-fba0646af9fe" },
                    { "dbe08caa-274a-46f5-9bc2-71f41316a5f6", 2882.77491828556m, "e770ba82-94ee-4917-b97b-89365749f507" },
                    { "64c0a796-cdaf-4b70-962b-dcfd54a08603", 964.63997706987m, "362c7ba2-2051-4534-9a90-26e9fdc20289" },
                    { "912aaf6e-727e-492a-b658-a907d9866791", 1515.46311169651m, "7d2b6bf3-b2d2-480d-96d1-10e95f5311e7" },
                    { "82354a6e-206c-4e7f-956c-00e71b52da92", 88.0479589514658m, "a28cd914-ca3b-4eb0-b4b1-4523ca3bc97c" },
                    { "f1df911f-8fa7-4f14-ac0b-c422ddecc16f", 1979.97543401084m, "2a6a7295-5bbf-4fd7-a4f3-4159b011d085" },
                    { "d1ea3682-4e30-42e2-a74f-b5150f812ea2", 1786.38898897282m, "850b3094-1933-49c1-a6ef-f71be3f52442" },
                    { "668ae928-9509-40a1-8f16-92a8ea9ed49d", 2509.82864643905m, "9b5daa53-d39f-4a04-bbf1-a08693d821a7" },
                    { "2d347562-26d0-4037-b87d-8e8e0c17511b", 1182.43870752977m, "c32106af-ded9-4fe7-9fcc-00523f1c816c" },
                    { "cfa2f17b-bc6a-4875-9c69-6bf50a831fe2", 2544.72506863285m, "71e2263a-b524-433c-9ec1-626a37b6758c" },
                    { "3cb9c412-4e2a-4ead-aaa0-459fd0c219c9", 2112.12808038673m, "32235ffc-9426-4539-b7fa-d6cf629e80b2" },
                    { "3a331a38-00cb-485c-a197-f5c4c4310efa", 892.068425608831m, "5914cc79-7378-4b4b-9eb1-c4eef0de6e0b" },
                    { "28c3adad-6217-43d7-a493-7a8df788bb93", 1567.97804989292m, "b588a55b-20cc-4f66-8d70-568faa047f60" },
                    { "5ada2956-7239-4f43-9b6e-39ce5bbed8c8", 70.5412743010285m, "7633c82c-9291-4f02-9fca-78a5f383a0e4" },
                    { "d3415dd8-cde8-49bc-b84c-eafc9c58cb01", 1041.13393791073m, "97709b32-b137-4aeb-ac14-04a93d8665ae" },
                    { "1769e23d-c38b-42dd-bd16-1b7cd400f5b9", 1038.20520594632m, "5801da1c-78f5-4a60-9b26-69e495b8a7c0" },
                    { "ece24e29-00e4-40ff-8006-a7e8e8f79088", 2386.32676256184m, "f05ec093-c375-4585-8c38-96f101714846" }
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
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TechId",
                table: "Requests",
                column: "TechId");

            migrationBuilder.CreateIndex(
                name: "IX_Teches_UserId",
                table: "Teches",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Teches");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
