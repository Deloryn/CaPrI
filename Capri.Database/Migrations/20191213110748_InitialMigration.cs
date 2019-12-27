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
                    ExpectedNumberOfBachelorProposals = table.Column<int>(nullable: false),
                    ExpectedNumberOfMasterProposals = table.Column<int>(nullable: false),
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
                    PromoterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Promoters_PromoterId",
                        column: x => x.PromoterId,
                        principalTable: "Promoters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("c02cc218-8b38-482f-9a8f-d0adef177002"), "ae3bf9c9-11a6-4685-92e1-eb91dcfb538f", "dean", "dean" },
                    { new Guid("ee0ef896-c347-4205-a71f-9c5acca847ad"), "23ea6bb3-c95e-41a6-869d-f9c0aae3c08b", "student", "student" },
                    { new Guid("f690a490-8590-4133-8f69-6a71cc8caaf7"), "a406b976-1105-4659-8133-b17756cdb555", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), new Guid("f690a490-8590-4133-8f69-6a71cc8caaf7"), new Guid("df9882d8-2cc3-48e5-898a-5735df64421f") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), new Guid("ee0ef896-c347-4205-a71f-9c5acca847ad"), new Guid("895246e1-b5fe-4980-afb4-07f9ff4f3a15") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), new Guid("ee0ef896-c347-4205-a71f-9c5acca847ad"), new Guid("f91a69b4-fc27-4390-8734-b13cb48dfad9") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), new Guid("ee0ef896-c347-4205-a71f-9c5acca847ad"), new Guid("5614ff52-bfb7-463f-8445-9ae4c929c359") },
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), new Guid("ee0ef896-c347-4205-a71f-9c5acca847ad"), new Guid("1e5b2a68-59e0-400b-b0a8-6204aa556be6") },
                    { new Guid("486c4119-0425-4802-ba9c-a922afa7ce1b"), new Guid("f690a490-8590-4133-8f69-6a71cc8caaf7"), new Guid("55b1b2f4-9b5a-4cbe-8646-0eba7efe40bd") },
                    { new Guid("253fe6c3-5974-4f94-a536-ffe73cfbc93f"), new Guid("ee0ef896-c347-4205-a71f-9c5acca847ad"), new Guid("00d328de-5529-4954-9cbd-dd568ffe830a") },
                    { new Guid("502d80fc-6e09-4622-8ad0-a216502eb927"), new Guid("ee0ef896-c347-4205-a71f-9c5acca847ad"), new Guid("948febcd-be78-4bc4-a15f-197cd253faa4") },
                    { new Guid("fecb04cb-687e-42c7-82de-4c6a75951d31"), new Guid("ee0ef896-c347-4205-a71f-9c5acca847ad"), new Guid("87b48860-66dc-45d6-bfad-4140f4783e52") },
                    { new Guid("b2670c65-edfb-4736-9953-5ff20e1e2841"), new Guid("c02cc218-8b38-482f-9a8f-d0adef177002"), new Guid("68ac2b22-0c92-46da-a800-deae10e9470b") },
                    { new Guid("6fedbbd9-5805-4fd9-be10-50869a6ff0ce"), new Guid("c02cc218-8b38-482f-9a8f-d0adef177002"), new Guid("8cf1f857-7891-438f-b220-c9badcb834de") },
                    { new Guid("bc22c227-ee68-4a69-894e-827e33642ee0"), new Guid("ee0ef896-c347-4205-a71f-9c5acca847ad"), new Guid("4a22fdde-cb73-40e7-b25b-fbd712cea748") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("895246e1-b5fe-4980-afb4-07f9ff4f3a15"), 0, "c531f18e-a6ab-4aad-a352-1f7f1ef8101b", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEI30krRFlXqURKwi1J1d/WdE2QU/NqeH+Z4Xz6CCRTDsP83Em1d5//OL8YcEwn3IiQ==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("f91a69b4-fc27-4390-8734-b13cb48dfad9"), 0, "7a6b324e-6ddc-47c4-b7b0-edb0cad8c820", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEO65mRG+Y5k4/iIkpTUlpXQxJRvrORadqWRbuJh+QtobZ/HQXdR/H8BCY0XzXMg1ug==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("5614ff52-bfb7-463f-8445-9ae4c929c359"), 0, "ef26953a-27fe-4da6-a557-f5f0be8a9243", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAENVdUL7iA0NuoWE3jlePgwzeF1aL/W/sw6WFnk5CYuykMrx5wB2SDrkDJ2xh2zShAg==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("1e5b2a68-59e0-400b-b0a8-6204aa556be6"), 0, "f41de217-be71-490d-b66e-df878b5cf404", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAELQBZCaQYYmE49wR01V2KlQ32hxYr/9HpLLdszQLbGg/292uY4qhjytyWD5MTiWl+w==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("4a22fdde-cb73-40e7-b25b-fbd712cea748"), 0, "7b1c8cba-6e39-45c3-a482-f0b48f074e46", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEFNbf3bPtLrRdbV3NEyhrPL1eVT6RZiVKCnZpkCnlHks+jCEXNC0qKPXNREHXims6Q==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("87b48860-66dc-45d6-bfad-4140f4783e52"), 0, "b71f69ac-3a8f-41f0-8125-82d06b79f345", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEKh3Tg8lMP8l5HZx3eYngaoQ7knyFQ3qXRyR37ky9n48NYeCL+AE6mcneYMUsAGO4g==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("948febcd-be78-4bc4-a15f-197cd253faa4"), 0, "f1175169-7c63-4ebd-94a3-8e49c5ffca88", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEG+0XnQhrOmTjjZ20/MvH6qP0Dd3rrB6VM+sY9hKVpHfXL84lElouct2pVBNjQyFMg==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("68ac2b22-0c92-46da-a800-deae10e9470b"), 0, "0c750628-8bd6-43f3-9657-f77736eb5795", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEEqkWBIF9X14VFc60mAyHlBQecI79emU7D/4Trksm+o2fN6iDHuhHBShHPr4LiF0ag==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("8cf1f857-7891-438f-b220-c9badcb834de"), 0, "683642fe-21ed-4785-a9f5-0c07206e8222", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEAzoVtW0aXRYCmFYthHbEKigMuaSdMCRj+OPt9E1tThoHrMVnbCG/KtBN+3NMr4W+A==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("55b1b2f4-9b5a-4cbe-8646-0eba7efe40bd"), 0, "c87b6b74-6cb8-4284-badd-5391158b80e0", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAELMWDJAzD/6cU2xqO0S6kGqfITFWHNtM9VWEf0dSLzc2nkOUr1f5Uy2N2o2jxk13aQ==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("00d328de-5529-4954-9cbd-dd568ffe830a"), 0, "494a5b76-c4c2-43a7-abe7-bae617cdd653", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAEA8n6sYR7k9OCY13qSyFfGW6i93fX8Nuwv9PeT4Kf0tfOHutsqZI/JdBSVRiiWJyHw==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("df9882d8-2cc3-48e5-898a-5735df64421f"), 0, "7d1bb7f9-a156-407f-9d10-c27c72a4f619", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEMl/soD3L5/2Ezp+La8ZGM1KbszGgodIFeS8deZCLS6FnQrX+c4nCaPL/sS38YabOw==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { new Guid("a242a7aa-bace-42e0-927f-2decf6c76dfa"), 3, 4, "Jan", "Kowalski", new Guid("55b1b2f4-9b5a-4cbe-8646-0eba7efe40bd") },
                    { new Guid("2bdd2074-e743-49b1-aef3-7d17b3690760"), 3, 4, "Jan", "Kowalski", new Guid("df9882d8-2cc3-48e5-898a-5735df64421f") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e56264a8-64c0-4bf9-82a4-b13bfbff5dde"), null, new Guid("87b48860-66dc-45d6-bfad-4140f4783e52") },
                    { new Guid("4b80fdf9-78c5-46c2-ba2f-e903564d794b"), null, new Guid("948febcd-be78-4bc4-a15f-197cd253faa4") },
                    { new Guid("2c034bf4-a76d-4696-9209-7653b07f7bc4"), null, new Guid("00d328de-5529-4954-9cbd-dd568ffe830a") },
                    { new Guid("e1ca0726-fbf7-4137-947e-42e8e5d58013"), null, new Guid("4a22fdde-cb73-40e7-b25b-fbd712cea748") },
                    { new Guid("861c37f0-50fd-4112-9ccd-643b705e41f8"), null, new Guid("1e5b2a68-59e0-400b-b0a8-6204aa556be6") },
                    { new Guid("b2ba326b-574a-44fc-b7a0-dca578931c80"), null, new Guid("5614ff52-bfb7-463f-8445-9ae4c929c359") },
                    { new Guid("ac65fbfb-57cc-46bf-9b4e-49ddc5b4172a"), null, new Guid("f91a69b4-fc27-4390-8734-b13cb48dfad9") },
                    { new Guid("f3917674-4d63-493a-ba0e-f0b3e329d109"), null, new Guid("895246e1-b5fe-4980-afb4-07f9ff4f3a15") }
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
