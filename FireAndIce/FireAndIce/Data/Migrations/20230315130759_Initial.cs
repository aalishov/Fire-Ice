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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "323310ee-8c7d-4287-96fe-e7b66edc7836", "93ad9f45-37e5-4913-9d7c-15b51b85c8ef", "Customer", "Customer" },
                    { "3b875e8f-07c9-4bf3-89b6-80e498e99346", "6c02b074-95ca-4c55-bcd8-70657369f8fe", "Tech", "Tech" },
                    { "eeaa5590-9443-46d6-870f-8f16417fa61f", "30d2929b-1958-4d31-840f-3ef83b6b915d", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5207656a-c474-4684-a3e8-294435bde626", 0, "cd036349-7429-4de3-982c-9c079e0b6d09", "customer96@abv.bg", false, "Alex", "Alexandrov", false, null, "customer96@abv.bg", "customer96@abv.bg", "AQAAAAEAACcQAAAAEJLAf11SwdDwO6n+Ju4GJi9jGOeuUwYQh3EH4TqaMRAtdR3ju0xiw+VE4lPxVVD6Ng==", null, false, "", false, "customer96@abv.bg" },
                    { "d62182ee-d7c5-4f7b-9c7f-3821df14646c", 0, "64857394-453f-4618-ba3a-de93ac65d25c", "customer97@abv.bg", false, "Jack", "Johnson", false, null, "customer97@abv.bg", "customer97@abv.bg", "AQAAAAEAACcQAAAAEKoyG/UDWutZ8oeGzRysq4jm8kfhJMkViNGfYJfzl0Bxhc87wicx7gaoSNWbqs2vvQ==", null, false, "", false, "customer97@abv.bg" },
                    { "91b819e9-5471-4c25-91c9-17a790be1831", 0, "fe9d0667-1ce1-4af8-be62-d53536d40d4b", "customer98@abv.bg", false, "Jane", "Alexandrov", false, null, "customer98@abv.bg", "customer98@abv.bg", "AQAAAAEAACcQAAAAEM+1Q5OBWRs29E4SMDV1e+pN/XO0uIujPlFmoYM3dtYcYRXp9oMQ0sIUNbq2DKbi+Q==", null, false, "", false, "customer98@abv.bg" },
                    { "07e9b088-93d1-4008-9895-dc9eb1fa8511", 0, "ba7b6952-3e62-466b-b443-7d622dfc5779", "customer99@abv.bg", false, "John", "Johnson", false, null, "customer99@abv.bg", "customer99@abv.bg", "AQAAAAEAACcQAAAAED+TWNXYgG+dosrHELfMiJwynJxStwy8R2A8PEUUzK/SjLyedHUDgUGACdJ0nMwQ1g==", null, false, "", false, "customer99@abv.bg" },
                    { "8bd20eed-b102-4887-85bb-1d40ced1d0ed", 0, "94122878-09f4-4c34-9ee9-41b2622f1eda", "tech0@abv.bg", false, "John", "Johnson", false, null, "tech0@abv.bg", "tech0@abv.bg", "AQAAAAEAACcQAAAAEGo5wUKWVswh6n64QIHI8z3v/UAHRK+yVAEaSH+gVLjLyVD9r1jRit9ww3nA5T+K3A==", null, false, "", false, "tech0@abv.bg" },
                    { "eb81855b-060e-4f06-a714-5feec172402b", 0, "be35922d-0450-4c24-b1ae-6ac2d2d11b3e", "tech1@abv.bg", false, "Alex", "Johnson", false, null, "tech1@abv.bg", "tech1@abv.bg", "AQAAAAEAACcQAAAAEO311lqKIoKTZZkooC1h3bTVqdUqXE0JVrLosR9e3g9FZ7wEbIzLuIKAm+726e9uwQ==", null, false, "", false, "tech1@abv.bg" },
                    { "0345c656-a63b-4816-bd28-d6e72a36d0a0", 0, "b9ca48b7-9dd2-4ae8-a99f-c890404ab2de", "tech2@abv.bg", false, "Jane", "Johnson", false, null, "tech2@abv.bg", "tech2@abv.bg", "AQAAAAEAACcQAAAAEIR5mBbEixTZVNHFFP8lrfzeruajrHimGlpUGZSLvRjwFbcn2nWnfKHXECbm0iBF3w==", null, false, "", false, "tech2@abv.bg" },
                    { "c18febfe-f8bc-447b-95be-cd76b0d8229d", 0, "76c1181a-405b-4dd6-89d1-484f56e60aad", "tech3@abv.bg", false, "Jane", "Johnson", false, null, "tech3@abv.bg", "tech3@abv.bg", "AQAAAAEAACcQAAAAEMIbNYiogzdAjc4ANIXADlkqX2yVEDQOs00JuGH6Rss/sazLQIhjl0hFE6ZpcGOfrA==", null, false, "", false, "tech3@abv.bg" },
                    { "969172aa-0d6a-427e-b13d-c39e52c0ae92", 0, "8504c54e-75c8-4714-92af-84cd63e1da3c", "tech4@abv.bg", false, "Jane", "Johnson", false, null, "tech4@abv.bg", "tech4@abv.bg", "AQAAAAEAACcQAAAAEL1jZzRPH8Uk+G0+y/V21sFMobB9HsMmnLyob/UftufoAr7auFmR+tmjMBOqgGCKTw==", null, false, "", false, "tech4@abv.bg" },
                    { "ef8a84c9-d2c6-45a8-8dc6-c4db482683db", 0, "cf2b0cb9-6c62-4d66-a67d-2331f84eb15a", "tech5@abv.bg", false, "Jack", "Alexandrov", false, null, "tech5@abv.bg", "tech5@abv.bg", "AQAAAAEAACcQAAAAEFj+foCsWE1M+VAfbereJ8nke2lRF+7kamiWK/AMMv3fSe++CmE899/JeF+sgenxPQ==", null, false, "", false, "tech5@abv.bg" },
                    { "5acdee34-7c8e-457c-ae57-824ebfa63067", 0, "ec50ae1c-eca5-46bb-b2f0-794cd4b7e9d7", "tech6@abv.bg", false, "Jane", "Johnson", false, null, "tech6@abv.bg", "tech6@abv.bg", "AQAAAAEAACcQAAAAEL0/qqMN6wrSx21RraBA6tQHz2/NXJaZs4OCuR+oFxohV5iIt/LMGZWiYlEIq4JkGg==", null, false, "", false, "tech6@abv.bg" },
                    { "935a8b72-9be4-4f8c-9870-ee73b23b4735", 0, "1f965b3d-ffe4-4867-b3eb-09296a720866", "tech7@abv.bg", false, "Alex", "Johnson", false, null, "tech7@abv.bg", "tech7@abv.bg", "AQAAAAEAACcQAAAAEOi22WRjPkIrH5UQeN4kF33RvvSg0xe+WX1+1n7qFyOxRWqLRnR3pPXUFRND96NzsA==", null, false, "", false, "tech7@abv.bg" },
                    { "b717c2e9-3271-4228-873e-bdd2890c5a0e", 0, "6bb5560f-a21f-4434-8e16-993dade0e462", "tech8@abv.bg", false, "Jack", "Alexandrov", false, null, "tech8@abv.bg", "tech8@abv.bg", "AQAAAAEAACcQAAAAENM7rLGGx6g/LIRmo5lOrUg4Cqzyk18V/pNxyjSnqxuCs4VomRVpjYcOnx5WUpBkng==", null, false, "", false, "tech8@abv.bg" },
                    { "2003286a-6c6b-4e75-8c52-f039d230591a", 0, "0a0ff9c0-c19f-4e2d-9517-2c6087940779", "tech9@abv.bg", false, "John", "Alexandrov", false, null, "tech9@abv.bg", "tech9@abv.bg", "AQAAAAEAACcQAAAAEIr1viK5UTXn7aii3fntNYUaFw5/puw91sGK4UWgA6TwIOCCdTvBCZtDJvpfvxwEPg==", null, false, "", false, "tech9@abv.bg" },
                    { "4b4c9518-ac97-470c-8833-2c9f5b90a7b3", 0, "5bfba7cd-1a93-44ff-9e13-74bde1e11d72", "tech10@abv.bg", false, "Jack", "Alexandrov", false, null, "tech10@abv.bg", "tech10@abv.bg", "AQAAAAEAACcQAAAAEExaqd8StnLFGnuvL1X70uhQQqmDsCz7kjmNEUfFtWWpVnnxFa3N0U0MLz60VOfjIg==", null, false, "", false, "tech10@abv.bg" },
                    { "96dd5af8-0960-4e24-90b9-7f27c34e586e", 0, "00101187-a5ec-405e-8271-a065a83aa8c6", "customer95@abv.bg", false, "Jane", "Johnson", false, null, "customer95@abv.bg", "customer95@abv.bg", "AQAAAAEAACcQAAAAENuq8Jmyc5Q+cIlv+BjFHx4ZI8EDXuLoh5VvSS/5xlZgWOak0yAErfCHxw653aTJYQ==", null, false, "", false, "customer95@abv.bg" },
                    { "3b54a9ec-f3ac-4adb-ae0f-d4d12357cbc6", 0, "ab0d7f65-8214-4f7b-afe6-14ff742efc0b", "tech11@abv.bg", false, "Alex", "Alexandrov", false, null, "tech11@abv.bg", "tech11@abv.bg", "AQAAAAEAACcQAAAAENZvSR9GtGcpoTFPL/3Gj76D9tjKEinnJ8qEHIgrwxCTGkeqdlT4ibsjU6fnHLm0YQ==", null, false, "", false, "tech11@abv.bg" },
                    { "92c19c5d-3294-4d48-bb1b-28d7a8513f02", 0, "9288c3c9-f3b5-499b-a682-2d952fd9cc74", "customer94@abv.bg", false, "John", "Alexandrov", false, null, "customer94@abv.bg", "customer94@abv.bg", "AQAAAAEAACcQAAAAEBiED83mUIHBsX2PwrVHWjJq/P3g6bE4D1DoNXBOoZO5s6f/J8GB14J/w5ql51J9OA==", null, false, "", false, "customer94@abv.bg" },
                    { "fe6ad777-a74d-4302-a246-e34f904531c2", 0, "a7f12e3d-9760-4bff-9216-bff17316aedf", "customer92@abv.bg", false, "Jack", "Alexandrov", false, null, "customer92@abv.bg", "customer92@abv.bg", "AQAAAAEAACcQAAAAEFeviMpMHK4Nx3Bg9j1O5DJi8XU3ldox8YigIqoNKodVtl8BF6LQ0ZVPpTXWxWxugw==", null, false, "", false, "customer92@abv.bg" },
                    { "c876b1f5-1cf8-476a-ae45-e6b38ea3b426", 0, "bc2c7681-c19d-4068-94a1-d8cf5e68e862", "customer77@abv.bg", false, "Jane", "Johnson", false, null, "customer77@abv.bg", "customer77@abv.bg", "AQAAAAEAACcQAAAAEEKdCSAwramWg+gziTk4uw581J4zMGRBAh2ujUn70PTc8hprov7yHgM7Fkg/5xI9bg==", null, false, "", false, "customer77@abv.bg" },
                    { "2230b57d-5172-4bfc-923a-e8488dd8a60a", 0, "6de12943-aa7e-4975-933b-301c803971ab", "customer78@abv.bg", false, "Alex", "Johnson", false, null, "customer78@abv.bg", "customer78@abv.bg", "AQAAAAEAACcQAAAAELxDuzsgAFF5ysvZIK6GIo7/Io0cKZziGZpQONSYn/9RBd2FG4A7/XSrNRJkGC+eNQ==", null, false, "", false, "customer78@abv.bg" },
                    { "82280915-4ba3-417d-8457-38e7e438920b", 0, "9925bac1-3ea5-4fc3-92b3-4f5e0f4ea5ff", "customer79@abv.bg", false, "Jack", "Alexandrov", false, null, "customer79@abv.bg", "customer79@abv.bg", "AQAAAAEAACcQAAAAEJDWbSR9mcOqY4RwYBR4CF9rqbSKBzW6tBI2QFUI0VRfCst/Y2DRNl5ZRQ/SFaMJUQ==", null, false, "", false, "customer79@abv.bg" },
                    { "ff017848-24b2-4075-9f82-c3be92e556ed", 0, "f8d2f9af-ee75-4e28-9761-d4d834be5eb6", "customer80@abv.bg", false, "Jack", "Johnson", false, null, "customer80@abv.bg", "customer80@abv.bg", "AQAAAAEAACcQAAAAEGeS5YZ37jFCCz4jlfnCuOm8wFxZ8Y2rpXrtjlY4T0g21Rms/J7rmNo7Ei+pjrEdVg==", null, false, "", false, "customer80@abv.bg" },
                    { "bd14e399-40ae-4a7d-8cce-081250f1dae8", 0, "dcae63db-954f-47fc-905b-a83a806184b3", "customer81@abv.bg", false, "Jack", "Johnson", false, null, "customer81@abv.bg", "customer81@abv.bg", "AQAAAAEAACcQAAAAEGofISU8sV92iTdg0SB1kjZtkeHezEwl3+uU3DPdfHqZI89LpDbmGs0ygs6IDFFUlQ==", null, false, "", false, "customer81@abv.bg" },
                    { "c3660765-6c34-406a-89f4-cffd346688c2", 0, "20bdf1a4-f405-458f-9a8b-2314e2035149", "customer82@abv.bg", false, "Jane", "Johnson", false, null, "customer82@abv.bg", "customer82@abv.bg", "AQAAAAEAACcQAAAAECwHSYyBQyAg1jVoFmlf0I9Vk0dMvNzuLJ+BfxVEe/6yN1XA+iIe0Mb8hyKyMjlNRA==", null, false, "", false, "customer82@abv.bg" },
                    { "f20f33d3-2930-49d0-8ce8-89698fc75267", 0, "8803cb37-921d-4679-bc73-ffd6cd0d0b49", "customer83@abv.bg", false, "Alex", "Johnson", false, null, "customer83@abv.bg", "customer83@abv.bg", "AQAAAAEAACcQAAAAEHJkKdbIgxSnh8DxeMHtRWS2kkB46pxSFopWFpHVS9lQRyd+/SVgU/32bzoZ2RzmkA==", null, false, "", false, "customer83@abv.bg" },
                    { "19799b68-744a-43fd-b23f-88d40dc7c303", 0, "641c6a7a-6137-402a-ad6a-f639ace1c60a", "customer84@abv.bg", false, "Jack", "Alexandrov", false, null, "customer84@abv.bg", "customer84@abv.bg", "AQAAAAEAACcQAAAAEGcH8mek7jdpYYNI6yDCC1D3QQUdzbGTvJVrJsjjKaz2IofwpqV8WcQRDbHP8Wg9bA==", null, false, "", false, "customer84@abv.bg" },
                    { "d4c3a173-4a85-46e1-af15-7cac793a802a", 0, "63a2e55f-fe2a-4a0b-9b6f-707fe5896f05", "customer85@abv.bg", false, "Jane", "Alexandrov", false, null, "customer85@abv.bg", "customer85@abv.bg", "AQAAAAEAACcQAAAAELRvBOUt6YW6YDZiwgQQb4UtfH6NS7VP5PaDLeRyzIdf5bKfLz4Eq/Oive98FbCIiA==", null, false, "", false, "customer85@abv.bg" },
                    { "0f7cd778-935c-4ecf-9f4d-832b07492a0e", 0, "4eef9d3c-0150-4b29-870e-4137e455ad6e", "customer86@abv.bg", false, "Jane", "Alexandrov", false, null, "customer86@abv.bg", "customer86@abv.bg", "AQAAAAEAACcQAAAAEB0LERcybjZH2IBOIf+0KIXTgwHGQ8chwy2ypkQceMNo8sUmwY5dtQmZD62/3/VLWQ==", null, false, "", false, "customer86@abv.bg" },
                    { "e374030e-d107-423f-a533-2a569675587a", 0, "0c27c258-8a4b-4ad6-8ccf-8a393e974491", "customer87@abv.bg", false, "Jane", "Johnson", false, null, "customer87@abv.bg", "customer87@abv.bg", "AQAAAAEAACcQAAAAEFIqRhWPF7y4FYjbF0tiO/OTXmoBQJgcvXA5bxrkEPmfy2u6gwAQN22hIIIf9Istbg==", null, false, "", false, "customer87@abv.bg" },
                    { "57aa6924-5b2a-4fcd-9d58-83cb1dc0d0f8", 0, "b7cbf166-f7a7-4217-8286-2dfe9a7a1209", "customer88@abv.bg", false, "John", "Johnson", false, null, "customer88@abv.bg", "customer88@abv.bg", "AQAAAAEAACcQAAAAEEgDQijLhZ8iLzgzWye7AcffgBSgZXBiGSV3+5jcFppch8b96jnWGdqDivoiE2L4ww==", null, false, "", false, "customer88@abv.bg" },
                    { "ec070840-565d-4b7b-bbdc-6e808f1410c4", 0, "5f20315a-32ca-447f-aa86-9e64035c7756", "customer89@abv.bg", false, "Alex", "Johnson", false, null, "customer89@abv.bg", "customer89@abv.bg", "AQAAAAEAACcQAAAAEGQ2Y+xrhGoJyDkaG4vlB1w48TrG6c3lSsmD8UzR7d3u9EdSUb3uN8R+qN+e/mrDJA==", null, false, "", false, "customer89@abv.bg" },
                    { "86bfd4c1-a904-4cbc-ad7a-293ee3b994c3", 0, "5b387519-a1e9-48b7-898c-d23a438c128f", "customer90@abv.bg", false, "Jack", "Alexandrov", false, null, "customer90@abv.bg", "customer90@abv.bg", "AQAAAAEAACcQAAAAEOoxmTknXmoEA0zjagEqNwCckW60AMQ59MDTqWL438Adw/u4YGgfBYWBiKVNyugKrQ==", null, false, "", false, "customer90@abv.bg" },
                    { "753c690a-5616-443d-93d2-52ac191ba59e", 0, "43901ed3-5433-4d05-b0cc-8dfe9a527ee1", "customer91@abv.bg", false, "Jack", "Alexandrov", false, null, "customer91@abv.bg", "customer91@abv.bg", "AQAAAAEAACcQAAAAEBa9FhWmdMIwxuCejQqefwfPxhjnd63e0v9XJDX1gUatDPAtann8Va1gyBTAE33//w==", null, false, "", false, "customer91@abv.bg" },
                    { "6da87c28-6735-4d8d-897e-ea3415062319", 0, "afe10a36-a334-483b-8a97-11f8f51fda22", "customer93@abv.bg", false, "Alex", "Johnson", false, null, "customer93@abv.bg", "customer93@abv.bg", "AQAAAAEAACcQAAAAEPnjJSBfiCfjGoRxvMSNMBFw5FaTj32CANGdhkQawtgRVzeENVjOeZj+15Ay+cjOdA==", null, false, "", false, "customer93@abv.bg" },
                    { "d75cc932-c238-45cf-9837-96516ccba18d", 0, "80bda5ab-1245-4075-b306-c6557141bd37", "tech49@abv.bg", false, "Jane", "Alexandrov", false, null, "tech49@abv.bg", "tech49@abv.bg", "AQAAAAEAACcQAAAAEAlDJ2FxL/YJmbNY7BSL/xwEqr5AS5wzhWiw/JANrm9mUHz5wde+csUNF7htjRB8Bw==", null, false, "", false, "tech49@abv.bg" },
                    { "662acc08-845f-40e8-a110-2e2025b014ba", 0, "50fca9ff-ed2a-4f5c-940c-55c111c4064c", "tech12@abv.bg", false, "Alex", "Johnson", false, null, "tech12@abv.bg", "tech12@abv.bg", "AQAAAAEAACcQAAAAEETDpE8j0qUV2J60MVt/zYdfIbgQAq/V0kTlAxuftBX9Snf0LKNUS4CVnFXTGFTKdA==", null, false, "", false, "tech12@abv.bg" },
                    { "34669351-9eac-4023-b658-e5973ae6a158", 0, "5a33ba24-b389-4518-a64b-777afe98f3db", "tech14@abv.bg", false, "John", "Alexandrov", false, null, "tech14@abv.bg", "tech14@abv.bg", "AQAAAAEAACcQAAAAEBp5N4cydTrQ+A/SAB8j+rAOcVQAxPwxIZWOaAPYmdBebj8dd2/zG+fCbUhZxP2PYw==", null, false, "", false, "tech14@abv.bg" },
                    { "33a9a829-dccb-4af4-9b0a-fde3bc323255", 0, "25124632-d52b-4974-bee6-c7f6360c76bd", "tech34@abv.bg", false, "Jane", "Alexandrov", false, null, "tech34@abv.bg", "tech34@abv.bg", "AQAAAAEAACcQAAAAEOw6rSkV/J7IIcRKly6eNp1xY0VpX1gYj895iZceYToGYe0rdyt8Z5UKsQ8df7B88Q==", null, false, "", false, "tech34@abv.bg" },
                    { "66ac7c71-ad4e-4ab7-bab6-9788cc8c38ea", 0, "0c6486e1-6768-46ca-8e36-79b3182c194f", "tech35@abv.bg", false, "John", "Johnson", false, null, "tech35@abv.bg", "tech35@abv.bg", "AQAAAAEAACcQAAAAEEX3VFeMxXjpy6g+Df8pz0lJ5nSy9Znf5W/sbuhslt/gZ45nl3Hfd8QT5vn2IKOWrw==", null, false, "", false, "tech35@abv.bg" },
                    { "eb1eee16-a36c-407f-a87a-be4e64f76ace", 0, "4ad00d88-680d-4666-9c10-3222a20b4276", "tech36@abv.bg", false, "Jack", "Johnson", false, null, "tech36@abv.bg", "tech36@abv.bg", "AQAAAAEAACcQAAAAEA+rHT9pTlSjc7Tk6eh9bslDBMMR6c29Ftns1w1h2KTT7OzO49920Aq0xs+xfAY+rg==", null, false, "", false, "tech36@abv.bg" },
                    { "3a82a1ed-6ed1-473e-afd2-876be2c24f70", 0, "edd829ac-4b24-491e-9aa9-964cd9f5989f", "tech37@abv.bg", false, "Jane", "Johnson", false, null, "tech37@abv.bg", "tech37@abv.bg", "AQAAAAEAACcQAAAAEKwhsFaYbHKvHD435ucF3mS6TH6Y8jsaeP8oz0WAcB7h0x4tinoGxvel59gA1uHJpw==", null, false, "", false, "tech37@abv.bg" },
                    { "eb3175bf-0ce0-42b8-bc91-e961f5ed3185", 0, "fde4de28-0b10-4388-9025-9c34324f112d", "tech38@abv.bg", false, "Jane", "Alexandrov", false, null, "tech38@abv.bg", "tech38@abv.bg", "AQAAAAEAACcQAAAAEBfHIcnsZOWaF855qpXP51b9/JrDqvdCOyR6UPXcK92K/V3J8LPgbSHacYWGBuPnSw==", null, false, "", false, "tech38@abv.bg" },
                    { "75db636b-5d39-49c6-a511-47165049eaca", 0, "57bf1227-1d1e-40f8-97ba-7dd302f425b0", "tech39@abv.bg", false, "Jane", "Johnson", false, null, "tech39@abv.bg", "tech39@abv.bg", "AQAAAAEAACcQAAAAEH/lBGFooTha6CVLkS0Tpf5xgcFjs5bascf5ManzJPfvOrv0sLYtf77Sc4Ry1zVEtw==", null, false, "", false, "tech39@abv.bg" },
                    { "1a6ba66b-f96b-432a-964c-d9386ae19b74", 0, "6fb58f09-8716-4d65-8a46-43cbeb67aaf9", "tech40@abv.bg", false, "Jack", "Johnson", false, null, "tech40@abv.bg", "tech40@abv.bg", "AQAAAAEAACcQAAAAEBcjQgfrHhFHy+kifcF1iyOZ5Ftde2dl4An1B6vcU2h3+kjdZCiiGbUlvwZqKNrahA==", null, false, "", false, "tech40@abv.bg" },
                    { "cdb452b3-8dc4-42f5-aae9-35e34fc12280", 0, "a5fda586-b680-4094-b8f9-d5438a8409d7", "tech41@abv.bg", false, "Jack", "Johnson", false, null, "tech41@abv.bg", "tech41@abv.bg", "AQAAAAEAACcQAAAAEJsAvcVQfuybroTTEryUAX85M5aMASH2djRBpTwMa2NeHWNcN9LQXfG2ILgHfaVTgg==", null, false, "", false, "tech41@abv.bg" },
                    { "ffe4aa6e-0e20-4c3b-8483-b241443e9ac0", 0, "48f21ef6-4ecd-4c1e-a8f5-04c08d3e15cd", "tech42@abv.bg", false, "Alex", "Johnson", false, null, "tech42@abv.bg", "tech42@abv.bg", "AQAAAAEAACcQAAAAEDCLriKC3WA7tKqdfGue9NUYnKU2wA6RF5MAAQPjsQvRcWqlHvGpd0dZiLx8XNP5gw==", null, false, "", false, "tech42@abv.bg" },
                    { "16512485-5d03-4755-aacb-eca8bec969c4", 0, "9118a39d-0df4-4665-aa4f-7f53686551b3", "tech43@abv.bg", false, "Jane", "Johnson", false, null, "tech43@abv.bg", "tech43@abv.bg", "AQAAAAEAACcQAAAAELsQwrhi0xxqvyxz+NYTUEmUzNwjyVLrAIzMNgNMFQuCu94hNmvNhA2aBDobIJYwQA==", null, false, "", false, "tech43@abv.bg" },
                    { "4f74c5df-1ba2-43d6-adf0-78268ae19182", 0, "4ed1f908-79ad-421e-9bee-86d506503863", "tech44@abv.bg", false, "John", "Alexandrov", false, null, "tech44@abv.bg", "tech44@abv.bg", "AQAAAAEAACcQAAAAEB9i9xIp/ugqmmx9MnAI0szfrKaA4KgIss6N1NhGgIoPbCH5vaILzYUBu0xRbLxDBQ==", null, false, "", false, "tech44@abv.bg" },
                    { "4529b86e-5fe0-4081-8bbd-0a7ff6137c6c", 0, "dfe51152-d2da-4126-961c-f4706e792120", "tech45@abv.bg", false, "John", "Johnson", false, null, "tech45@abv.bg", "tech45@abv.bg", "AQAAAAEAACcQAAAAEPNVrM8SxVIhbw0T1MkXMe8mkKpRnQPpAT+XqJ/e62qcsvSUbi6+HYzjEqKW6whTrg==", null, false, "", false, "tech45@abv.bg" },
                    { "0c34bd6b-1cb2-495f-930a-7f89e3ce4cdb", 0, "fee885c3-ffbd-4eae-8c76-6af0d44acf90", "tech46@abv.bg", false, "Alex", "Johnson", false, null, "tech46@abv.bg", "tech46@abv.bg", "AQAAAAEAACcQAAAAEMSHex3LkXoYuDK/lT8X/7kCoSA25gH23lsyk8Ho4Qo6Wg23C7PXYxht/Rt81t+iHA==", null, false, "", false, "tech46@abv.bg" },
                    { "04b95fb2-994f-401b-a376-8e34f021f725", 0, "1261878c-4e62-4991-9df5-9c44fb0047f3", "tech47@abv.bg", false, "Jane", "Johnson", false, null, "tech47@abv.bg", "tech47@abv.bg", "AQAAAAEAACcQAAAAEGtZc1tCGl9P1utGWjbTKONe/M9iGwKUJylsPB11PS+jafj4x3u73bNPMcsHYXc/ug==", null, false, "", false, "tech47@abv.bg" },
                    { "0eeaeb88-4258-4d5b-88d0-d803eafad74d", 0, "dd094f06-f6c8-4125-bc97-353c8e19b74e", "tech48@abv.bg", false, "John", "Alexandrov", false, null, "tech48@abv.bg", "tech48@abv.bg", "AQAAAAEAACcQAAAAEOauPHrvSefDXNmvvVvd2ilAOh6kj/xForjyCnOlE1XaLH+RQW4Awdm8caqdxGi/Kg==", null, false, "", false, "tech48@abv.bg" },
                    { "dd5c3a58-456f-4b4f-a0b1-123461b861c2", 0, "ab563616-30a5-4bf4-b2ce-da814405b2f9", "tech33@abv.bg", false, "John", "Alexandrov", false, null, "tech33@abv.bg", "tech33@abv.bg", "AQAAAAEAACcQAAAAENnQJx1rg/QT96Nv2aEyX8dgsF8DJx2ZUGJOAxvuo5+BFay0RoIvgBTzra6vaQjB9A==", null, false, "", false, "tech33@abv.bg" },
                    { "5c3e9855-4db4-4649-a23f-b4e86e25fd00", 0, "7556bed6-7ef7-45ef-bc48-75c92ddf4b31", "customer76@abv.bg", false, "Jane", "Alexandrov", false, null, "customer76@abv.bg", "customer76@abv.bg", "AQAAAAEAACcQAAAAEDLBkST4xEGmceXciK9kYYiKEzd6oCNHl4fR4a02owE8/Gy8x9LKorQemsO/MGyrJg==", null, false, "", false, "customer76@abv.bg" },
                    { "38624d16-ad64-426d-9087-59f0a6232068", 0, "6994583e-24f2-4187-b9f2-92eda2fbe610", "tech32@abv.bg", false, "Jack", "Johnson", false, null, "tech32@abv.bg", "tech32@abv.bg", "AQAAAAEAACcQAAAAECLHS1yY00Qzpqzb4uJSNb2o1F9qQiK315xFPsy+HNvt+YorW4pSPffiPh90GHKCvQ==", null, false, "", false, "tech32@abv.bg" },
                    { "7c6e2c93-c6bf-4cd0-ab7c-4da59c8f210f", 0, "546aeed3-96f7-4c66-822f-140466418007", "tech30@abv.bg", false, "Jane", "Alexandrov", false, null, "tech30@abv.bg", "tech30@abv.bg", "AQAAAAEAACcQAAAAEKIVCxyor8ffKiA2Uyr7Q0S4VRRjSkUnhUnwLFjSRHNOOl1S9Tlssvx55MCKFPU3mA==", null, false, "", false, "tech30@abv.bg" },
                    { "0adac9c2-e448-4e26-bc8c-7b062b38b14f", 0, "1b5a361a-7bf6-4598-a7f6-2e6696267d93", "tech15@abv.bg", false, "John", "Alexandrov", false, null, "tech15@abv.bg", "tech15@abv.bg", "AQAAAAEAACcQAAAAEB2M+5qofL4W+lmH7swFnFn0Iuxs7wzQqdNLVou1q2kDvlpLXBXBgLwRXPggtQdxIw==", null, false, "", false, "tech15@abv.bg" },
                    { "49a70cc3-4635-4fc5-8ae0-813ee2238214", 0, "cd6612ca-d7af-4636-bf0a-2f196c92db34", "tech16@abv.bg", false, "John", "Alexandrov", false, null, "tech16@abv.bg", "tech16@abv.bg", "AQAAAAEAACcQAAAAEJA8YSakxNpokJdBBs9hrnLT0lkauRLaf1sAn7fvnpJwdiXKuS3NKDPn2XxlJxpoXg==", null, false, "", false, "tech16@abv.bg" },
                    { "1cd18ee8-6db8-4ed0-a762-0471114a2027", 0, "23a0e8ef-9ca4-45fd-87a2-eaf1769af090", "tech17@abv.bg", false, "Jane", "Alexandrov", false, null, "tech17@abv.bg", "tech17@abv.bg", "AQAAAAEAACcQAAAAEGFYnj9iSSpJbTqndIusPEUILoAzzWg++PtLZboX6AYL9hgAxO7DFtY7c80dK6l56g==", null, false, "", false, "tech17@abv.bg" },
                    { "92b407b6-e617-46df-b757-5d4c4de0c5c3", 0, "4e42635f-f06e-4e88-a734-92e671d7607a", "tech18@abv.bg", false, "Jane", "Alexandrov", false, null, "tech18@abv.bg", "tech18@abv.bg", "AQAAAAEAACcQAAAAEG7Xr4qWb6NgVKqlrO4VMBOYTAd1yN4xh+eZYfbO3eu4ydzv6Gz66d2UubKAyrmy4Q==", null, false, "", false, "tech18@abv.bg" },
                    { "c8e3e307-5689-42f7-8139-8e0573013d19", 0, "681838c5-08b6-4b96-9fae-e240efd3100b", "tech19@abv.bg", false, "Alex", "Johnson", false, null, "tech19@abv.bg", "tech19@abv.bg", "AQAAAAEAACcQAAAAEDVcRHM+xPpbaa57uB29tVtfN9VNLg2AlBSt3gTdLMR5uNnOhbk++8EHvot5gXPM1A==", null, false, "", false, "tech19@abv.bg" },
                    { "b65add3e-6930-4a11-b69e-c72412434a28", 0, "85b34b44-2bea-4fd4-837a-967e7afc951b", "tech20@abv.bg", false, "Alex", "Johnson", false, null, "tech20@abv.bg", "tech20@abv.bg", "AQAAAAEAACcQAAAAEKkElUm1stzHt9WivkKBghOZCOFMxtU/lxsA0cCAEcZ0kpdttoan8BvEq7vUlfofZg==", null, false, "", false, "tech20@abv.bg" },
                    { "5d3bd496-6a31-4323-baa8-802a423faf45", 0, "cb1bc067-f32b-4feb-85da-53264300901f", "tech21@abv.bg", false, "Jane", "Alexandrov", false, null, "tech21@abv.bg", "tech21@abv.bg", "AQAAAAEAACcQAAAAEIkWViGLyP4ZOIbt88VIzyPOpFTwXycOW/8kTJr8RLPwsafwv/OyN3CgHzsjaTqXgQ==", null, false, "", false, "tech21@abv.bg" },
                    { "117714be-4af0-430d-90a1-f43319825d85", 0, "72a430e7-8a00-4666-8294-e6524dcde4a9", "tech22@abv.bg", false, "Jack", "Johnson", false, null, "tech22@abv.bg", "tech22@abv.bg", "AQAAAAEAACcQAAAAECMpyALM9EFvFh92VxBPB6eOaXU9JWwzOWT405VixxGoJHwaUY1XppmkYF/Tu65Mww==", null, false, "", false, "tech22@abv.bg" },
                    { "20fc2d6d-d70a-4b33-a123-bcf1416a4d88", 0, "549176fd-0b5f-4590-9184-98f3ec6c55db", "tech23@abv.bg", false, "John", "Johnson", false, null, "tech23@abv.bg", "tech23@abv.bg", "AQAAAAEAACcQAAAAELGiCcIiqYebtqh6SyjjZhc1ta+NqFbdzy7AmObDIF0OpXBVh8Edpt56pOLDV5J5+g==", null, false, "", false, "tech23@abv.bg" },
                    { "86449d5c-80c9-41e6-8673-068253347120", 0, "77dfbd3e-b8db-4ff3-8711-b0ca486cf4ef", "tech24@abv.bg", false, "Alex", "Alexandrov", false, null, "tech24@abv.bg", "tech24@abv.bg", "AQAAAAEAACcQAAAAEEat8W4DjlO9SgLMwMWKoJmNyz4sgmz1BOZOsqNn2vpkoLvLxsTAssRsYnSX+jJkoQ==", null, false, "", false, "tech24@abv.bg" },
                    { "323cfc4e-deaa-4478-8922-4f9b1111e3a5", 0, "f40e7fe6-1884-4933-8857-6f06057d73a2", "tech25@abv.bg", false, "Alex", "Johnson", false, null, "tech25@abv.bg", "tech25@abv.bg", "AQAAAAEAACcQAAAAEKcNqXaL8Yg9dtENPP9v2Wu6gZ8a4frnRtXssfO3T2JcCWMO6MBj9bkECVaIO6EwqQ==", null, false, "", false, "tech25@abv.bg" },
                    { "d641258a-fd7a-4e8a-8810-fa2a9481f9ac", 0, "d9df2224-2361-4f52-8dec-1cf377ed3f63", "tech26@abv.bg", false, "Alex", "Johnson", false, null, "tech26@abv.bg", "tech26@abv.bg", "AQAAAAEAACcQAAAAEPoAdhFzTHVd7yYzxO+UhOsj1iEKRgcadb9viU8EdgdiuS8zzuVVwFAXiznpav0aOw==", null, false, "", false, "tech26@abv.bg" },
                    { "bdd8ee75-a4ec-4244-ad4a-f48ffe42fdae", 0, "96576013-0a0c-4a41-9fae-35584e8a9a68", "tech27@abv.bg", false, "Jack", "Johnson", false, null, "tech27@abv.bg", "tech27@abv.bg", "AQAAAAEAACcQAAAAEEMyaXCMfXMdlxUmo6TvDooBklus6aQMe74+1785Bl0aqd2a0C+1ILTSgoNXAX1cjg==", null, false, "", false, "tech27@abv.bg" },
                    { "f6453e75-6bc1-421b-8958-3330946eca0a", 0, "f8eec35c-2acb-41d0-99a8-f64056928caf", "tech28@abv.bg", false, "Jack", "Johnson", false, null, "tech28@abv.bg", "tech28@abv.bg", "AQAAAAEAACcQAAAAEPMX/a4upX+/OAOqZGFF+u7SzXGN0SUBJqxHOWNFFQZcotLvxfTemKGRH/MTDfCqLg==", null, false, "", false, "tech28@abv.bg" },
                    { "ba1b2379-3e57-4eae-a0be-b2c88fbe67aa", 0, "caa4d412-e837-4f11-b3f6-c74749b8cadf", "tech29@abv.bg", false, "John", "Alexandrov", false, null, "tech29@abv.bg", "tech29@abv.bg", "AQAAAAEAACcQAAAAELtgi6AXjHGB3pEABJ/D7eCqVMJWldwfMziRCuzq9Nbe1y4FxaAW6qY6lrD2si3qyg==", null, false, "", false, "tech29@abv.bg" },
                    { "2ecd6e0c-a1ef-4568-af65-319c8d88d4fc", 0, "257d56ef-c7c4-43e1-8de1-0fd7ab8e3c1e", "tech31@abv.bg", false, "Alex", "Alexandrov", false, null, "tech31@abv.bg", "tech31@abv.bg", "AQAAAAEAACcQAAAAEA+E0Y5QBIcv66ckCvHtUOFxPtxbZbQfx21l9UP8pZQAGSJpX5OBkENJYcBs06LObg==", null, false, "", false, "tech31@abv.bg" },
                    { "dcc831b4-ceb3-495c-ad12-7dd49d056f95", 0, "b2f4b089-4619-4096-88f4-37dcfe675ca3", "tech13@abv.bg", false, "Jack", "Alexandrov", false, null, "tech13@abv.bg", "tech13@abv.bg", "AQAAAAEAACcQAAAAEBfvKFHEyRC+ZyKUo7sNDe+ZvfQglAgyAto+7OHewDESGcYHZbRcpLRoprba9M6dew==", null, false, "", false, "tech13@abv.bg" },
                    { "8bda9135-9403-4163-b414-df71fda17612", 0, "ea2c8518-7a78-43cf-a3fb-eeb4cf9f82c8", "customer75@abv.bg", false, "John", "Johnson", false, null, "customer75@abv.bg", "customer75@abv.bg", "AQAAAAEAACcQAAAAEDpiQ9Nz+eyuWO/m2x1HWTdmCVpFM4NcnS2ckgIyoD1YPJJZd6CkkGDIBxJPgrI8+g==", null, false, "", false, "customer75@abv.bg" },
                    { "13785b1b-81b3-44f6-a5d8-63c20b0863dc", 0, "60965967-5cc6-4c19-816d-d87a9b799629", "customer73@abv.bg", false, "John", "Alexandrov", false, null, "customer73@abv.bg", "customer73@abv.bg", "AQAAAAEAACcQAAAAEMttmW2X0OSDyE8J1kADXdE2lShVm8AC0xNPuCHAhHu4pSqGg4KjUuNtAUOX+qvBmQ==", null, false, "", false, "customer73@abv.bg" },
                    { "6a3aaf87-d38a-4184-a9e2-06f81f5cd1f7", 0, "01b80a27-a5f9-4246-8d39-1f54af115f1f", "customer19@abv.bg", false, "John", "Johnson", false, null, "customer19@abv.bg", "customer19@abv.bg", "AQAAAAEAACcQAAAAED4xbZ9A9CXseB2tiraC2Y13pA+PXSTXhmZkmdBhhRWx+SoVMV3uT2D4CiFXAOcDrw==", null, false, "", false, "customer19@abv.bg" },
                    { "d53f8031-c378-462c-92b0-c08d777433f0", 0, "e20c1d81-d06b-46f6-8531-ecbba0a87b42", "customer20@abv.bg", false, "Alex", "Alexandrov", false, null, "customer20@abv.bg", "customer20@abv.bg", "AQAAAAEAACcQAAAAECaQ0HmK/50dmQuElNrNzDFTI7Djh14/PgY7+jR1ChMMtC3m5DR64K7G3kvs8VMfhw==", null, false, "", false, "customer20@abv.bg" },
                    { "93a91039-12c2-4876-b493-fbad6e9da0cd", 0, "8891d2c3-04a5-4531-92c4-c8faa45e2fbb", "customer21@abv.bg", false, "Jack", "Alexandrov", false, null, "customer21@abv.bg", "customer21@abv.bg", "AQAAAAEAACcQAAAAEGgvEGVZh202QWgtplEVnMltiAWZeCqPcBFULJq8COLzgTsp263eRL+iA8JbirYK3w==", null, false, "", false, "customer21@abv.bg" },
                    { "9a616128-e9fa-4eee-a151-c64375e4e195", 0, "9e53a847-1bf5-48fe-9e99-45469cea4728", "customer22@abv.bg", false, "Jack", "Alexandrov", false, null, "customer22@abv.bg", "customer22@abv.bg", "AQAAAAEAACcQAAAAEOjJ5IU+4LsNzP9A1cV8nJnLP9nRee9SgWSjEJq96eoqXZmSM8jK93Qa+a1iz6RgcQ==", null, false, "", false, "customer22@abv.bg" },
                    { "850e61dd-47e0-4ae2-bf23-461cea5b3489", 0, "bccfb302-5657-4f47-a9ce-46ec44f47b65", "customer23@abv.bg", false, "John", "Johnson", false, null, "customer23@abv.bg", "customer23@abv.bg", "AQAAAAEAACcQAAAAEMOXTFk+KU3m6wWDJmbzri/zRjFuqnw8TT+9q6TdGQxdfMfnrViDjvleqS99CdwzbA==", null, false, "", false, "customer23@abv.bg" },
                    { "9b285dc2-1e7c-45f4-9779-a314ff8f7021", 0, "8dd0277a-76c5-4b0d-bda2-ca67565a56ef", "customer24@abv.bg", false, "John", "Alexandrov", false, null, "customer24@abv.bg", "customer24@abv.bg", "AQAAAAEAACcQAAAAEPl84e4S8N/rWcrTCg2dh1u+gCtX2MOr9IK501NLebh7ejiycZLalk7PSIj1+76NKw==", null, false, "", false, "customer24@abv.bg" },
                    { "76ac581e-3156-42c0-a30b-c7deab7ed9d8", 0, "ff72c6d9-3eec-4ea4-b27d-8f789c8b5010", "customer25@abv.bg", false, "Jack", "Alexandrov", false, null, "customer25@abv.bg", "customer25@abv.bg", "AQAAAAEAACcQAAAAEJmFboPhAyBaU8IV8f8pa8GflPgak74LNjKfjeZnZZKNuEXbhAimxh3ZjP8hE9ESuw==", null, false, "", false, "customer25@abv.bg" },
                    { "b5ce5e52-082a-4733-8a7f-0f25bf8f9860", 0, "ad657468-e81c-479d-a159-31d567ea1663", "customer26@abv.bg", false, "Jack", "Johnson", false, null, "customer26@abv.bg", "customer26@abv.bg", "AQAAAAEAACcQAAAAEPUFRxWr61u43/rDAmRJU7puriBfhRrvBtzuE6XlmgbbscfKEYs2s00ARri/LG1opQ==", null, false, "", false, "customer26@abv.bg" },
                    { "7d3d79c2-221c-41d6-8689-9b51ea7c2ad2", 0, "546f1d07-4bf7-4ad8-aaab-4f454590afc9", "customer27@abv.bg", false, "Jane", "Johnson", false, null, "customer27@abv.bg", "customer27@abv.bg", "AQAAAAEAACcQAAAAEHaxhBK23qyNRIfhBiMz/60zBYjw8oP9TnO19UEj2SHOc61foooOhzz5U2Bsg57f+w==", null, false, "", false, "customer27@abv.bg" },
                    { "af8d30e3-8e78-4132-89ab-cbd05291cd66", 0, "76f95f93-8251-41b1-b648-c416e1964276", "customer28@abv.bg", false, "John", "Johnson", false, null, "customer28@abv.bg", "customer28@abv.bg", "AQAAAAEAACcQAAAAEKVFi58WVMTGmuTErHWuSbOgIfzHYBwcGMZ7lE033vdk/t7rHAJhhhSLS73La5i9TQ==", null, false, "", false, "customer28@abv.bg" },
                    { "f95950f1-d541-44a7-94a7-5e307cd6712b", 0, "a7edd423-b903-4f4d-98b6-5fa6254f9537", "customer29@abv.bg", false, "Jane", "Johnson", false, null, "customer29@abv.bg", "customer29@abv.bg", "AQAAAAEAACcQAAAAEO6FZ7oXl7mNjvcohttShCEvfYdgS9r8Un6rarLEgFbbv2U85H0OsjKnvsp0uISjZg==", null, false, "", false, "customer29@abv.bg" },
                    { "8405e16e-9e70-4e35-980d-495216ea4342", 0, "9e0c8037-7f95-4753-98b0-1c41ffa2e89e", "customer30@abv.bg", false, "John", "Johnson", false, null, "customer30@abv.bg", "customer30@abv.bg", "AQAAAAEAACcQAAAAEA/fOhYGQ3R9zfTwbZXPO1piKfxaVUtNR3fNCSNJZYhdzpppnhBfTT+ElgyffrJxnA==", null, false, "", false, "customer30@abv.bg" },
                    { "34d6c333-afe9-48f3-b1b4-de40aae089c5", 0, "5ad656a2-9373-4341-bca0-d625803d33e0", "customer31@abv.bg", false, "Jane", "Johnson", false, null, "customer31@abv.bg", "customer31@abv.bg", "AQAAAAEAACcQAAAAEEK+rK8ZzwkYVsMxZFXRaklduhytNZVF7fbF+lF5klw4QI2+nDzQiaT0OCQO0IxoYg==", null, false, "", false, "customer31@abv.bg" },
                    { "7b8872a4-99d3-46ce-bef2-b11151112060", 0, "b595ffca-0046-49d1-ade4-e2c5c4e03e38", "customer32@abv.bg", false, "Jack", "Alexandrov", false, null, "customer32@abv.bg", "customer32@abv.bg", "AQAAAAEAACcQAAAAEFA/7U2XAw1txclnX1f3NXB4isV298K1JjHap+ddn8g70wHCKrtuoKH4QA4gJ56Vxg==", null, false, "", false, "customer32@abv.bg" },
                    { "ebd39e5d-17df-4af2-bcb1-a2d40d5cec43", 0, "5a308fa8-63a4-43e8-b6a4-864860116b50", "customer33@abv.bg", false, "John", "Alexandrov", false, null, "customer33@abv.bg", "customer33@abv.bg", "AQAAAAEAACcQAAAAEOvgI5l9inEHELyO+prmrbfQGso9LxFJC7us415urCnxORFnyW1y8ZRFSzf1YZqE+w==", null, false, "", false, "customer33@abv.bg" },
                    { "5b025639-4a4b-4b1c-8a22-20fe4ca43f82", 0, "904bda0f-a6e9-4424-8dca-cf424cd7764a", "customer18@abv.bg", false, "John", "Johnson", false, null, "customer18@abv.bg", "customer18@abv.bg", "AQAAAAEAACcQAAAAEEQUhEpJnMKmsBWVIYiRwEoN2FCyuvIJzildPnCcdaOfku9r9E6z68/UIDSUefKTNw==", null, false, "", false, "customer18@abv.bg" },
                    { "dce64fb2-d8a4-44fd-952e-09bf3c1d1af3", 0, "b159b07a-08c9-41c2-a792-35681f1a320a", "customer34@abv.bg", false, "Alex", "Johnson", false, null, "customer34@abv.bg", "customer34@abv.bg", "AQAAAAEAACcQAAAAEDZuw/XMluEBItYVWVoFsDv/ojQvFfNHQGFPdDpGh1of/SYqjWHxPCo6kkafI3LdjQ==", null, false, "", false, "customer34@abv.bg" },
                    { "5dabd3ad-a587-49d4-aa6a-f401ce398973", 0, "b2c3bf82-5040-46c1-8b69-4407e72080c4", "customer17@abv.bg", false, "Alex", "Alexandrov", false, null, "customer17@abv.bg", "customer17@abv.bg", "AQAAAAEAACcQAAAAEAzYkeiz90GLNK1xMyU4rUfJ7b73kMYptucYjUahOXA4fvz+plNBVPZ5tR2VurXYuw==", null, false, "", false, "customer17@abv.bg" },
                    { "0aa27193-ac76-4c92-bdd9-fd23e39cb9af", 0, "110cbbe4-c26e-41b7-9d1c-015f1573eedd", "customer15@abv.bg", false, "John", "Alexandrov", false, null, "customer15@abv.bg", "customer15@abv.bg", "AQAAAAEAACcQAAAAEIhcsB7ohzqcUqR6IRcWqgHjnm1Jhzk6VRkQh7bb9t5aQD3Egp/34avPKVdv1gqyOA==", null, false, "", false, "customer15@abv.bg" },
                    { "b19bf3f9-4627-449b-ac76-641061bdca25", 0, "2f92bb4d-0919-43fd-b50a-140d2e000738", "customer0@abv.bg", false, "Jack", "Johnson", false, null, "customer0@abv.bg", "customer0@abv.bg", "AQAAAAEAACcQAAAAEERoyTCaF+cZNNmcBWNQBGHBrMTbzfG0I/VCKerGzXnDgEKVNcSx+7QbGDpvlaSACg==", null, false, "", false, "customer0@abv.bg" },
                    { "ed504eb3-6a0c-491d-9706-bd8ff8b8be43", 0, "a6a5b99e-c5bf-4345-b945-433c098fce92", "customer1@abv.bg", false, "Jane", "Johnson", false, null, "customer1@abv.bg", "customer1@abv.bg", "AQAAAAEAACcQAAAAENWSNDClPnxndHqBgP8P+yrGRXpCbYyec1550uiRexJSqS25iyj1wyGNf5uYWmIegA==", null, false, "", false, "customer1@abv.bg" },
                    { "c704630b-626a-4d9f-ac4e-b43eef7e2983", 0, "670173a8-6729-4bbd-a61e-2c5de8a7a3e9", "customer2@abv.bg", false, "Jane", "Alexandrov", false, null, "customer2@abv.bg", "customer2@abv.bg", "AQAAAAEAACcQAAAAEJ3AdvmPe7ArDPVHRmArWTGJKg7NkOm/3726EkzS/TZhgc6oUpudC4CIFZc+WnJJjg==", null, false, "", false, "customer2@abv.bg" },
                    { "734f601c-0c15-4f7e-84c3-31bd23a29e60", 0, "7518720b-ad6a-4200-99e1-6da8fa5bb0d7", "customer3@abv.bg", false, "Jane", "Johnson", false, null, "customer3@abv.bg", "customer3@abv.bg", "AQAAAAEAACcQAAAAEBas2PCQc0bGakd2L6aCfgtp1C+wVv3mkUxZmUbmF4yU5EPY293UtdGn1TWRu5XGiw==", null, false, "", false, "customer3@abv.bg" },
                    { "40a56206-3e26-439a-8837-2ee99244e1a1", 0, "11316ad6-f01c-4ee0-a7a8-b8b6c9b839fb", "customer4@abv.bg", false, "John", "Alexandrov", false, null, "customer4@abv.bg", "customer4@abv.bg", "AQAAAAEAACcQAAAAEE4EXJ/Bf9x8/w0kUMwvgJtsQZ3m9W2F1A842/JdTWD4YUH9tSOEWXrb7CYekBcdRQ==", null, false, "", false, "customer4@abv.bg" },
                    { "b8fda415-72d7-4153-8c71-a59457caa7c6", 0, "d4b0556c-9991-4daa-bfa8-9dffdbda3ff6", "customer5@abv.bg", false, "Jane", "Alexandrov", false, null, "customer5@abv.bg", "customer5@abv.bg", "AQAAAAEAACcQAAAAELtADLYDmfcYWGKncSEptHSFD98mOcRMuAHkfBZfIW6RzHBAx8bYeI4duCvW+rrATQ==", null, false, "", false, "customer5@abv.bg" },
                    { "2e788cc8-9d8c-4f28-bd18-e51ec4fe011a", 0, "5e5779b0-e0e6-411e-af5f-2ad19584abf5", "customer6@abv.bg", false, "Jane", "Johnson", false, null, "customer6@abv.bg", "customer6@abv.bg", "AQAAAAEAACcQAAAAEN7tQr30nALVroKHqUeAPg+bBtTUEch31+gYZQWGVpMKsE83sp/bdx4djVfy+MLs3Q==", null, false, "", false, "customer6@abv.bg" },
                    { "bae7e705-67bf-4d01-ab0a-1dd6e9717388", 0, "968462d4-85d8-4eaa-97dd-2bda60e7b9a3", "customer7@abv.bg", false, "Jack", "Alexandrov", false, null, "customer7@abv.bg", "customer7@abv.bg", "AQAAAAEAACcQAAAAEJt3YWw4/olVwhhhXdI24I12FUODu1f1gmFs0FT1atcUK8rkKt9kP/jjMKQLS/xZZQ==", null, false, "", false, "customer7@abv.bg" },
                    { "d6bdd860-8277-44b9-8549-314ed4ff7323", 0, "3f142562-0332-4867-af2c-7fb2428261c4", "customer8@abv.bg", false, "Jack", "Alexandrov", false, null, "customer8@abv.bg", "customer8@abv.bg", "AQAAAAEAACcQAAAAEEDo2VN1WKexSHHbdSgyWugA66/HZHsMLxP1VwYBSgoNEHRrQYRRzeJJyGh3yjVtLA==", null, false, "", false, "customer8@abv.bg" },
                    { "a65de10f-73cc-4408-8390-9e6df5fea499", 0, "a6b58ab6-bcb0-491e-a576-783cadcc6aca", "customer9@abv.bg", false, "Jane", "Johnson", false, null, "customer9@abv.bg", "customer9@abv.bg", "AQAAAAEAACcQAAAAELARSvkRtCaWHKQFFE7hlwpubyj91R9/1HvjMzl/qmQSfI5QJ/ikoLcxIhH4jz+csw==", null, false, "", false, "customer9@abv.bg" },
                    { "30bbcbf3-42cc-46a3-9a25-939b805f3215", 0, "28d68ef1-9669-43f6-8c6d-f276dd7d9d35", "customer10@abv.bg", false, "John", "Alexandrov", false, null, "customer10@abv.bg", "customer10@abv.bg", "AQAAAAEAACcQAAAAELgKKQkw0YUp+WXFh63qGu8RpugQrfPvR5ZRC9wRFP0XhsR79/aROcsjON4fW0Tmcw==", null, false, "", false, "customer10@abv.bg" },
                    { "d5f96247-2228-4b06-9e4e-bccffdf2c98c", 0, "084609dd-4a60-4e1d-b984-aefefcd367bb", "customer11@abv.bg", false, "Jane", "Johnson", false, null, "customer11@abv.bg", "customer11@abv.bg", "AQAAAAEAACcQAAAAENt0mTZewQXXjhE7XkwGVLq7ArKNAfQg6lPc1d6NG3htAFAZ5mmhGKRDiDQibj41EA==", null, false, "", false, "customer11@abv.bg" },
                    { "31ebe926-3637-4e4b-90fc-ee872387f141", 0, "384e458c-6d80-411c-83da-54ec7b27e389", "customer12@abv.bg", false, "Jane", "Alexandrov", false, null, "customer12@abv.bg", "customer12@abv.bg", "AQAAAAEAACcQAAAAEEQJNFWTeljJ3DHD8m2ZaY5R5OANmxEPv0RG4+QTkvCjPwgn8Ai7R5BZUPiAh2kztQ==", null, false, "", false, "customer12@abv.bg" },
                    { "5ac7fc41-d766-4a2e-b72a-93893da9c108", 0, "1c565adc-49d7-44b7-a243-9e4517fbe297", "customer13@abv.bg", false, "Alex", "Alexandrov", false, null, "customer13@abv.bg", "customer13@abv.bg", "AQAAAAEAACcQAAAAECbNgbkSbWBbmEMwflXirOnddbJexZAKBrkt1mGqDxewHA2x4yrX/ufHX2aO3ypQUA==", null, false, "", false, "customer13@abv.bg" },
                    { "f7b386b2-31eb-4f06-8c78-2ab2e53dff4d", 0, "ec22bf3a-63b2-42d6-b16f-9be0a0ada7de", "customer14@abv.bg", false, "Jane", "Alexandrov", false, null, "customer14@abv.bg", "customer14@abv.bg", "AQAAAAEAACcQAAAAEI2I17WFkkJHKw35Qi5tSrHgtPpiTDHIocZ5/96kyORYu3bm1gULBbHP3vw52oy5cg==", null, false, "", false, "customer14@abv.bg" },
                    { "89e6fc54-522f-414c-94b8-e13ed875dd3e", 0, "076613ef-eb70-4b66-ae3b-f14848191f65", "customer16@abv.bg", false, "John", "Johnson", false, null, "customer16@abv.bg", "customer16@abv.bg", "AQAAAAEAACcQAAAAEOCIa1JJAO6FT9a4zpDwmj2aPDew9m7CmEESvTy2p4gdUpX3ABPLUvjsBNm0wziZHw==", null, false, "", false, "customer16@abv.bg" },
                    { "05c7eede-7046-4cc5-9f28-bdef5a0e9384", 0, "d40ae66f-5f83-4746-89ee-0b6eba4b0293", "customer35@abv.bg", false, "Jane", "Johnson", false, null, "customer35@abv.bg", "customer35@abv.bg", "AQAAAAEAACcQAAAAEKy0o6BiqqGvKtcngDz3c0KLuyY7K/fho7FFPRyJgb8EnI3XAX4xJ1zgjZ4m0HjOtw==", null, false, "", false, "customer35@abv.bg" },
                    { "cdec4ded-ebf1-4ca1-b0dd-524317cdb2b7", 0, "6ddc8723-89b7-4e7a-a5b6-b18314a59ec3", "customer36@abv.bg", false, "John", "Johnson", false, null, "customer36@abv.bg", "customer36@abv.bg", "AQAAAAEAACcQAAAAEOmgJ7G9bI3c6mwHbxvbSCY1U+5C5uQ8pPIqhVwLS523XaGmJcdJhTzQOu8GZSgGTw==", null, false, "", false, "customer36@abv.bg" },
                    { "bfebf995-0034-4b3d-a32a-f036f8ac9d50", 0, "a8a95b53-491b-4c2a-8ccc-bf104ad862a8", "customer37@abv.bg", false, "Alex", "Alexandrov", false, null, "customer37@abv.bg", "customer37@abv.bg", "AQAAAAEAACcQAAAAEK9zNKYaVnYb6En2y/01tSojDwcF9Rd5IQWf0PHHBYaiZftkxpwJWWaxLU5EgPdFbQ==", null, false, "", false, "customer37@abv.bg" },
                    { "0f5a6d46-12cc-4e9a-ac21-3635a4be5491", 0, "d4adc941-3e30-4a2d-a9b4-0378fd5bff5d", "customer58@abv.bg", false, "John", "Alexandrov", false, null, "customer58@abv.bg", "customer58@abv.bg", "AQAAAAEAACcQAAAAEJr8aFqf4y93yDTxo0xunfCJ+MBUb5nJBT6y6bjH07i8ccbNapLfy12tBixWr2Lb5Q==", null, false, "", false, "customer58@abv.bg" },
                    { "0c7c0b35-81f1-4daf-999e-e7025c2799e0", 0, "a4963d96-29b0-403e-a769-e2d3b1495d47", "customer59@abv.bg", false, "John", "Johnson", false, null, "customer59@abv.bg", "customer59@abv.bg", "AQAAAAEAACcQAAAAEDAUCmsmUTKYLbbQ8HHjLzXUK4gEzCHwLEg+EYrDxDRdFPeW0YFtxJvtPR1QK+4Ehw==", null, false, "", false, "customer59@abv.bg" },
                    { "e3c55ad5-3bbb-47ea-8f8b-fc476fdafc01", 0, "80cf402c-c542-47de-afb0-ad18c341990b", "customer60@abv.bg", false, "Alex", "Johnson", false, null, "customer60@abv.bg", "customer60@abv.bg", "AQAAAAEAACcQAAAAEDvBlhfX1PbXpaua2AmPJvhaZaFFI2SgLrBHZOCbTp+YI8r3tMgIEAz9MqHrraGIcw==", null, false, "", false, "customer60@abv.bg" },
                    { "e2dd9ff5-793d-4a1c-b646-c395e8af10b6", 0, "deaf64b9-6b06-477a-aef9-47702a90c1df", "customer61@abv.bg", false, "Jack", "Alexandrov", false, null, "customer61@abv.bg", "customer61@abv.bg", "AQAAAAEAACcQAAAAEM67qAZLeC/Jg87CDZzGLaKDqkP/RO8+hi1aYxvajQyb//bHcwoEMtYBRjK5ZXVlhw==", null, false, "", false, "customer61@abv.bg" },
                    { "c25adfd4-a2f4-4dc9-b355-0d343e46531d", 0, "fdda18bc-0c3d-45ca-b362-3adbe416f761", "customer62@abv.bg", false, "Alex", "Alexandrov", false, null, "customer62@abv.bg", "customer62@abv.bg", "AQAAAAEAACcQAAAAENSZitkx1ezpQ1TvAOjbFc4TC5nK78u3OYMjHqbUM+FZTcXnG/1gm1JRssYdRPAuWQ==", null, false, "", false, "customer62@abv.bg" },
                    { "d83da919-fa32-4274-8ccb-e8f21d830dec", 0, "fbe4dc37-d15e-4a36-af27-09a95fd88312", "customer63@abv.bg", false, "Jack", "Alexandrov", false, null, "customer63@abv.bg", "customer63@abv.bg", "AQAAAAEAACcQAAAAEFW91yFsJ172cxdxBgkDFkr4rMjf1iTNCuQasClsJ4lYEO3604BLXAQ1dwsdedwrog==", null, false, "", false, "customer63@abv.bg" },
                    { "6476ecde-a2c0-4413-a447-5d6da9bfc8ac", 0, "661e0d4b-a5e8-486e-b677-240711fb4bb4", "customer64@abv.bg", false, "Alex", "Johnson", false, null, "customer64@abv.bg", "customer64@abv.bg", "AQAAAAEAACcQAAAAEKlcZhEivohx2J/Udwkw2hSifriW8g4Lsm15C2/AyH/p/g+guFQzg2Mn4LWCWJK4pQ==", null, false, "", false, "customer64@abv.bg" },
                    { "3bcec75a-ab0b-4cd2-86f9-cd3c9a1d40fc", 0, "7b4a22a0-b9a4-4031-b51d-a3129d6d437b", "customer65@abv.bg", false, "John", "Johnson", false, null, "customer65@abv.bg", "customer65@abv.bg", "AQAAAAEAACcQAAAAEOEOnwAltfOUOWqRTHkxVeAxn0ThXIP5wovdW/+47INvuirSVk079b+5yoxq78NX/Q==", null, false, "", false, "customer65@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "69990512-73d1-4c07-84aa-62394fece7b8", 0, "52b07014-6609-4a1d-aa1d-095764978944", "customer66@abv.bg", false, "Alex", "Johnson", false, null, "customer66@abv.bg", "customer66@abv.bg", "AQAAAAEAACcQAAAAEInla9E0sMWMqF1Xb6PqNDhYFzv76rYGmPsk//iGhmMayvApu+EhzUQrO4bcJksSrQ==", null, false, "", false, "customer66@abv.bg" },
                    { "9e2233ec-3d19-4fbe-bfe2-98552790d467", 0, "d1759525-e4ea-4e0e-8d8b-c08636e3ead0", "customer67@abv.bg", false, "Alex", "Alexandrov", false, null, "customer67@abv.bg", "customer67@abv.bg", "AQAAAAEAACcQAAAAEGzKAWmjTsMoGL/fRCcutE2UqxkkjpDBNo4V1x9jFpakDaAm6bz/Yy3FT6Ai15E2rw==", null, false, "", false, "customer67@abv.bg" },
                    { "42e06c60-c75d-431e-8420-1de1d13ae00a", 0, "bbcf006a-aa53-43b2-9bfd-62280c440585", "customer68@abv.bg", false, "Jane", "Johnson", false, null, "customer68@abv.bg", "customer68@abv.bg", "AQAAAAEAACcQAAAAEFpWfSdbnVNRgPeggCkyy4aAzzFb0g6dO54FRrQcKS0hdmXQxD/eS8GzWjpEhYwywg==", null, false, "", false, "customer68@abv.bg" },
                    { "19f70e5c-072e-4d75-a6f2-2b5a5163aa16", 0, "3dfcd575-805b-4b08-a9e2-646e3ea74d3a", "customer69@abv.bg", false, "Jane", "Johnson", false, null, "customer69@abv.bg", "customer69@abv.bg", "AQAAAAEAACcQAAAAEKJwrBMBmVFjQLFnC0EDndXSnzpjURA48X1zqFXYADAcUL1cTMDkZR85W36Ac0lyCw==", null, false, "", false, "customer69@abv.bg" },
                    { "f30be200-cde2-43d5-947e-64729128b8b0", 0, "488cde67-9096-4cc2-9b2f-7ac59101e688", "customer70@abv.bg", false, "Jane", "Johnson", false, null, "customer70@abv.bg", "customer70@abv.bg", "AQAAAAEAACcQAAAAEF31t9JuhvQMZdxCTvI/kZkC4afm/qS1KsGBMwpH5MiGpoLJHvKp4gk0Kkme/hLWnA==", null, false, "", false, "customer70@abv.bg" },
                    { "a1100055-9be1-4c36-a560-de163fa0ea90", 0, "ebc3906b-c8e9-449c-ba31-02e88ae166b9", "customer71@abv.bg", false, "Alex", "Johnson", false, null, "customer71@abv.bg", "customer71@abv.bg", "AQAAAAEAACcQAAAAEJJKQpj+LU9+xyMhOMS2Xy6qdHG9Ejj2TcE5WkYpm6jZEs6Y+lRAB8voO/OdawHzTw==", null, false, "", false, "customer71@abv.bg" },
                    { "62a4dc1d-ede1-4324-b59b-3fa95a319d44", 0, "0d3a9ef5-f641-47fa-90f8-c72b748751ea", "customer72@abv.bg", false, "Alex", "Alexandrov", false, null, "customer72@abv.bg", "customer72@abv.bg", "AQAAAAEAACcQAAAAEKEGlyhHYugDOUMue8QQlKenjK351pyjPJaD2fUmO8/+fexlmGwqj0pccvL/VR4o0w==", null, false, "", false, "customer72@abv.bg" },
                    { "663c67ea-43f6-41db-90ab-2bfe0b78391c", 0, "e533a56c-2470-4144-9822-500d666ea74e", "customer57@abv.bg", false, "John", "Alexandrov", false, null, "customer57@abv.bg", "customer57@abv.bg", "AQAAAAEAACcQAAAAEJVEIEa+0XlrDzdLgrv/bUxNiIQjdo4vmowTMOTCIqTZxxMQAfbvpgaJBoQoeUJkzA==", null, false, "", false, "customer57@abv.bg" },
                    { "1e4d1251-f721-412c-9d3a-f3554ca0c13e", 0, "b181887c-c258-41d2-842a-3791196989da", "customer56@abv.bg", false, "Alex", "Johnson", false, null, "customer56@abv.bg", "customer56@abv.bg", "AQAAAAEAACcQAAAAECn6AzrqursGuOm3rQ7k6b8LH8Mkbwhkr+qRvpYw+s90tUep6teY8O8hebDs1ZpuCg==", null, false, "", false, "customer56@abv.bg" },
                    { "d6f2c2c8-ffbc-42a5-82dc-1617e925f690", 0, "6b264494-fdbd-48aa-8c3f-121132a30779", "customer55@abv.bg", false, "Jack", "Johnson", false, null, "customer55@abv.bg", "customer55@abv.bg", "AQAAAAEAACcQAAAAEKEbxZyrQezf2Fb2MOAqpwsMTjCqOyUDTntfo7Etnyk3wrci2sjkBCemPhRfitOqaQ==", null, false, "", false, "customer55@abv.bg" },
                    { "f6223436-a8a6-4046-a692-fae46bc97b11", 0, "0afc584c-3ef2-4f70-922a-2d84a5ca05af", "customer54@abv.bg", false, "Jane", "Johnson", false, null, "customer54@abv.bg", "customer54@abv.bg", "AQAAAAEAACcQAAAAEF/pHXHjUKd4UvKfNxtxuvOEiWr6sbWI2ggZcvpDqPHMakdtTHiyW7uLXVtw/Gb4uw==", null, false, "", false, "customer54@abv.bg" },
                    { "90c0143f-9810-4487-97c4-16c5c568a042", 0, "9ad515fa-6ef1-4092-8684-d8bb631ef2e2", "customer38@abv.bg", false, "Jane", "Alexandrov", false, null, "customer38@abv.bg", "customer38@abv.bg", "AQAAAAEAACcQAAAAEO2Ry2yaUTF3/2jhWYDzqqqVeHoUxcBzeXpLHKhRk1nBjFFpYFRpLyB9p7Hek5sYJw==", null, false, "", false, "customer38@abv.bg" },
                    { "83e18efd-ecdf-423f-a79c-49e6ba34f709", 0, "832cc0a9-0bda-40fd-a546-f769c1852499", "customer39@abv.bg", false, "Jane", "Johnson", false, null, "customer39@abv.bg", "customer39@abv.bg", "AQAAAAEAACcQAAAAEFld+/8QM/3VbAKY57eUZcyE1cWcR994xH85b+atI0D7+mN7DA8oLK+0XOqiCTOWVA==", null, false, "", false, "customer39@abv.bg" },
                    { "f2b6c581-c96b-41c5-bdbb-2c9d34306792", 0, "9a3964b9-70eb-4c93-a159-b20a141bdb42", "customer40@abv.bg", false, "Jack", "Alexandrov", false, null, "customer40@abv.bg", "customer40@abv.bg", "AQAAAAEAACcQAAAAEOW+NQDTfA7OdyBXFspuhmWYB8n1nVFVJELQx0yH52rFQ0JafnXvUtGX3VvkBnRvrw==", null, false, "", false, "customer40@abv.bg" },
                    { "2a20da90-9168-4dcc-9d19-bfce22611cd5", 0, "86e32503-850d-4b5f-9823-3a195bb180c8", "customer41@abv.bg", false, "Jack", "Johnson", false, null, "customer41@abv.bg", "customer41@abv.bg", "AQAAAAEAACcQAAAAEInJ8qGa963HqUB1yNQmUyKO7nnKIinQj1AT3Bjk5qAuduCsv32lsPpqggnGmdcnXQ==", null, false, "", false, "customer41@abv.bg" },
                    { "43acd9d4-aa73-4926-bb53-318bd6dac944", 0, "998e0b1c-782b-44c8-9df8-e0ea9f8b91d1", "customer42@abv.bg", false, "Jack", "Alexandrov", false, null, "customer42@abv.bg", "customer42@abv.bg", "AQAAAAEAACcQAAAAEA92b3JO6jRAb99ngMHBiLOPfcmB1gHwZ4xm9LNEtT9RgACZsirKI6tqN3rSOvMupA==", null, false, "", false, "customer42@abv.bg" },
                    { "499201b2-4a90-487b-9702-c7e28aa67bf0", 0, "defc41f3-3eda-46fd-85d7-944a66bb34e0", "customer43@abv.bg", false, "John", "Johnson", false, null, "customer43@abv.bg", "customer43@abv.bg", "AQAAAAEAACcQAAAAEBRkkHoo4lnhEtXTCbEFBssO5a1isoeSmC5463njacOL+FE+OjGoPXCap9v9hVu74g==", null, false, "", false, "customer43@abv.bg" },
                    { "902378f6-d8df-4a15-87c4-c8b718c46943", 0, "f5dbb1c5-1ff3-475f-9392-965eb3a379d7", "customer44@abv.bg", false, "Jane", "Alexandrov", false, null, "customer44@abv.bg", "customer44@abv.bg", "AQAAAAEAACcQAAAAEGl0JCh8j213HtUI9ppb9MQR1E9yL92maPGgspfR+hFlK8vCyV9zD5xHxIoZXFF3dw==", null, false, "", false, "customer44@abv.bg" },
                    { "9bd92fb6-f4e7-4c09-83ad-75b938181bb9", 0, "fae2d1a4-c264-4fbe-afef-b3ff2b70a385", "customer74@abv.bg", false, "John", "Johnson", false, null, "customer74@abv.bg", "customer74@abv.bg", "AQAAAAEAACcQAAAAEI6MSvetqMrlOYoIVubnQRUafIKkpU8m2T3GxD7mb0YJBDUHWNXSIoh8cLc3igPJPQ==", null, false, "", false, "customer74@abv.bg" },
                    { "b3f7c91f-1f24-47cd-a04e-123498f1ffb4", 0, "3bb4fbce-9f81-4f69-8ba7-02a2b78eae5a", "customer45@abv.bg", false, "Jack", "Johnson", false, null, "customer45@abv.bg", "customer45@abv.bg", "AQAAAAEAACcQAAAAEJeuMYZqYFLdIpiWXAdURApfgg5nByGceTg9qTSWQ1p/6EnMkPdJ9BzMiPql1gb+Mg==", null, false, "", false, "customer45@abv.bg" },
                    { "75bf046b-8540-44ff-ad0b-08a0e3419f41", 0, "c23c6725-4383-4481-b2e2-ac864d01dd3c", "customer47@abv.bg", false, "Jane", "Alexandrov", false, null, "customer47@abv.bg", "customer47@abv.bg", "AQAAAAEAACcQAAAAEAlQHti4EdeuEMxYTSLgHS6yb5/vxHnsHERQ1s6rqsF6MKCC1d7ITWiuJBIxsu5+Dg==", null, false, "", false, "customer47@abv.bg" },
                    { "93cb1a37-331c-4b1a-b9d3-5a4a0e05217d", 0, "3477ee37-ac33-45fe-a428-92ae3dfcfddd", "customer48@abv.bg", false, "Jane", "Alexandrov", false, null, "customer48@abv.bg", "customer48@abv.bg", "AQAAAAEAACcQAAAAEGVefgOFjdhXBvNLkl7wmQF/fDfzNKfvCBqJ5F0+oOi7Zj49IJPg3bLafK0z8iYb+Q==", null, false, "", false, "customer48@abv.bg" },
                    { "aed656a7-42bb-4034-990a-c58fca8e2069", 0, "6356c12a-f56d-4e74-b9a3-3a68778e48ab", "customer49@abv.bg", false, "Alex", "Alexandrov", false, null, "customer49@abv.bg", "customer49@abv.bg", "AQAAAAEAACcQAAAAEPjLXC4GTYd0viF5KTfvwPlt5pGegdWUkRj9n2Vr/lMIBd5CYnPLGY7dfYBkD9+/jw==", null, false, "", false, "customer49@abv.bg" },
                    { "92ecc3ac-ab04-42ed-95b8-a46d5b13a0da", 0, "724252fa-2b61-4454-85b0-633b81c8a2de", "customer50@abv.bg", false, "Jane", "Johnson", false, null, "customer50@abv.bg", "customer50@abv.bg", "AQAAAAEAACcQAAAAEOGy4FCdxSHpzC0raWFhLOWIaYznX/NC4SWCJGZF7yC2/qvx+SWq2wWgN3ZDkMelCQ==", null, false, "", false, "customer50@abv.bg" },
                    { "268f42a0-5656-430b-9f41-06d54a60d0da", 0, "0295eb29-f2b7-4c9d-97b7-92132d7aa965", "customer51@abv.bg", false, "John", "Johnson", false, null, "customer51@abv.bg", "customer51@abv.bg", "AQAAAAEAACcQAAAAEKvGkU7cGJZ+sV3E7h9lDMiDQubBk3+B2iZmj48GQRL/FL+Io4MWEbsv56LrtEeNbg==", null, false, "", false, "customer51@abv.bg" },
                    { "84854fc4-3c1c-4ba5-921a-228516fc8b50", 0, "56450bc2-2099-4fda-80a8-f8316540b6cd", "customer52@abv.bg", false, "Jack", "Johnson", false, null, "customer52@abv.bg", "customer52@abv.bg", "AQAAAAEAACcQAAAAELjAqxgXwVyHHDt3HN4ghb8dXPbwyeFUt10vhnpGQW8WTkHWky/2ooBP2Spfb1FuuA==", null, false, "", false, "customer52@abv.bg" },
                    { "b6a90681-cd84-4a44-a2d1-5016613c12bd", 0, "4307c5e2-0be6-421c-935b-13e610e993aa", "customer53@abv.bg", false, "John", "Johnson", false, null, "customer53@abv.bg", "customer53@abv.bg", "AQAAAAEAACcQAAAAEJeRR71CSoyOLjCabvJBT19hO7dk3PxhrPdGlDmoV5qcIgkmmM/kR4vTydbhvaxAWQ==", null, false, "", false, "customer53@abv.bg" },
                    { "3da6e3e5-91f3-4996-b345-003be05d5455", 0, "01c252f3-9cae-4072-960d-df29693bac4d", "customer46@abv.bg", false, "Jack", "Alexandrov", false, null, "customer46@abv.bg", "customer46@abv.bg", "AQAAAAEAACcQAAAAEDvQyhT9oNTE2SQHgDRAZB9t9CySpculdKhzPVo89vlHBdH0jNkUJHf/HzkdhIpTew==", null, false, "", false, "customer46@abv.bg" },
                    { "db8553ae-edf5-4678-9eb2-f5d04fee6a9a", 0, "db410d85-7192-48b4-aad5-5e39ce837eeb", "admin@abv.bg", false, "Jane", "Johnson", false, null, "admin@abv.bg", "admin@abv.bg", "AQAAAAEAACcQAAAAEEVZMk7iSxp97JGP0Cn4hvGdBgXlpRNVq0ytd7CuxMeka57G/U5veu9AKRqHy2j2hQ==", null, false, "", false, "admin@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "db8553ae-edf5-4678-9eb2-f5d04fee6a9a", "eeaa5590-9443-46d6-870f-8f16417fa61f" },
                    { "c704630b-626a-4d9f-ac4e-b43eef7e2983", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "ed504eb3-6a0c-491d-9706-bd8ff8b8be43", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "b19bf3f9-4627-449b-ac76-641061bdca25", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "d75cc932-c238-45cf-9837-96516ccba18d", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "0eeaeb88-4258-4d5b-88d0-d803eafad74d", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "04b95fb2-994f-401b-a376-8e34f021f725", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "734f601c-0c15-4f7e-84c3-31bd23a29e60", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "0c34bd6b-1cb2-495f-930a-7f89e3ce4cdb", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "4f74c5df-1ba2-43d6-adf0-78268ae19182", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "16512485-5d03-4755-aacb-eca8bec969c4", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "ffe4aa6e-0e20-4c3b-8483-b241443e9ac0", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "cdb452b3-8dc4-42f5-aae9-35e34fc12280", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "1a6ba66b-f96b-432a-964c-d9386ae19b74", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "75db636b-5d39-49c6-a511-47165049eaca", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "4529b86e-5fe0-4081-8bbd-0a7ff6137c6c", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "40a56206-3e26-439a-8837-2ee99244e1a1", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "b8fda415-72d7-4153-8c71-a59457caa7c6", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "2e788cc8-9d8c-4f28-bd18-e51ec4fe011a", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "93a91039-12c2-4876-b493-fbad6e9da0cd", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "d53f8031-c378-462c-92b0-c08d777433f0", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "6a3aaf87-d38a-4184-a9e2-06f81f5cd1f7", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "5b025639-4a4b-4b1c-8a22-20fe4ca43f82", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "5dabd3ad-a587-49d4-aa6a-f401ce398973", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "89e6fc54-522f-414c-94b8-e13ed875dd3e", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "0aa27193-ac76-4c92-bdd9-fd23e39cb9af", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "f7b386b2-31eb-4f06-8c78-2ab2e53dff4d", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "5ac7fc41-d766-4a2e-b72a-93893da9c108", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "31ebe926-3637-4e4b-90fc-ee872387f141", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "d5f96247-2228-4b06-9e4e-bccffdf2c98c", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "30bbcbf3-42cc-46a3-9a25-939b805f3215", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "a65de10f-73cc-4408-8390-9e6df5fea499", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "d6bdd860-8277-44b9-8549-314ed4ff7323", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "bae7e705-67bf-4d01-ab0a-1dd6e9717388", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "eb3175bf-0ce0-42b8-bc91-e961f5ed3185", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "3a82a1ed-6ed1-473e-afd2-876be2c24f70", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "eb1eee16-a36c-407f-a87a-be4e64f76ace", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "66ac7c71-ad4e-4ab7-bab6-9788cc8c38ea", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "0adac9c2-e448-4e26-bc8c-7b062b38b14f", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "34669351-9eac-4023-b658-e5973ae6a158", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "dcc831b4-ceb3-495c-ad12-7dd49d056f95", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "662acc08-845f-40e8-a110-2e2025b014ba", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "3b54a9ec-f3ac-4adb-ae0f-d4d12357cbc6", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "4b4c9518-ac97-470c-8833-2c9f5b90a7b3", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "2003286a-6c6b-4e75-8c52-f039d230591a", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "b717c2e9-3271-4228-873e-bdd2890c5a0e", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "935a8b72-9be4-4f8c-9870-ee73b23b4735", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "5acdee34-7c8e-457c-ae57-824ebfa63067", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "ef8a84c9-d2c6-45a8-8dc6-c4db482683db", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "969172aa-0d6a-427e-b13d-c39e52c0ae92", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "c18febfe-f8bc-447b-95be-cd76b0d8229d", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "0345c656-a63b-4816-bd28-d6e72a36d0a0", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "eb81855b-060e-4f06-a714-5feec172402b", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "49a70cc3-4635-4fc5-8ae0-813ee2238214", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "9a616128-e9fa-4eee-a151-c64375e4e195", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "1cd18ee8-6db8-4ed0-a762-0471114a2027", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "c8e3e307-5689-42f7-8139-8e0573013d19", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "33a9a829-dccb-4af4-9b0a-fde3bc323255", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "dd5c3a58-456f-4b4f-a0b1-123461b861c2", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "38624d16-ad64-426d-9087-59f0a6232068", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "2ecd6e0c-a1ef-4568-af65-319c8d88d4fc", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "7c6e2c93-c6bf-4cd0-ab7c-4da59c8f210f", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "ba1b2379-3e57-4eae-a0be-b2c88fbe67aa", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "f6453e75-6bc1-421b-8958-3330946eca0a", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "bdd8ee75-a4ec-4244-ad4a-f48ffe42fdae", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "d641258a-fd7a-4e8a-8810-fa2a9481f9ac", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "323cfc4e-deaa-4478-8922-4f9b1111e3a5", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "86449d5c-80c9-41e6-8673-068253347120", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "20fc2d6d-d70a-4b33-a123-bcf1416a4d88", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "117714be-4af0-430d-90a1-f43319825d85", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "5d3bd496-6a31-4323-baa8-802a423faf45", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "b65add3e-6930-4a11-b69e-c72412434a28", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "92b407b6-e617-46df-b757-5d4c4de0c5c3", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "850e61dd-47e0-4ae2-bf23-461cea5b3489", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "9b285dc2-1e7c-45f4-9779-a314ff8f7021", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "76ac581e-3156-42c0-a30b-c7deab7ed9d8", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "2230b57d-5172-4bfc-923a-e8488dd8a60a", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "c876b1f5-1cf8-476a-ae45-e6b38ea3b426", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "5c3e9855-4db4-4649-a23f-b4e86e25fd00", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "8bda9135-9403-4163-b414-df71fda17612", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "9bd92fb6-f4e7-4c09-83ad-75b938181bb9", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "13785b1b-81b3-44f6-a5d8-63c20b0863dc", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "62a4dc1d-ede1-4324-b59b-3fa95a319d44", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "a1100055-9be1-4c36-a560-de163fa0ea90", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "f30be200-cde2-43d5-947e-64729128b8b0", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "19f70e5c-072e-4d75-a6f2-2b5a5163aa16", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "42e06c60-c75d-431e-8420-1de1d13ae00a", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "9e2233ec-3d19-4fbe-bfe2-98552790d467", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "69990512-73d1-4c07-84aa-62394fece7b8", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "3bcec75a-ab0b-4cd2-86f9-cd3c9a1d40fc", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "6476ecde-a2c0-4413-a447-5d6da9bfc8ac", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "82280915-4ba3-417d-8457-38e7e438920b", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "d83da919-fa32-4274-8ccb-e8f21d830dec", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "ff017848-24b2-4075-9f82-c3be92e556ed", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "c3660765-6c34-406a-89f4-cffd346688c2", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "d62182ee-d7c5-4f7b-9c7f-3821df14646c", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "5207656a-c474-4684-a3e8-294435bde626", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "96dd5af8-0960-4e24-90b9-7f27c34e586e", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "92c19c5d-3294-4d48-bb1b-28d7a8513f02", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "6da87c28-6735-4d8d-897e-ea3415062319", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "fe6ad777-a74d-4302-a246-e34f904531c2", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "753c690a-5616-443d-93d2-52ac191ba59e", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "86bfd4c1-a904-4cbc-ad7a-293ee3b994c3", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "ec070840-565d-4b7b-bbdc-6e808f1410c4", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "57aa6924-5b2a-4fcd-9d58-83cb1dc0d0f8", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "e374030e-d107-423f-a533-2a569675587a", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "0f7cd778-935c-4ecf-9f4d-832b07492a0e", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "d4c3a173-4a85-46e1-af15-7cac793a802a", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "19799b68-744a-43fd-b23f-88d40dc7c303", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "f20f33d3-2930-49d0-8ce8-89698fc75267", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "bd14e399-40ae-4a7d-8cce-081250f1dae8", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "8bd20eed-b102-4887-85bb-1d40ced1d0ed", "3b875e8f-07c9-4bf3-89b6-80e498e99346" },
                    { "c25adfd4-a2f4-4dc9-b355-0d343e46531d", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "e3c55ad5-3bbb-47ea-8f8b-fc476fdafc01", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "f2b6c581-c96b-41c5-bdbb-2c9d34306792", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "83e18efd-ecdf-423f-a79c-49e6ba34f709", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "90c0143f-9810-4487-97c4-16c5c568a042", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "bfebf995-0034-4b3d-a32a-f036f8ac9d50", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "cdec4ded-ebf1-4ca1-b0dd-524317cdb2b7", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "05c7eede-7046-4cc5-9f28-bdef5a0e9384", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "dce64fb2-d8a4-44fd-952e-09bf3c1d1af3", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "ebd39e5d-17df-4af2-bcb1-a2d40d5cec43", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "7b8872a4-99d3-46ce-bef2-b11151112060", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "34d6c333-afe9-48f3-b1b4-de40aae089c5", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "8405e16e-9e70-4e35-980d-495216ea4342", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "f95950f1-d541-44a7-94a7-5e307cd6712b", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "af8d30e3-8e78-4132-89ab-cbd05291cd66", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "7d3d79c2-221c-41d6-8689-9b51ea7c2ad2", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "b5ce5e52-082a-4733-8a7f-0f25bf8f9860", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "2a20da90-9168-4dcc-9d19-bfce22611cd5", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "e2dd9ff5-793d-4a1c-b646-c395e8af10b6", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "43acd9d4-aa73-4926-bb53-318bd6dac944", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "902378f6-d8df-4a15-87c4-c8b718c46943", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "0c7c0b35-81f1-4daf-999e-e7025c2799e0", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "0f5a6d46-12cc-4e9a-ac21-3635a4be5491", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "663c67ea-43f6-41db-90ab-2bfe0b78391c", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "1e4d1251-f721-412c-9d3a-f3554ca0c13e", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "d6f2c2c8-ffbc-42a5-82dc-1617e925f690", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "f6223436-a8a6-4046-a692-fae46bc97b11", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "b6a90681-cd84-4a44-a2d1-5016613c12bd", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "84854fc4-3c1c-4ba5-921a-228516fc8b50", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "268f42a0-5656-430b-9f41-06d54a60d0da", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "92ecc3ac-ab04-42ed-95b8-a46d5b13a0da", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "aed656a7-42bb-4034-990a-c58fca8e2069", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "93cb1a37-331c-4b1a-b9d3-5a4a0e05217d", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "75bf046b-8540-44ff-ad0b-08a0e3419f41", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "3da6e3e5-91f3-4996-b345-003be05d5455", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "b3f7c91f-1f24-47cd-a04e-123498f1ffb4", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "499201b2-4a90-487b-9702-c7e28aa67bf0", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "91b819e9-5471-4c25-91c9-17a790be1831", "323310ee-8c7d-4287-96fe-e7b66edc7836" },
                    { "07e9b088-93d1-4008-9895-dc9eb1fa8511", "323310ee-8c7d-4287-96fe-e7b66edc7836" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "UserId" },
                values: new object[,]
                {
                    { "d22c276a-f979-411f-b173-058e21e97d6e", "Street 142", "9bd92fb6-f4e7-4c09-83ad-75b938181bb9" },
                    { "c9303c68-599c-41ec-9b5d-dd7189b8546a", "Street 407", "84854fc4-3c1c-4ba5-921a-228516fc8b50" },
                    { "1819ce13-fa0e-4317-9892-fe662749d6a4", "Street 174", "268f42a0-5656-430b-9f41-06d54a60d0da" },
                    { "6b1d7fff-cf70-4408-bb4e-1d55d4b77bea", "Street 59", "92ecc3ac-ab04-42ed-95b8-a46d5b13a0da" },
                    { "0e73a2d9-5595-4705-95eb-90dc9e491f3b", "Street 285", "aed656a7-42bb-4034-990a-c58fca8e2069" },
                    { "97617101-69a4-460e-9857-60a612b6ca2e", "Street 318", "93cb1a37-331c-4b1a-b9d3-5a4a0e05217d" },
                    { "3cb84adc-799c-483b-b198-8a09111b696a", "Street 227", "75bf046b-8540-44ff-ad0b-08a0e3419f41" },
                    { "51422af3-99df-47fa-ad41-1cb899ed2b93", "Street 363", "b6a90681-cd84-4a44-a2d1-5016613c12bd" },
                    { "e311b1c5-0bac-4cd1-a1f0-f04725f4cf62", "Street 162", "3da6e3e5-91f3-4996-b345-003be05d5455" },
                    { "b389babe-c9a5-4ecb-ae1e-2db04e518c76", "Street 367", "902378f6-d8df-4a15-87c4-c8b718c46943" },
                    { "69d99a6b-7382-4168-8743-0dc1b9628813", "Street 81", "499201b2-4a90-487b-9702-c7e28aa67bf0" },
                    { "fa3cb703-5144-4385-9a3b-6b709474856a", "Street 381", "43acd9d4-aa73-4926-bb53-318bd6dac944" },
                    { "5ed7babf-7d9f-42ca-8e6f-296c1fb67b7d", "Street 284", "2a20da90-9168-4dcc-9d19-bfce22611cd5" },
                    { "f7d518bb-010b-463b-8918-ec89050a9207", "Street 353", "f2b6c581-c96b-41c5-bdbb-2c9d34306792" },
                    { "6ee5f49e-501f-42f6-9686-c78a2e84689f", "Street 212", "83e18efd-ecdf-423f-a79c-49e6ba34f709" },
                    { "aed49bca-b612-4677-85ad-23fb82cd5ec3", "Street 43", "b3f7c91f-1f24-47cd-a04e-123498f1ffb4" },
                    { "0eb6f9f4-f409-4e80-abe5-5652ca1ca891", "Street 382", "f6223436-a8a6-4046-a692-fae46bc97b11" },
                    { "f470d2d9-ea24-4bf7-9340-7f27d0164863", "Street 57", "d6f2c2c8-ffbc-42a5-82dc-1617e925f690" },
                    { "55def284-1c8e-435d-bafb-6cbbfe83ab19", "Street 173", "1e4d1251-f721-412c-9d3a-f3554ca0c13e" },
                    { "ec9c4cb3-04c8-4e97-89e5-d7498b14e525", "Street 232", "a1100055-9be1-4c36-a560-de163fa0ea90" },
                    { "492493ae-7edc-4d82-bc65-5df36f92255d", "Street 79", "f30be200-cde2-43d5-947e-64729128b8b0" },
                    { "e0f5b0ca-9520-421c-a7d8-673f663fccb4", "Street 353", "19f70e5c-072e-4d75-a6f2-2b5a5163aa16" },
                    { "07a99783-9743-46dd-8a45-669f67657cdf", "Street 157", "42e06c60-c75d-431e-8420-1de1d13ae00a" },
                    { "8156af63-dc95-4d55-b9d3-8d7f0d48bb45", "Street 143", "9e2233ec-3d19-4fbe-bfe2-98552790d467" },
                    { "74b423bf-c52f-492b-bef0-8e36109c0566", "Street 38", "69990512-73d1-4c07-84aa-62394fece7b8" },
                    { "ee99ad15-e419-4c8c-a9bb-a4d6035dd821", "Street 37", "3bcec75a-ab0b-4cd2-86f9-cd3c9a1d40fc" },
                    { "d6f9df2c-6f3e-46c2-9b1a-e2bd743ecaf4", "Street 222", "6476ecde-a2c0-4413-a447-5d6da9bfc8ac" },
                    { "bb5f4337-6e74-46c0-8434-8d5c86274a58", "Street 94", "d83da919-fa32-4274-8ccb-e8f21d830dec" },
                    { "58e284c6-ea8a-440a-bb5d-377628c7faa0", "Street 164", "c25adfd4-a2f4-4dc9-b355-0d343e46531d" },
                    { "1b8ff9bc-a814-4fb9-9af5-7f22bae231b6", "Street 322", "e2dd9ff5-793d-4a1c-b646-c395e8af10b6" },
                    { "f721171a-541a-424d-ad8b-4178ba3b95f1", "Street 135", "e3c55ad5-3bbb-47ea-8f8b-fc476fdafc01" },
                    { "f637d677-2dc4-4b89-a55c-3d66ae45c731", "Street 55", "0c7c0b35-81f1-4daf-999e-e7025c2799e0" },
                    { "80d5673b-be81-458b-9997-01e8da204b2a", "Street 120", "0f5a6d46-12cc-4e9a-ac21-3635a4be5491" },
                    { "0eb016b0-3241-4ff4-9bd5-a68b375d17eb", "Street 128", "663c67ea-43f6-41db-90ab-2bfe0b78391c" },
                    { "bae9ac03-7cfa-44ce-909c-1e99b812b36a", "Street 276", "90c0143f-9810-4487-97c4-16c5c568a042" },
                    { "f1210dfa-3c6e-46e6-90d6-3900dfe35bde", "Street 406", "bfebf995-0034-4b3d-a32a-f036f8ac9d50" },
                    { "4a506881-8e1b-4620-af62-57b1622d8298", "Street 49", "cdec4ded-ebf1-4ca1-b0dd-524317cdb2b7" },
                    { "f3a8c890-2a50-4422-8943-31ade6c4b9a6", "Street 208", "05c7eede-7046-4cc5-9f28-bdef5a0e9384" },
                    { "d6b8b81a-a0be-4029-af36-5834412e6789", "Street 128", "0aa27193-ac76-4c92-bdd9-fd23e39cb9af" },
                    { "92c7a56f-8b9d-49eb-9644-3f5ce180a034", "Street 111", "f7b386b2-31eb-4f06-8c78-2ab2e53dff4d" },
                    { "ff94b565-8a71-40e7-90ff-d06de8d526bb", "Street 412", "5ac7fc41-d766-4a2e-b72a-93893da9c108" },
                    { "b9d6cc2a-2f1c-4479-9f6c-37f8bbb10d60", "Street 138", "31ebe926-3637-4e4b-90fc-ee872387f141" },
                    { "c484427a-3595-4a74-ae92-08eac35d84ed", "Street 111", "d5f96247-2228-4b06-9e4e-bccffdf2c98c" },
                    { "f8dc96ae-9a52-4baa-aa22-e032f706fb98", "Street 129", "30bbcbf3-42cc-46a3-9a25-939b805f3215" },
                    { "65b36521-068f-4a67-abcf-640163743a1e", "Street 170", "a65de10f-73cc-4408-8390-9e6df5fea499" },
                    { "02321b09-c1fa-4efd-9427-6fe45da2be2b", "Street 143", "d6bdd860-8277-44b9-8549-314ed4ff7323" },
                    { "d1a45cb7-e1f9-4418-a0d8-bdf93270f920", "Street 411", "bae7e705-67bf-4d01-ab0a-1dd6e9717388" },
                    { "d518425e-3632-4379-8457-9ec380ff83cf", "Street 379", "2e788cc8-9d8c-4f28-bd18-e51ec4fe011a" },
                    { "a273aa92-9498-4cb2-a9ef-adf49f11645a", "Street 91", "b8fda415-72d7-4153-8c71-a59457caa7c6" },
                    { "9afb54a4-9527-4ca8-bfbe-ea5b5a627f9f", "Street 333", "40a56206-3e26-439a-8837-2ee99244e1a1" },
                    { "2af3f653-7449-4924-a971-233139a1eae1", "Street 391", "734f601c-0c15-4f7e-84c3-31bd23a29e60" },
                    { "ad7331a3-2382-498a-803e-f32db707eacc", "Street 436", "c704630b-626a-4d9f-ac4e-b43eef7e2983" },
                    { "5e12ddf1-c74f-45e1-8f3a-37aafd519801", "Street 182", "ed504eb3-6a0c-491d-9706-bd8ff8b8be43" },
                    { "9b77fb31-db62-4775-9c70-3c2bafc51d3d", "Street 189", "89e6fc54-522f-414c-94b8-e13ed875dd3e" },
                    { "a23e1f01-ff3f-4b55-bdbe-4dacd767387b", "Street 303", "62a4dc1d-ede1-4324-b59b-3fa95a319d44" },
                    { "9163111b-3550-4d9f-83f5-45ebac908aa3", "Street 130", "5dabd3ad-a587-49d4-aa6a-f401ce398973" },
                    { "18037db4-2d0b-4486-8c1f-e0ebc5cb872f", "Street 46", "6a3aaf87-d38a-4184-a9e2-06f81f5cd1f7" },
                    { "1eee7080-7acf-4c00-bbe5-1c8d31224b3e", "Street 256", "dce64fb2-d8a4-44fd-952e-09bf3c1d1af3" },
                    { "47116a44-8ec3-472f-9308-cc095b703ad3", "Street 444", "ebd39e5d-17df-4af2-bcb1-a2d40d5cec43" },
                    { "14419880-20f0-4d88-b77e-b4340440cc0d", "Street 73", "7b8872a4-99d3-46ce-bef2-b11151112060" },
                    { "79a53a9c-bcba-47d1-be58-44af2fac799b", "Street 92", "34d6c333-afe9-48f3-b1b4-de40aae089c5" },
                    { "98573e2b-e49e-41b6-ba4f-53cfcaf7b939", "Street 398", "8405e16e-9e70-4e35-980d-495216ea4342" },
                    { "aadf5dee-aa3d-44ab-a31a-5d45f1faf3b7", "Street 50", "f95950f1-d541-44a7-94a7-5e307cd6712b" },
                    { "3236d7bb-5685-4ad5-9035-5f2681b78152", "Street 247", "af8d30e3-8e78-4132-89ab-cbd05291cd66" },
                    { "c28b67a4-5a07-4fcc-92f8-822e2bf96427", "Street 57", "7d3d79c2-221c-41d6-8689-9b51ea7c2ad2" },
                    { "b8290551-a1d5-442e-a7d3-7e773c8ffc1f", "Street 406", "b5ce5e52-082a-4733-8a7f-0f25bf8f9860" },
                    { "632d1955-0c3e-4f3f-ba49-73280a366753", "Street 279", "76ac581e-3156-42c0-a30b-c7deab7ed9d8" },
                    { "de4eb845-32ee-48f3-bf66-de4725014015", "Street 272", "9b285dc2-1e7c-45f4-9779-a314ff8f7021" },
                    { "86028136-c007-41a6-acdf-ef128e244924", "Street 308", "850e61dd-47e0-4ae2-bf23-461cea5b3489" },
                    { "fdbc7301-74a2-45df-8171-6e0f579c4803", "Street 9", "9a616128-e9fa-4eee-a151-c64375e4e195" },
                    { "bb4a17ff-afe3-4ce6-985b-1d831e37b63e", "Street 110", "93a91039-12c2-4876-b493-fbad6e9da0cd" },
                    { "7e7fbb37-fc13-4064-80a5-be373ff5101f", "Street 296", "d53f8031-c378-462c-92b0-c08d777433f0" },
                    { "487fe1df-a5a5-44e9-9f32-9c36993b92db", "Street 144", "5b025639-4a4b-4b1c-8a22-20fe4ca43f82" },
                    { "185ed368-b31a-4407-8619-41b33861d96b", "Street 381", "13785b1b-81b3-44f6-a5d8-63c20b0863dc" },
                    { "f0eeef57-1eb4-4281-bde8-ce7836c146ed", "Street 166", "b19bf3f9-4627-449b-ac76-641061bdca25" },
                    { "6a2bb51e-558b-4216-a7e3-ec2cd099073b", "Street 13", "8bda9135-9403-4163-b414-df71fda17612" },
                    { "684bca08-25e4-42af-9a60-0d641e31f074", "Street 309", "91b819e9-5471-4c25-91c9-17a790be1831" },
                    { "ebee6599-4737-4b98-9e52-b45e1279823e", "Street 287", "d62182ee-d7c5-4f7b-9c7f-3821df14646c" },
                    { "ca8194a2-e430-4f03-a310-c1b1bed35bc7", "Street 120", "5207656a-c474-4684-a3e8-294435bde626" },
                    { "448c22a7-1a06-428b-82fc-deb803679bfb", "Street 32", "96dd5af8-0960-4e24-90b9-7f27c34e586e" },
                    { "40768598-a425-4c68-b4bf-0b2fb402c156", "Street 78", "92c19c5d-3294-4d48-bb1b-28d7a8513f02" },
                    { "fc35dbb6-1e3a-4b4d-8ad9-1f240703d1d8", "Street 222", "6da87c28-6735-4d8d-897e-ea3415062319" },
                    { "bc6f8942-2eb1-4661-bc37-1adc3c243907", "Street 287", "fe6ad777-a74d-4302-a246-e34f904531c2" },
                    { "e9d6fa24-6675-4e52-a04a-0c32a468054b", "Street 370", "753c690a-5616-443d-93d2-52ac191ba59e" },
                    { "ac5377dd-b4a1-481f-81e9-f7091829e391", "Street 35", "86bfd4c1-a904-4cbc-ad7a-293ee3b994c3" },
                    { "b4080902-2532-426d-84a7-f4ef186cc32e", "Street 199", "ec070840-565d-4b7b-bbdc-6e808f1410c4" },
                    { "3efc4198-f99a-4930-95e8-d74407b26714", "Street 63", "57aa6924-5b2a-4fcd-9d58-83cb1dc0d0f8" },
                    { "6f9d8a47-4519-40d5-951f-5293209021c2", "Street 331", "07e9b088-93d1-4008-9895-dc9eb1fa8511" },
                    { "dc5ad50e-c0a8-4931-8f49-662c1ee126ac", "Street 135", "0f7cd778-935c-4ecf-9f4d-832b07492a0e" },
                    { "06875cf0-f775-4c48-b358-2929a781aff8", "Street 224", "d4c3a173-4a85-46e1-af15-7cac793a802a" },
                    { "6a433ca2-5d7f-4a8d-a3ab-054193e3c997", "Street 440", "19799b68-744a-43fd-b23f-88d40dc7c303" },
                    { "fe50e0b9-73d3-410b-bc63-23d236d4b5b7", "Street 412", "f20f33d3-2930-49d0-8ce8-89698fc75267" },
                    { "6e6ac0af-5ba6-4027-b96e-870402ff9273", "Street 188", "c3660765-6c34-406a-89f4-cffd346688c2" },
                    { "49031291-1052-4c1d-aa2b-9618abcc5baa", "Street 180", "bd14e399-40ae-4a7d-8cce-081250f1dae8" },
                    { "438f6835-b436-44b5-a66f-813cbacb72b7", "Street 118", "ff017848-24b2-4075-9f82-c3be92e556ed" },
                    { "2ce9fe4b-0d09-4170-87c6-44dd4f224da7", "Street 230", "82280915-4ba3-417d-8457-38e7e438920b" },
                    { "bb77e5c7-d3eb-4252-b1dd-7d0a0ac76b3b", "Street 390", "2230b57d-5172-4bfc-923a-e8488dd8a60a" },
                    { "7c93ec4f-80e1-4d07-94ea-1dbcb8396a3c", "Street 378", "c876b1f5-1cf8-476a-ae45-e6b38ea3b426" },
                    { "11bc43b8-5c95-4993-8593-fdf410248424", "Street 179", "5c3e9855-4db4-4649-a23f-b4e86e25fd00" },
                    { "50aa13d8-659c-4a00-a241-91194e50a6c3", "Street 160", "e374030e-d107-423f-a533-2a569675587a" }
                });

            migrationBuilder.InsertData(
                table: "Teches",
                columns: new[] { "Id", "Salary", "UserId" },
                values: new object[,]
                {
                    { "0b488542-0a98-4a4b-9600-9df314efc383", 1498.15350514751m, "33a9a829-dccb-4af4-9b0a-fde3bc323255" },
                    { "b0f12c96-64ab-4648-bf68-c2cd2a78d85e", 398.432146943376m, "dd5c3a58-456f-4b4f-a0b1-123461b861c2" },
                    { "110852ab-a275-4e08-8fcf-24bfcf00d769", 465.826761194424m, "38624d16-ad64-426d-9087-59f0a6232068" },
                    { "6c73c160-b79a-47fc-9ca8-92bc2752869f", 2276.49699769751m, "2ecd6e0c-a1ef-4568-af65-319c8d88d4fc" },
                    { "c6fc08d7-a481-42d0-9e8b-a872c0b8bb98", 2633.6987864383m, "d641258a-fd7a-4e8a-8810-fa2a9481f9ac" },
                    { "b6c87656-ef17-48b4-8784-01502d8cdbea", 738.175473519682m, "ba1b2379-3e57-4eae-a0be-b2c88fbe67aa" },
                    { "fc511f21-16e7-4217-bd35-809447d31838", 2025.97487719076m, "f6453e75-6bc1-421b-8958-3330946eca0a" },
                    { "b383655b-7281-4c5c-bda7-7b2c36e86942", 545.485331930912m, "bdd8ee75-a4ec-4244-ad4a-f48ffe42fdae" },
                    { "54effd22-c760-47dd-8916-4c4526801d85", 657.596586578338m, "66ac7c71-ad4e-4ab7-bab6-9788cc8c38ea" },
                    { "f1331116-fab7-49aa-8e74-a3d8c42919e7", 2279.74841617036m, "7c6e2c93-c6bf-4cd0-ab7c-4da59c8f210f" },
                    { "e7c896b3-ca97-4dd4-b2e9-a19d3a863ffc", 734.169633469624m, "eb1eee16-a36c-407f-a87a-be4e64f76ace" },
                    { "98d1da4d-3cb2-4e6f-ac5c-1185769c84cf", 2592.65405386344m, "ffe4aa6e-0e20-4c3b-8483-b241443e9ac0" },
                    { "e353b0a4-888b-402b-bbc1-61e156d5d201", 1379.12944768515m, "eb3175bf-0ce0-42b8-bc91-e961f5ed3185" },
                    { "ade47fdb-e9c9-427c-95c5-87a092331e3f", 1092.8804413848m, "75db636b-5d39-49c6-a511-47165049eaca" },
                    { "f17b70cc-df57-43c8-a117-413fb905cfc2", 2353.3033883913m, "1a6ba66b-f96b-432a-964c-d9386ae19b74" },
                    { "27a84131-8535-4778-862e-d75f72884704", 729.276908435522m, "cdb452b3-8dc4-42f5-aae9-35e34fc12280" },
                    { "25510542-b6e4-46d4-9d39-a09baabafadb", 955.347347983786m, "16512485-5d03-4755-aacb-eca8bec969c4" },
                    { "953cbf01-37f8-4f48-9acb-ce0002523393", 2141.2106021965m, "4f74c5df-1ba2-43d6-adf0-78268ae19182" },
                    { "1dfc42ba-c39a-4cdc-9914-0f15664f3c92", 1604.86678621027m, "4529b86e-5fe0-4081-8bbd-0a7ff6137c6c" },
                    { "f9efc18b-4dfd-4c6d-91fb-c2ebc6906c03", 1221.59893122576m, "0c34bd6b-1cb2-495f-930a-7f89e3ce4cdb" },
                    { "f8362704-e60e-4c43-94f7-bada861dabac", 2642.14983472701m, "04b95fb2-994f-401b-a376-8e34f021f725" },
                    { "4206b13c-13a1-4727-aa4e-b1955cca66af", 1056.23473415907m, "323cfc4e-deaa-4478-8922-4f9b1111e3a5" },
                    { "5379c6cc-27d2-4b62-a136-fe1a4101260d", 1485.01432989026m, "3a82a1ed-6ed1-473e-afd2-876be2c24f70" },
                    { "054b1e32-99a5-46b8-a14b-a40e40b3e2f9", 2119.73472876462m, "86449d5c-80c9-41e6-8673-068253347120" },
                    { "51709ea0-c935-4443-98f2-1a556b867cf8", 1248.89019841742m, "662acc08-845f-40e8-a110-2e2025b014ba" },
                    { "cd36ced2-0942-4863-bd5d-fea67b6b5e9c", 534.240181806609m, "117714be-4af0-430d-90a1-f43319825d85" },
                    { "159f431e-d272-4bd0-b040-1e3e2a894015", 32.40112822149m, "8bd20eed-b102-4887-85bb-1d40ced1d0ed" },
                    { "1ded70c9-dbb1-4c36-8751-50b6bb66d3ba", 124.303382413603m, "eb81855b-060e-4f06-a714-5feec172402b" },
                    { "d876f978-a020-4788-ae5b-d58b852d1315", 464.760486718621m, "0345c656-a63b-4816-bd28-d6e72a36d0a0" },
                    { "e8d8b8d7-7776-4af6-865d-54701260f824", 2770.22975625947m, "c18febfe-f8bc-447b-95be-cd76b0d8229d" },
                    { "a7ac399f-b08d-44bf-8647-07c68b19dcc7", 1371.34849064581m, "969172aa-0d6a-427e-b13d-c39e52c0ae92" },
                    { "cf2d6a0d-3abf-44a7-aa63-1fdfe4b9ad51", 1844.63642809756m, "ef8a84c9-d2c6-45a8-8dc6-c4db482683db" },
                    { "442fe801-bc5a-4512-9857-de2b05c82a2b", 2138.16874806684m, "5acdee34-7c8e-457c-ae57-824ebfa63067" },
                    { "3750c130-6624-4b80-9482-0e9028ce7a2c", 169.824981675402m, "935a8b72-9be4-4f8c-9870-ee73b23b4735" },
                    { "c4b68ea9-84b3-4c12-9eba-56b1ccdac5f0", 1474.43179994562m, "b717c2e9-3271-4228-873e-bdd2890c5a0e" },
                    { "b23e54c1-b376-44de-8dd2-33b92bcfc4ae", 2465.02751226771m, "2003286a-6c6b-4e75-8c52-f039d230591a" },
                    { "4ebae49e-6097-4ad6-adf5-aaee19b187e8", 2718.55479093201m, "20fc2d6d-d70a-4b33-a123-bcf1416a4d88" },
                    { "6e23b16e-8c00-4cd9-aab0-10298013d78e", 2186.72139299415m, "4b4c9518-ac97-470c-8833-2c9f5b90a7b3" },
                    { "90e9e896-3976-4e9a-96c5-dd9edc7327a8", 819.870834154948m, "d75cc932-c238-45cf-9837-96516ccba18d" },
                    { "a05a8237-2bc5-4fea-a7bf-390baa4ebd2a", 2269.79482093351m, "dcc831b4-ceb3-495c-ad12-7dd49d056f95" },
                    { "71f62d38-cef6-4dd7-9131-94a6d8d43838", 2580.23505312402m, "34669351-9eac-4023-b658-e5973ae6a158" },
                    { "27cb1c2e-a113-456d-b04a-2b94941ae7fd", 2698.52417134611m, "0adac9c2-e448-4e26-bc8c-7b062b38b14f" },
                    { "9ddc7590-4fbc-4dc4-ade6-ebac325316f0", 894.236207890434m, "49a70cc3-4635-4fc5-8ae0-813ee2238214" },
                    { "511c52de-5396-4775-a7e2-51f1bc12038f", 1340.47210046112m, "1cd18ee8-6db8-4ed0-a762-0471114a2027" },
                    { "e23c886d-b304-48db-93a2-148ac85be98f", 687.275519914588m, "92b407b6-e617-46df-b757-5d4c4de0c5c3" },
                    { "44e5e0ac-1f14-4be1-8d76-8044cdc90726", 2985.21415516046m, "c8e3e307-5689-42f7-8139-8e0573013d19" },
                    { "116437ba-454e-4237-9f57-975fc8d34da7", 2345.5610886894m, "b65add3e-6930-4a11-b69e-c72412434a28" },
                    { "6d8fe54d-eb17-4d33-b41b-9157ecaebef6", 2181.92213037141m, "5d3bd496-6a31-4323-baa8-802a423faf45" },
                    { "2ea683e1-44cb-4a18-bbe4-03fe0ccb5bba", 1627.6646254713m, "3b54a9ec-f3ac-4adb-ae0f-d4d12357cbc6" },
                    { "8aa65855-9b44-4d87-b935-160f10993dff", 1898.45485561455m, "0eeaeb88-4258-4d5b-88d0-d803eafad74d" }
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
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Teches");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
