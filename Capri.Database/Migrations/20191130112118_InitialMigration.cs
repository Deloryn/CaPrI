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
                    PromoterId = table.Column<Guid>(nullable: false),
                    PromoterId1 = table.Column<Guid>(nullable: true)
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
                    { new Guid("f61e3c32-58ca-42e4-b70c-3e87cbab88ac"), "e3449912-7001-47f4-ab68-22c51db82774", "admin", "admin" },
                    { new Guid("560513df-4210-4ca4-b4dd-8b4b2890bb0b"), "67f9ac58-b1c2-4dd1-96c5-44aed605d580", "dean", "dean" },
                    { new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), "139f2a78-adee-4dc8-9a28-cec36c74d4c4", "student", "student" },
                    { new Guid("52b0fee2-7ed7-4dc2-b39e-901a85bd5c72"), "3debde0a-b320-48e0-9bbd-5dd85a6ff6ec", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1d306d4b-ac61-4d02-8333-e883dbc5bc23"), new Guid("52b0fee2-7ed7-4dc2-b39e-901a85bd5c72"), new Guid("4d017242-93a8-4846-bc37-19af61bf8c3c") },
                    { new Guid("e808945f-f753-411d-b630-667052e45100"), new Guid("52b0fee2-7ed7-4dc2-b39e-901a85bd5c72"), new Guid("f5ddef41-423c-4019-86c6-6a1ad7b118d9") },
                    { new Guid("3f17fadc-69e2-472a-a562-ea271dc3ba41"), new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), new Guid("651e94f8-c4c9-422e-9a18-0a97f346f711") },
                    { new Guid("1387dc83-9467-4ddd-bb74-6dbceab9df8d"), new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), new Guid("3b3d8bfa-4f33-40c7-97fa-c7603c8e01dc") },
                    { new Guid("fb73c8ce-61f0-4099-a140-d87118bb7e64"), new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), new Guid("86dd4cfb-8c25-4ea2-b9e4-02a3bf90f04b") },
                    { new Guid("50b51a21-021c-4a7a-b82b-111398e1efef"), new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), new Guid("28c7ab57-e880-449f-8872-bcb3926af60e") },
                    { new Guid("2d9043b3-cbb5-4926-904d-a87c66376dc3"), new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), new Guid("b0a39d16-11c1-4839-a85d-eb1b1516a26a") },
                    { new Guid("599948c0-e1ce-40ea-8159-302bfb035959"), new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), new Guid("c4fccbdc-bbd5-4178-8a10-b57c314739b4") },
                    { new Guid("566b6d3e-922c-46ee-9b51-c885eab74b1b"), new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), new Guid("45e1a663-02bb-432f-9f39-4f16a147128a") },
                    { new Guid("25e51715-7b1d-41b3-b2e8-689afb170d1a"), new Guid("560513df-4210-4ca4-b4dd-8b4b2890bb0b"), new Guid("a3d47d5b-6153-4279-94ba-bfb1530e4cc6") },
                    { new Guid("f9c97bb9-c44c-4f90-849e-360f6a4dd070"), new Guid("560513df-4210-4ca4-b4dd-8b4b2890bb0b"), new Guid("443154d5-030a-433f-a490-7caad4cc3bb7") },
                    { new Guid("0a362762-20d5-43ce-a423-9469b284d735"), new Guid("f61e3c32-58ca-42e4-b70c-3e87cbab88ac"), new Guid("8fc81b45-6907-47d4-bbfa-dfb79e240527") },
                    { new Guid("90e28168-f20c-4cfa-8050-fc6be9aac0d4"), new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), new Guid("fd079259-7702-40cd-888e-a2a30d9349ea") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("b0a39d16-11c1-4839-a85d-eb1b1516a26a"), 0, "b9265335-bc06-43c5-ae96-ff2a53cb6992", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEIijz/GYn5qYisJBD2bSVlM4vzYVnNDoLKDteeCq9SFv8aMRSceNEhD3BQZ9rgx86g==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("651e94f8-c4c9-422e-9a18-0a97f346f711"), 0, "f4a14606-3c64-49d0-a306-fe1e05121989", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEK20+0iRuXGc7HvqILynWbaWDYvlRiDXsv+UR+16o/oo/2Rgc1DNOkdGR6JzDafQDg==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("3b3d8bfa-4f33-40c7-97fa-c7603c8e01dc"), 0, "e62b6462-4370-432e-8266-0a7bdbb6da6c", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEATtNCBpuxVciS78cymFo1iBDHtn89tw2censmFwvanOUmQYivCLaBLx/TBBd2bKxA==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("86dd4cfb-8c25-4ea2-b9e4-02a3bf90f04b"), 0, "3c94716e-0ed4-47c7-b049-cf9b4bc7d1f7", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEOyjhSBbuqB6awdSR27znkGdMfp9YEsQ7agGcpqK/Ykr5SH4mbbG5bKEG4I7rRFmiA==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("28c7ab57-e880-449f-8872-bcb3926af60e"), 0, "560e50ff-2d71-4d2c-a5c5-329aac9c51d9", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEIr6TtMpOwYIJ+GAGYCKCClkfYXhIHSNV7zV60JXJ4xhOoWMAOOpZcbHvBHEdgvaYQ==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("45e1a663-02bb-432f-9f39-4f16a147128a"), 0, "8156e2a7-b2b3-4347-91ed-a28be611e5c5", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEJbBmtcBs+kxFIX1P/PKqQALqLHbZLgM2D1wMS8FmiBlu7ZUCDAGUs9MgzhdUnd+1w==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("c4fccbdc-bbd5-4178-8a10-b57c314739b4"), 0, "39a03667-e007-4b50-a903-d9423455433c", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEGyR/pUSgmkvqI08P4Tby4s39sHkREDSuz8g+I1NyMTbnQ/73PIDGOL66dRtTQEcDg==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("a3d47d5b-6153-4279-94ba-bfb1530e4cc6"), 0, "8e4808ad-d820-4f67-a91f-0f9f30e775a9", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEJ2PkgRIe0yyxDke4xV0JxJ02da8KeDcjMXtNe3yVZORRDqeptUjQmx2qsuJWPInhA==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("443154d5-030a-433f-a490-7caad4cc3bb7"), 0, "98a100bc-ee4e-463e-b84b-f3a0ccf89fe9", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEOT742qr0L1boAeHjveg1hbaix9az3/2HNnIqPJdyKV8UP5jlwZ9rmmLguNlzZY/TA==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("8fc81b45-6907-47d4-bbfa-dfb79e240527"), 0, "45ecf151-2a59-4341-b05b-802e14b4389a", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEOqMknFptMq+z/4CbdmcWKRnmCtnTMItBy3wfteuErI6rlmH9ju5vMURdoKXwyNwdw==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("f5ddef41-423c-4019-86c6-6a1ad7b118d9"), 0, "0cc797b9-0962-4650-afc1-b9572f50e29d", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAECkv6u/sScVM2E0+DFLdurnzaAQ+1201hxGZXHengcpQmFl7M1bs4h2pefa4Cb9uug==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("fd079259-7702-40cd-888e-a2a30d9349ea"), 0, "dc161edc-ef2e-4dc3-b57d-c360976b538f", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAENUIvlf+mVPWRFqhUnHQOrSDvoAeh9EXTizqOT2YNAYbSBOwq1ZP0S69qbNCV6/vEQ==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("4d017242-93a8-4846-bc37-19af61bf8c3c"), 0, "b081d0fd-a687-4166-9efb-721a18354b73", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEATgum8Pkx/dg3flk5y9NwDzoQBdzP5OLNIS8gCAsFcVW14VsCT/SB0ZJ952shfhKg==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "CanSubmitBachelorProposals", "CanSubmitMasterProposals", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { new Guid("32e7fdda-9528-4263-a6db-0f3e079039de"), true, true, "Jan", "Kowalski", new Guid("f5ddef41-423c-4019-86c6-6a1ad7b118d9") },
                    { new Guid("fca052f9-566f-4b50-9ef0-233af72b6888"), true, true, "Jan", "Kowalski", new Guid("4d017242-93a8-4846-bc37-19af61bf8c3c") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c161a023-1257-4431-8667-03b7919fc332"), null, new Guid("45e1a663-02bb-432f-9f39-4f16a147128a") },
                    { new Guid("d3cba93a-4da5-455f-a70b-b9452be27792"), null, new Guid("c4fccbdc-bbd5-4178-8a10-b57c314739b4") },
                    { new Guid("34c9ff28-5d56-49aa-ba79-94dce9f74c23"), null, new Guid("fd079259-7702-40cd-888e-a2a30d9349ea") },
                    { new Guid("ae4d7ac1-d95c-435e-96b2-0b712cb11631"), null, new Guid("28c7ab57-e880-449f-8872-bcb3926af60e") },
                    { new Guid("eedf24b6-330d-4766-a146-a5926a59fd19"), null, new Guid("86dd4cfb-8c25-4ea2-b9e4-02a3bf90f04b") },
                    { new Guid("8886bc27-8c6d-4093-9da9-dba6544143c1"), null, new Guid("3b3d8bfa-4f33-40c7-97fa-c7603c8e01dc") },
                    { new Guid("5ffe2239-13e1-40bf-9374-2337b191262a"), null, new Guid("651e94f8-c4c9-422e-9a18-0a97f346f711") },
                    { new Guid("8cf38aac-02c7-4703-a650-2243def3705a"), null, new Guid("b0a39d16-11c1-4839-a85d-eb1b1516a26a") }
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
