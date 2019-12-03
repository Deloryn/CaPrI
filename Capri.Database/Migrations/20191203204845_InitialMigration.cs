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
                    { new Guid("d27e8d35-4423-47f4-bc24-0a732641e438"), "6effc538-245e-46ab-9782-8695a8d6f7de", "admin", "admin" },
                    { new Guid("42419760-47c3-4067-bf28-8572c09bd396"), "3e19bea4-8fb0-4643-892c-37289eb15489", "dean", "dean" },
                    { new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), "901407ed-f931-4fef-aa23-5c848ca16b24", "student", "student" },
                    { new Guid("f7cda159-c95a-441a-a013-a39545da25cf"), "1e75401a-935a-40f8-8bf3-6037b03fe4b8", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("689cb556-a244-42c8-9df6-4f1cd813370a"), new Guid("f7cda159-c95a-441a-a013-a39545da25cf"), new Guid("4e8351ab-6b59-4f13-8f28-7313d8af4585") },
                    { new Guid("d5e4ac4a-781a-4681-8519-e3d0cd93b4be"), new Guid("f7cda159-c95a-441a-a013-a39545da25cf"), new Guid("04bb5bb4-8ec8-4b42-b753-dddf057797c7") },
                    { new Guid("88df3316-340c-4b9a-8043-9948d9bfab78"), new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), new Guid("ad1a346e-b0d8-46b6-b76d-d96b63840993") },
                    { new Guid("7a74e2a8-6d7e-4f86-a943-0e8bcf3ca7d8"), new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), new Guid("d77cb639-f8a0-46be-8724-72b0772158cf") },
                    { new Guid("5072b464-08c9-4454-acee-48c9cf5c1a76"), new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), new Guid("d7512dc4-2423-45d1-bd8d-e71a47bb12fd") },
                    { new Guid("b88a5077-5308-449f-a715-cfc40fa12dc6"), new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), new Guid("9cc14694-f564-4f55-a15f-86e47f14922e") },
                    { new Guid("bff047f6-d6e9-4b0f-8ae4-bf1287cdf2bd"), new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), new Guid("9ddff194-d407-454b-918e-ce3fee675608") },
                    { new Guid("10d9c6f2-151b-4cbf-a2a2-b8274f4bfa9e"), new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), new Guid("9c2d6bdf-6bbf-400f-a8a0-acb3a34a4f2e") },
                    { new Guid("7d37d06e-af45-4a2d-aee0-93cffc149603"), new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), new Guid("81c25a34-37bd-40ab-89ea-b21d2b92e899") },
                    { new Guid("0c33c043-0de7-4f35-ab92-233d91547de1"), new Guid("42419760-47c3-4067-bf28-8572c09bd396"), new Guid("c1f09835-b040-440a-a7bf-af9fd8c2cec8") },
                    { new Guid("a56977ff-4914-48ff-9a4d-2899f5af034a"), new Guid("42419760-47c3-4067-bf28-8572c09bd396"), new Guid("cb041449-6144-4a78-a425-b8bcdb816c74") },
                    { new Guid("4416e55f-d838-44d7-8409-cdb2b5bba4ef"), new Guid("d27e8d35-4423-47f4-bc24-0a732641e438"), new Guid("cc994903-703a-43b0-8524-0d5e0771d264") },
                    { new Guid("66acae93-76c0-4d3e-b22e-e4542c37f884"), new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), new Guid("6abf766e-a637-41cf-93f3-a099cce68b30") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("9ddff194-d407-454b-918e-ce3fee675608"), 0, "896eb097-30c1-4732-a344-01d037c9433c", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEBumkWfFP3TsXgbHV5GuOKETT2t1l2A3XEvEosJ5+TGw/sxAlxte+fHyNw/D7LjgAw==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("ad1a346e-b0d8-46b6-b76d-d96b63840993"), 0, "21ffe6f7-302b-4289-af47-a77c3f65280a", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEEISrmpeNwOeVdHWHsHh+PjvV9DtMPrv8awwQhxKbGBDATcbQF9Np7jeoOowqrKvqg==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("d77cb639-f8a0-46be-8724-72b0772158cf"), 0, "05ecbe17-d37e-4cb9-bdd5-dfe82b8c6304", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEPhbSd9nn35ZIH80VXMJtHZGtU+tQLedYGUDuMIK+hYgKwrOGjKhYh4MMh+Ntovz/A==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("d7512dc4-2423-45d1-bd8d-e71a47bb12fd"), 0, "a1dde13b-30a5-4640-8727-a421629ea0fe", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEF1azm1+Nmkxbt3HivQOGrdAn4QzGJfq9C/vJeGEwWDhF8+hYThpEfsXJvkrmOMfuQ==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("9cc14694-f564-4f55-a15f-86e47f14922e"), 0, "54202bcb-6d99-4163-ad1c-0cfbe3e79a6e", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAENe0fNAT70puryj0ue5UE20ioNQl/XA8HcLjkpy1VgsuEE65CKLBotjeCyV3G3wkdw==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("81c25a34-37bd-40ab-89ea-b21d2b92e899"), 0, "b3a9205a-dcc2-40b1-b7ed-98876ac6b5a3", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEAcirm8jUUWUY3e5p8cLJMWjxdgCpBPrcMBUa94qcZ5TAeWr3O6NVhilPbzIeEd9cA==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("9c2d6bdf-6bbf-400f-a8a0-acb3a34a4f2e"), 0, "727f5a7b-aba8-44ba-90de-3afda021c8ae", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEKlUvlkYX8w5SYQ5esY6X/TWVDfV/oJx4y5t7RRKDvuNdNGZCPaq/WtR8ASHztVEXA==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("c1f09835-b040-440a-a7bf-af9fd8c2cec8"), 0, "34cc3103-d68a-4a48-9c43-0c8bb09552c8", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAELbntyE7M2fgJzVDuM7oPHMoiJ7cbIgw4iOhzu9qxHogsCDxaS8Aqp4IdPv50AZ0Nw==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("cb041449-6144-4a78-a425-b8bcdb816c74"), 0, "8e0a5c75-3520-41d1-93eb-2ef21c67e5a3", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEJJL2dgRPxu22Vb5eGxJVGV5G/tBIUVZSMEWa1aUOad+TML1PxOLEKSLgK7coK+kKw==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("cc994903-703a-43b0-8524-0d5e0771d264"), 0, "8125b0aa-8de0-44bc-b583-7337d9677bf2", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAECKvYpds5CdeDfw9auu70C1jhA/zRDvMnMQ90fIMAnOBfZHu78sKe1Q2cxdGPGm50w==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("04bb5bb4-8ec8-4b42-b753-dddf057797c7"), 0, "c12ec296-b13c-4940-9c62-03d19ddba8b6", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAEFIR2iqdmPJqOgSIPJOXmFmQjFZxnR1mUSgL2unqlJbo5OuLZlr+JvHOlJerPdePPA==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("6abf766e-a637-41cf-93f3-a099cce68b30"), 0, "0bc6df4a-7be3-4b85-a556-60fbbbf361d3", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAEAbMbed3z+Qwa03WDYzLnuEllPhOBGqWogYvZzdtPVCAzu/tFjlp+RnUpXZ3xOgo1w==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("4e8351ab-6b59-4f13-8f28-7313d8af4585"), 0, "da8d9e55-ef8c-48ee-ab2d-caaf503144b8", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEA6ixEs9n44U5fuQoWfq6lNXArndiMQCo4A1g8pGdQUtJ2l1RLyilqQxHBWxKvhEBg==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { new Guid("2c764fdf-b14f-4553-877c-d953450bc2eb"), 3, 4, "Jan", "Kowalski", new Guid("04bb5bb4-8ec8-4b42-b753-dddf057797c7") },
                    { new Guid("fd7b776a-cc16-468b-b3ec-63c00f33ddac"), 3, 4, "Jan", "Kowalski", new Guid("4e8351ab-6b59-4f13-8f28-7313d8af4585") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2a76da8a-018b-4878-a14f-401a6025ff9a"), null, new Guid("81c25a34-37bd-40ab-89ea-b21d2b92e899") },
                    { new Guid("d18cd9e5-fa11-499c-a52e-cae5fc63cf99"), null, new Guid("9c2d6bdf-6bbf-400f-a8a0-acb3a34a4f2e") },
                    { new Guid("56d18300-066b-41e0-9c7f-f145a3853537"), null, new Guid("6abf766e-a637-41cf-93f3-a099cce68b30") },
                    { new Guid("ed4ef787-5e8a-4117-a95b-95dbc1c751fd"), null, new Guid("9cc14694-f564-4f55-a15f-86e47f14922e") },
                    { new Guid("a0495b29-831b-48b5-b291-4d8fa2e99d4e"), null, new Guid("d7512dc4-2423-45d1-bd8d-e71a47bb12fd") },
                    { new Guid("1aa2ae96-ed80-47f2-99d4-d4182130448d"), null, new Guid("d77cb639-f8a0-46be-8724-72b0772158cf") },
                    { new Guid("084c36ee-4f48-4f18-be8f-4590bdcc63ef"), null, new Guid("ad1a346e-b0d8-46b6-b76d-d96b63840993") },
                    { new Guid("abd9b78c-2508-4935-944a-8c81b242e5d2"), null, new Guid("9ddff194-d407-454b-918e-ce3fee675608") }
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
