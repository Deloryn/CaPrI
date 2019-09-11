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
                name: "User",
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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CanSubmitBachelorProposals = table.Column<bool>(nullable: true),
                    ProposalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Topic = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    PromoterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposal_User_PromoterId",
                        column: x => x.PromoterId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cf755c9e-1fa8-431b-a843-685515b6492f"), "c82007b2-7f65-4b7c-ad87-7cca7d7c3733", "admin", "admin" },
                    { new Guid("9530cb95-ff5b-4a7d-933e-311bf7df39b3"), "5343fce2-0be0-4634-9ef8-2fc3e364961e", "dean", "dean" },
                    { new Guid("6fd2aed2-7506-46e7-af52-aff29de5c7ae"), "5f86f12d-a606-464b-bba6-b9f5d954f8b1", "student", "student" },
                    { new Guid("cde3233f-3d70-41c9-bd65-ae52f2965c26"), "bac1cdc5-b237-4773-a77f-4fc903a39e60", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ProposalId" },
                values: new object[,]
                {
                    { new Guid("ee4a511c-bc5f-47d1-8089-6643b3386206"), 0, "b2603169-9acd-44d1-8b4f-6f68c157b09d", "Student", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEPA0LsWk3ox8lepkLZaNWLcDz8FYfPocmc8UVuTg13jO1+u7jPZiR4tUbRLgpMk8Bg==", null, false, "", false, "student6@gmail.com", null },
                    { new Guid("84b47ba5-c432-4ce4-a059-9158fca19aaf"), 0, "39e99e18-f2a5-49b4-a652-49bbc24675ef", "Student", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEHyaeD0f1KaRFMZt+3lrY5bUHbLWsnBmeuvBmfar4z02EmZCnYPE/OBLbWucKgWkig==", null, false, "", false, "student5@gmail.com", null },
                    { new Guid("a7fa3426-c6a8-428d-810b-40ed0f7c831c"), 0, "3ded807a-9282-4d9b-8e47-fb8ed938ecdf", "Student", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEInbYVlFkBSAd0rFLRhEx5hz8wm0VuxoCyK0w1s8pdPgo6ouKQnUSwZciRlWxU1MEw==", null, false, "", false, "student4@gmail.com", null },
                    { new Guid("0cb455d8-e44e-4e83-bab6-6c396eaa4880"), 0, "9394271a-4ebf-4fc4-a21a-ad16de245081", "Student", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAELON3X++Uloh2SrL11R8aVPuXFs/GAB8yEiOjyh/lqEO9I52rMZdZHD83+88+LxwBg==", null, false, "", false, "student3@gmail.com", null },
                    { new Guid("3b8b57da-e120-44b5-a419-2323fe327e46"), 0, "2df5eca0-9b59-40f5-ac6e-5f84e31c20e2", "Student", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEOKsjd7ERhqAUmRAibeDvTiAUOb9IufLQLRQTAhJRSl5CyCL0CQaSO2oI+ElNpXVMQ==", null, false, "", false, "student2@gmail.com", null },
                    { new Guid("21620ed2-e276-4335-bb21-06a725d3f48e"), 0, "5e18ed73-d309-47e7-9584-791592b9019b", "Student", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEKByNY5G1pGEd+oqspTKFNobPsMQPdCRnvTvw3vCRPikBUhZvKfyVuYu9lfzvRa4yw==", null, false, "", false, "student1@gmail.com", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CanSubmitBachelorProposals" },
                values: new object[,]
                {
                    { new Guid("27cf0cdb-f3e8-40ff-948a-a942907c02b9"), 0, "d5d2dcad-c5a3-4cdc-886c-82d42686ccd0", "Promoter", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEJew+7umuQ0TiQ2Zsh7W35j5Q+62/IlGOTZ7qJ+NCzeg4oNKiKCWcXtSDVwfYhhhDw==", null, false, "", false, "promoter2@gmail.com", true },
                    { new Guid("6e94fbe0-0be4-44cc-87d4-bc18c644dd52"), 0, "3c105a64-6d61-4605-81fa-dee49517e232", "Promoter", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAECblSmDidQr5hzW9KxMJz0aZWSyDKQPEKjjZDmd7ovQxuZg2kQ0scB/7XS3XEmUzqw==", null, false, "", false, "promoter1@gmail.com", true }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("26d85022-6548-4132-bbd6-1dd7d3ac5b14"), 0, "3f75e517-ec31-467a-8df3-5f74706f13e5", "User", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEPai47qT19usidodFtunCJGMVNwuwWYX9F+gu7CKM7yEgCq9TfMcUssdf+wZxz+CGQ==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("15648e5b-23f0-4e29-a296-fe8f39e6da63"), 0, "df5efa2b-6358-4f6e-a815-88d73f42a38e", "User", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEPQ2Jsriy1q+JC9uzDHDfkx11d5iEC89I01EU9VGKOiEA8M36qcyFq6vVehNB9g+QQ==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("d1eb3bc0-f8d5-43cf-97be-a65ca0eac532"), 0, "75407574-1792-469c-938d-7f04d893385a", "User", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEPuv5d7y3W4wQWr06UTvzyfG7oP0ep2/C9o2X+V978waDNspzCyFxOjj+gELVL3HYA==", null, false, "", false, "admin1@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ProposalId" },
                values: new object[,]
                {
                    { new Guid("99296901-fe1f-47e0-8743-f244069a1a1a"), 0, "24fb6d16-42d5-4460-b136-41260258c4b2", "Student", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAELAQYHqeG5ukpyw81V4zZrGIlLrVCfSm5EkXdKwqRe15IxlzYMoGYDxIIkw6xd4ZCg==", null, false, "", false, "student8@gmail.com", null },
                    { new Guid("cc9b564d-31f7-4dc3-a5d7-5774deb557e9"), 0, "d1a4fe02-2d31-49f0-b1a4-0faa7c6bb62c", "Student", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEOqYBLygshZ3Yr1BluJVjvNe7DXBn5V/xfP7Y41cjjS83wMVWe8CKkI9UWTGYEr4wQ==", null, false, "", false, "student7@gmail.com", null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b89c1c14-db06-484a-a52f-ff8faaf6cbaa"), new Guid("cde3233f-3d70-41c9-bd65-ae52f2965c26"), new Guid("27cf0cdb-f3e8-40ff-948a-a942907c02b9") },
                    { new Guid("f0ee38dd-9008-46a0-9083-b76d02df6636"), new Guid("6fd2aed2-7506-46e7-af52-aff29de5c7ae"), new Guid("cc9b564d-31f7-4dc3-a5d7-5774deb557e9") },
                    { new Guid("df549e68-7804-4ca2-a57a-42ba1d1dee43"), new Guid("6fd2aed2-7506-46e7-af52-aff29de5c7ae"), new Guid("ee4a511c-bc5f-47d1-8089-6643b3386206") },
                    { new Guid("f8a89372-b381-4f6d-aa2a-9ba9f6ba7b9f"), new Guid("6fd2aed2-7506-46e7-af52-aff29de5c7ae"), new Guid("84b47ba5-c432-4ce4-a059-9158fca19aaf") },
                    { new Guid("ebd42969-552a-4693-8404-0911ab20088c"), new Guid("6fd2aed2-7506-46e7-af52-aff29de5c7ae"), new Guid("a7fa3426-c6a8-428d-810b-40ed0f7c831c") },
                    { new Guid("3bbd1c67-a4d2-44b6-866f-a156c837d355"), new Guid("6fd2aed2-7506-46e7-af52-aff29de5c7ae"), new Guid("0cb455d8-e44e-4e83-bab6-6c396eaa4880") },
                    { new Guid("8e76536d-aa12-45de-b92b-b304bcb9cc37"), new Guid("6fd2aed2-7506-46e7-af52-aff29de5c7ae"), new Guid("3b8b57da-e120-44b5-a419-2323fe327e46") },
                    { new Guid("f8209afa-0447-4984-be3f-115e9fa3361d"), new Guid("6fd2aed2-7506-46e7-af52-aff29de5c7ae"), new Guid("21620ed2-e276-4335-bb21-06a725d3f48e") },
                    { new Guid("ff8c5df2-8e89-47ac-a309-702d622ac4b2"), new Guid("9530cb95-ff5b-4a7d-933e-311bf7df39b3"), new Guid("26d85022-6548-4132-bbd6-1dd7d3ac5b14") },
                    { new Guid("cd9a3ba2-f923-422c-8090-388b6998d2cb"), new Guid("9530cb95-ff5b-4a7d-933e-311bf7df39b3"), new Guid("15648e5b-23f0-4e29-a296-fe8f39e6da63") },
                    { new Guid("e0588665-ae98-4e76-9f46-a69547dcd60c"), new Guid("cf755c9e-1fa8-431b-a843-685515b6492f"), new Guid("d1eb3bc0-f8d5-43cf-97be-a65ca0eac532") },
                    { new Guid("30d199c6-8875-4a4d-98e7-a2eb87fa7082"), new Guid("cde3233f-3d70-41c9-bd65-ae52f2965c26"), new Guid("6e94fbe0-0be4-44cc-87d4-bc18c644dd52") },
                    { new Guid("83fdc4cc-ce2e-422d-b99b-d30210cb6eef"), new Guid("6fd2aed2-7506-46e7-af52-aff29de5c7ae"), new Guid("99296901-fe1f-47e0-8743-f244069a1a1a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_PromoterId",
                table: "Proposal",
                column: "PromoterId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProposalId",
                table: "User",
                column: "ProposalId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Proposal_ProposalId",
                table: "User",
                column: "ProposalId",
                principalTable: "Proposal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposal_User_PromoterId",
                table: "Proposal");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Proposal");
        }
    }
}
