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
                    { new Guid("052805d8-cb10-4cb8-b93d-63ac12b858bf"), "68ded89d-af2b-48d3-a455-82746d01d7b1", "admin", "admin" },
                    { new Guid("8b4ac60f-71e6-4265-aaba-2200e2242a64"), "fd545f0f-ae6e-44b4-9619-1ca1e9a8933a", "dean", "dean" },
                    { new Guid("94d1f90c-c453-459d-82c8-8da182f406e5"), "cf1999fa-1ca7-4597-80da-c48cb4ef3a27", "student", "student" },
                    { new Guid("d5698ae4-cde6-4302-a83c-85078e0a42c5"), "d4378fa8-63f8-4152-8798-bc840939a7a7", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5b3f8a2e-eff6-43b7-83ef-31ad03d39d90"), new Guid("d5698ae4-cde6-4302-a83c-85078e0a42c5"), new Guid("0d2ee102-06a9-4a3b-ab6a-ee954f364598") },
                    { new Guid("3e577a4b-ef57-486a-92fe-df4a62eaab90"), new Guid("d5698ae4-cde6-4302-a83c-85078e0a42c5"), new Guid("ebe1f763-f12b-4d83-a813-c8873c03705f") },
                    { new Guid("5e223132-ae98-41c8-a671-0be433d94178"), new Guid("94d1f90c-c453-459d-82c8-8da182f406e5"), new Guid("4ea80fdf-b840-47e5-8285-0718d4687bae") },
                    { new Guid("b6e967f9-0e50-4f7f-839b-bbe373e6594c"), new Guid("94d1f90c-c453-459d-82c8-8da182f406e5"), new Guid("393f7550-c316-4235-a64e-9a34df3994bf") },
                    { new Guid("f3f5ab5f-101b-4bd1-9c5c-3b3dd9172f02"), new Guid("94d1f90c-c453-459d-82c8-8da182f406e5"), new Guid("7803567a-77cb-41a7-b7c4-6001ce3ba460") },
                    { new Guid("b2836b24-ef4d-4a2f-b788-d0fcce25ef22"), new Guid("94d1f90c-c453-459d-82c8-8da182f406e5"), new Guid("711713fb-c525-411a-b6bc-b072e7f50ecc") },
                    { new Guid("7af5c3b5-8d8e-48fa-aa09-e1670a705c20"), new Guid("94d1f90c-c453-459d-82c8-8da182f406e5"), new Guid("e7779777-8615-4f78-8ad8-7d2909d5703b") },
                    { new Guid("29d9c647-bb4d-4522-8af5-9f861b7d26cb"), new Guid("94d1f90c-c453-459d-82c8-8da182f406e5"), new Guid("de74c9e3-a456-4c5a-8af6-dbac149a47aa") },
                    { new Guid("5ea714cb-c6ed-4fa7-8ad1-323f49e4e798"), new Guid("94d1f90c-c453-459d-82c8-8da182f406e5"), new Guid("5760171d-29af-4dbc-962d-f5deb91d34f0") },
                    { new Guid("ca514399-b0de-4193-ad6b-8f59778f02ec"), new Guid("8b4ac60f-71e6-4265-aaba-2200e2242a64"), new Guid("8df71ba7-cb6f-4ae7-9aa0-d5782dca4c32") },
                    { new Guid("53f61f01-fae8-4eb0-a567-e4506bc08d16"), new Guid("8b4ac60f-71e6-4265-aaba-2200e2242a64"), new Guid("1bb62633-3157-4d59-8dde-39b7c5dc8b2a") },
                    { new Guid("a63d4b29-8f64-4050-ae0b-c51be23b9f81"), new Guid("052805d8-cb10-4cb8-b93d-63ac12b858bf"), new Guid("f2261f23-c60a-4aac-b923-d6c491323a70") },
                    { new Guid("767cd0fa-99bd-4872-ae02-2c78cb0b68c7"), new Guid("94d1f90c-c453-459d-82c8-8da182f406e5"), new Guid("30caf02f-ac64-47ec-bf99-151e4d1a7e88") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("e7779777-8615-4f78-8ad8-7d2909d5703b"), 0, "1e577bcb-6518-4e00-afcf-977b13035d24", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEIbPMONX06+GwPpEYTfT3sS5kujEgUx6ZAZ5zuBCokIhUFEqLjRdj8vCWmAjK7G1hw==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("4ea80fdf-b840-47e5-8285-0718d4687bae"), 0, "4b56baf1-5899-489d-8fcd-c5ab615f7dc1", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEM315OGts0K/Jfy/3cI2AoJFiiMpRX3+xmjkxyZbiKrikszzjMEmMb4clX//UJiI4Q==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("393f7550-c316-4235-a64e-9a34df3994bf"), 0, "2ef66b67-4b23-4a23-9947-fefb4ced9f56", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEJT/iwMMAU/sJ19TNCedBLcKRCm6gTOYKuMfCrQq3JlbT1xO2vtCCvMxVZIO/78bjg==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("7803567a-77cb-41a7-b7c4-6001ce3ba460"), 0, "f51e1485-b73b-4138-88b5-ff3010302108", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEBcCX/1t7LEZ51S1DXzm3BZqBqrQMf3VjzEa147xcccUUpt/T+c0JO+HHQaZCEysPQ==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("711713fb-c525-411a-b6bc-b072e7f50ecc"), 0, "47bb81f3-72f3-4fc7-b331-84b440e8d082", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEN5j9RqeRgRqW1/OAP8Ip32iH1j4krP+zMXPqkmPytk7NX4qmuHk/kLKA45aZGR3iw==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("5760171d-29af-4dbc-962d-f5deb91d34f0"), 0, "1056aa40-06ab-4c13-a9d6-6e2572eb0c5b", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEMIi68GOMYn868LqX2MuHGU17YB9w6TCShrJ20QdSJi6GkpHR9xAlRU7d4M15WmSig==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("de74c9e3-a456-4c5a-8af6-dbac149a47aa"), 0, "b9cfd373-2418-410f-9ce1-b5c114871fe9", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEFaYIlZeYLR6QUFQKZCykH2GXsgA0sov0Lrk3z5hieUuH4J4J6o4mjP4BXH6lnJwfg==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("8df71ba7-cb6f-4ae7-9aa0-d5782dca4c32"), 0, "4cd5654d-1a69-4988-96ea-38d2daaf4427", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEBLbGLwvDRz1OcLRKz03Rs+t1ae2ofDxwWWTzIcDiXYvZX0rjKgsmNcrgwTUekFMAA==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("1bb62633-3157-4d59-8dde-39b7c5dc8b2a"), 0, "28374727-e301-4050-a762-f027ebaa2fe0", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEHspuq+CdCW/S58IWA9eBuEzDXIeIBTdqsKYkBDoSbfcUYpRsfgXR4JEqN1JDE9Ujg==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("f2261f23-c60a-4aac-b923-d6c491323a70"), 0, "79b25d66-5a4b-46e7-9d69-097927d744c4", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEJTm+ZVKPwdfNaOHUJ6B6pvrJo+m6tB0Sn0tdYF/gTtikiMH1V5kfvsvm+0ObbtFow==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("ebe1f763-f12b-4d83-a813-c8873c03705f"), 0, "ccce0abe-eaa7-480d-8d9b-46876db1af17", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAEM75ofv6zr7bomnpW+7VlkTKxuTV8rw9tz6dG5thCjSGK1vztdBNhrVYXwKucigAZg==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("30caf02f-ac64-47ec-bf99-151e4d1a7e88"), 0, "c2067af2-d131-4fcd-a3e3-53fddabbe406", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAENfOr/6YpRSjHodMxAaF/Jc2Fc8+ZkotJIS4ZdnF77NogtCBVgTNlIuvHAzvlFQa7g==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("0d2ee102-06a9-4a3b-ab6a-ee954f364598"), 0, "3dacc041-0e7c-4425-93ce-633952e17572", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEJlWGaIyqxyEjQYtWZaQJg3cz6Dszn0j/z0uGY1k/RVM+vAc037nJl7yM3BzhKnK0w==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { new Guid("a54b01ba-e82f-4e9f-994e-0c25912b43d4"), 3, 4, "Jan", "Kowalski", new Guid("ebe1f763-f12b-4d83-a813-c8873c03705f") },
                    { new Guid("0f0524ab-5f82-4f85-b333-243bac54c4f2"), 3, 4, "Jan", "Kowalski", new Guid("0d2ee102-06a9-4a3b-ab6a-ee954f364598") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d4be0990-7710-4575-b784-57e62f8a9b56"), null, new Guid("5760171d-29af-4dbc-962d-f5deb91d34f0") },
                    { new Guid("8db17ea4-6e22-49f5-b5c3-0c2d19bf5775"), null, new Guid("de74c9e3-a456-4c5a-8af6-dbac149a47aa") },
                    { new Guid("3985c39c-ec7d-45dc-8a8c-ba6ac4192c67"), null, new Guid("30caf02f-ac64-47ec-bf99-151e4d1a7e88") },
                    { new Guid("c7f6a624-663d-4df2-8a02-18584312aac2"), null, new Guid("711713fb-c525-411a-b6bc-b072e7f50ecc") },
                    { new Guid("79bb4932-b9ed-4743-ac4b-e8403dc6e30c"), null, new Guid("7803567a-77cb-41a7-b7c4-6001ce3ba460") },
                    { new Guid("250c8d11-e424-40a5-a911-5f003873fddf"), null, new Guid("393f7550-c316-4235-a64e-9a34df3994bf") },
                    { new Guid("aa4df3ba-625f-4e4f-b4e0-73aec3f9b0cd"), null, new Guid("4ea80fdf-b840-47e5-8285-0718d4687bae") },
                    { new Guid("66b318fd-4dbf-44df-992d-2785e5fbfd61"), null, new Guid("e7779777-8615-4f78-8ad8-7d2909d5703b") }
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
