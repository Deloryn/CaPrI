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
                    Type = table.Column<int>(nullable: false),
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
                    { new Guid("e78bc187-e8b5-45c4-b33b-5717e61fec46"), "29124110-3aa4-464f-a0f7-9887b2e3077d", "admin", "admin" },
                    { new Guid("2195c00a-aeb2-4fdd-a4e1-5914405b0232"), "980b2457-4ea1-4746-b2aa-1db4f193e39e", "dean", "dean" },
                    { new Guid("e27a1eaa-62dc-473e-bc5e-8b53be54147a"), "0a50de7d-0a4f-4a13-88e8-33dcc7e15d53", "student", "student" },
                    { new Guid("8196d3fb-8242-4ef1-98f5-a84641e872cc"), "15f9c570-69ef-41a5-95f1-5ff9b0a60d78", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3ccf946c-9293-409d-9ab0-8631845672d2"), new Guid("8196d3fb-8242-4ef1-98f5-a84641e872cc"), new Guid("1d6a3813-eedd-4ad8-8e85-acbd5742519a") },
                    { new Guid("a3fb053d-f3ab-4cb1-9e0a-b23660a6dfd1"), new Guid("8196d3fb-8242-4ef1-98f5-a84641e872cc"), new Guid("902c3696-477f-4a76-8010-f43bea1fc1ce") },
                    { new Guid("050d61a7-6c28-4063-9b30-6ccc4b5917a3"), new Guid("e27a1eaa-62dc-473e-bc5e-8b53be54147a"), new Guid("1d98d2f9-fc2b-445e-9240-2b52f855fdff") },
                    { new Guid("ab9dbd09-49d3-4b4e-9d01-7dc0ad3fc56f"), new Guid("e27a1eaa-62dc-473e-bc5e-8b53be54147a"), new Guid("85744990-e124-44b1-9551-667f2d2b18f8") },
                    { new Guid("da3492a6-a71f-486d-9131-ba6e48c78cef"), new Guid("e27a1eaa-62dc-473e-bc5e-8b53be54147a"), new Guid("42611b34-024e-44e6-b9e2-9e899348226e") },
                    { new Guid("1ff6862d-559b-4de9-a17a-cf50c37df6d9"), new Guid("e27a1eaa-62dc-473e-bc5e-8b53be54147a"), new Guid("0612bfba-673a-412a-8066-c4e8edf80ae0") },
                    { new Guid("29cdb480-bcf7-4454-b2eb-51f42f44f28e"), new Guid("e27a1eaa-62dc-473e-bc5e-8b53be54147a"), new Guid("6a5041d4-61e5-4853-93c8-087e04a37eab") },
                    { new Guid("91ed289c-ff8f-4f51-ad8e-31174e389be3"), new Guid("e27a1eaa-62dc-473e-bc5e-8b53be54147a"), new Guid("193ee547-0487-4be6-8484-98bb490f1d28") },
                    { new Guid("236603e8-b149-490d-b44d-ac7d7c751fc4"), new Guid("e27a1eaa-62dc-473e-bc5e-8b53be54147a"), new Guid("5b2ddf01-17ef-43e5-afcc-e56999a223d2") },
                    { new Guid("44d9de78-08d7-4be5-b9df-7a54c24bc93b"), new Guid("2195c00a-aeb2-4fdd-a4e1-5914405b0232"), new Guid("155efa13-0af5-42ee-82de-a933dacfbf72") },
                    { new Guid("37b94448-753b-4f7e-acb6-a13b83ab1a3c"), new Guid("2195c00a-aeb2-4fdd-a4e1-5914405b0232"), new Guid("38dd8e9c-5b77-4de1-a93b-d6aad9b4b2e9") },
                    { new Guid("292e36a9-fc57-4e6e-b2b5-38fd046d5054"), new Guid("e78bc187-e8b5-45c4-b33b-5717e61fec46"), new Guid("0366953a-71e8-4f6c-b3d8-2196c36f63c0") },
                    { new Guid("4facfa07-e351-4d65-821f-9088ae6ed1c7"), new Guid("e27a1eaa-62dc-473e-bc5e-8b53be54147a"), new Guid("147c9928-3d2d-440e-bd2c-783b9ae625a4") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6a5041d4-61e5-4853-93c8-087e04a37eab"), 0, "9d7561be-5055-461b-96dd-e557d5eacec7", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEIanSbymb8Qq83HRSmEMzMjvpYxmVRrK46f240Z2hGSuvm9n3vqBEzLpF+yI60aZpg==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("1d98d2f9-fc2b-445e-9240-2b52f855fdff"), 0, "29d482e1-83f9-4bea-ae46-5a20ef7d1e48", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEMXoEg1s+vzDdUuxN/VrRiu/PHP/r+cY6O8R5dAhjC79h+2/07Ztl9drT7GrOhPU+g==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("85744990-e124-44b1-9551-667f2d2b18f8"), 0, "1a839031-e885-4611-a0a7-f3cca286a566", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEFJ25qCuWA4PGFK8gNa6pI1eU6WzI9mPXYcJYq2J3oggvX2xznjind4MUHeiymOvmw==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("42611b34-024e-44e6-b9e2-9e899348226e"), 0, "16037304-858b-4a59-a9a6-40228dde0cea", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEPLvdLtlMgC3i8CO+689P8c/DPr2uWx3R51DZ27X7aDqJMtTcMDnGa8jxM5yoREpSQ==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("0612bfba-673a-412a-8066-c4e8edf80ae0"), 0, "841e50b2-17c2-473a-adf4-7231ffc4d4e4", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEJyOm+XFTxVJ14ViF1vKdAbVpKCWM6TyB7StnbFO1eBmUlu9B8pSuYvcd8Qh550OMg==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("5b2ddf01-17ef-43e5-afcc-e56999a223d2"), 0, "eb8c928f-b4e5-4883-a72c-3dd664df3cc9", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEH1wNGtRAriaCwFL8dpq5Ia1QALAdU5XJSpLVDgcL01VTjlZvEenkkGsJsixoIrKZg==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("193ee547-0487-4be6-8484-98bb490f1d28"), 0, "7791d7e4-24ca-4982-bec9-006d10955ce9", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEFzJBl8VTAknQuzF4Bc5NWpME04ksN+yp7sBTXIBiNjgHAKtK9nOjuz1iQpATBMcYg==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("155efa13-0af5-42ee-82de-a933dacfbf72"), 0, "eb4aaeb4-8e6c-4267-aea7-251d0cb98886", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEG2pRwrFERd6d/LZxlmvCnkZ0rwIDmwrzHiShj7LFU4WNmIkVVTVpsm7QsHiZliiUg==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("38dd8e9c-5b77-4de1-a93b-d6aad9b4b2e9"), 0, "7605842c-2a74-4787-8d0c-f3fec546d901", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEO/s9wLk8YG6C0tvzuF6W+4Tpi133OY6m3pr4QTBGFCYs0SpS8pX1+18g4hlDspeRA==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("0366953a-71e8-4f6c-b3d8-2196c36f63c0"), 0, "becdc44f-eaab-4c22-b6ad-c6dfcb496b2d", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEGQ4cpCCAiXWe2D3z7ZeWkLQ8aDXZJ/LygFM2JsUmZDT3MB7H3L0FkD7ki7mRJm+ZQ==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("902c3696-477f-4a76-8010-f43bea1fc1ce"), 0, "9fbe29ad-acc1-4f8a-971f-646b6c5638b8", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAEHtNC0QbWBbf4W0zODmc8l+sdGZTvAmwdWwq8wE76ssLtt+7eYfOaztshVaJFYVSwA==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("147c9928-3d2d-440e-bd2c-783b9ae625a4"), 0, "c32a7c72-66fd-4461-a866-f8c69296aa9b", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAEKUDKQ4BoLIXvpaQR+iG2qLpdVdhO7ukiGT8/Q85Ay+S/AlcNkI6pvuPH3Ytsl8Zpw==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("1d6a3813-eedd-4ad8-8e85-acbd5742519a"), 0, "4be4cabb-3ffb-4291-bab7-b34cc778deda", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEFPgMwJFrA/cHssXDggW6bf5QT8e+ForN0FoNOxzvBtHRoj+5utOv6MmtHUGO5hYOw==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "CanSubmitBachelorProposals", "CanSubmitMasterProposals", "UserId" },
                values: new object[,]
                {
                    { new Guid("fbe254eb-c9ec-48d2-bb3e-b459d7b8180b"), true, true, new Guid("902c3696-477f-4a76-8010-f43bea1fc1ce") },
                    { new Guid("49df02bc-9520-4bc8-8ce8-7fd16403c03e"), true, true, new Guid("1d6a3813-eedd-4ad8-8e85-acbd5742519a") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0c9af1d6-5889-4c40-89f0-8a6b8625d586"), null, new Guid("5b2ddf01-17ef-43e5-afcc-e56999a223d2") },
                    { new Guid("3facc1cc-7930-4a37-816f-a9150079c228"), null, new Guid("193ee547-0487-4be6-8484-98bb490f1d28") },
                    { new Guid("f194ba25-9f1c-4ae3-a2e3-7594be36dd69"), null, new Guid("147c9928-3d2d-440e-bd2c-783b9ae625a4") },
                    { new Guid("01d20285-719e-4f54-9be5-d45a9919f542"), null, new Guid("0612bfba-673a-412a-8066-c4e8edf80ae0") },
                    { new Guid("c476a1eb-db63-4105-9781-781bbcb764e2"), null, new Guid("42611b34-024e-44e6-b9e2-9e899348226e") },
                    { new Guid("e9e95e41-aadc-4885-8780-479a663be362"), null, new Guid("85744990-e124-44b1-9551-667f2d2b18f8") },
                    { new Guid("2be6f969-3ffc-4a35-8ddf-a69bd02b0b70"), null, new Guid("1d98d2f9-fc2b-445e-9240-2b52f855fdff") },
                    { new Guid("54451773-6312-43ec-9570-4bcd4b3084ba"), null, new Guid("6a5041d4-61e5-4853-93c8-087e04a37eab") }
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
