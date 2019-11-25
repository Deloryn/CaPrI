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
                    { new Guid("4949a0f7-ea6a-48b0-8495-de5bdedc9112"), "06d06898-60a5-489e-9498-95dc54a55d25", "admin", "admin" },
                    { new Guid("e20e49d3-01d1-4f8f-9fb7-4aabf8c7ef48"), "414056bf-2974-49d1-9136-7cec34e60de8", "dean", "dean" },
                    { new Guid("37cfc35b-b196-442c-b5ea-645f542cd308"), "f70dbd6c-177f-4c99-b309-7cfb7b65977c", "student", "student" },
                    { new Guid("848b3e60-02de-4b57-8a13-67dad13850df"), "7ee3a676-4451-4235-8042-f50292079bf1", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("93c2de63-6f88-47b4-8005-c7609fc73cb9"), new Guid("848b3e60-02de-4b57-8a13-67dad13850df"), new Guid("0b6e162b-ec2c-4531-95e0-3cb8e531bc1e") },
                    { new Guid("b3e9681f-2f4f-4919-b2fa-7d6df52ea20c"), new Guid("848b3e60-02de-4b57-8a13-67dad13850df"), new Guid("00b694f9-16e6-4694-87be-67b86f5b125f") },
                    { new Guid("399a58c7-eb42-4aba-a824-3954130d3770"), new Guid("37cfc35b-b196-442c-b5ea-645f542cd308"), new Guid("55f69499-f43e-40e6-815c-7f90b30e0c48") },
                    { new Guid("d396fb08-279e-4c6c-92c7-4f86572c50aa"), new Guid("37cfc35b-b196-442c-b5ea-645f542cd308"), new Guid("b6e30589-0007-49d3-b809-94082439195c") },
                    { new Guid("9915face-d6ce-4534-8975-ef78cb474aac"), new Guid("37cfc35b-b196-442c-b5ea-645f542cd308"), new Guid("ef0f767d-6fd9-4caa-9242-149c964286f5") },
                    { new Guid("73b40b23-80b9-42e0-9530-5fdfcd8338d0"), new Guid("37cfc35b-b196-442c-b5ea-645f542cd308"), new Guid("5a5942c2-89d2-47c9-85b4-ecf29bae5745") },
                    { new Guid("d1ea7158-0425-47e4-915c-f08ff34e60e3"), new Guid("37cfc35b-b196-442c-b5ea-645f542cd308"), new Guid("50a23bc0-09b8-4878-85d7-d30221241d0b") },
                    { new Guid("4aecdbd1-e922-4886-8ed4-0622fa53e3c1"), new Guid("37cfc35b-b196-442c-b5ea-645f542cd308"), new Guid("92101757-a6f0-40ba-8b17-54200b3cdaf4") },
                    { new Guid("089c81ed-5490-4d6e-ad88-8e9576403b7b"), new Guid("37cfc35b-b196-442c-b5ea-645f542cd308"), new Guid("3f968515-5d19-4381-b4d4-7973e9749a0d") },
                    { new Guid("38f87300-5f11-4c5e-aa74-fc4b20076c8f"), new Guid("e20e49d3-01d1-4f8f-9fb7-4aabf8c7ef48"), new Guid("44a21a0d-14b5-4e13-a090-8d9904c1315c") },
                    { new Guid("3ffb1094-b542-4a08-b4c9-98feb35ca4f3"), new Guid("e20e49d3-01d1-4f8f-9fb7-4aabf8c7ef48"), new Guid("b557a033-8b23-465a-93a4-90879534c470") },
                    { new Guid("07870bf6-52ac-4f95-8345-7fa43cd8377a"), new Guid("4949a0f7-ea6a-48b0-8495-de5bdedc9112"), new Guid("f85d2ece-58ec-4922-85a8-3cb1d0ed4e06") },
                    { new Guid("2c044cf8-717b-4d33-8104-b900ce05a69f"), new Guid("37cfc35b-b196-442c-b5ea-645f542cd308"), new Guid("69e2b8fc-7db7-4c4c-9add-d5be8468c9d6") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("50a23bc0-09b8-4878-85d7-d30221241d0b"), 0, "dfdbc037-3df7-4977-a8c8-640b180987ee", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEAfE5tXzWpjL7PK1wqlqG/PUJ6q3kNMqhsGnLPYxzHVIpkURN39iwsTHf5e0ig+QLA==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("55f69499-f43e-40e6-815c-7f90b30e0c48"), 0, "27055214-f684-41ee-96e9-95614dac7570", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEOSh9UMwFZCLmzFYKPin53lnX8LQDstefSObGEzfe50LHgw3Q/lIUeN4n0wq+nOHqA==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("b6e30589-0007-49d3-b809-94082439195c"), 0, "a775008d-ec47-46c4-ace3-8e8d0253e442", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAECX2DrEDXzAoUKhY2S7ghKzOv75xUw+/GVAyjUPmYmXYr03snh0OENnoDtOGITmvzQ==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("ef0f767d-6fd9-4caa-9242-149c964286f5"), 0, "8402c58a-fbe1-4b10-b565-3a9ef0c2de39", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAELv8subnVyh5Vw8OonekkvAQ017IhO0+scdYAPX8SRmj7rQEGuDP5qNAguDM84oh1Q==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("5a5942c2-89d2-47c9-85b4-ecf29bae5745"), 0, "ef27e10a-da12-4792-8e4c-e86935de8f03", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEM9PyB0gRH3FhRQRdVkDUsVAe5eqeGBhFHGa/KQG2gagoTRt0sKKJ5pcNvEvQbT6yg==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("3f968515-5d19-4381-b4d4-7973e9749a0d"), 0, "cc38b001-0c7e-4490-b58d-36753f3ed451", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEGglLzjMYbEOmKuc706SPUvdBgIczilcocKh3MQWY1PDvwpjRUtXTcQtJ5SQaYw0+Q==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("92101757-a6f0-40ba-8b17-54200b3cdaf4"), 0, "c510f7cc-f10c-4e1f-85c8-5471aed63257", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEPJBUfvvPeuF1EgijVzxMd4XXBzw7ShUyOLav8FB4ZWKbY1rLJoIQQWmi2RC6Wtn2Q==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("44a21a0d-14b5-4e13-a090-8d9904c1315c"), 0, "75f51e0b-6617-4abd-a6ed-a330d86a9e3d", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEIDtXc3i4ZFd3Bpl1keXF6Iv+SRno+Jc8ejtZ9z+Fmmvj37FWgGqkiQzeQph4tqJIg==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("b557a033-8b23-465a-93a4-90879534c470"), 0, "c27c9cd8-8b2d-4e5b-9c59-d2f736a8f770", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEAhfdiAUiEqbndUZJjNFHMRI2GtHUrZxIgPMeE2xt/vgTJhcH0ebfXDP5B8TWbD29Q==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("f85d2ece-58ec-4922-85a8-3cb1d0ed4e06"), 0, "2dc7277c-d543-4a87-a312-52cd9b0f1ce4", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEG8Entt6FFjzEmaCyo6jLAk3pYpjs48QbP7X88z094jHX+kJrxv5euLIIy/PN9HvEQ==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("00b694f9-16e6-4694-87be-67b86f5b125f"), 0, "b8df243c-1c9c-4e33-9be9-9315d6f844c4", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAEKueuLZtoO+5cWbOArY5xbf2qEOSoO2MADYXGiYv/zIcZfmmoEWVdHqBU0MsxknoNQ==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("69e2b8fc-7db7-4c4c-9add-d5be8468c9d6"), 0, "02ea6484-7100-4029-b351-59467dc73e9e", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAENbSi/c/2MYlsXFZCSJfiUBDwv1WSvey/k90jamq8qn2ZvNJxqoibLo4Jpj/i+ijuw==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("0b6e162b-ec2c-4531-95e0-3cb8e531bc1e"), 0, "34b3817c-2831-4a3a-a75f-bc8edb1c6e4b", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEJfh94jYsNzpkZjToRnPwpPmvwq3VuIKiaeA/s6mI2rgnOv+kqZlGaO6UstBUbWGRA==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "CanSubmitBachelorProposals", "CanSubmitMasterProposals", "FirstName", "LastName", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("b3521b30-d419-4a7c-89ab-94d1b983b59c"), true, true, "Jan", "Kowalski", "Phd.", new Guid("00b694f9-16e6-4694-87be-67b86f5b125f") },
                    { new Guid("fc151c25-1427-4d6b-9509-bd6eca80df9e"), true, true, "Jan", "Kowalski", "Phd.", new Guid("0b6e162b-ec2c-4531-95e0-3cb8e531bc1e") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a3b6a2f0-b06c-4c1c-a732-1860b0cb3e7c"), null, new Guid("3f968515-5d19-4381-b4d4-7973e9749a0d") },
                    { new Guid("5b580e21-7765-4d31-a1cc-fe4a38317003"), null, new Guid("92101757-a6f0-40ba-8b17-54200b3cdaf4") },
                    { new Guid("a81391b2-5447-46f1-8344-7836fa00b4d8"), null, new Guid("69e2b8fc-7db7-4c4c-9add-d5be8468c9d6") },
                    { new Guid("7d2b0013-672c-43dd-b321-19623b4bec4b"), null, new Guid("5a5942c2-89d2-47c9-85b4-ecf29bae5745") },
                    { new Guid("f974589a-be25-4ecd-a37f-21eb9a564881"), null, new Guid("ef0f767d-6fd9-4caa-9242-149c964286f5") },
                    { new Guid("be107470-7a37-4ece-b48d-95c6c8cea576"), null, new Guid("b6e30589-0007-49d3-b809-94082439195c") },
                    { new Guid("0c8d5cec-a26c-425c-a552-1aca9795275f"), null, new Guid("55f69499-f43e-40e6-815c-7f90b30e0c48") },
                    { new Guid("8f7d3030-f48f-4d64-a987-f83ab8b52d86"), null, new Guid("50a23bc0-09b8-4878-85d7-d30221241d0b") }
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
