using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capri.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promoters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    CanSubmitBachelorProposals = table.Column<bool>(nullable: false),
                    CanSubmitMasterProposals = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promoters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promoters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Topic = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Mode = table.Column<int>(nullable: false),
                    PromoterId1 = table.Column<Guid>(nullable: true),
                    PromoterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Promoters_PromoterId",
                        column: x => x.PromoterId,
                        principalTable: "Promoters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposals_Promoters_PromoterId1",
                        column: x => x.PromoterId1,
                        principalTable: "Promoters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ProposalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5454fd40-c2d9-4273-aac4-b8467a96ca01"), "c54b8fff-2fa1-4e83-99a6-e44b53806f78", "admin", "admin" },
                    { new Guid("53066f92-374d-461a-9aac-cf0ae4bd12ae"), "47f7684c-1fb5-43b3-aeae-ac40b006fde2", "dean", "dean" },
                    { new Guid("f8b25702-b933-49ec-ad34-57b318e15279"), "3f5f9c3b-a541-4925-87a0-23ba8f0506c5", "student", "student" },
                    { new Guid("eae672e4-7dcb-44b5-9412-567b6529b5b6"), "1032cf27-5319-4abe-955f-c1da01c5fa1d", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4df6477a-55e9-43cf-b9ec-b2c6c03e7a83"), new Guid("eae672e4-7dcb-44b5-9412-567b6529b5b6"), new Guid("4f2f1b37-4fcc-474e-b4a3-edff69668a80") },
                    { new Guid("94a15b69-36fa-491e-b23b-831f588fdd4f"), new Guid("eae672e4-7dcb-44b5-9412-567b6529b5b6"), new Guid("1dfc42f6-d3cd-4b35-8681-eead25df0aea") },
                    { new Guid("af201a76-1440-449c-9a5e-9396e5f59143"), new Guid("f8b25702-b933-49ec-ad34-57b318e15279"), new Guid("81503dfe-3973-4df8-89e5-3554aa16f3b2") },
                    { new Guid("6c4ea15f-004d-49e5-98a9-9631d54de42f"), new Guid("f8b25702-b933-49ec-ad34-57b318e15279"), new Guid("a87085c0-afc1-4f4b-94f8-6b564140ac6d") },
                    { new Guid("0ea7de61-dc94-4276-8526-16ceb3e92b70"), new Guid("f8b25702-b933-49ec-ad34-57b318e15279"), new Guid("314a14fb-1bcd-4ef1-affd-77b33f650d8a") },
                    { new Guid("063ef35b-abcc-4929-a6ad-c7cb9bf45e78"), new Guid("f8b25702-b933-49ec-ad34-57b318e15279"), new Guid("b6b2385c-d80f-4e62-bbfb-fb7a50a40d84") },
                    { new Guid("25b5116b-5ddd-48c3-b6c6-7afce3a2960d"), new Guid("f8b25702-b933-49ec-ad34-57b318e15279"), new Guid("62246e4a-671d-4988-bb80-b22e3c5e14f5") },
                    { new Guid("d8376854-4d09-4566-a673-9cbcdbc6475c"), new Guid("f8b25702-b933-49ec-ad34-57b318e15279"), new Guid("bc1d5c2b-139c-475f-b887-33a5bf13500a") },
                    { new Guid("c9b12104-a892-45f8-b3fb-9fdb9e634c01"), new Guid("f8b25702-b933-49ec-ad34-57b318e15279"), new Guid("7ea8b2d5-5c9e-4be1-b270-f369ce231acd") },
                    { new Guid("21e64f35-bc25-4bab-aa07-c58370228a06"), new Guid("53066f92-374d-461a-9aac-cf0ae4bd12ae"), new Guid("4de7df58-b74c-459f-87fd-586ef556d41d") },
                    { new Guid("f1bef887-26d4-4468-92dd-c53b35d6e5cd"), new Guid("53066f92-374d-461a-9aac-cf0ae4bd12ae"), new Guid("b01947d7-8277-48e2-bddb-c59645e26f4d") },
                    { new Guid("0c037d71-83aa-4cdf-af2d-3a5e5aa9ef93"), new Guid("5454fd40-c2d9-4273-aac4-b8467a96ca01"), new Guid("519d2687-d78a-49f5-b884-d6ce2cb10c0f") },
                    { new Guid("f1077c0e-12f4-4e14-97ff-7f37d783201c"), new Guid("f8b25702-b933-49ec-ad34-57b318e15279"), new Guid("6433f142-9cdf-42c3-8ce6-04cd021f6c71") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("62246e4a-671d-4988-bb80-b22e3c5e14f5"), 0, "decdbf64-6553-4371-9e09-6b7dabdeb1c1", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEHGCIodgCu9oaq01x9mOhJh4y6OveA8GlSVt0GXrYhzBTuv1qSlc3uJSsBLGcnioyw==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("81503dfe-3973-4df8-89e5-3554aa16f3b2"), 0, "432e53fc-e969-4c37-ac33-413e1c67227a", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEKxN8iGsHSPFHOLfoTs6lXgDRQIOowRMDe4wd75h50v2GfjtOyeq+vGZOp3I+zHWCg==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("a87085c0-afc1-4f4b-94f8-6b564140ac6d"), 0, "6125011e-830a-4927-94a3-376e589bdb62", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEOLGgTpVFzjF5NNMQhonsjiIJP+ZXsPOiaqafdi+zRFdOm9wHdnRy0amq5iLKQTN4A==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("314a14fb-1bcd-4ef1-affd-77b33f650d8a"), 0, "d27f1a8f-c1be-4eb3-859b-194f7d8c1860", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEPBTGRvDydUywx/XLtcqr0MdU/Os9+7/pFPX07L9Dv3mgw21WvRXObcwjRwEvrJOeg==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("b6b2385c-d80f-4e62-bbfb-fb7a50a40d84"), 0, "071af231-426f-44fb-9e8b-bb6af42f166b", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEH2gEA6xZ/YP/Jci0p1KjabLQ0tKLdDun87Y3GYBQh+7LXaxQbiD0jhVIG0LzYCiBA==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("7ea8b2d5-5c9e-4be1-b270-f369ce231acd"), 0, "94a93e0d-2876-4d68-a9df-e89949b2f69b", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEJwaRpZwzUVJ7NNUq7N3rwTekprHfwNg2l77PJZW8VCmsMmxbumjXRJYtdRlF/psDw==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("bc1d5c2b-139c-475f-b887-33a5bf13500a"), 0, "6d9cda31-f0bc-4d5e-bd55-f5d347cf5665", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEMfTaSALFZOzr04oHB90THJTO5K/os3XBMUA5gdWb/qABCnz4oBtJ3ndAkm1jxjVGQ==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("4de7df58-b74c-459f-87fd-586ef556d41d"), 0, "087023e2-749b-4d52-8507-a929b31bafc4", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEJ+Z/CLSSzimgqzYis/kOsnA1NZbRc6/TMqDC/++oVqhYIxBZ3jEtSxPEAF6i7JgTw==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("b01947d7-8277-48e2-bddb-c59645e26f4d"), 0, "062b20cc-5ef5-470c-9ae8-fda77f85e9e7", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEOaWzOGyIfv0OZeIv2POZgG+gxfD7Pr80hjXRg9iG1cuFKbjHWeG0Sw/ojElTCVOCA==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("519d2687-d78a-49f5-b884-d6ce2cb10c0f"), 0, "8997e222-15bb-4398-aa79-140206d96fbc", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEPPf7/YOxW+gVoXB6KFUhbjcgHCwTLeQoux4LR0cO7JDdVp2YV/onGkY77fa+AdOrg==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("1dfc42f6-d3cd-4b35-8681-eead25df0aea"), 0, "713bbf1e-83c7-4ff5-a31e-aea69923e614", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAEJTPje5DuIIkiSvyHXH+8SyNdhV6mcgdEbhD+XIhinloFBU4QOz33TD6yo8t6NHeig==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("6433f142-9cdf-42c3-8ce6-04cd021f6c71"), 0, "e276748f-e9de-462d-9970-ea787ea99d9c", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAEJb9vyAJmsO8pdXZfGcsqSE/C48EtBPij/4I5M23PFbdMNsj5syJZBgIDyRuCLp6fg==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("4f2f1b37-4fcc-474e-b4a3-edff69668a80"), 0, "fbe0e63c-bda9-4500-8dec-294024799c89", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEDKKucobQPCvinKXnFilIYSyqpFFMIYMjeYfnDUd2zq9yUWXqtwhTE7skooqBnCrOQ==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "CanSubmitBachelorProposals", "CanSubmitMasterProposals", "FirstName", "LastName", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("e830fa61-0860-4e48-bbe6-01f37017520e"), true, true, "Jan", "Kowalski", "Phd.", new Guid("1dfc42f6-d3cd-4b35-8681-eead25df0aea") },
                    { new Guid("b9135b5f-e507-4abc-95c5-81f4516a06d0"), true, true, "Jan", "Kowalski", "Phd.", new Guid("4f2f1b37-4fcc-474e-b4a3-edff69668a80") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1f822a62-87d7-4f2a-af17-7a5ae2aa96a3"), null, new Guid("7ea8b2d5-5c9e-4be1-b270-f369ce231acd") },
                    { new Guid("bac4f6d9-970f-48f8-89e8-741d1968f047"), null, new Guid("bc1d5c2b-139c-475f-b887-33a5bf13500a") },
                    { new Guid("338dc616-b551-431a-9763-ff9cef533be0"), null, new Guid("6433f142-9cdf-42c3-8ce6-04cd021f6c71") },
                    { new Guid("2394bd4d-c8da-47e2-b60b-32851aa97e7e"), null, new Guid("b6b2385c-d80f-4e62-bbfb-fb7a50a40d84") },
                    { new Guid("66de4632-1e8c-41ee-97a0-2f8854f21d8e"), null, new Guid("314a14fb-1bcd-4ef1-affd-77b33f650d8a") },
                    { new Guid("c18e3ca7-3a00-4294-8b9f-f64c852ba194"), null, new Guid("a87085c0-afc1-4f4b-94f8-6b564140ac6d") },
                    { new Guid("d17fc388-28d0-471d-aab1-0c077aa53543"), null, new Guid("81503dfe-3973-4df8-89e5-3554aa16f3b2") },
                    { new Guid("7b51dcfd-87f6-49ed-8edb-816d4e57daa5"), null, new Guid("62246e4a-671d-4988-bb80-b22e3c5e14f5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promoters_UserId",
                table: "Promoters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_PromoterId",
                table: "Proposals",
                column: "PromoterId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_PromoterId1",
                table: "Proposals",
                column: "PromoterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProposalId",
                table: "Students",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Promoters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
