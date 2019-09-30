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
                    { new Guid("5933c8bb-6094-49cc-9313-6b784a820c1e"), "c1718cd9-c480-494f-b5f2-03ade3a7a474", "admin", "admin" },
                    { new Guid("756f25fc-0dc8-4893-b1cd-96aef6baa645"), "29c07907-6221-475a-b705-182fb7a89713", "dean", "dean" },
                    { new Guid("1fdd44c4-37fb-4302-88b8-7ff29d7f205d"), "cded1c98-6b49-4ca1-a64f-0cb1c7f21ef5", "student", "student" },
                    { new Guid("acce96ec-bcb9-44c1-b6a5-99a67803bd30"), "8cafe5da-7928-4187-8519-1b6c25914443", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f1811b5c-2f7a-4176-a762-4be1a6e47b14"), new Guid("acce96ec-bcb9-44c1-b6a5-99a67803bd30"), new Guid("5cc5d319-2d46-44ed-95eb-aae8a0d85bf5") },
                    { new Guid("81833620-9b63-4d9c-8852-8fcf78a53e4d"), new Guid("acce96ec-bcb9-44c1-b6a5-99a67803bd30"), new Guid("90426b18-c881-424d-97b2-11fd0d232ad6") },
                    { new Guid("4fa33943-39e7-4412-ad02-75ea1e764b8b"), new Guid("1fdd44c4-37fb-4302-88b8-7ff29d7f205d"), new Guid("11315ff8-6bc5-4eba-b95a-00420e822330") },
                    { new Guid("7fd66867-5801-470c-825e-d12876c470f9"), new Guid("1fdd44c4-37fb-4302-88b8-7ff29d7f205d"), new Guid("f9f25735-14c0-4e64-92c0-c2763d77b99e") },
                    { new Guid("4b503ff0-5123-4624-a841-d7d2076c91c9"), new Guid("1fdd44c4-37fb-4302-88b8-7ff29d7f205d"), new Guid("8e1fc3de-e849-42fe-8c4e-918f8942263c") },
                    { new Guid("503ad0ab-60fb-4540-882c-67206b6d46b3"), new Guid("1fdd44c4-37fb-4302-88b8-7ff29d7f205d"), new Guid("767eb583-513d-455e-b586-6910127c49c5") },
                    { new Guid("121a1a2c-90ab-4a89-94b4-5cbf78c519f0"), new Guid("1fdd44c4-37fb-4302-88b8-7ff29d7f205d"), new Guid("ba730cd3-13eb-42a0-bcd5-23c321cfe300") },
                    { new Guid("dea94d3e-8571-480f-a915-3ce2936faec8"), new Guid("1fdd44c4-37fb-4302-88b8-7ff29d7f205d"), new Guid("3a373b54-007f-482b-a147-37d692e63c8c") },
                    { new Guid("4e485017-3be6-45de-a86e-d737a70ad675"), new Guid("1fdd44c4-37fb-4302-88b8-7ff29d7f205d"), new Guid("5382ad90-7ee3-421c-af3b-22a5ae4f1303") },
                    { new Guid("8e8a4d66-05a0-4b16-8005-b2e2145024da"), new Guid("756f25fc-0dc8-4893-b1cd-96aef6baa645"), new Guid("19d6e93e-d674-4e9c-812e-8889f6125248") },
                    { new Guid("2f483a0f-8c82-42a1-94ae-7525377e5337"), new Guid("756f25fc-0dc8-4893-b1cd-96aef6baa645"), new Guid("018dea98-9c46-4995-850b-407ffdef4e92") },
                    { new Guid("215cfeb4-ea0e-4e12-b1c7-9fba18d04ecb"), new Guid("5933c8bb-6094-49cc-9313-6b784a820c1e"), new Guid("3b7bc181-a375-47ff-8b49-43c78f25137d") },
                    { new Guid("dda29efe-66fd-4bc5-8058-8b63ce7e5a7f"), new Guid("1fdd44c4-37fb-4302-88b8-7ff29d7f205d"), new Guid("e2d7b9f1-9e76-4910-b1b5-16e16a8a8383") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("ba730cd3-13eb-42a0-bcd5-23c321cfe300"), 0, "7f6cf40c-5ea5-46be-bbe8-df22df7fea14", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEJdSjHZwCRgzcGGWcTxqxkMbkTM62MKBvTkG83widrtQiBRGE9OuukuU87ylSBcsxg==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("11315ff8-6bc5-4eba-b95a-00420e822330"), 0, "f44dbd55-32b6-463b-915e-b882d171773f", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEP0yu+NtTH/Y3TdKIWkUq0zhmOu8ISvrMFY4oLmReoXAKbc7FWEFUyIhsAnWPP+GAg==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("f9f25735-14c0-4e64-92c0-c2763d77b99e"), 0, "35ae3ac3-abcf-498c-bef0-e1ba846c81e4", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEPAI6nds8MRLGb/aRu0WRer0ij7pYYWUzRc3wWLJ69a7nHuARazuVd2T6exB10Epvg==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("8e1fc3de-e849-42fe-8c4e-918f8942263c"), 0, "9833219d-5d3d-4a0b-90ec-572d74dc1dda", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEMR2zXezp+z7AVR38GdRCh2u6UqLBTeYlwPIkVjL8LaswDFyAWFTnrIAh1W/jTJURw==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("767eb583-513d-455e-b586-6910127c49c5"), 0, "edb90797-9451-4e65-9413-8bced1d67d5b", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEKama54Yqxfcc2o8wWIPu5zOdeXjwYlklyGEjkQXNSlysbuLqnMbASkNsYA6E2RIaw==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("5382ad90-7ee3-421c-af3b-22a5ae4f1303"), 0, "335e65c4-1b2e-4ef9-be3e-b2e0a6f01a17", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEB4+Dvq5gXcfo5gML3Lwb1D5jWz/a8C8DfDZr+j51zYNhzMk50wmkXfRG3L6gs8ErA==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("3a373b54-007f-482b-a147-37d692e63c8c"), 0, "4c68e1f2-71e4-400d-8c76-ba17182d384b", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAED2xnpOYFnMufIpFWyhFg2rrsPAlCF682ltqXBG1o6oW51YzjR1iadC+anJfPXfvkA==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("19d6e93e-d674-4e9c-812e-8889f6125248"), 0, "fef98029-9662-4294-93ae-0e8845f9881e", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEMlKgNutDU1j9Err5exojPcm3sTvAlDbx3jg2oWJ41ALPn8+ftaRvT7TkWuTgMj0Tw==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("018dea98-9c46-4995-850b-407ffdef4e92"), 0, "77fe6514-c7a1-431a-a874-34e63163a2a3", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEBRB/5OBOW+HbQgdDIPP4pdqDrxM0CD3+jvIj/WMqztuMjBF6mN29uwJjgHUMuAkUg==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("3b7bc181-a375-47ff-8b49-43c78f25137d"), 0, "7a8c3498-a54b-482f-be2e-a7dd8b0ff3e6", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEE9XzU3yahak5pgbPscgb8zxHBICkOGA5JMB0egeM63e0gMjJREfuogrwhaf/OLd6w==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("90426b18-c881-424d-97b2-11fd0d232ad6"), 0, "553c8710-f755-4808-bc53-302bebd2c8d3", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAEIx2g5cR+lyQDwNw3qUst8LLPaEBewUCIB/kdYqEFgL00q3Txm6vPWZcFVQaaqvwfw==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("e2d7b9f1-9e76-4910-b1b5-16e16a8a8383"), 0, "1059373d-2949-4e1e-ada4-2c74f8b8f03b", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAEGHQE3CjfqmjTo26jfpxU45TpCIoflXbeymMNUK2RkJNs2AKUlBRC3e+5TSyhNoPIg==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("5cc5d319-2d46-44ed-95eb-aae8a0d85bf5"), 0, "e8a67764-da82-41ea-a53e-521eb2e48c12", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEDdTdDrG3v/nr9QpNH/a7fsYM6URMZ96uda+QZJnwvbFnMvc5K8DdawGj79szIqXXg==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "CanSubmitBachelorProposals", "CanSubmitMasterProposals", "UserId" },
                values: new object[,]
                {
                    { new Guid("3ecad404-b35d-4160-8d7b-afbc4b9b473b"), true, true, new Guid("90426b18-c881-424d-97b2-11fd0d232ad6") },
                    { new Guid("46788cfe-7558-4bd0-8d90-90b124fecdb0"), true, true, new Guid("5cc5d319-2d46-44ed-95eb-aae8a0d85bf5") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cf171f9e-9144-4555-a480-974a38d93d64"), null, new Guid("5382ad90-7ee3-421c-af3b-22a5ae4f1303") },
                    { new Guid("32e3abad-f107-4785-8f81-59a13d64440e"), null, new Guid("3a373b54-007f-482b-a147-37d692e63c8c") },
                    { new Guid("184f7e51-16e0-4662-abd0-b8be24ba7a9b"), null, new Guid("e2d7b9f1-9e76-4910-b1b5-16e16a8a8383") },
                    { new Guid("07126f80-a1e7-4217-ad3f-c341fa95ca0a"), null, new Guid("767eb583-513d-455e-b586-6910127c49c5") },
                    { new Guid("e6b41e22-a91e-463f-809b-5544e603cb24"), null, new Guid("8e1fc3de-e849-42fe-8c4e-918f8942263c") },
                    { new Guid("99b9215c-09bb-4cbe-bb13-13bac0a148a8"), null, new Guid("f9f25735-14c0-4e64-92c0-c2763d77b99e") },
                    { new Guid("6e15357d-8e42-4bce-a569-d41ee954111f"), null, new Guid("11315ff8-6bc5-4eba-b95a-00420e822330") },
                    { new Guid("5c15c981-b479-4231-bb61-7238b63d48c2"), null, new Guid("ba730cd3-13eb-42a0-bcd5-23c321cfe300") }
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
