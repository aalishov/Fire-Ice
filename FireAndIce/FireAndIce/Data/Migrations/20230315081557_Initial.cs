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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aed97cb5-70ad-4d5c-afab-decbb1c13ca5", "148d30b8-7a6d-4e7f-a7d8-9a0c3befdbfe", "Customer", "Customer" },
                    { "4a4d39cc-65a8-4533-ba05-73316945a16d", "b408ee55-c4de-4bd3-9c0a-47d99dc2eecd", "Tech", "Tech" },
                    { "d6d6c823-b770-4ed8-a93b-1ee9fb28f142", "0ee8a846-99cd-43fd-b9a7-a525fd94067c", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "517d8890-fc19-44e9-8277-e2024e17a0c4", 0, "64fe3163-5829-4864-b810-edeba3142b80", "customer96@abv.bg", false, null, null, false, null, "customer96@abv.bg", "customer96@abv.bg", "AQAAAAEAACcQAAAAECFAx0iRgc/LwdLkXfYA0XvDaOi9+ZyETr+aDib8ZBs50ApPzxbh5GO75NLfNziY6Q==", null, false, "", false, "customer96@abv.bg" },
                    { "62fd09ed-5c12-4d42-83d7-82b9e9c8d24b", 0, "7e18754c-7a8b-4cbc-850b-7e7b817200ea", "customer97@abv.bg", false, null, null, false, null, "customer97@abv.bg", "customer97@abv.bg", "AQAAAAEAACcQAAAAEE+88IirTSbBuCn6fGX6sa+/2+pxneTzbo3k+Fa5JRwJDUZHwBwnq9KaR1J8/VQ9+A==", null, false, "", false, "customer97@abv.bg" },
                    { "bb8a9607-a293-40fd-bcf1-539829f57377", 0, "9b52b82c-7e89-47ea-8aa7-3d3a08fd1a16", "customer98@abv.bg", false, null, null, false, null, "customer98@abv.bg", "customer98@abv.bg", "AQAAAAEAACcQAAAAENl4RflsFspj8kQ6TL+DtA4+AVZQhtszONvcjJ8/86gQGX7jyaMRFnL3J/9f/8UNPQ==", null, false, "", false, "customer98@abv.bg" },
                    { "812eb3d2-e4db-4fe7-b605-02e4dd9957d3", 0, "f8c70381-50a2-4549-94bd-cbc9630cfa30", "customer99@abv.bg", false, null, null, false, null, "customer99@abv.bg", "customer99@abv.bg", "AQAAAAEAACcQAAAAEPpZL8D3lWx9UNV4Bxghkt3nccufToBRQXQjj6/5IESTAiyDqXC8ff2rkMmhQw26aw==", null, false, "", false, "customer99@abv.bg" },
                    { "947e2d2c-30ea-49d0-9793-8b1f72da1dd7", 0, "b47d957d-37d8-46fb-82c5-878e17c82139", "tech0@abv.bg", false, null, null, false, null, "tech0@abv.bg", "tech0@abv.bg", "AQAAAAEAACcQAAAAECJSiFkgaYRHRuYg04iQhpJJKRa9Q7avzoDoQdlo5JVyBYDGUcBS6UO5U/8esc5IvA==", null, false, "", false, "tech0@abv.bg" },
                    { "8a82d4a6-d219-4c16-81df-0ebb91bc7be9", 0, "cc54e749-9907-4ab8-a3d5-b316170cfc6f", "tech1@abv.bg", false, null, null, false, null, "tech1@abv.bg", "tech1@abv.bg", "AQAAAAEAACcQAAAAEIeRV3FKbRbK3xdOnwG4/u9xPepAaYpv8Msp83zyWOwd+XddFffMvc4gmQFPkCVLiw==", null, false, "", false, "tech1@abv.bg" },
                    { "352dcbda-c54a-43af-9a6a-e34b54c6ece0", 0, "81f94537-4314-42a0-9506-7dcc242fe2da", "tech2@abv.bg", false, null, null, false, null, "tech2@abv.bg", "tech2@abv.bg", "AQAAAAEAACcQAAAAEL8/tMAt6RONZrOYmMQRMx3HaR4YvYZrx7kYBHAA4MHog0wPcZtG2HzoUGXFdSSEbw==", null, false, "", false, "tech2@abv.bg" },
                    { "764e4eb6-3966-4edd-9aaf-50c67db101a9", 0, "ee5fc1b6-eead-4533-ad04-2911ea628ab9", "tech3@abv.bg", false, null, null, false, null, "tech3@abv.bg", "tech3@abv.bg", "AQAAAAEAACcQAAAAEFtPSnqkoEhI7szAReU/1+IMQx/LCPSMmt7DCIHQNZZzvhN1Pslmz14rOrACOsKBEA==", null, false, "", false, "tech3@abv.bg" },
                    { "a374a09b-8b48-4d8e-b10d-42aed3dbab7b", 0, "8b5a4d77-1245-40dc-a7af-4745367b5c45", "tech4@abv.bg", false, null, null, false, null, "tech4@abv.bg", "tech4@abv.bg", "AQAAAAEAACcQAAAAEAjbF5yV+QwcrxVTR4h8QnsBa4psL8x4fMrrTjfdFyFF9UajEiDwZVt6iA8MnauBsg==", null, false, "", false, "tech4@abv.bg" },
                    { "9285e36c-6a9d-46da-96aa-ff936d581c64", 0, "810f98b4-0042-4cdb-b55f-c1ce8a15b9e2", "tech5@abv.bg", false, null, null, false, null, "tech5@abv.bg", "tech5@abv.bg", "AQAAAAEAACcQAAAAEJ6c86PDVSBTbcGKl/rxuEyxnYxe/OQebf8CAK3GZwFGqx1oppkyxAQ/onCzl3ECvg==", null, false, "", false, "tech5@abv.bg" },
                    { "d58660e8-5d40-4b78-9385-041c893d3361", 0, "2c47c943-9abd-4b76-a0e7-1123f1b6579e", "tech6@abv.bg", false, null, null, false, null, "tech6@abv.bg", "tech6@abv.bg", "AQAAAAEAACcQAAAAEBx1XrQswvKSy+6loyZH1/7adl2vIVdS8DAs2LPiNyzvAurXFAMw/H6E7aSDNXPsdg==", null, false, "", false, "tech6@abv.bg" },
                    { "5361559a-0c4d-4707-b692-e68f1d557b18", 0, "76736f63-3f1f-44b9-8932-2f51344bd226", "tech7@abv.bg", false, null, null, false, null, "tech7@abv.bg", "tech7@abv.bg", "AQAAAAEAACcQAAAAEN7Dkao4aYQTJecufn5ZzVmmqCrYE4xeQNu73XVySdOOIGQLxqHLZAk2ABtky6/xdw==", null, false, "", false, "tech7@abv.bg" },
                    { "fd5e33f6-408a-40c8-8f41-5b51eaf00897", 0, "bb066d2a-9cb9-4a3c-a669-f272d0a01f11", "tech8@abv.bg", false, null, null, false, null, "tech8@abv.bg", "tech8@abv.bg", "AQAAAAEAACcQAAAAEFkPW9eN5D3Eaxo5LTXzLAQC4su2sOZZmmKg6nMkKVMxCHWjUHDQlzKA1ki2GJXNDw==", null, false, "", false, "tech8@abv.bg" },
                    { "e13b9cad-0ae9-48ec-a77a-1d78de038061", 0, "24de9300-af3b-4270-bc64-5b9b34545217", "tech9@abv.bg", false, null, null, false, null, "tech9@abv.bg", "tech9@abv.bg", "AQAAAAEAACcQAAAAEAXTw1IHBStblB5TE/SihTW6qj3u6uFrUF+MqzN4UPRePg0RAXRRKPNSHEu7OcfTuw==", null, false, "", false, "tech9@abv.bg" },
                    { "ab214fe2-bb79-4ece-ad39-d1568d974a8e", 0, "9a941134-9c84-46e4-b16e-c1d59436ff6c", "tech10@abv.bg", false, null, null, false, null, "tech10@abv.bg", "tech10@abv.bg", "AQAAAAEAACcQAAAAEFSOI46pddLongNj/EgK4sXk58CkX9TFnfGeQHRwsB/4P2FJi120d5klhdXsLjUVUQ==", null, false, "", false, "tech10@abv.bg" },
                    { "4cc2b5f9-ffca-44b7-ad55-bcc1b1b67bf8", 0, "f811d5bf-187c-4d94-aebf-98b58d30c55f", "customer95@abv.bg", false, null, null, false, null, "customer95@abv.bg", "customer95@abv.bg", "AQAAAAEAACcQAAAAEG1GAaZ+AV8YT/nyJVwz1aJ718UEN+ITurpI/DgZTLOt1mlDjFN4Mbxw0WoEhG9yxQ==", null, false, "", false, "customer95@abv.bg" },
                    { "25cb8819-6ba0-4309-946c-2840dd3ded04", 0, "b17c97cf-ffb9-49bc-b2d4-c5297e672428", "tech11@abv.bg", false, null, null, false, null, "tech11@abv.bg", "tech11@abv.bg", "AQAAAAEAACcQAAAAEEnzuL8NR2FJE2k0FJqa2FbQSRK7nNNW9JIZZLcJu6YpQGp0cX3l2wMkVk4XxGxtMw==", null, false, "", false, "tech11@abv.bg" },
                    { "badb7886-ba5c-4a34-8571-6a2c3228f9f6", 0, "776c0f46-531b-4023-a5d3-721b7d754060", "customer94@abv.bg", false, null, null, false, null, "customer94@abv.bg", "customer94@abv.bg", "AQAAAAEAACcQAAAAEDKBq0fLwgcWezEjIM2MgQPElzVt0cDqAXmcaLEsyywLtrCmZHNlJqwyj5tvZ1uTbQ==", null, false, "", false, "customer94@abv.bg" },
                    { "94f66f1a-9aa2-41d1-b51a-01f8521d0199", 0, "21e58d0a-beff-4bdb-8b8e-ba9d8ae93002", "customer92@abv.bg", false, null, null, false, null, "customer92@abv.bg", "customer92@abv.bg", "AQAAAAEAACcQAAAAEO8w1cMQ+7lKzqH6eb9ot9p6h6dMTxX9LYxm4ILu/9yYdke2+OqwS7eCeYPzSd77MA==", null, false, "", false, "customer92@abv.bg" },
                    { "6f502c9c-3c89-405d-af67-b9f8eaf52599", 0, "f83d1ff9-1f6e-46fa-ae84-9bfa78286d6b", "customer77@abv.bg", false, null, null, false, null, "customer77@abv.bg", "customer77@abv.bg", "AQAAAAEAACcQAAAAEJAzzm8xGQJzuy3ExyJVgYBIlgVfBdfEwOOaEyQP+chdgDdbai4nLOzwcJcDO0Wwtg==", null, false, "", false, "customer77@abv.bg" },
                    { "d9e75766-b00b-4020-8e68-4ed4b2422ad2", 0, "8bd830d5-43b7-44a8-89dd-da674a214b88", "customer78@abv.bg", false, null, null, false, null, "customer78@abv.bg", "customer78@abv.bg", "AQAAAAEAACcQAAAAEBTB5l3NxKqyCaYJKz1xPGBzcCYVf6GzKiso3YJIioLZLTqqC70S6wbnI0pllp6Omw==", null, false, "", false, "customer78@abv.bg" },
                    { "2b7f4460-993e-4607-a561-aa9b0c7fffac", 0, "515cd64a-2b1f-4cd8-a906-628ec80f91eb", "customer79@abv.bg", false, null, null, false, null, "customer79@abv.bg", "customer79@abv.bg", "AQAAAAEAACcQAAAAECNBislsTkVDVpyFlHI87cHBi35xmfl4DXOIIc9uU1B01ojf39/X7RHsXW+HuzCUYQ==", null, false, "", false, "customer79@abv.bg" },
                    { "fef55d5b-b9a8-496d-84dd-9392b6bfbb26", 0, "cf73037e-8560-4caf-8d7b-fe4d807b9ca0", "customer80@abv.bg", false, null, null, false, null, "customer80@abv.bg", "customer80@abv.bg", "AQAAAAEAACcQAAAAELVohPOPrYeLTImO1dfqyHFfYKQsWYKlasJ9//vnesvbfiaeYnA20ldO5WcUQhtyng==", null, false, "", false, "customer80@abv.bg" },
                    { "b273b2f2-0172-4e5e-b643-dcc53a8e6596", 0, "a3f45816-e9ea-4d5a-9adf-b17d11bcdd27", "customer81@abv.bg", false, null, null, false, null, "customer81@abv.bg", "customer81@abv.bg", "AQAAAAEAACcQAAAAEG0slY5qPCDH8MWUlvC9ARHnJgaUcg0wP+OURO8rrY2OvUqOJt4ZXEGpuDNc/7NObg==", null, false, "", false, "customer81@abv.bg" },
                    { "f127cfd6-d199-40eb-b813-3c9a6de4e0a2", 0, "99755bcf-8203-4cd8-9c49-d0077cd900ca", "customer82@abv.bg", false, null, null, false, null, "customer82@abv.bg", "customer82@abv.bg", "AQAAAAEAACcQAAAAEJIgvAJHNoy8keQlxufWtYGjXJR7R+qEC6mMSwXV9cpn+evw7BaxHqTk+vx3gN0ryw==", null, false, "", false, "customer82@abv.bg" },
                    { "62875e18-ca90-4041-9540-559bc8c0961b", 0, "8f26ec5a-76ca-4ae4-bf89-4bce10f96426", "customer83@abv.bg", false, null, null, false, null, "customer83@abv.bg", "customer83@abv.bg", "AQAAAAEAACcQAAAAEECzwffPC8JSAyNoXG4z1Xu7sfC5GdxLiyHfH6z6sLgo31QJvhsYZmroA8m57vnPCw==", null, false, "", false, "customer83@abv.bg" },
                    { "424445a3-e372-479f-b7a1-10fe12053fa9", 0, "2dee721d-3ab0-479f-a832-8f4bb7dc51dc", "customer84@abv.bg", false, null, null, false, null, "customer84@abv.bg", "customer84@abv.bg", "AQAAAAEAACcQAAAAEI8drqVdMZD0XgImOExNlRUrVMVChumCLlUL0nyz0UP6qzXy2Z6WMpiTQyyvEN/2pA==", null, false, "", false, "customer84@abv.bg" },
                    { "fa7dbd5c-dfb9-42e0-a8bb-a96320c65abf", 0, "aba7f269-1726-4ac7-8e4b-597ced7f5acf", "customer85@abv.bg", false, null, null, false, null, "customer85@abv.bg", "customer85@abv.bg", "AQAAAAEAACcQAAAAEL3nJN5/MBF27OOjlvgWtBGQeiXH0LKNakukfUJi0t+Is72g7IltOO+pSMfetKirvw==", null, false, "", false, "customer85@abv.bg" },
                    { "fe0eec49-354e-43ba-a97a-5c31357c5753", 0, "07f275c2-78a5-47a5-a505-1a598b7387b5", "customer86@abv.bg", false, null, null, false, null, "customer86@abv.bg", "customer86@abv.bg", "AQAAAAEAACcQAAAAEHR0Isz9xoMBYcqLciONlJtVJN3DN+IooAmSrSAIrlxtnVuZIZa0+Of8qyuWUrfKZA==", null, false, "", false, "customer86@abv.bg" },
                    { "13a135bd-e0ee-49b8-a4a8-efb84259454d", 0, "64b0e707-fbf0-49cb-b011-49208b608db6", "customer87@abv.bg", false, null, null, false, null, "customer87@abv.bg", "customer87@abv.bg", "AQAAAAEAACcQAAAAEOwA+VkBHBjUHncr3IDNakSYdrAjq2ceUnkZaf46eVAQs0FZ068SlDkgVqJIGc+WlA==", null, false, "", false, "customer87@abv.bg" },
                    { "16d681f9-5fd4-47e4-b279-1452a9b5f374", 0, "d455d328-d9df-45df-985d-a7ddd575c77b", "customer88@abv.bg", false, null, null, false, null, "customer88@abv.bg", "customer88@abv.bg", "AQAAAAEAACcQAAAAEMX6a93wNcsZKnb2mZw6Z636iqldBycHZfzagnssT3ktiaArPfmxrxHPxFbmRRuqlQ==", null, false, "", false, "customer88@abv.bg" },
                    { "2cb27c90-e77d-4cd3-8f7a-ebfce05f56ed", 0, "be73d5d9-6b95-4917-8357-a97871efd5f6", "customer89@abv.bg", false, null, null, false, null, "customer89@abv.bg", "customer89@abv.bg", "AQAAAAEAACcQAAAAEAt78VSyT0lHzSwprOzzDg13pqoUdRRTIiVTFqKFCFc1iNZRcbabbR5OCfJSPhKGWA==", null, false, "", false, "customer89@abv.bg" },
                    { "34286d7a-6c35-4b42-b579-9138d67140cb", 0, "2941205d-67a1-4dfe-b34d-b80f632bd1b3", "customer90@abv.bg", false, null, null, false, null, "customer90@abv.bg", "customer90@abv.bg", "AQAAAAEAACcQAAAAEBju92Q8kvItT4usoYQ6tzHLge34zM/5WEMRdJ+AH/EQ0J6ehO5zE8v1vzxY0EJy2Q==", null, false, "", false, "customer90@abv.bg" },
                    { "616b44bf-5786-4469-9d76-3147a32931eb", 0, "5a8c8da9-65c3-49ed-b99f-5d5209e6e2d9", "customer91@abv.bg", false, null, null, false, null, "customer91@abv.bg", "customer91@abv.bg", "AQAAAAEAACcQAAAAEHeCjBzEXHye3HUZbcyNxZspGpByld/DTndg1GFhKth/SY06NexBzwwBAWhZtjh1KQ==", null, false, "", false, "customer91@abv.bg" },
                    { "38b590fd-efe1-4e2d-82f2-d57b04cd03dd", 0, "70e394e7-b080-4592-a31d-77ec5dda1346", "customer93@abv.bg", false, null, null, false, null, "customer93@abv.bg", "customer93@abv.bg", "AQAAAAEAACcQAAAAEFrZl+pVFuFZk1ugFRBKs4yF2kBNu9gNBog1yeX8unsv9sQQcphwBbM9ed+P6cL13g==", null, false, "", false, "customer93@abv.bg" },
                    { "f1a9afc0-5eb6-45c8-8d99-ad19fef0957b", 0, "f32f9467-b487-4e9a-a7a0-4aca8055d43a", "tech49@abv.bg", false, null, null, false, null, "tech49@abv.bg", "tech49@abv.bg", "AQAAAAEAACcQAAAAEJ2AeNwrmZuukaW0paoollnzWN5LU3Jlynuc/sa0R5jfZqwxBKop1BZNlmPCB8xc9Q==", null, false, "", false, "tech49@abv.bg" },
                    { "dbdafd92-720a-40cf-9db5-cc9affdb920a", 0, "edd7a2bc-3581-48da-a4c2-6af660ced9e3", "tech12@abv.bg", false, null, null, false, null, "tech12@abv.bg", "tech12@abv.bg", "AQAAAAEAACcQAAAAEHEBwKGpZ9X7AN9XFxiTOnzoT+OnbuPPI7HSmUTc1JWWFzY1sTWY5fJNHBeH7l9oKQ==", null, false, "", false, "tech12@abv.bg" },
                    { "2b2c8efa-714d-4573-ae02-aa06631dbc41", 0, "596ac8e7-55b3-4b24-be78-2ae9c8a1634b", "tech14@abv.bg", false, null, null, false, null, "tech14@abv.bg", "tech14@abv.bg", "AQAAAAEAACcQAAAAEFUPGI/A6rBNGFQg8eq0G6seCTbinqzhQ4KTX7Bs4Es1/fT+t6LNr2iIWvu0e6EF8A==", null, false, "", false, "tech14@abv.bg" },
                    { "b45c77ee-1907-472f-91e5-55f9f123d449", 0, "13fd6780-8ef2-48fd-b16e-5d1108de2382", "tech34@abv.bg", false, null, null, false, null, "tech34@abv.bg", "tech34@abv.bg", "AQAAAAEAACcQAAAAEKfbd9SBemiJu3pOlPCH+etB9Tukw90NcbAVhi/HvrKrddsDws9TEui+JrXGuJKNOQ==", null, false, "", false, "tech34@abv.bg" },
                    { "302428c5-8ebe-4800-ba49-33f3aef046ba", 0, "9179512e-aed7-4f3c-8b31-c5cef58cf3dc", "tech35@abv.bg", false, null, null, false, null, "tech35@abv.bg", "tech35@abv.bg", "AQAAAAEAACcQAAAAEEwvGx3MR1m/kMQbxljeM3FAcPxv4/u20+tGLw4S5xM5UNqBkwXUTp2WzPEI9MM+kw==", null, false, "", false, "tech35@abv.bg" },
                    { "5d382f8e-93c1-48eb-bd17-d78e37745228", 0, "29c7bf33-0104-4299-b057-f18cf223ab3b", "tech36@abv.bg", false, null, null, false, null, "tech36@abv.bg", "tech36@abv.bg", "AQAAAAEAACcQAAAAEDPViPFSr2pfOH/xeuTYqbCfgBMApG8XMbbgWcLrN51/7xID3JrdLFu1oWM6Agg28Q==", null, false, "", false, "tech36@abv.bg" },
                    { "2f0c48c2-637c-431b-94d2-57badf0cb1b2", 0, "51d12ecf-00eb-43e6-b0b6-d273a7e6c580", "tech37@abv.bg", false, null, null, false, null, "tech37@abv.bg", "tech37@abv.bg", "AQAAAAEAACcQAAAAENcIUtZow1WIXvQXEZJjBPtN4hlHY8MysrYeHuXqn3A7fogTA6agZ5aXGDktqer0HQ==", null, false, "", false, "tech37@abv.bg" },
                    { "6f2aa5aa-fd7d-4b9a-90ec-3936404c8388", 0, "bae760da-b60c-4b95-9c7e-cae5c47371fe", "tech38@abv.bg", false, null, null, false, null, "tech38@abv.bg", "tech38@abv.bg", "AQAAAAEAACcQAAAAEMHq4MvU54k5PZ2tMZbAdreb1zuNnR3UDbJbGFSwdB1CtVXC5kEKPc/xgwOZqMXFQQ==", null, false, "", false, "tech38@abv.bg" },
                    { "f780341a-aba6-4056-9d07-52a1c67fa9f6", 0, "847ad8e9-668e-4eed-82d6-9928d9b6cd22", "tech39@abv.bg", false, null, null, false, null, "tech39@abv.bg", "tech39@abv.bg", "AQAAAAEAACcQAAAAEOl/ugyb5UY85EC6BO8wnG3z5HfSYc3+WfF4+51b26CxjEoZ+dlQWbFwFNBylN0I8g==", null, false, "", false, "tech39@abv.bg" },
                    { "00e0f42d-d973-4eff-8c24-b3df9caeb264", 0, "5e6ab72a-70e6-456f-a0b3-7ea1df3c4696", "tech40@abv.bg", false, null, null, false, null, "tech40@abv.bg", "tech40@abv.bg", "AQAAAAEAACcQAAAAEG5QoVD3YA1P5rKTr9Szl/76LZTNO67SrK23EjLmnIYv/GCxWA576usOPMkSO7Z7bQ==", null, false, "", false, "tech40@abv.bg" },
                    { "8bc2fa76-5737-4648-aab5-b314a012ccc6", 0, "d2d2aebb-63f9-4d98-9b03-cf9e8e6433f2", "tech41@abv.bg", false, null, null, false, null, "tech41@abv.bg", "tech41@abv.bg", "AQAAAAEAACcQAAAAEID0doJjNwb7kIqxNBXwHu8YXlI7N4RheCAuOY9MR2G0yoRTsGreJ1kBeTwGRz469g==", null, false, "", false, "tech41@abv.bg" },
                    { "44a91cfc-2fdd-460d-b7aa-4dff57932333", 0, "3df25deb-1d1b-4a22-9ced-8bacaee4e0a8", "tech42@abv.bg", false, null, null, false, null, "tech42@abv.bg", "tech42@abv.bg", "AQAAAAEAACcQAAAAEHeTyaU2eyKRIBwVNECjlgmniROG9P6v4s7YZm02VTWU+9Bjwtrb5DiDPiNz38qFnA==", null, false, "", false, "tech42@abv.bg" },
                    { "4e8d24ef-c754-48a8-8ef5-dfdfd177b989", 0, "6dd2ca10-f6bd-43ee-b15a-ca05d946dde0", "tech43@abv.bg", false, null, null, false, null, "tech43@abv.bg", "tech43@abv.bg", "AQAAAAEAACcQAAAAEGsY42ZvTkuGLH7b+x6q2Lpvz82NNZ57BRgkip27ehrj0081QfafdT/9khAqX8IIjg==", null, false, "", false, "tech43@abv.bg" },
                    { "521fab4e-6fd3-466f-bded-0f05b9111ad4", 0, "4193e97a-8f83-41d1-a278-eccfbf22d971", "tech44@abv.bg", false, null, null, false, null, "tech44@abv.bg", "tech44@abv.bg", "AQAAAAEAACcQAAAAEP4fXGWKLoP9X9mY9JHTreH/cBkFGltVJFeoFuXHypeXfwdtptGmvn3/Hqh2FEqgUw==", null, false, "", false, "tech44@abv.bg" },
                    { "712ebeab-9bb1-4f4d-b021-fdaa45167d9f", 0, "d3b8495c-6ce3-4ac6-a37a-7c43ff658208", "tech45@abv.bg", false, null, null, false, null, "tech45@abv.bg", "tech45@abv.bg", "AQAAAAEAACcQAAAAENgoyj/EW9cQZ3vgO+w/5wjuskinphVRb8G4Bqwsm9gsr1FKo1i22dQB7dP/rB5B3w==", null, false, "", false, "tech45@abv.bg" },
                    { "f8903c4c-8801-4794-b80c-9c448f56dc58", 0, "555da181-0637-4b55-a513-95c22ba707fa", "tech46@abv.bg", false, null, null, false, null, "tech46@abv.bg", "tech46@abv.bg", "AQAAAAEAACcQAAAAEGZzwmJ6gTtzYR7KLKcnp+yb/xLaeWUtUqbBTIeBDv2HChogTTgzBSSgcCxFn2+p/A==", null, false, "", false, "tech46@abv.bg" },
                    { "7c5fcebb-5fc4-4724-8b01-62a70dd2aea1", 0, "3dfe7213-5019-4b0f-9a5a-f7a246ae76a3", "tech47@abv.bg", false, null, null, false, null, "tech47@abv.bg", "tech47@abv.bg", "AQAAAAEAACcQAAAAEFzcps1Xf3GaUHNMWf7S4Ik4VrAnlSL7doJdiBnt1zNfa8lBzA4tu1YgB76QsSn4fA==", null, false, "", false, "tech47@abv.bg" },
                    { "d9042be0-4b13-4bda-9895-d7645990e7e3", 0, "04e14dd6-30b1-48d9-a3c3-bd55512447e7", "tech48@abv.bg", false, null, null, false, null, "tech48@abv.bg", "tech48@abv.bg", "AQAAAAEAACcQAAAAEGCFUOL/5L158X5K2zYcErRcpGGgDwVX1VP3fcBZ39kVSV/Ag6LqaGT+4j0ocL9ekw==", null, false, "", false, "tech48@abv.bg" },
                    { "d00448be-9d84-44b4-92b5-c037a0a5f8e3", 0, "310c5bed-cb33-4015-8c56-0d137ef480dd", "tech33@abv.bg", false, null, null, false, null, "tech33@abv.bg", "tech33@abv.bg", "AQAAAAEAACcQAAAAEHLPs7eEou/DMsYvv5w+qiLxD16ZKaJpvkDNCm2/gXlJZJjRAoodRmYtzz9+hLMDGA==", null, false, "", false, "tech33@abv.bg" },
                    { "d7f90b3a-516a-4374-b094-06054626ef89", 0, "edf748d9-ee03-4309-a23d-6f38bb351d40", "customer76@abv.bg", false, null, null, false, null, "customer76@abv.bg", "customer76@abv.bg", "AQAAAAEAACcQAAAAEAKLngNPdMUZ0Qxgprig8yn1VjVA+SOv74og2p4Gu+nxLKDqh/kK9o1JQX9QStheAQ==", null, false, "", false, "customer76@abv.bg" },
                    { "c16f3d62-b72e-4c70-927e-71ee9154522b", 0, "8dfc805d-c691-49b0-a8a2-c11cf4342992", "tech32@abv.bg", false, null, null, false, null, "tech32@abv.bg", "tech32@abv.bg", "AQAAAAEAACcQAAAAEAgLmAnYbXKcLeezL5BHytOBQGH/YOEzwfW7982ckoSFb50p0NnJFzhzYzW464M1Fw==", null, false, "", false, "tech32@abv.bg" },
                    { "f8b4df11-73a0-46e8-b6db-fcf7ccccf9c6", 0, "2e93c022-35b8-4042-8c1b-6303a214f999", "tech30@abv.bg", false, null, null, false, null, "tech30@abv.bg", "tech30@abv.bg", "AQAAAAEAACcQAAAAEPLMFgU9QqdSCE0sP+MTkOYVDL7Im1B45n2PlqT5V9FNSDlxnWNNJAlhPcqZGHTXjw==", null, false, "", false, "tech30@abv.bg" },
                    { "ffb5b8ca-d86a-454c-93db-31bfa7ccbd2e", 0, "bb2a13e8-4c40-4783-b854-5ad43c1968e1", "tech15@abv.bg", false, null, null, false, null, "tech15@abv.bg", "tech15@abv.bg", "AQAAAAEAACcQAAAAEGhBUbgQ80WIVV1vgzm9/R1nJzhAxypHfVGi7yadoIAeU/pLLud8POpOMeFBpJMNRg==", null, false, "", false, "tech15@abv.bg" },
                    { "72592b47-f04c-4102-ad3f-c9fa198e6c8b", 0, "bb0e47d2-6a7c-452f-aec3-be9a1160a173", "tech16@abv.bg", false, null, null, false, null, "tech16@abv.bg", "tech16@abv.bg", "AQAAAAEAACcQAAAAEAUy1eU8P+I5OM20hhuXEQS9imK3aNm1kxLlOJyFoP7UmOSG0eGsBoYT0ECMtwWkJQ==", null, false, "", false, "tech16@abv.bg" },
                    { "788e73ad-ae79-4df6-a52b-71fd7941cedc", 0, "7da5dd02-35ae-4474-ae14-ea136e36a3d0", "tech17@abv.bg", false, null, null, false, null, "tech17@abv.bg", "tech17@abv.bg", "AQAAAAEAACcQAAAAEIrdvHP9h31WOuBjmdVD6C5wVeOazL7jID+JTwHKkMa/ui0NR2Uv49xHP9BC7Oyxtg==", null, false, "", false, "tech17@abv.bg" },
                    { "c2a5594e-da58-40b0-a3f3-7ed960ce8280", 0, "2edfd549-2122-4415-80ac-3bd0ccecc587", "tech18@abv.bg", false, null, null, false, null, "tech18@abv.bg", "tech18@abv.bg", "AQAAAAEAACcQAAAAELAtkTjaMnRUQdW/xoqtvSr/GCdCIwKdsrvCfkbk+Mt+V3lM8KSfUJ6u5QA8mnpSPA==", null, false, "", false, "tech18@abv.bg" },
                    { "b6d48df1-78de-497b-9b1b-c2904e39cf3a", 0, "b82cbbac-8da8-47d4-8718-ea999c2d424e", "tech19@abv.bg", false, null, null, false, null, "tech19@abv.bg", "tech19@abv.bg", "AQAAAAEAACcQAAAAEP7z7bKJ+QnfRfKcevmvmBqJWHZlx2qysEIrH5uPH3NNKYi6lJ6scgwWCR77qjopew==", null, false, "", false, "tech19@abv.bg" },
                    { "01bb6e49-0350-4d67-8f5b-ab0ab04a0e1a", 0, "fc907d05-ad96-4e36-96cb-0487645efd1e", "tech20@abv.bg", false, null, null, false, null, "tech20@abv.bg", "tech20@abv.bg", "AQAAAAEAACcQAAAAENqbPdZ1xr2y/wy8ARF2crTcV/ZNhgGtVfqRBH6dIBuvIuWpnnUw7+m8nOdbn8NNrg==", null, false, "", false, "tech20@abv.bg" },
                    { "17126fdb-401e-4bb1-93a3-2091e5a7ef9d", 0, "311293c5-30a4-414a-9287-0c69362a2e50", "tech21@abv.bg", false, null, null, false, null, "tech21@abv.bg", "tech21@abv.bg", "AQAAAAEAACcQAAAAENCIusI7/p53WW3XQnf2OvOApNyxqzTLLadUtHACMjo7u2eWgiKmLet8PCjLWs3OJw==", null, false, "", false, "tech21@abv.bg" },
                    { "2cd50383-1140-41cf-a2a4-08952e1bde12", 0, "1c38d76e-9c05-43fe-95a4-10f84ce0048d", "tech22@abv.bg", false, null, null, false, null, "tech22@abv.bg", "tech22@abv.bg", "AQAAAAEAACcQAAAAEJ6ArOSqKzFsfZQUxjALPT/XY+jd7t+bnjgUQykFAzConx0dK0ab8qEYbrque9llmQ==", null, false, "", false, "tech22@abv.bg" },
                    { "30146d61-507d-46a0-8d0a-f00ba7bd6f31", 0, "ab8a4600-2ef0-4042-9f21-346e628ddd9d", "tech23@abv.bg", false, null, null, false, null, "tech23@abv.bg", "tech23@abv.bg", "AQAAAAEAACcQAAAAECXY2s35qcO8kU/ntp/5lnt/s12DicmY+QlW9s30DlaDmy6TXQIJHEzaatubGGOESA==", null, false, "", false, "tech23@abv.bg" },
                    { "5e2e044a-5ee3-458b-aff8-bb26caaefce0", 0, "181c9ba0-60f7-4bb9-89a4-a19fe26f2845", "tech24@abv.bg", false, null, null, false, null, "tech24@abv.bg", "tech24@abv.bg", "AQAAAAEAACcQAAAAECV/XlyjvhTSb2bZ7JdIKXLXV/5cGTRy06vYI/HGl9Y1LJS3MMqKi8lPJsJgUbpXRQ==", null, false, "", false, "tech24@abv.bg" },
                    { "b3284f96-78a4-43e9-add1-7f85c203f82b", 0, "4e104a12-4bee-469f-9120-d67998bb2550", "tech25@abv.bg", false, null, null, false, null, "tech25@abv.bg", "tech25@abv.bg", "AQAAAAEAACcQAAAAEGVKZbJoTq/QipI3iOc9x8nqz9fIuyNZ/mWyb9NozG/0zLEBb41PXufaWpgsJysObw==", null, false, "", false, "tech25@abv.bg" },
                    { "e46a291a-e2b6-4eab-851f-bcd4ef726b84", 0, "193134a7-8e86-4dc3-a97d-5fdf8e873e5f", "tech26@abv.bg", false, null, null, false, null, "tech26@abv.bg", "tech26@abv.bg", "AQAAAAEAACcQAAAAEC0CayC0XJ/MyyrVHq8GZ1VECzeYH+0jD/6Uvr/lTmjbPJar1RhEw2Hhm8BK7LMM2Q==", null, false, "", false, "tech26@abv.bg" },
                    { "9a58ae09-b98f-40ef-bfdb-3ceec1a58999", 0, "fe3839cf-1ad4-4f5e-af5b-61cde30fa69f", "tech27@abv.bg", false, null, null, false, null, "tech27@abv.bg", "tech27@abv.bg", "AQAAAAEAACcQAAAAEAcY+6MQaN7lrYbTirSjgOoBb46f2FmiglF6WFdXrDYAv71NfSZQwp9KgLtU8Vtpnw==", null, false, "", false, "tech27@abv.bg" },
                    { "e737f935-8bfb-4ef6-b7d4-68c648f290da", 0, "cb67cb53-e574-433e-ac14-e3503fff7c30", "tech28@abv.bg", false, null, null, false, null, "tech28@abv.bg", "tech28@abv.bg", "AQAAAAEAACcQAAAAEGCeZFKrqIpWBpMD3oWMcSVNezdXErZtJm/Hbs/nnGaMLufz/otzEyF9mOaJdsf5Dw==", null, false, "", false, "tech28@abv.bg" },
                    { "72e5cb0e-837d-421e-b315-ba43e6ae3cc9", 0, "b0b6587f-3b34-4db8-aa25-ed8d9645f71d", "tech29@abv.bg", false, null, null, false, null, "tech29@abv.bg", "tech29@abv.bg", "AQAAAAEAACcQAAAAECs9UtQXG3/Pj8FoCCLJOf5w/kmY+t55BoQO1qNqAI+Ig9n2uWiCLNb3Orcy/LdNLQ==", null, false, "", false, "tech29@abv.bg" },
                    { "4176b20f-bc55-413d-9708-2df9fc073b90", 0, "653ee27a-5335-4c21-8730-5ce9d729a1ee", "tech31@abv.bg", false, null, null, false, null, "tech31@abv.bg", "tech31@abv.bg", "AQAAAAEAACcQAAAAEBFtf2cGj5FN8qX7/zTi8deZq4ZQAjB9r3IaIaM0WRWlPwf/Ec2k+iwhMc9e7Usypw==", null, false, "", false, "tech31@abv.bg" },
                    { "0068da3f-9f6d-4dfb-8c4f-762ccd73d3d2", 0, "ca5d7b7e-db97-4cb1-ba12-14b63ca1b0cd", "tech13@abv.bg", false, null, null, false, null, "tech13@abv.bg", "tech13@abv.bg", "AQAAAAEAACcQAAAAECXhmlcHq4UD11cSbtC93ebGieMjbi9YSJXTFJEXuaF+cTX54eLhSY6JDK6m17IdKA==", null, false, "", false, "tech13@abv.bg" },
                    { "a8d0fad3-ae95-4556-995a-1a385b25e4a5", 0, "384c31b6-9ed5-403d-9ed2-641385c721f3", "customer75@abv.bg", false, null, null, false, null, "customer75@abv.bg", "customer75@abv.bg", "AQAAAAEAACcQAAAAEL73asuN5N/k/AjySd1ICsodPImNBNR99jdPM+lqobyZBOxpGXDi/OIsVtSF7/NAUA==", null, false, "", false, "customer75@abv.bg" },
                    { "7297afa2-b930-439e-839f-d525628f5ba5", 0, "f38354c1-2dca-438b-9c0e-68976dedc42b", "customer73@abv.bg", false, null, null, false, null, "customer73@abv.bg", "customer73@abv.bg", "AQAAAAEAACcQAAAAEGfe8ZhlyMoUaESZ5dXOkcRljBkpSndY1xtTl8D+/TRm6JuwIUaNg6gNaIJZy/MMzw==", null, false, "", false, "customer73@abv.bg" },
                    { "1d16af57-4358-4b76-bb1e-4559b7e9bf4d", 0, "c21d3f24-71f5-4614-b467-83c374d6ab3a", "customer19@abv.bg", false, null, null, false, null, "customer19@abv.bg", "customer19@abv.bg", "AQAAAAEAACcQAAAAEJZwzGKrOZawwclEUv6WKr1WFt81LRZDrNKykwsytTx0fP+w0/YPG8REOG6fOUmggg==", null, false, "", false, "customer19@abv.bg" },
                    { "223f5c13-2feb-45fa-849b-bcd26c640367", 0, "8f46adec-99c5-4cf0-a0ce-9dfc13a76484", "customer20@abv.bg", false, null, null, false, null, "customer20@abv.bg", "customer20@abv.bg", "AQAAAAEAACcQAAAAEOHYJ9VD5Y5epBB7HQlS0Y9k1xwErJYp4JWB6kFuo6WMuzFDiB44d8d8l+cuaKU8hg==", null, false, "", false, "customer20@abv.bg" },
                    { "1e3d9cd7-9f91-4fc4-b045-c393d811bcd3", 0, "9ca7dc59-04c6-48ce-bf74-66d0b4f4d4fa", "customer21@abv.bg", false, null, null, false, null, "customer21@abv.bg", "customer21@abv.bg", "AQAAAAEAACcQAAAAELBXL5x28ZWflw+ERYNZ0HVUHh6CxkegRLCYzsCCK9cozqNlBf32YEY/u5pdnDmzag==", null, false, "", false, "customer21@abv.bg" },
                    { "1e14374b-fbc5-4359-ab4c-778e040da512", 0, "c4842176-29e8-41d8-87ca-edf4754e2d88", "customer22@abv.bg", false, null, null, false, null, "customer22@abv.bg", "customer22@abv.bg", "AQAAAAEAACcQAAAAEKyVT+OIsMGp8wynqILeakbgX7oLePpuzxDvDh1mg98dnM5AHeJe41c0MMZBcOTNQw==", null, false, "", false, "customer22@abv.bg" },
                    { "4cdce805-419f-4338-aa45-4ac586e5aa42", 0, "bf3be954-4c5b-44ed-87f9-af9189a5733a", "customer23@abv.bg", false, null, null, false, null, "customer23@abv.bg", "customer23@abv.bg", "AQAAAAEAACcQAAAAEA890RGxhoOkKs35+SwVOpPEJ2DpHAAbSSAuM03OHKlWEWjE8dYWt07mzVi0UWxAPA==", null, false, "", false, "customer23@abv.bg" },
                    { "ef840b88-0f30-47f5-b45b-c12531716f88", 0, "6d499e92-30a1-42d9-9e16-2f20299ad7ed", "customer24@abv.bg", false, null, null, false, null, "customer24@abv.bg", "customer24@abv.bg", "AQAAAAEAACcQAAAAEKuq/rXRektKxnzq1HdJUFMBpumOTfWAug9mO0L+Wj5kOC38lpKOyysQIOFsq0ldBQ==", null, false, "", false, "customer24@abv.bg" },
                    { "0b5724c2-81b8-4221-8d6e-078443d4d6f7", 0, "a4bf936b-3dc8-4c3e-8108-f535fa6dbb73", "customer25@abv.bg", false, null, null, false, null, "customer25@abv.bg", "customer25@abv.bg", "AQAAAAEAACcQAAAAECbw7UU3axbTtGenL8TZ5tu870xkecnPvRzeA8cvsh3NRdG4DOYq6XknNn84SRvKwg==", null, false, "", false, "customer25@abv.bg" },
                    { "6c71fcb8-c422-41b9-8d73-d7bcae113665", 0, "7f23e70c-596f-462c-b2f3-90ca4c48cc5a", "customer26@abv.bg", false, null, null, false, null, "customer26@abv.bg", "customer26@abv.bg", "AQAAAAEAACcQAAAAEH7AhfLAAa1+JUyHEHBl1Qv63+ZXCRmpCCwyqkjfy3INNyPM9wgzxfr1OIGi8ducow==", null, false, "", false, "customer26@abv.bg" },
                    { "a0a4a36a-2b6c-4e82-9037-fbef84482a17", 0, "21e68954-d54a-4ddf-a1ce-b5d65a56e3a7", "customer27@abv.bg", false, null, null, false, null, "customer27@abv.bg", "customer27@abv.bg", "AQAAAAEAACcQAAAAEDC9e9QEmydv6XEim45Af265viCGz6akxlWKCpY6EfJHM9MFJTRyuzzdYCqzICrf3w==", null, false, "", false, "customer27@abv.bg" },
                    { "028a23cf-80ea-4951-a173-57784964a8da", 0, "7a2ea3dd-41e8-4234-9310-97dd78cd5f3c", "customer28@abv.bg", false, null, null, false, null, "customer28@abv.bg", "customer28@abv.bg", "AQAAAAEAACcQAAAAEF+LhuBGyElO4x8maLwqAmVERUtZKxegYX2qWTUAeKsvAJWsvyuGoZKwKabg1uDIAg==", null, false, "", false, "customer28@abv.bg" },
                    { "9f0bce34-bb0f-4fd1-8963-4b8a671b9a7e", 0, "84defd39-be1f-4866-8049-a945988fc6d4", "customer29@abv.bg", false, null, null, false, null, "customer29@abv.bg", "customer29@abv.bg", "AQAAAAEAACcQAAAAEFQnC1ToLeHm9YbJUg13wtRGewxhXpYn7LpBUM2ctJkZ0w4JAQp6atMnki5WUIC0vA==", null, false, "", false, "customer29@abv.bg" },
                    { "92d9039d-5ebf-489f-8d6f-074102c8d397", 0, "d65315b3-d5e1-4807-a48b-93da15171524", "customer30@abv.bg", false, null, null, false, null, "customer30@abv.bg", "customer30@abv.bg", "AQAAAAEAACcQAAAAEAP0GPQELQI4Sr6sjtxiEKJ9VfwFqAhgtSrAM3ddiZIgkf/aAQLUZBtP8jrxBhLETw==", null, false, "", false, "customer30@abv.bg" },
                    { "7f1124cd-b826-4fe6-a55a-0927fa51eb9b", 0, "215b4edd-6c5d-446d-9de7-e69528ad4b57", "customer31@abv.bg", false, null, null, false, null, "customer31@abv.bg", "customer31@abv.bg", "AQAAAAEAACcQAAAAED366GBtGH7XK81ZksdUDKolr2STCnB2RNEOAknmVKVWdHIwJcfEH5xWrgedDI6D7A==", null, false, "", false, "customer31@abv.bg" },
                    { "9ce29c1d-f6f6-4d3a-ab12-9bfd89cfb917", 0, "208c141d-556f-4134-8c3a-a7cace2d07e6", "customer32@abv.bg", false, null, null, false, null, "customer32@abv.bg", "customer32@abv.bg", "AQAAAAEAACcQAAAAEJhlaZES9HuAd3ChGpryMh2GYM6LtNQgwDvAd0iz/s1n6GFVwoZbt2IirZOAeTy2Kw==", null, false, "", false, "customer32@abv.bg" },
                    { "27abfd3d-50bc-4a54-b50a-6f50ca2c93c6", 0, "a12d4d27-07ef-4b34-8d6e-644507618e84", "customer33@abv.bg", false, null, null, false, null, "customer33@abv.bg", "customer33@abv.bg", "AQAAAAEAACcQAAAAELfXsU1ABSfljUBNicRObhEM/QVze77r4+StgyIhdKP5D1X8qcpizTs7Pbm7DDvefg==", null, false, "", false, "customer33@abv.bg" },
                    { "1090a66d-33ee-4154-ab8b-578e5ee0b400", 0, "e4d0747a-ffd1-41be-a23b-95a36aad69c5", "customer18@abv.bg", false, null, null, false, null, "customer18@abv.bg", "customer18@abv.bg", "AQAAAAEAACcQAAAAEAYwVHFCIznyUOBItC83AN8bTQ2YKLYIAdZZ6jDqrv2t7UR6XkV3RpE8Z9Nxyma5bg==", null, false, "", false, "customer18@abv.bg" },
                    { "ec2dffa2-0d15-4707-ae31-16602b91c0fe", 0, "9a0bfb6a-a900-4baa-bb47-c0a70c964615", "customer34@abv.bg", false, null, null, false, null, "customer34@abv.bg", "customer34@abv.bg", "AQAAAAEAACcQAAAAENijqXQHtrpZOmXo2XZ8x+l/BJDqEw+pjiQA3CwQgCCBpt9niBJenSMVC4KYDHGl3Q==", null, false, "", false, "customer34@abv.bg" },
                    { "7e4afd22-76c1-4275-8d11-6969322f6cf2", 0, "a31021f4-b6f3-4e4f-ac63-3c1acc0ebc7d", "customer17@abv.bg", false, null, null, false, null, "customer17@abv.bg", "customer17@abv.bg", "AQAAAAEAACcQAAAAELEZLeTHmQoZvu7AkYm27UfeafFsLkVtclwtSP7y68NY4PnpxWYGGSrxIw40Q+fwAw==", null, false, "", false, "customer17@abv.bg" },
                    { "aedb5efc-17ae-4afb-b0f4-430c856141c1", 0, "af79f81f-7b5a-44f3-9de0-bf61846eabba", "customer15@abv.bg", false, null, null, false, null, "customer15@abv.bg", "customer15@abv.bg", "AQAAAAEAACcQAAAAEBECSC3QG7ymQis3QbHtKWVEWM69wZeXjwlRe95YNWK5eEKfdqOZIwDqfneWKMccYQ==", null, false, "", false, "customer15@abv.bg" },
                    { "83b64cbc-19e1-4d05-b3ce-07a3ae9f918b", 0, "392da6b9-9632-42ec-b40e-aae76d5b8b65", "customer0@abv.bg", false, null, null, false, null, "customer0@abv.bg", "customer0@abv.bg", "AQAAAAEAACcQAAAAEIGrjfVmqEKiCUi52BA5eb1QeryOojpA1JXgCiefxSC4rrAZBroOblCbVCqpd7wtuw==", null, false, "", false, "customer0@abv.bg" },
                    { "36bc6df0-b093-4c81-956e-14a801845cbb", 0, "96c4b219-30d9-410f-9116-869e4fe58fae", "customer1@abv.bg", false, null, null, false, null, "customer1@abv.bg", "customer1@abv.bg", "AQAAAAEAACcQAAAAEBL0zpETVJetobN0iR8Jwd0fmY7KC/8EErTzZSwlPFCIaVJAvRVnG1QFVhAS1jc8nw==", null, false, "", false, "customer1@abv.bg" },
                    { "c5f81580-cb48-4681-a296-6de1b1a969ce", 0, "1dc85345-1083-4172-b6cf-331c4dd03bdc", "customer2@abv.bg", false, null, null, false, null, "customer2@abv.bg", "customer2@abv.bg", "AQAAAAEAACcQAAAAENjF9vFPZtAKmOXYA2IUO+/wdQT7CznnVuOfJnKns63e38e+ENewV+yjA1ZG3BQqHA==", null, false, "", false, "customer2@abv.bg" },
                    { "3d0ede8f-12ae-452f-9693-db650ffbb604", 0, "9058e77d-e3e6-4955-a303-78bbed00f99d", "customer3@abv.bg", false, null, null, false, null, "customer3@abv.bg", "customer3@abv.bg", "AQAAAAEAACcQAAAAEFzptbSDsrVvHb7YYWmhcDDZdFk8jMKSrufVtftWneqkIgJYp8RjFlBG4G8Z2VVe0Q==", null, false, "", false, "customer3@abv.bg" },
                    { "7eb9a636-ba64-4729-9955-68b4cea86451", 0, "a4613431-6186-4b18-bf89-b50aa7c3627f", "customer4@abv.bg", false, null, null, false, null, "customer4@abv.bg", "customer4@abv.bg", "AQAAAAEAACcQAAAAEPTmm+2BLo6XIbj+neQEJOvtE4Ft0u9c6WswgxgZIrmx1rd9+qTfpgOtxVDi4AfTMg==", null, false, "", false, "customer4@abv.bg" },
                    { "cceb2370-5d86-4ace-83b9-e62f461ea64d", 0, "51dc57dd-a95c-4648-9d02-8532aea165a1", "customer5@abv.bg", false, null, null, false, null, "customer5@abv.bg", "customer5@abv.bg", "AQAAAAEAACcQAAAAEKUejuRh3YaAuZdidEUh/x6qvMla6h6gD+jMaI+1WEHIePfQHgy+o20+w+fWBRdm0Q==", null, false, "", false, "customer5@abv.bg" },
                    { "fc31ed89-55ca-454d-859c-24b2e69a6b94", 0, "f31a1d65-165d-4e0a-8c4a-299db7b5d03f", "customer6@abv.bg", false, null, null, false, null, "customer6@abv.bg", "customer6@abv.bg", "AQAAAAEAACcQAAAAEPeTAqk5eQbNtVyfMdmjTKSeg8zUF3EuuPw4su/pgrE+0d8Bp5jwS3+Co96pOlLfag==", null, false, "", false, "customer6@abv.bg" },
                    { "fce41c41-f3f7-495f-bc6d-2feeb63fd9ba", 0, "8d82de4e-2cdc-4f08-b9ed-d25384348e8f", "customer7@abv.bg", false, null, null, false, null, "customer7@abv.bg", "customer7@abv.bg", "AQAAAAEAACcQAAAAEA150HTGw5NCvRHcCwd/mfp3uYv3x8HVSoLVwEauXMUmTTQizEIjdwZ0AC+jrO+2ww==", null, false, "", false, "customer7@abv.bg" },
                    { "e227db7d-2fd8-4796-8d0f-66a043764421", 0, "808f4291-bea7-487c-a73b-a019c26b7532", "customer8@abv.bg", false, null, null, false, null, "customer8@abv.bg", "customer8@abv.bg", "AQAAAAEAACcQAAAAEIf8XLfbjz1V4wE70s0f/D1AQCHoe7YInSjDWH8/XmfXF4kPhQuKNWDQyHjnxqaobA==", null, false, "", false, "customer8@abv.bg" },
                    { "f041fbd0-119f-4002-ac26-1a2e97e5849e", 0, "1ee9ef33-af62-4c43-aedc-12f45a09e13c", "customer9@abv.bg", false, null, null, false, null, "customer9@abv.bg", "customer9@abv.bg", "AQAAAAEAACcQAAAAEKs4SXdWD6+w79Tq6z8o6jnUpBCyYgTsU9NX+EAtfFybj5O3lxna00EXJ/lJaWmysQ==", null, false, "", false, "customer9@abv.bg" },
                    { "1e0c3e7b-7682-4b45-97be-81acf58dc77c", 0, "0f23a9d9-b2db-4d3f-a857-87eab3aeda78", "customer10@abv.bg", false, null, null, false, null, "customer10@abv.bg", "customer10@abv.bg", "AQAAAAEAACcQAAAAEMFLoEae/DtqDyVeMHRLomw1LhlsjOpKDszoIBbgfyrR+Zi18BgaBeOfBrJi2Vdbpg==", null, false, "", false, "customer10@abv.bg" },
                    { "5d4cd492-05a6-4207-96bc-b133ce0154f8", 0, "003d2dc2-134a-4e1d-9baf-42b9a0a9f2a9", "customer11@abv.bg", false, null, null, false, null, "customer11@abv.bg", "customer11@abv.bg", "AQAAAAEAACcQAAAAEO+nlMk4PnqoT/PMKaDcXgu2qivS7UH3O6ZZTn6PGaT6g4uCz+ThcAqiwBNxTuHxLQ==", null, false, "", false, "customer11@abv.bg" },
                    { "c72defd7-3b71-4521-9180-ee1004f14495", 0, "79ad027b-20b0-4472-a200-b2980d70a5d9", "customer12@abv.bg", false, null, null, false, null, "customer12@abv.bg", "customer12@abv.bg", "AQAAAAEAACcQAAAAEN35dTGLvJkoxiwv4hMUT2pax37YEm5kJFx3ycQrJ6aNSk9aBLGR5P1MQItkYaY6pg==", null, false, "", false, "customer12@abv.bg" },
                    { "9b74c05d-d736-4d96-bb57-66a4cbcd6858", 0, "782720f9-fa7f-4841-8c59-001d1825855a", "customer13@abv.bg", false, null, null, false, null, "customer13@abv.bg", "customer13@abv.bg", "AQAAAAEAACcQAAAAEOncX+qzKpzyOxQdUguKECDjJ7vb0L/CtDil50yNTQj6KSwcG4AfUp+IJ/ez7spulQ==", null, false, "", false, "customer13@abv.bg" },
                    { "5a622559-61ee-4d6a-9803-cb04ef588112", 0, "9836d5cc-8c36-4e50-bd3e-693b2080ac29", "customer14@abv.bg", false, null, null, false, null, "customer14@abv.bg", "customer14@abv.bg", "AQAAAAEAACcQAAAAEEEB+8HaSUBMgDFbHl98RNU6oQzwMuuw/hbkBDaT0OXyvwykrufFeojxjDTxEYtzKw==", null, false, "", false, "customer14@abv.bg" },
                    { "9101f064-bce4-434f-94c9-d4f7f4c02cd8", 0, "40951551-0d6e-49ae-928a-e93d3e6ceff8", "customer16@abv.bg", false, null, null, false, null, "customer16@abv.bg", "customer16@abv.bg", "AQAAAAEAACcQAAAAEIm2IIgKVF+I76F+zXBEAtRaSszweIUh/0EW8Idfs+YeUX4nfcreAQK/tI4VUb5skA==", null, false, "", false, "customer16@abv.bg" },
                    { "0aef5cce-f2d0-48e0-bb8f-75e3f349cd41", 0, "fb4eafe8-8c10-4724-b763-1a9b5f930ad9", "customer35@abv.bg", false, null, null, false, null, "customer35@abv.bg", "customer35@abv.bg", "AQAAAAEAACcQAAAAED4U3cSq+EF89loNbl9qFxbRvlntPdjXqpqycLD4wf2i6KBweP7NUDJ071hkjEW6PA==", null, false, "", false, "customer35@abv.bg" },
                    { "4fb717c8-d2c8-43d4-b6b1-dc401793f136", 0, "2cbe3113-23f8-4ac3-9122-f6925610f3e5", "customer36@abv.bg", false, null, null, false, null, "customer36@abv.bg", "customer36@abv.bg", "AQAAAAEAACcQAAAAEDFftlTjQ6V142DDFaoJHSgdpJgsabSxBREyf8+HlhcDfmmVHhR269k9d06UK4pQmA==", null, false, "", false, "customer36@abv.bg" },
                    { "8c2f4f6b-48a5-46a0-ac96-f90d8214eeb9", 0, "c621d12e-4398-4442-9535-3b648b394a55", "customer37@abv.bg", false, null, null, false, null, "customer37@abv.bg", "customer37@abv.bg", "AQAAAAEAACcQAAAAELSLfJ0GujVZpagEaABhgKOtMbr/nHMaEWxscqJAA52tQ8O1EsO9N5f1+Vuv+7fOeA==", null, false, "", false, "customer37@abv.bg" },
                    { "5b0b4f44-c7f0-4a72-87d9-ae7b4cbc4ca7", 0, "0ffb2715-6e51-4be3-b81e-4518b5e673fb", "customer58@abv.bg", false, null, null, false, null, "customer58@abv.bg", "customer58@abv.bg", "AQAAAAEAACcQAAAAEIh/3SNL+QwwPu3MUWbb+PUGyc+AyghKOev+QPw/pqUwqVVjG/BNduH1eNyY4VUsaw==", null, false, "", false, "customer58@abv.bg" },
                    { "4f5bc153-53d1-4de2-a742-b09e664f8dc3", 0, "ec299e1f-49f1-406a-a561-fa4b78943836", "customer59@abv.bg", false, null, null, false, null, "customer59@abv.bg", "customer59@abv.bg", "AQAAAAEAACcQAAAAELaD8w0t06zHrcR4pG3QnTsTPXQHCPmuhCv2nUjXYvx90PDO9dM1D5vIM7Dt/1CiEQ==", null, false, "", false, "customer59@abv.bg" },
                    { "29d7126a-8ffc-42b7-b318-c724952d2e5e", 0, "32cbd5b5-c8bb-4086-b942-4391a93757c2", "customer60@abv.bg", false, null, null, false, null, "customer60@abv.bg", "customer60@abv.bg", "AQAAAAEAACcQAAAAEFl3viFsh/JHyBhKS3EEjsYg4HddqxRM9AwwZ5jzuhK2oXqoAVYUSH7Z7HMqjsUl0w==", null, false, "", false, "customer60@abv.bg" },
                    { "6c0e5e90-620d-4750-9cd6-97ce877b2be1", 0, "a8a12ef3-4a16-4eb2-9572-8672190293a9", "customer61@abv.bg", false, null, null, false, null, "customer61@abv.bg", "customer61@abv.bg", "AQAAAAEAACcQAAAAEOwKQODK/o2byEpglznaz9ghatgG+bZ5dwUHM4aL79ryPIRtnBWO0B0SFOEObEe66A==", null, false, "", false, "customer61@abv.bg" },
                    { "b4e666f0-495e-427a-9a12-53cbff05186f", 0, "884e6ffd-9fab-4546-b145-deddcd4b4360", "customer62@abv.bg", false, null, null, false, null, "customer62@abv.bg", "customer62@abv.bg", "AQAAAAEAACcQAAAAEMbITBPKgTWBBXGGlBv/V0Yi0YFmZEn4i/657xxYogiXGFhzsDQl49jyc4zhCZOxCQ==", null, false, "", false, "customer62@abv.bg" },
                    { "c8a9d770-7875-4494-9b53-2d39b43d78b9", 0, "efb70f7e-bf17-42aa-8abc-c20a692a80c7", "customer63@abv.bg", false, null, null, false, null, "customer63@abv.bg", "customer63@abv.bg", "AQAAAAEAACcQAAAAEK9e0gTUABT6H8bpcUHe0f1IZoecuXMQ2rY2B7TC5H4AO1iNYQOb/dqVf8IHPDCrww==", null, false, "", false, "customer63@abv.bg" },
                    { "10a3bb82-5716-4edd-944c-f4578839eb9a", 0, "6949fe01-0d32-4236-93c2-35cadc5d52ee", "customer64@abv.bg", false, null, null, false, null, "customer64@abv.bg", "customer64@abv.bg", "AQAAAAEAACcQAAAAEBQMw3cSROhI0XqYXjNsDVfziGZzC9pfoOoJKHZkqs09Pm+auub2VyA+SacuikIaTw==", null, false, "", false, "customer64@abv.bg" },
                    { "bf96c536-730a-4618-8a51-b75236f3ab9d", 0, "cb1d46fb-0aa3-455d-a559-a624ba882557", "customer65@abv.bg", false, null, null, false, null, "customer65@abv.bg", "customer65@abv.bg", "AQAAAAEAACcQAAAAEMErBDZCQ1BquRyoL3ZUUqcseK7C1v357REMN8Aj7W4gF2wC/DcWZFdviAZzAYQMHg==", null, false, "", false, "customer65@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "af0f05d2-cfbe-4c1d-b32f-9691a8b9767a", 0, "4be68179-73c9-4792-b750-ebef462563a9", "customer66@abv.bg", false, null, null, false, null, "customer66@abv.bg", "customer66@abv.bg", "AQAAAAEAACcQAAAAEFb+taLtolYBVfrRACmwja9Mn8DywdzRv7jDXryZIx0GfsGdNelpy0mGHroYmP11IA==", null, false, "", false, "customer66@abv.bg" },
                    { "ab3e8869-cdc0-4ca0-8dd2-9e86aaa61956", 0, "04bac2d8-b070-4f64-98ce-b60a557fea36", "customer67@abv.bg", false, null, null, false, null, "customer67@abv.bg", "customer67@abv.bg", "AQAAAAEAACcQAAAAED/kdw8fp8R8lpYUlAzo64efohpfn/2ByM2aM2lA+rBeIHxLwY0i+/8urwmefFXBgQ==", null, false, "", false, "customer67@abv.bg" },
                    { "b93b6e28-4065-467a-b0d0-6bd3557c3622", 0, "fcd3bcf6-3609-4c61-a666-417906620004", "customer68@abv.bg", false, null, null, false, null, "customer68@abv.bg", "customer68@abv.bg", "AQAAAAEAACcQAAAAEHt/RMP3Yrr3XE7Uyfem3Tcv6Z1ginbQffXAuq0gf6mYq66JDP0DSX4srZ/VfxqEZg==", null, false, "", false, "customer68@abv.bg" },
                    { "e6411dcb-5115-4fc4-85cf-1f9033112ed9", 0, "acae7dd3-a86f-491c-8b43-3a8386f5009a", "customer69@abv.bg", false, null, null, false, null, "customer69@abv.bg", "customer69@abv.bg", "AQAAAAEAACcQAAAAEDxjYD2OnidY7huvzWSlpHESiQfeTcNHtgCRiK3CDpIirLfssN5JXB14GQMjwfLiuQ==", null, false, "", false, "customer69@abv.bg" },
                    { "2c12c3d4-5de4-4385-9a70-1231c47630b0", 0, "3d8243b6-fabb-4153-a2a7-cbd740dbcb8d", "customer70@abv.bg", false, null, null, false, null, "customer70@abv.bg", "customer70@abv.bg", "AQAAAAEAACcQAAAAEH+7LN7xZ4monpAeJsebRlL9lXN01wIxXGlPnYOTtFZuEynsu6448+MOHekJNJ9Z4w==", null, false, "", false, "customer70@abv.bg" },
                    { "44466744-53c3-41e7-a701-e831743d4855", 0, "ffd66ad3-bf14-4114-ba39-31c3b026307a", "customer71@abv.bg", false, null, null, false, null, "customer71@abv.bg", "customer71@abv.bg", "AQAAAAEAACcQAAAAEDVGvdvCby3bYANR+K6dscma9BFlDAri9Cv/acRppeyJWYR23ipRhVVUXZE3P0OAzw==", null, false, "", false, "customer71@abv.bg" },
                    { "d4148ccf-2446-445a-a382-870efe500389", 0, "9f9cb520-779c-4d6a-9479-286c7c9d6c2c", "customer72@abv.bg", false, null, null, false, null, "customer72@abv.bg", "customer72@abv.bg", "AQAAAAEAACcQAAAAEHYkcf2TpYN+DdjsLFbUuETTn7JtGnfrkjoXNoq/Vmb7818FtycbGVaMbtEUFWJ1Ug==", null, false, "", false, "customer72@abv.bg" },
                    { "74f93c38-b2cd-4bfc-a49c-7aa49159e9ab", 0, "d2ed6c8a-d6e3-4169-b3d5-54b05ab0393e", "customer57@abv.bg", false, null, null, false, null, "customer57@abv.bg", "customer57@abv.bg", "AQAAAAEAACcQAAAAEOzJsTJ3xCivehHrWQna2viIKlxTSzMfw/yN9ksfdv8EZJu4n1hXLyq6mWJ2pMCk5Q==", null, false, "", false, "customer57@abv.bg" },
                    { "37f5bbe3-64d1-41cc-bd77-58d33daa79ad", 0, "223d3524-aead-462b-9c07-efb5180b966d", "customer56@abv.bg", false, null, null, false, null, "customer56@abv.bg", "customer56@abv.bg", "AQAAAAEAACcQAAAAELECnCtsndG6CL/XxCcGMi3T3K9CthGclPo8iJd1V9viEumpZKzHQWJdgs1ZjvhfDg==", null, false, "", false, "customer56@abv.bg" },
                    { "22f27049-b716-432d-b240-54be401feb54", 0, "029f4a2e-7981-4ce0-b319-0adcf9da4594", "customer55@abv.bg", false, null, null, false, null, "customer55@abv.bg", "customer55@abv.bg", "AQAAAAEAACcQAAAAEKo/iUIeqLIcSJadgBrN/F9v5AZYZ0uHh6zxykdsHyweCgoS0IbzUrzokBdOSgq6Lw==", null, false, "", false, "customer55@abv.bg" },
                    { "057bbdb9-8772-44a9-891d-0b0b953a3756", 0, "5682df20-e930-48af-8548-a4e6423271d3", "customer54@abv.bg", false, null, null, false, null, "customer54@abv.bg", "customer54@abv.bg", "AQAAAAEAACcQAAAAEIgNrIME060Qxo+k7ZsGdFVrjvAWrtC3Mym04X3j2dkimS4xMmuiQr+RD9xwccGHuA==", null, false, "", false, "customer54@abv.bg" },
                    { "0e51298e-eb7e-4793-a5ae-a3009d134a57", 0, "e37b38d4-c54f-4f69-a24c-0e1190cd603b", "customer38@abv.bg", false, null, null, false, null, "customer38@abv.bg", "customer38@abv.bg", "AQAAAAEAACcQAAAAEOsFQKFDqb+71bZbKMCqD4P62Acpt+tYDYTsHMejIC/jBEbUJFMIDWhZgfxAYf0dOg==", null, false, "", false, "customer38@abv.bg" },
                    { "e7849b82-081c-440d-a9ff-54bedb29b1a0", 0, "66782d17-1e63-48dd-8b89-f50e81bea34a", "customer39@abv.bg", false, null, null, false, null, "customer39@abv.bg", "customer39@abv.bg", "AQAAAAEAACcQAAAAEA5RBAW7OEz0G3ZJN3reUNnTn1fti/E/VWzYbSJyBWguGf2t+1Gka9UG9HNFYNimLQ==", null, false, "", false, "customer39@abv.bg" },
                    { "3826c217-8008-4ec3-a915-0bd456b27ee8", 0, "3ce1c943-af51-49fe-8893-43f804da1d8f", "customer40@abv.bg", false, null, null, false, null, "customer40@abv.bg", "customer40@abv.bg", "AQAAAAEAACcQAAAAEHkhk1OgTqAIFOh/wqnZG3+EvfvwnV3zYNLc5N2x4qm7nlejQLfoiTCVH2deQO5o1w==", null, false, "", false, "customer40@abv.bg" },
                    { "85ac7cc7-d9f6-4f34-95c6-17aee4bc5950", 0, "d2782f51-a9d8-46a2-87ff-782c4ed5c1af", "customer41@abv.bg", false, null, null, false, null, "customer41@abv.bg", "customer41@abv.bg", "AQAAAAEAACcQAAAAEJcME+IcyQ+gquISuMr/+Hq+srkQ2W6otWHFpdCIeKCcBRKFTPEEslLEeWCcnf68KQ==", null, false, "", false, "customer41@abv.bg" },
                    { "eee9fa9f-53a9-443f-9285-85e41a291431", 0, "d0677b20-3377-4429-be3c-37a4d7bdd7a2", "customer42@abv.bg", false, null, null, false, null, "customer42@abv.bg", "customer42@abv.bg", "AQAAAAEAACcQAAAAEFRA5U8RRGlp50KYmgPlIalFG2fP461qkFNcKSK3VmHeTQl9n6a0wAFSwt+Vu+Mang==", null, false, "", false, "customer42@abv.bg" },
                    { "0d0bde24-b658-430c-8c6a-7590c9e2c746", 0, "01d01739-d7c3-4423-a39f-aee6e2dce7db", "customer43@abv.bg", false, null, null, false, null, "customer43@abv.bg", "customer43@abv.bg", "AQAAAAEAACcQAAAAEPPv4SnoB0Mdn7qU2UX6H9oWbjZUi0px+x9wGEe5bHhkY5dMf077Q7GmK4LdSFV+2g==", null, false, "", false, "customer43@abv.bg" },
                    { "3c7f6fe3-b933-4993-821f-1680394ddcf8", 0, "ca25948b-d14f-43e0-b7f0-423006225441", "customer44@abv.bg", false, null, null, false, null, "customer44@abv.bg", "customer44@abv.bg", "AQAAAAEAACcQAAAAELJ2lAVXl2Jcxijiixs8nKurLsMLN/CcGmUe/w9U2MW8RIbHWyyBp3pe00k6ohVsTw==", null, false, "", false, "customer44@abv.bg" },
                    { "282f0422-bafc-479a-b0bd-3ae88ebe648e", 0, "926dc778-48fa-4777-83c5-067a1752d744", "customer74@abv.bg", false, null, null, false, null, "customer74@abv.bg", "customer74@abv.bg", "AQAAAAEAACcQAAAAEBVn+1k26XSrEfEwaGesMVNSHs4OCHV8cFeUwILsclNkZJUqrv3W5yR09HL/kHt+3Q==", null, false, "", false, "customer74@abv.bg" },
                    { "c5ae6377-2e4e-4aaa-917b-76ce3708a074", 0, "32d35c4f-4691-4eda-bb35-71e24d182302", "customer45@abv.bg", false, null, null, false, null, "customer45@abv.bg", "customer45@abv.bg", "AQAAAAEAACcQAAAAEPo/wYEfM440DorFgixriRG9UWPqzFMl8qQ9mN16At7OmhvCltTxrJPLdnnlgqep3g==", null, false, "", false, "customer45@abv.bg" },
                    { "a81bd685-4f8d-4ae5-9a56-4eaee4d526f8", 0, "5a4f79a2-e790-430f-80f7-0cd4873f2351", "customer47@abv.bg", false, null, null, false, null, "customer47@abv.bg", "customer47@abv.bg", "AQAAAAEAACcQAAAAEHtds4gjXI/vL/zZd1HT2dS7ullZty7DR4Dwq2EfFMXAIpaCAydaxg0ZJVzNU1sf/Q==", null, false, "", false, "customer47@abv.bg" },
                    { "9f593bba-2ab3-4913-8459-9bdadd0d98c3", 0, "0fd99808-6865-482e-b425-ebaaf3a2c1d8", "customer48@abv.bg", false, null, null, false, null, "customer48@abv.bg", "customer48@abv.bg", "AQAAAAEAACcQAAAAEEBnKMatI2hgXhpM2cm2wylvflyfnvzH4gbexVXYJloB3Rjjz9Qi9pMPXl1086nUAQ==", null, false, "", false, "customer48@abv.bg" },
                    { "98643520-3698-4347-8f45-e4ad5103bfbf", 0, "ec6f5f0d-a142-4505-9402-12fc8184e913", "customer49@abv.bg", false, null, null, false, null, "customer49@abv.bg", "customer49@abv.bg", "AQAAAAEAACcQAAAAEJbmxYV3b7+BIbO3lx5sImS0ShvsywVgaMfSzxQk19P4k2VBzcqSZM4KS4BbFEFs3g==", null, false, "", false, "customer49@abv.bg" },
                    { "27dabaa6-5b82-49bf-8c31-3bc7a151cb09", 0, "876b79eb-15cf-481a-b710-3a7f20c37566", "customer50@abv.bg", false, null, null, false, null, "customer50@abv.bg", "customer50@abv.bg", "AQAAAAEAACcQAAAAELau7D2nVs99MxjVHmRi2ZYKSqmTzkgkWifqm3uu4SrCW+QDNk8PyHseIu3aggS/tA==", null, false, "", false, "customer50@abv.bg" },
                    { "ac2c5198-9d88-44ac-b0a9-d8546379ff0b", 0, "7402d110-1d9e-4c98-811c-ae651ab4cbcf", "customer51@abv.bg", false, null, null, false, null, "customer51@abv.bg", "customer51@abv.bg", "AQAAAAEAACcQAAAAEIBj7TkUNrsn7yZanK4oiEVOAe7Yoqby4XxXE0ZvmpMjUAvbmnJl4oTCEuGtQ3aeNA==", null, false, "", false, "customer51@abv.bg" },
                    { "459f38b5-f368-4653-9248-eedcfd35529d", 0, "90c7c9d7-15fa-4852-9ace-0833c37df9cd", "customer52@abv.bg", false, null, null, false, null, "customer52@abv.bg", "customer52@abv.bg", "AQAAAAEAACcQAAAAEFXgM/2wjCaMFwuElZ5/SZ3xyE5NnOVD59LmyeHGCmpWiCIknFHa3OgXMjc5yrzKGA==", null, false, "", false, "customer52@abv.bg" },
                    { "8f73e65d-e662-454d-9008-1309412fedec", 0, "81bad99e-1015-461f-90ad-3d47bc6b5ba5", "customer53@abv.bg", false, null, null, false, null, "customer53@abv.bg", "customer53@abv.bg", "AQAAAAEAACcQAAAAEDOaEZP3UwC8JyKN+WWd9DA78Er0KI6zM2i17SKcdaIJSXV2XptDODemkGGzgIwUsA==", null, false, "", false, "customer53@abv.bg" },
                    { "a2bd25dc-d133-4080-ba1c-f84d1831de33", 0, "cda55ab2-efa7-4943-b72d-bed39b4d3c9d", "customer46@abv.bg", false, null, null, false, null, "customer46@abv.bg", "customer46@abv.bg", "AQAAAAEAACcQAAAAEOTbqmCoTLIGrhe+4Z1Ylx9Me5rBc1kQWXg/egCBczLBvgj4g9xkks5dHMmGW5/iVA==", null, false, "", false, "customer46@abv.bg" },
                    { "cb9a0d10-db30-44d3-9c8e-66f8dd049a03", 0, "26475b66-ecbf-4898-8973-ab8a246a259c", "admin@abv.bg", false, null, null, false, null, "admin@abv.bg", "admin@abv.bg", "AQAAAAEAACcQAAAAEIbcpTVQlOsVhLma8CfF7Xp9Qcm/oUrgFdBIQN/QZCauNIr3oKZJWtmhF3F9obxHTw==", null, false, "", false, "admin@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "cb9a0d10-db30-44d3-9c8e-66f8dd049a03", "d6d6c823-b770-4ed8-a93b-1ee9fb28f142" },
                    { "c5f81580-cb48-4681-a296-6de1b1a969ce", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "36bc6df0-b093-4c81-956e-14a801845cbb", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "83b64cbc-19e1-4d05-b3ce-07a3ae9f918b", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "f1a9afc0-5eb6-45c8-8d99-ad19fef0957b", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "d9042be0-4b13-4bda-9895-d7645990e7e3", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "7c5fcebb-5fc4-4724-8b01-62a70dd2aea1", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "3d0ede8f-12ae-452f-9693-db650ffbb604", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "f8903c4c-8801-4794-b80c-9c448f56dc58", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "521fab4e-6fd3-466f-bded-0f05b9111ad4", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "4e8d24ef-c754-48a8-8ef5-dfdfd177b989", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "44a91cfc-2fdd-460d-b7aa-4dff57932333", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "8bc2fa76-5737-4648-aab5-b314a012ccc6", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "00e0f42d-d973-4eff-8c24-b3df9caeb264", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "f780341a-aba6-4056-9d07-52a1c67fa9f6", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "712ebeab-9bb1-4f4d-b021-fdaa45167d9f", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "7eb9a636-ba64-4729-9955-68b4cea86451", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "cceb2370-5d86-4ace-83b9-e62f461ea64d", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "fc31ed89-55ca-454d-859c-24b2e69a6b94", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "1e3d9cd7-9f91-4fc4-b045-c393d811bcd3", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "223f5c13-2feb-45fa-849b-bcd26c640367", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "1d16af57-4358-4b76-bb1e-4559b7e9bf4d", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "1090a66d-33ee-4154-ab8b-578e5ee0b400", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "7e4afd22-76c1-4275-8d11-6969322f6cf2", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "9101f064-bce4-434f-94c9-d4f7f4c02cd8", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "aedb5efc-17ae-4afb-b0f4-430c856141c1", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "5a622559-61ee-4d6a-9803-cb04ef588112", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "9b74c05d-d736-4d96-bb57-66a4cbcd6858", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "c72defd7-3b71-4521-9180-ee1004f14495", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "5d4cd492-05a6-4207-96bc-b133ce0154f8", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "1e0c3e7b-7682-4b45-97be-81acf58dc77c", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "f041fbd0-119f-4002-ac26-1a2e97e5849e", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "e227db7d-2fd8-4796-8d0f-66a043764421", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "fce41c41-f3f7-495f-bc6d-2feeb63fd9ba", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "6f2aa5aa-fd7d-4b9a-90ec-3936404c8388", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "2f0c48c2-637c-431b-94d2-57badf0cb1b2", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "5d382f8e-93c1-48eb-bd17-d78e37745228", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "302428c5-8ebe-4800-ba49-33f3aef046ba", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "ffb5b8ca-d86a-454c-93db-31bfa7ccbd2e", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "2b2c8efa-714d-4573-ae02-aa06631dbc41", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "0068da3f-9f6d-4dfb-8c4f-762ccd73d3d2", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "dbdafd92-720a-40cf-9db5-cc9affdb920a", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "25cb8819-6ba0-4309-946c-2840dd3ded04", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "ab214fe2-bb79-4ece-ad39-d1568d974a8e", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "e13b9cad-0ae9-48ec-a77a-1d78de038061", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "fd5e33f6-408a-40c8-8f41-5b51eaf00897", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "5361559a-0c4d-4707-b692-e68f1d557b18", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "d58660e8-5d40-4b78-9385-041c893d3361", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "9285e36c-6a9d-46da-96aa-ff936d581c64", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "a374a09b-8b48-4d8e-b10d-42aed3dbab7b", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "764e4eb6-3966-4edd-9aaf-50c67db101a9", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "352dcbda-c54a-43af-9a6a-e34b54c6ece0", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "8a82d4a6-d219-4c16-81df-0ebb91bc7be9", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "72592b47-f04c-4102-ad3f-c9fa198e6c8b", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "1e14374b-fbc5-4359-ab4c-778e040da512", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "788e73ad-ae79-4df6-a52b-71fd7941cedc", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "b6d48df1-78de-497b-9b1b-c2904e39cf3a", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "b45c77ee-1907-472f-91e5-55f9f123d449", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "d00448be-9d84-44b4-92b5-c037a0a5f8e3", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "c16f3d62-b72e-4c70-927e-71ee9154522b", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "4176b20f-bc55-413d-9708-2df9fc073b90", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "f8b4df11-73a0-46e8-b6db-fcf7ccccf9c6", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "72e5cb0e-837d-421e-b315-ba43e6ae3cc9", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "e737f935-8bfb-4ef6-b7d4-68c648f290da", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "9a58ae09-b98f-40ef-bfdb-3ceec1a58999", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "e46a291a-e2b6-4eab-851f-bcd4ef726b84", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "b3284f96-78a4-43e9-add1-7f85c203f82b", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "5e2e044a-5ee3-458b-aff8-bb26caaefce0", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "30146d61-507d-46a0-8d0a-f00ba7bd6f31", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "2cd50383-1140-41cf-a2a4-08952e1bde12", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "17126fdb-401e-4bb1-93a3-2091e5a7ef9d", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "01bb6e49-0350-4d67-8f5b-ab0ab04a0e1a", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "c2a5594e-da58-40b0-a3f3-7ed960ce8280", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "4cdce805-419f-4338-aa45-4ac586e5aa42", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "ef840b88-0f30-47f5-b45b-c12531716f88", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "0b5724c2-81b8-4221-8d6e-078443d4d6f7", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "d9e75766-b00b-4020-8e68-4ed4b2422ad2", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "6f502c9c-3c89-405d-af67-b9f8eaf52599", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "d7f90b3a-516a-4374-b094-06054626ef89", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "a8d0fad3-ae95-4556-995a-1a385b25e4a5", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "282f0422-bafc-479a-b0bd-3ae88ebe648e", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "7297afa2-b930-439e-839f-d525628f5ba5", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "d4148ccf-2446-445a-a382-870efe500389", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "44466744-53c3-41e7-a701-e831743d4855", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "2c12c3d4-5de4-4385-9a70-1231c47630b0", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "e6411dcb-5115-4fc4-85cf-1f9033112ed9", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "b93b6e28-4065-467a-b0d0-6bd3557c3622", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "ab3e8869-cdc0-4ca0-8dd2-9e86aaa61956", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "af0f05d2-cfbe-4c1d-b32f-9691a8b9767a", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "bf96c536-730a-4618-8a51-b75236f3ab9d", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "10a3bb82-5716-4edd-944c-f4578839eb9a", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "2b7f4460-993e-4607-a561-aa9b0c7fffac", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "c8a9d770-7875-4494-9b53-2d39b43d78b9", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "fef55d5b-b9a8-496d-84dd-9392b6bfbb26", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "f127cfd6-d199-40eb-b813-3c9a6de4e0a2", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "62fd09ed-5c12-4d42-83d7-82b9e9c8d24b", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "517d8890-fc19-44e9-8277-e2024e17a0c4", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "4cc2b5f9-ffca-44b7-ad55-bcc1b1b67bf8", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "badb7886-ba5c-4a34-8571-6a2c3228f9f6", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "38b590fd-efe1-4e2d-82f2-d57b04cd03dd", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "94f66f1a-9aa2-41d1-b51a-01f8521d0199", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "616b44bf-5786-4469-9d76-3147a32931eb", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "34286d7a-6c35-4b42-b579-9138d67140cb", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "2cb27c90-e77d-4cd3-8f7a-ebfce05f56ed", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "16d681f9-5fd4-47e4-b279-1452a9b5f374", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "13a135bd-e0ee-49b8-a4a8-efb84259454d", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "fe0eec49-354e-43ba-a97a-5c31357c5753", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "fa7dbd5c-dfb9-42e0-a8bb-a96320c65abf", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "424445a3-e372-479f-b7a1-10fe12053fa9", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "62875e18-ca90-4041-9540-559bc8c0961b", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "b273b2f2-0172-4e5e-b643-dcc53a8e6596", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "947e2d2c-30ea-49d0-9793-8b1f72da1dd7", "4a4d39cc-65a8-4533-ba05-73316945a16d" },
                    { "b4e666f0-495e-427a-9a12-53cbff05186f", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "29d7126a-8ffc-42b7-b318-c724952d2e5e", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "3826c217-8008-4ec3-a915-0bd456b27ee8", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "e7849b82-081c-440d-a9ff-54bedb29b1a0", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "0e51298e-eb7e-4793-a5ae-a3009d134a57", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "8c2f4f6b-48a5-46a0-ac96-f90d8214eeb9", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "4fb717c8-d2c8-43d4-b6b1-dc401793f136", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "0aef5cce-f2d0-48e0-bb8f-75e3f349cd41", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "ec2dffa2-0d15-4707-ae31-16602b91c0fe", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "27abfd3d-50bc-4a54-b50a-6f50ca2c93c6", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "9ce29c1d-f6f6-4d3a-ab12-9bfd89cfb917", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "7f1124cd-b826-4fe6-a55a-0927fa51eb9b", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "92d9039d-5ebf-489f-8d6f-074102c8d397", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "9f0bce34-bb0f-4fd1-8963-4b8a671b9a7e", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "028a23cf-80ea-4951-a173-57784964a8da", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "a0a4a36a-2b6c-4e82-9037-fbef84482a17", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "6c71fcb8-c422-41b9-8d73-d7bcae113665", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "85ac7cc7-d9f6-4f34-95c6-17aee4bc5950", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "6c0e5e90-620d-4750-9cd6-97ce877b2be1", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "eee9fa9f-53a9-443f-9285-85e41a291431", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "3c7f6fe3-b933-4993-821f-1680394ddcf8", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "4f5bc153-53d1-4de2-a742-b09e664f8dc3", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "5b0b4f44-c7f0-4a72-87d9-ae7b4cbc4ca7", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "74f93c38-b2cd-4bfc-a49c-7aa49159e9ab", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "37f5bbe3-64d1-41cc-bd77-58d33daa79ad", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "22f27049-b716-432d-b240-54be401feb54", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "057bbdb9-8772-44a9-891d-0b0b953a3756", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "8f73e65d-e662-454d-9008-1309412fedec", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "459f38b5-f368-4653-9248-eedcfd35529d", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "ac2c5198-9d88-44ac-b0a9-d8546379ff0b", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "27dabaa6-5b82-49bf-8c31-3bc7a151cb09", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "98643520-3698-4347-8f45-e4ad5103bfbf", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "9f593bba-2ab3-4913-8459-9bdadd0d98c3", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "a81bd685-4f8d-4ae5-9a56-4eaee4d526f8", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "a2bd25dc-d133-4080-ba1c-f84d1831de33", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "c5ae6377-2e4e-4aaa-917b-76ce3708a074", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "0d0bde24-b658-430c-8c6a-7590c9e2c746", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "bb8a9607-a293-40fd-bcf1-539829f57377", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" },
                    { "812eb3d2-e4db-4fe7-b605-02e4dd9957d3", "aed97cb5-70ad-4d5c-afab-decbb1c13ca5" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "UserId" },
                values: new object[,]
                {
                    { "cc5cdab3-449b-4de4-a66e-a677882e2856", "Street 414", "282f0422-bafc-479a-b0bd-3ae88ebe648e" },
                    { "c07271c9-6cd2-4afd-90bb-e2c51425321c", "Street 65", "459f38b5-f368-4653-9248-eedcfd35529d" },
                    { "0c349b59-eec4-4870-9eed-c6f2097d7ab1", "Street 136", "ac2c5198-9d88-44ac-b0a9-d8546379ff0b" },
                    { "226e68cf-ddc3-4640-b5fb-3c14cbbc2df8", "Street 37", "27dabaa6-5b82-49bf-8c31-3bc7a151cb09" },
                    { "f6eda43e-1f7e-4fd6-a1b5-f4fe77374842", "Street 342", "98643520-3698-4347-8f45-e4ad5103bfbf" },
                    { "b0fc0cda-5e9f-4441-b95b-f1cd9c8169bb", "Street 433", "9f593bba-2ab3-4913-8459-9bdadd0d98c3" },
                    { "917088ab-105a-49f8-bb12-764c92f0eda7", "Street 129", "a81bd685-4f8d-4ae5-9a56-4eaee4d526f8" },
                    { "506c2e71-627e-4f24-94e2-b8ba907d5f5b", "Street 39", "8f73e65d-e662-454d-9008-1309412fedec" },
                    { "4ff91863-7d8c-41f2-aa65-cf735e5cf2ff", "Street 173", "a2bd25dc-d133-4080-ba1c-f84d1831de33" },
                    { "789ca218-d00a-4505-8d6d-d1608bf03801", "Street 176", "3c7f6fe3-b933-4993-821f-1680394ddcf8" },
                    { "7da5d936-ccf1-4e17-be95-1882040f9ab9", "Street 399", "0d0bde24-b658-430c-8c6a-7590c9e2c746" },
                    { "fe20f7c7-258d-4cef-8f64-9e0e52352298", "Street 217", "eee9fa9f-53a9-443f-9285-85e41a291431" },
                    { "a8513297-b86a-47da-a56c-f14061269c2e", "Street 30", "85ac7cc7-d9f6-4f34-95c6-17aee4bc5950" },
                    { "8d4098c0-9f4a-4d5d-a736-bf0974c0823d", "Street 283", "3826c217-8008-4ec3-a915-0bd456b27ee8" },
                    { "0e9e7a51-731b-4939-9d3e-7d4330687c58", "Street 270", "e7849b82-081c-440d-a9ff-54bedb29b1a0" },
                    { "ec7bea8e-9041-40ad-bfbf-63bd08a9898a", "Street 82", "c5ae6377-2e4e-4aaa-917b-76ce3708a074" },
                    { "e853601c-3cb1-489c-94fb-4132978184c6", "Street 117", "057bbdb9-8772-44a9-891d-0b0b953a3756" },
                    { "97b8dfa2-864f-40d7-b088-782133f4bfac", "Street 212", "22f27049-b716-432d-b240-54be401feb54" },
                    { "5c89bfb3-151f-4ea1-96c3-a57dcea08aa8", "Street 357", "37f5bbe3-64d1-41cc-bd77-58d33daa79ad" },
                    { "a5ce4338-ae7c-4c82-8da2-6001b8847c5a", "Street 15", "44466744-53c3-41e7-a701-e831743d4855" },
                    { "db876af5-fbe2-4262-8c00-f064e66da659", "Street 229", "2c12c3d4-5de4-4385-9a70-1231c47630b0" },
                    { "9af39d72-c1a4-4efb-be2b-96bf9a3e2317", "Street 383", "e6411dcb-5115-4fc4-85cf-1f9033112ed9" },
                    { "25958205-83f4-46ce-852e-4c590392e9dc", "Street 81", "b93b6e28-4065-467a-b0d0-6bd3557c3622" },
                    { "471164ae-7abd-4128-b11b-46860b22d65b", "Street 209", "ab3e8869-cdc0-4ca0-8dd2-9e86aaa61956" },
                    { "8fb5e269-827f-4190-83b6-fc49a627e887", "Street 364", "af0f05d2-cfbe-4c1d-b32f-9691a8b9767a" },
                    { "8fc3c78c-9af3-4cdb-afcb-a107fe50d06c", "Street 367", "bf96c536-730a-4618-8a51-b75236f3ab9d" },
                    { "54c46b68-476d-42ad-974e-f12a026f90be", "Street 224", "10a3bb82-5716-4edd-944c-f4578839eb9a" },
                    { "24fc964e-4fbe-4eba-b8d3-514d62448980", "Street 142", "c8a9d770-7875-4494-9b53-2d39b43d78b9" },
                    { "2baf9c14-249d-4d68-aa23-fa42aaa63198", "Street 157", "b4e666f0-495e-427a-9a12-53cbff05186f" },
                    { "1ff95fc6-1bcc-43d6-97d8-47475d0dad02", "Street 392", "6c0e5e90-620d-4750-9cd6-97ce877b2be1" },
                    { "8a5c2f1d-046b-4409-8da3-07909c422825", "Street 36", "29d7126a-8ffc-42b7-b318-c724952d2e5e" },
                    { "537a6907-5f94-45ab-9b57-f5c142d281a7", "Street 236", "4f5bc153-53d1-4de2-a742-b09e664f8dc3" },
                    { "4c6239f2-7f65-4e2a-9809-a445d97673d2", "Street 192", "5b0b4f44-c7f0-4a72-87d9-ae7b4cbc4ca7" },
                    { "d6c5db4b-745d-414b-b9b1-969c5b1ee8b0", "Street 383", "74f93c38-b2cd-4bfc-a49c-7aa49159e9ab" },
                    { "84f5a936-c603-47b6-a822-a04558ec8bfb", "Street 208", "0e51298e-eb7e-4793-a5ae-a3009d134a57" },
                    { "b1e3ff41-99eb-4c15-b636-2978089e448c", "Street 96", "8c2f4f6b-48a5-46a0-ac96-f90d8214eeb9" },
                    { "6470af9c-b598-477f-a548-4f3005fea712", "Street 40", "4fb717c8-d2c8-43d4-b6b1-dc401793f136" },
                    { "ea6bfea2-268a-4202-8bc8-cad5f7ddc0f6", "Street 198", "0aef5cce-f2d0-48e0-bb8f-75e3f349cd41" },
                    { "d57730d1-13f5-40f8-911f-8778b3d91631", "Street 268", "aedb5efc-17ae-4afb-b0f4-430c856141c1" },
                    { "1bdf2f49-3160-45cf-be9a-e1dadfa21f6d", "Street 132", "5a622559-61ee-4d6a-9803-cb04ef588112" },
                    { "2043c822-d88b-4a8d-b46d-7530de888ab6", "Street 45", "9b74c05d-d736-4d96-bb57-66a4cbcd6858" },
                    { "59f6a0f8-ae03-4485-a183-1544056bf335", "Street 251", "c72defd7-3b71-4521-9180-ee1004f14495" },
                    { "ccbbd4df-383e-4ab9-8ed2-3ffb470bf290", "Street 116", "5d4cd492-05a6-4207-96bc-b133ce0154f8" },
                    { "a4b509c4-2e8e-49fc-860e-337ccde80554", "Street 288", "1e0c3e7b-7682-4b45-97be-81acf58dc77c" },
                    { "70bdbe2a-0299-41d8-9a09-b385940e1f96", "Street 339", "f041fbd0-119f-4002-ac26-1a2e97e5849e" },
                    { "35e3a6b1-04fc-4d4c-87c6-9728de472b93", "Street 228", "e227db7d-2fd8-4796-8d0f-66a043764421" },
                    { "a2cbe9ba-c437-495c-a304-5d509c66dfac", "Street 348", "fce41c41-f3f7-495f-bc6d-2feeb63fd9ba" },
                    { "b3647e3a-6773-4157-ac0d-89d54d8d9432", "Street 230", "fc31ed89-55ca-454d-859c-24b2e69a6b94" },
                    { "bf5bdb9d-6c0c-41ee-85dc-0ba40f51c801", "Street 115", "cceb2370-5d86-4ace-83b9-e62f461ea64d" },
                    { "d30d8fe7-13c5-4080-8ada-7f5f9530d2be", "Street 166", "7eb9a636-ba64-4729-9955-68b4cea86451" },
                    { "a1d41104-4340-48c8-8323-1c3dc7f1c46a", "Street 406", "3d0ede8f-12ae-452f-9693-db650ffbb604" },
                    { "2f5d60f8-40a6-4e63-9cb1-0ece6a4617b2", "Street 45", "c5f81580-cb48-4681-a296-6de1b1a969ce" },
                    { "ed63fce6-7a4e-4305-b1a7-9c5dd99eeaf4", "Street 12", "36bc6df0-b093-4c81-956e-14a801845cbb" },
                    { "ab9660e1-8d89-4328-a9e5-46d480cf6229", "Street 110", "9101f064-bce4-434f-94c9-d4f7f4c02cd8" },
                    { "42c3e5c1-611f-4ec2-b008-e81889e8f030", "Street 404", "d4148ccf-2446-445a-a382-870efe500389" },
                    { "8b9b95c2-98e7-4e88-9d80-5fc2c8187fc0", "Street 163", "7e4afd22-76c1-4275-8d11-6969322f6cf2" },
                    { "ac890725-60f2-46b3-91d8-c8cd9590e103", "Street 247", "1d16af57-4358-4b76-bb1e-4559b7e9bf4d" },
                    { "a10f628e-ce78-47d0-8c5e-4c1cf650ae60", "Street 413", "ec2dffa2-0d15-4707-ae31-16602b91c0fe" },
                    { "4be007dc-16bb-4189-a117-f0fa722e55de", "Street 43", "27abfd3d-50bc-4a54-b50a-6f50ca2c93c6" },
                    { "5bdf8e83-d947-413b-a500-1bc8c9dcc58d", "Street 202", "9ce29c1d-f6f6-4d3a-ab12-9bfd89cfb917" },
                    { "a28fbaa1-978b-474f-8843-0e55f9648e29", "Street 371", "7f1124cd-b826-4fe6-a55a-0927fa51eb9b" },
                    { "76f2df20-face-49e3-8d04-e52e9d4c9678", "Street 115", "92d9039d-5ebf-489f-8d6f-074102c8d397" },
                    { "e2d55561-b609-429f-bcd9-e951cf4c49e2", "Street 87", "9f0bce34-bb0f-4fd1-8963-4b8a671b9a7e" },
                    { "3c76deba-9260-4f05-93bb-0dccc1b65822", "Street 192", "028a23cf-80ea-4951-a173-57784964a8da" },
                    { "31ef1dbe-e595-4945-a358-961e488683db", "Street 287", "a0a4a36a-2b6c-4e82-9037-fbef84482a17" },
                    { "32099e06-d07a-42bc-ae3f-51e52d1611e3", "Street 79", "6c71fcb8-c422-41b9-8d73-d7bcae113665" },
                    { "0c771897-7920-49eb-83a3-1559dcbf6536", "Street 379", "0b5724c2-81b8-4221-8d6e-078443d4d6f7" },
                    { "066c0143-6d07-478c-8778-353837e1dd02", "Street 215", "ef840b88-0f30-47f5-b45b-c12531716f88" },
                    { "470689a6-67cc-4c09-b1f0-0efe4381ac36", "Street 112", "4cdce805-419f-4338-aa45-4ac586e5aa42" },
                    { "01b6bbc8-1729-49ee-962d-34f5ee569251", "Street 104", "1e14374b-fbc5-4359-ab4c-778e040da512" },
                    { "7210382b-7e8a-42bb-a4ab-fe2a54e3e5a5", "Street 317", "1e3d9cd7-9f91-4fc4-b045-c393d811bcd3" },
                    { "ef6b11fb-d9c2-44bd-8592-f91d2a926c30", "Street 150", "223f5c13-2feb-45fa-849b-bcd26c640367" },
                    { "c1607a7c-a852-4f0f-8967-3e130cf92e47", "Street 65", "1090a66d-33ee-4154-ab8b-578e5ee0b400" },
                    { "f8fd6981-2ade-4776-8e2c-937cd3ff3207", "Street 245", "7297afa2-b930-439e-839f-d525628f5ba5" },
                    { "00ec722c-4673-4789-85d9-1fbccf266cb7", "Street 79", "83b64cbc-19e1-4d05-b3ce-07a3ae9f918b" },
                    { "8540a192-79d7-41d9-99c1-2efd8a1b7804", "Street 121", "a8d0fad3-ae95-4556-995a-1a385b25e4a5" },
                    { "c4681ec9-4f25-4573-836b-cbf827cba346", "Street 175", "bb8a9607-a293-40fd-bcf1-539829f57377" },
                    { "198af309-3e76-4031-a303-61529c6a5426", "Street 76", "62fd09ed-5c12-4d42-83d7-82b9e9c8d24b" },
                    { "2a3165b2-d1df-4f62-8aaa-518811aeeabd", "Street 323", "517d8890-fc19-44e9-8277-e2024e17a0c4" },
                    { "fb7d2ecc-9403-411a-ba15-ccac5d349017", "Street 340", "4cc2b5f9-ffca-44b7-ad55-bcc1b1b67bf8" },
                    { "a7a5ad61-7090-43c4-a03f-0185925742e8", "Street 234", "badb7886-ba5c-4a34-8571-6a2c3228f9f6" },
                    { "b639f0d5-113e-4769-828d-d641480c2449", "Street 421", "38b590fd-efe1-4e2d-82f2-d57b04cd03dd" },
                    { "dbd899ea-85df-4335-a784-1e85869a66bb", "Street 353", "94f66f1a-9aa2-41d1-b51a-01f8521d0199" },
                    { "3a979de0-34f6-4d95-9372-01469bc6f2d1", "Street 106", "616b44bf-5786-4469-9d76-3147a32931eb" },
                    { "56f43136-95c7-4ee2-9e6a-552ca40ec871", "Street 290", "34286d7a-6c35-4b42-b579-9138d67140cb" },
                    { "7f915587-4c5e-43f7-885a-77eceb703161", "Street 202", "2cb27c90-e77d-4cd3-8f7a-ebfce05f56ed" },
                    { "3d4b1bf5-6747-484d-8790-4a83895cf9f5", "Street 375", "16d681f9-5fd4-47e4-b279-1452a9b5f374" },
                    { "759e9049-a5ca-46f3-95a9-243e1e20930a", "Street 258", "812eb3d2-e4db-4fe7-b605-02e4dd9957d3" },
                    { "29539d5a-a739-4eb1-a190-27b487e3a312", "Street 307", "fe0eec49-354e-43ba-a97a-5c31357c5753" },
                    { "15278a59-de12-4b08-a3b0-0b224a60a574", "Street 429", "fa7dbd5c-dfb9-42e0-a8bb-a96320c65abf" },
                    { "5041dcaa-f6a1-4887-b0c0-b0f4e947856c", "Street 51", "424445a3-e372-479f-b7a1-10fe12053fa9" },
                    { "bf8f2285-66fa-41ea-bc80-95574ab5a87f", "Street 299", "62875e18-ca90-4041-9540-559bc8c0961b" },
                    { "71e64b97-8a57-413e-8358-d928c3dd240d", "Street 304", "f127cfd6-d199-40eb-b813-3c9a6de4e0a2" },
                    { "6d7fd5f9-6d4f-4266-b63f-ca8d742f1b98", "Street 399", "b273b2f2-0172-4e5e-b643-dcc53a8e6596" },
                    { "c0305201-2d91-4743-a12f-d6ac3fab1cb0", "Street 207", "fef55d5b-b9a8-496d-84dd-9392b6bfbb26" },
                    { "24b3e9ca-889c-4e47-b8ab-56299ea668a1", "Street 133", "2b7f4460-993e-4607-a561-aa9b0c7fffac" },
                    { "b03036ee-353b-46dd-90a0-870a506f7aef", "Street 385", "d9e75766-b00b-4020-8e68-4ed4b2422ad2" },
                    { "95f900d2-d612-4054-98a6-1535caed549f", "Street 155", "6f502c9c-3c89-405d-af67-b9f8eaf52599" },
                    { "91da16dd-5877-4009-b517-6392c7c4ed18", "Street 100", "d7f90b3a-516a-4374-b094-06054626ef89" },
                    { "b06a79c9-9e5a-489a-a196-6e01c1ff36a1", "Street 164", "13a135bd-e0ee-49b8-a4a8-efb84259454d" }
                });

            migrationBuilder.InsertData(
                table: "Teches",
                columns: new[] { "Id", "Salary", "UserId" },
                values: new object[,]
                {
                    { "e0510043-6b95-4b19-b115-b589233eeef2", 1844.84644133823m, "b45c77ee-1907-472f-91e5-55f9f123d449" },
                    { "670971c3-d627-4db0-99e9-87c58ff06d71", 566.06985096171m, "d00448be-9d84-44b4-92b5-c037a0a5f8e3" },
                    { "f9c984f9-7593-4645-865b-f239f0c538c0", 1912.34512157382m, "c16f3d62-b72e-4c70-927e-71ee9154522b" },
                    { "8388e2f0-4efc-4775-903e-664727ba979c", 105.736061048571m, "4176b20f-bc55-413d-9708-2df9fc073b90" },
                    { "d8dca6a6-9c53-4722-9a9a-576d0efc93b0", 492.579685753481m, "e46a291a-e2b6-4eab-851f-bcd4ef726b84" },
                    { "bc2bb645-dd1c-41b8-86ae-8443bf13af47", 326.73032317624m, "72e5cb0e-837d-421e-b315-ba43e6ae3cc9" },
                    { "dab68028-2bce-449c-a645-1eaa6b3da6f4", 51.8276123571338m, "e737f935-8bfb-4ef6-b7d4-68c648f290da" },
                    { "3cae491f-3839-48de-82bf-4a26bef49e8d", 1926.32610533681m, "9a58ae09-b98f-40ef-bfdb-3ceec1a58999" },
                    { "93f21a41-ec83-4cb5-af7f-7e075ffbcafd", 1078.83433023413m, "302428c5-8ebe-4800-ba49-33f3aef046ba" },
                    { "2d534ae3-a141-4077-b49b-25e8a3924d0e", 1102.27953693936m, "f8b4df11-73a0-46e8-b6db-fcf7ccccf9c6" },
                    { "a5899d8e-958c-411c-b35f-e733a4056b4d", 1562.98191731935m, "5d382f8e-93c1-48eb-bd17-d78e37745228" },
                    { "15c7d2b0-b13f-4801-8305-175029ac0063", 397.222255541581m, "44a91cfc-2fdd-460d-b7aa-4dff57932333" },
                    { "6f3a5efc-c585-4b79-b892-3d944fec8d65", 827.642253985462m, "6f2aa5aa-fd7d-4b9a-90ec-3936404c8388" },
                    { "7afe1e48-3680-4c08-8e0d-30d5b0413b47", 125.63732086012m, "f780341a-aba6-4056-9d07-52a1c67fa9f6" },
                    { "13c96538-aabe-48ec-8718-df473271a7f6", 1104.96130264595m, "00e0f42d-d973-4eff-8c24-b3df9caeb264" },
                    { "82789fe7-8b85-41ca-b3ba-cff63c38d875", 169.11952577956m, "8bc2fa76-5737-4648-aab5-b314a012ccc6" },
                    { "225b5660-6d8e-4094-ab62-51c7b16887b8", 1687.1027609739m, "4e8d24ef-c754-48a8-8ef5-dfdfd177b989" },
                    { "562bd2cf-a965-4be2-a14a-ec4c957ccaf2", 398.91397505948m, "521fab4e-6fd3-466f-bded-0f05b9111ad4" },
                    { "7c086ec5-4683-421d-a086-6a2256c77ed4", 391.115016486084m, "712ebeab-9bb1-4f4d-b021-fdaa45167d9f" },
                    { "c3912779-649f-4d4b-8b6c-b398fd8aface", 483.887957634352m, "f8903c4c-8801-4794-b80c-9c448f56dc58" },
                    { "53f401af-53f6-4e0f-96c9-a92bfa4e4a2c", 1305.81047819267m, "7c5fcebb-5fc4-4724-8b01-62a70dd2aea1" },
                    { "aef9460e-ed90-4125-8554-0b3c7efec397", 546.999545091297m, "b3284f96-78a4-43e9-add1-7f85c203f82b" },
                    { "da15813b-18bb-4de3-bab4-f7cbaa2bf911", 1130.7031200876m, "2f0c48c2-637c-431b-94d2-57badf0cb1b2" },
                    { "26e08fba-fc90-4b8e-b1fb-7fcb96e6af74", 415.160136490669m, "5e2e044a-5ee3-458b-aff8-bb26caaefce0" },
                    { "0e7643ea-f69a-49eb-8e16-59d6cf6d7bbf", 1987.97541297412m, "dbdafd92-720a-40cf-9db5-cc9affdb920a" },
                    { "9984d9ba-5d22-40d1-a0f1-e22b58c14998", 1257.35695159871m, "2cd50383-1140-41cf-a2a4-08952e1bde12" },
                    { "c94bfb15-e69a-4b2a-ac73-7d135cafa8a4", 744.005806159231m, "947e2d2c-30ea-49d0-9793-8b1f72da1dd7" },
                    { "cd1a95b0-4bee-4e2e-a7df-22f9b59111c8", 1840.83967275957m, "8a82d4a6-d219-4c16-81df-0ebb91bc7be9" },
                    { "c3659f6d-c00b-46df-be95-aa0a575cbee7", 212.747266615158m, "352dcbda-c54a-43af-9a6a-e34b54c6ece0" },
                    { "f0e0eb04-5f05-43f6-a18e-302399806bd4", 220.909095472148m, "764e4eb6-3966-4edd-9aaf-50c67db101a9" },
                    { "0f39e70b-02c0-4206-bddc-2e475dc15dca", 502.23723263584m, "a374a09b-8b48-4d8e-b10d-42aed3dbab7b" },
                    { "b6903438-b9a2-431a-879f-34a91909f02b", 98.6128943500169m, "9285e36c-6a9d-46da-96aa-ff936d581c64" },
                    { "f08792db-6248-442a-b15f-4d382e4fd5fe", 802.945559286953m, "d58660e8-5d40-4b78-9385-041c893d3361" },
                    { "11cb048b-acb2-4d8f-8526-538041c987d3", 1195.0376830972m, "5361559a-0c4d-4707-b692-e68f1d557b18" },
                    { "04f051b9-2e4a-455c-9db7-9aef1eeadcb5", 329.025566731126m, "fd5e33f6-408a-40c8-8f41-5b51eaf00897" },
                    { "04501c93-73a6-4dde-93a9-85d39c43dbe2", 1982.36718586756m, "e13b9cad-0ae9-48ec-a77a-1d78de038061" },
                    { "d968af88-8cd3-4a77-8bc9-562942512f9f", 1463.0275775972m, "30146d61-507d-46a0-8d0a-f00ba7bd6f31" },
                    { "4dce9305-9970-47ae-894a-1bb203888b32", 498.069623717139m, "ab214fe2-bb79-4ece-ad39-d1568d974a8e" },
                    { "f1b5fcc7-88ba-41bf-ab46-56eee1464c2f", 653.817316821691m, "f1a9afc0-5eb6-45c8-8d99-ad19fef0957b" },
                    { "b3ad07b9-991c-4b01-a0fd-15b2d5c8a8c8", 265.434365843159m, "0068da3f-9f6d-4dfb-8c4f-762ccd73d3d2" },
                    { "540fbe69-969f-455b-b200-4c22f0923aa0", 131.44632993799m, "2b2c8efa-714d-4573-ae02-aa06631dbc41" },
                    { "fb9484e6-5e87-46ed-b3f4-b7d1293ee323", 384.575531065732m, "ffb5b8ca-d86a-454c-93db-31bfa7ccbd2e" },
                    { "619eb691-45cb-4008-af5b-8f95699d61a3", 393.163554553484m, "72592b47-f04c-4102-ad3f-c9fa198e6c8b" },
                    { "4697f633-abd1-49e5-8c2b-62972dbc8967", 1366.12308834033m, "788e73ad-ae79-4df6-a52b-71fd7941cedc" },
                    { "a1b13c00-75ab-4347-80f8-ec6aa5042ec8", 404.628751056562m, "c2a5594e-da58-40b0-a3f3-7ed960ce8280" },
                    { "4f9b002f-46e7-4081-a935-d429260fb1cd", 1088.10723344242m, "b6d48df1-78de-497b-9b1b-c2904e39cf3a" },
                    { "7b300ed7-cfda-4a0f-a27e-7ad339138746", 268.011123066773m, "01bb6e49-0350-4d67-8f5b-ab0ab04a0e1a" },
                    { "4fca52ec-5127-4f14-b474-c04a7f28933b", 894.226573824057m, "17126fdb-401e-4bb1-93a3-2091e5a7ef9d" },
                    { "dc4e9f13-550d-4518-94ee-f961873ce7e4", 899.345969268748m, "25cb8819-6ba0-4309-946c-2840dd3ded04" },
                    { "61c7937f-366f-44b6-86b3-5220fd2c062b", 1741.28620128207m, "d9042be0-4b13-4bda-9895-d7645990e7e3" }
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
