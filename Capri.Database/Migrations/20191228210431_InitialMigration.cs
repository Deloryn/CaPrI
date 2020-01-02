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
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                });

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
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    FacultyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promoters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TitlePrefix = table.Column<string>(nullable: false),
                    TitlePostfix = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    ExpectedNumberOfBachelorProposals = table.Column<int>(nullable: false),
                    ExpectedNumberOfMasterProposals = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    InstituteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promoters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promoters_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TopicPolish = table.Column<string>(nullable: false),
                    TopicEnglish = table.Column<string>(nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Specialization = table.Column<string>(nullable: true),
                    OutputData = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StudyProfile = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Mode = table.Column<int>(nullable: false),
                    PromoterId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4d92de45-7826-4b15-a057-bfdaf54d9266"), "Wydział Architektury" },
                    { new Guid("503a5f3e-96a8-4ed3-bc0c-8b9f0d576ecf"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("136a1aef-d2f3-4982-b921-826486dbcc77"), "Wydział Inżynierii Transportu" },
                    { new Guid("9c97a026-605b-4867-a496-8db746941c1c"), "Wydział Informatyki" },
                    { new Guid("dd726095-5968-4bbb-8236-bf2383502614"), "Wydział Fizyki Technicznej" },
                    { new Guid("53bd1bd4-9030-408f-86e7-48fced5240b7"), "Wydział Technologii Chemicznej" },
                    { new Guid("55232fba-5913-436b-8c50-492c941a2fc7"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("9a96e204-aa4a-4d1c-b7f9-d71f62b7cc43"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("e6dc55d7-9760-4db1-9c0c-683ca9a8a1a6"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("6faa0c55-aa3a-4a13-872a-47285b8e5820"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6f4619e2-bebe-4782-9806-23bdcd79ce13"), "Instytut Informatyki" },
                    { new Guid("0a0c8f22-58c1-40a6-bdf3-60779e6b2730"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("192c1c49-2439-40d1-9d42-9394c7f38fd0"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("240704d2-4352-45af-9077-50af176e6e97"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("a4503425-0c14-4c64-baa6-b21ddc232050"), "Instytut Inżynierii Środowiska" },
                    { new Guid("fa18de74-56df-49ee-954b-2f65dd506138"), "Instytut Inżynierii Lądowej" },
                    { new Guid("81adffe5-e185-4f28-bf0f-a1dabbe644fb"), "Instytut Technologii Materiałów" },
                    { new Guid("c4365013-b1a7-467e-a5ad-d4db65c8e618"), "Instytut Matematyki" },
                    { new Guid("742edf48-48bd-495e-a732-54f617707290"), "Instytut Technologii Mechanicznej" },
                    { new Guid("ac70734c-3e05-4991-8ed2-24204f7bf8f3"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("4bbd9c37-f38e-4e1a-a6d6-d69943e9b291"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("02c63674-4210-498a-9442-73e059bbed31"), "287eadb5-5562-4aaf-bc4b-91960fb36b41", "dean", "dean" },
                    { new Guid("f3674215-0a0e-4170-8ab6-3695eefc735c"), "22233ca9-2990-4413-bbe9-c01ed4307116", "student", "student" },
                    { new Guid("7334a38a-066c-4bcf-bba4-9232c08a62d1"), "e91e9285-a396-4f1d-9a33-1c0c6d602c20", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6df4b062-d86f-4f17-b276-e655416c0dbf"), new Guid("7334a38a-066c-4bcf-bba4-9232c08a62d1"), new Guid("0cf73f9f-5ec7-41a6-99cc-7558fdaeafde") },
                    { new Guid("752a2ff8-6387-4081-9cb8-5076aadc9d05"), new Guid("02c63674-4210-498a-9442-73e059bbed31"), new Guid("584eda9a-3bfe-44a9-b6ee-f9c894609872") },
                    { new Guid("68c581d2-09b7-406d-9a95-b1adcbc3eb57"), new Guid("02c63674-4210-498a-9442-73e059bbed31"), new Guid("f9781e52-4db0-4734-a8dc-5b63074ffe04") },
                    { new Guid("0e2c0382-cdd2-4d2f-a06d-8f000df7bc31"), new Guid("02c63674-4210-498a-9442-73e059bbed31"), new Guid("dd307629-0568-47c9-997c-832403d699b1") },
                    { new Guid("7f5cec01-d34f-4387-9412-4555c1b3b699"), new Guid("02c63674-4210-498a-9442-73e059bbed31"), new Guid("52cfe1a9-3fd0-4a6c-bbdb-159a8ca2b528") },
                    { new Guid("c11a11ff-d014-4c9e-852a-91485e6c75e8"), new Guid("f3674215-0a0e-4170-8ab6-3695eefc735c"), new Guid("a758608b-40c1-4c0e-b434-e57b21735456") },
                    { new Guid("d0b1f80b-a665-4a10-8c70-012ad20f0a72"), new Guid("f3674215-0a0e-4170-8ab6-3695eefc735c"), new Guid("1e18a714-667d-44e0-93fa-cfed150f4e20") },
                    { new Guid("73db9cc8-cad4-4b02-85f0-40df9aba008a"), new Guid("f3674215-0a0e-4170-8ab6-3695eefc735c"), new Guid("f9417561-3213-488e-a11a-8f6d9260f156") },
                    { new Guid("6c0d833f-1d77-4cae-99d8-4382ea74875c"), new Guid("7334a38a-066c-4bcf-bba4-9232c08a62d1"), new Guid("83ec2cca-56aa-4e27-a5a3-c4e83a0a413a") },
                    { new Guid("af202734-46dd-44e7-bfe4-3821b0b660ec"), new Guid("7334a38a-066c-4bcf-bba4-9232c08a62d1"), new Guid("0b33b1f0-183a-481e-a55e-1736ea13fa34") },
                    { new Guid("28d6ef44-8463-45eb-8308-36e7bf7d861f"), new Guid("7334a38a-066c-4bcf-bba4-9232c08a62d1"), new Guid("656ec475-6024-4445-a4dc-1216193ec4db") },
                    { new Guid("5e183d79-df38-4605-91f1-3919772e72c2"), new Guid("7334a38a-066c-4bcf-bba4-9232c08a62d1"), new Guid("8f439966-de35-4789-a724-7f590da4c172") },
                    { new Guid("86e2ab4f-7f21-4954-8a55-770ab2870c0c"), new Guid("7334a38a-066c-4bcf-bba4-9232c08a62d1"), new Guid("3a71cb95-cb31-416d-839d-872a39090936") },
                    { new Guid("fe4931fa-e8dc-4e8e-9d1d-f61ca60f61af"), new Guid("f3674215-0a0e-4170-8ab6-3695eefc735c"), new Guid("85c31dc7-5bd0-4935-a757-1a4880cbb5ce") },
                    { new Guid("a5b4ab14-6c8e-4b59-9f13-e01edf51754b"), new Guid("7334a38a-066c-4bcf-bba4-9232c08a62d1"), new Guid("859f57a9-e875-410f-bea3-b51113831bef") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1e18a714-667d-44e0-93fa-cfed150f4e20"), 0, "f0a845e5-b928-4ad0-be33-0cad3224a318", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAEMKKMWymQiDDe1j0m5o/wkO5wAsokwQYjRzQxQ9hxlka5G0PZNb4Eixk/oeQJNov8Q==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("584eda9a-3bfe-44a9-b6ee-f9c894609872"), 0, "f1f5b145-a8d7-465c-8f6f-4f3fe38ef971", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAECMdJn9xMVuQrHvyt1OAjxQAdKioWyRgE8RM3bfYOaStcJcaunbvlH5rTCzygUGuww==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("f9781e52-4db0-4734-a8dc-5b63074ffe04"), 0, "915b35cb-7247-4d48-9070-c66bb66d9495", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAEN8uFrWrWfAOFbM5acdluAko0okrZSJQSH3fAV2lKbI5zh05zZesduUSqXHf7MCR8g==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("a758608b-40c1-4c0e-b434-e57b21735456"), 0, "cc97e850-7c69-4bcb-8b84-b265fbd787e7", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEJPEhMv4sVn0Ci/BxcjeuHtHSpXxYEpUw7KkiNsAr5c1JmxpwWOlJrme8Hq/+/icpw==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("dd307629-0568-47c9-997c-832403d699b1"), 0, "b77c7f69-4b42-45e9-a4a3-ac2e6822f950", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAENeXz+DQu6hXVgwzLycYuN+a9K37ewOf+gY8L4D/gsHOKHgBkqHu+ALqvtIIH+tgNg==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("83ec2cca-56aa-4e27-a5a3-c4e83a0a413a"), 0, "e1c792ac-681b-4000-8ea4-c88c0759ac5c", "katarzyna.adamska@put.poznan.pl", true, false, null, "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEMnjmZIhXdu7v6OkDmVIokK0mAmqEIC5df6ZUsxSAdYC3O2p8aA00jA2hhUrmWdoWg==", null, false, "", false, "katarzyna.adamska@put.poznan.pl" },
                    { new Guid("3a71cb95-cb31-416d-839d-872a39090936"), 0, "66023dc8-44a1-41f5-a581-9f74bf32d22a", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEE/ZJkP4BSEoPITe07+EKHhPYWoXKpqvtcpNYl9OipHgzVn7LQ6wG11F5xP5ytpiRw==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("8f439966-de35-4789-a724-7f590da4c172"), 0, "a532f10d-e018-4fe3-89fc-2ee58fb707f4", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEGL+hnbiIbITSa9aiZ0BCZudg/4HI5UyDT8IgFDJWJXvkIB1Jo+PERdrV3MUvI4zQQ==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("656ec475-6024-4445-a4dc-1216193ec4db"), 0, "aef40123-14a7-4733-86c5-f60c97b7f51d", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEFP23x/zC+txZeHuhrJ9/EbIhOBBo9NraeWkMJhNGv7SfUi35DBsmi+NPROGA8p8dQ==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("52cfe1a9-3fd0-4a6c-bbdb-159a8ca2b528"), 0, "1b58d4a1-71c7-4eee-a6fb-d3283eb01e3c", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAEEjnNzgsR8HK+EO2+5c6MXv9MPqXoZ+euMbLXsMmq+CyT43lL0RvMGtYkPaVS8RpKw==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("0cf73f9f-5ec7-41a6-99cc-7558fdaeafde"), 0, "36d6a84f-65d3-46a6-b8fa-0363a158e309", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEM4ScB0Oj0sSHPeQqsgKLxZSg4v+rS927W805sqxP9TUfpz+KnfovZkZQDQZeh7PQw==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("f9417561-3213-488e-a11a-8f6d9260f156"), 0, "75cce663-87d3-4c0c-b534-2a02f4568bff", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAELAwmsUQgHQOpNLSEuy+gf7oazuWNV8XMW2P2edaS7paphd4dGn2WFhkwHdxcXpoaw==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("85c31dc7-5bd0-4935-a757-1a4880cbb5ce"), 0, "384504d3-9c6a-407c-91c7-4f9afdb7c212", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAEEh6NyxCMVhRNjpZANuYmwga8J74sMiJMDWTOJ7Ypq2AfX5Tm1y0idXMLAKFUOV07g==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("859f57a9-e875-410f-bea3-b51113831bef"), 0, "83f70bd4-d1a0-42df-8bae-c45fd4c19f82", "krzysztof.alejski@put.poznan.pl", true, false, null, "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEDFM2rWN+cHzRjeJxKSfVMlADa4X2CR1AXCagbUvYGc1fbmbm4VCWKOBypakOK2t3w==", null, false, "", false, "krzysztof.alejski@put.poznan.pl" },
                    { new Guid("0b33b1f0-183a-481e-a55e-1736ea13fa34"), 0, "b8acebae-93b4-46bb-8e1f-a8c5636c497d", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAENbTMITiYBvXTVQKBrGH297adHBE06sHq5bq2FPE8WTE/sOUXvDMd0BA6fxvjDtnyA==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("203ef0aa-4e1a-418c-8fe1-abf7b294e270"), new Guid("4d92de45-7826-4b15-a057-bfdaf54d9266"), "Architektura" },
                    { new Guid("eb5d1a64-8f4a-4557-8d4a-3a31d88b8a41"), new Guid("53bd1bd4-9030-408f-86e7-48fced5240b7"), "Inżynieria Farmaceutyczna" },
                    { new Guid("a300a83b-7020-4d2c-962a-28a20a207043"), new Guid("53bd1bd4-9030-408f-86e7-48fced5240b7"), "Technologie Ochrony Środowiska" },
                    { new Guid("3508fe9e-5a49-4180-9bc6-b9f604570795"), new Guid("53bd1bd4-9030-408f-86e7-48fced5240b7"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("c67ef2a5-e584-4a47-bb6c-5089d741c1d3"), new Guid("53bd1bd4-9030-408f-86e7-48fced5240b7"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("2a7e3b2d-458f-486c-b193-79f5f1b18620"), new Guid("503a5f3e-96a8-4ed3-bc0c-8b9f0d576ecf"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("2a8b4ac1-aedf-49fd-adfa-8ccb0a10a64e"), new Guid("503a5f3e-96a8-4ed3-bc0c-8b9f0d576ecf"), "Inżynieria Zarządzania" },
                    { new Guid("5bc72034-9930-4b66-9894-0ee9d1092673"), new Guid("503a5f3e-96a8-4ed3-bc0c-8b9f0d576ecf"), "Logistyka" },
                    { new Guid("ff6b4615-2fb0-461d-97bf-b1640798a6f3"), new Guid("136a1aef-d2f3-4982-b921-826486dbcc77"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("8c2becc3-4f79-435b-8145-3dabada35d99"), new Guid("136a1aef-d2f3-4982-b921-826486dbcc77"), "Transport" },
                    { new Guid("67e5586a-bb73-4511-83ac-096474492d7e"), new Guid("9c97a026-605b-4867-a496-8db746941c1c"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("2d8be24b-8c82-45b2-b227-dd99910ef9a3"), new Guid("9c97a026-605b-4867-a496-8db746941c1c"), "Bioinformatyka" },
                    { new Guid("0bd7b838-66ec-4a31-afb6-bcb3e7d92343"), new Guid("9c97a026-605b-4867-a496-8db746941c1c"), "Informatyka" },
                    { new Guid("5c02298f-afa4-461e-b623-4a90a91a8428"), new Guid("dd726095-5968-4bbb-8236-bf2383502614"), "Fizyka Techniczna" },
                    { new Guid("b1399990-c893-4952-942e-acc20f6e4c41"), new Guid("dd726095-5968-4bbb-8236-bf2383502614"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("35c7c46a-1b38-4b24-b3ca-24454f8958fe"), new Guid("136a1aef-d2f3-4982-b921-826486dbcc77"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("9de08f19-19a6-4355-9ea5-9a3b23a210a3"), new Guid("6faa0c55-aa3a-4a13-872a-47285b8e5820"), "Energetyka" },
                    { new Guid("6a12a146-acb9-49ca-b00e-ee4bf6c73269"), new Guid("4d92de45-7826-4b15-a057-bfdaf54d9266"), "Architektura Wnętrz" },
                    { new Guid("3b4fe87f-8ec1-4bb8-8cfb-22f56957e325"), new Guid("6faa0c55-aa3a-4a13-872a-47285b8e5820"), "Matematyka w Technice" },
                    { new Guid("ad99bc65-8419-4811-bc33-3aa2481d8b5d"), new Guid("e6dc55d7-9760-4db1-9c0c-683ca9a8a1a6"), "Inżynieria Środowiska" },
                    { new Guid("709cae7c-448c-47f3-a71a-1f81f602a6b2"), new Guid("9a96e204-aa4a-4d1c-b7f9-d71f62b7cc43"), "Inżynieria Biomedyczna" },
                    { new Guid("41abb32d-2149-45b2-a054-0ee00fce19ff"), new Guid("9a96e204-aa4a-4d1c-b7f9-d71f62b7cc43"), "Inżynieria Materiałowa" },
                    { new Guid("e7b5c844-e581-4c76-9eae-45bb58de9b66"), new Guid("9a96e204-aa4a-4d1c-b7f9-d71f62b7cc43"), "Mechanika i Budowa Maszyn" },
                    { new Guid("d46bc62b-f805-45a4-92d7-b7906f8d0747"), new Guid("e6dc55d7-9760-4db1-9c0c-683ca9a8a1a6"), "Budownictwo" },
                    { new Guid("de7dc0ff-9cd1-45fe-bce6-3e2768c61c78"), new Guid("9a96e204-aa4a-4d1c-b7f9-d71f62b7cc43"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("1e5ddb0f-1b14-44b8-80f0-7cf5c1860607"), new Guid("55232fba-5913-436b-8c50-492c941a2fc7"), "Elektronika i Telekomunikacja" },
                    { new Guid("bb3e12e4-5356-4d20-8b66-19a277cd999b"), new Guid("55232fba-5913-436b-8c50-492c941a2fc7"), "Teleinformatyka" },
                    { new Guid("04dccfb0-022b-4f2a-a890-1e6c12401d2a"), new Guid("6faa0c55-aa3a-4a13-872a-47285b8e5820"), "Automatyka i Robotyka" },
                    { new Guid("ed3b5cd7-017c-47ea-91bb-4cd26c1d5ac1"), new Guid("6faa0c55-aa3a-4a13-872a-47285b8e5820"), "Elektrotechnika" },
                    { new Guid("75460fd2-88c8-4314-b38c-ae0400d060bb"), new Guid("9a96e204-aa4a-4d1c-b7f9-d71f62b7cc43"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("6f4619e2-bebe-4782-9806-23bdcd79ce13"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("3a71cb95-cb31-416d-839d-872a39090936") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("6f4619e2-bebe-4782-9806-23bdcd79ce13"), "Kotłowski", "", "dr hab. inż.", new Guid("8f439966-de35-4789-a724-7f590da4c172") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("6f4619e2-bebe-4782-9806-23bdcd79ce13"), "Kadziński", "", "dr hab. inż.", new Guid("656ec475-6024-4445-a4dc-1216193ec4db") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("6f4619e2-bebe-4782-9806-23bdcd79ce13"), "Prędki", "", "dr inż.", new Guid("0b33b1f0-183a-481e-a55e-1736ea13fa34") },
                    { new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), 3, 2, "Krzysztof", new Guid("ac70734c-3e05-4991-8ed2-24204f7bf8f3"), "Alejski", "prof. PP", "dr hab. inż.", new Guid("859f57a9-e875-410f-bea3-b51113831bef") },
                    { new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), 1, 1, "Katarzyna", new Guid("ac70734c-3e05-4991-8ed2-24204f7bf8f3"), "Adamska", "", "dr inż.", new Guid("83ec2cca-56aa-4e27-a5a3-c4e83a0a413a") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("6f4619e2-bebe-4782-9806-23bdcd79ce13"), "Masłowska", "", "dr inż.", new Guid("0cf73f9f-5ec7-41a6-99cc-7558fdaeafde") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("86915a9d-3111-4a7e-b405-1380da7dae64"), null, new Guid("f9417561-3213-488e-a11a-8f6d9260f156") },
                    { new Guid("6c0b784d-dc91-4873-b81e-c6b855b4a2a0"), null, new Guid("1e18a714-667d-44e0-93fa-cfed150f4e20") },
                    { new Guid("825f3a41-b3c7-4956-a370-96815d8c731a"), null, new Guid("a758608b-40c1-4c0e-b434-e57b21735456") },
                    { new Guid("c20f2495-8513-44b8-8dd6-5ed4da38bead"), null, new Guid("85c31dc7-5bd0-4935-a757-1a4880cbb5ce") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "Mode", "OutputData", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("cb2ab5c3-3d9d-4c85-afa4-a365bcbdcec4"), new Guid("0bd7b838-66ec-4a31-afb6-bcb3e7d92343"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 0, "Brak danych", new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("8236e6ea-60be-41fe-a8fb-9f8a8bd1c469"), new Guid("0bd7b838-66ec-4a31-afb6-bcb3e7d92343"), "Opis.....", 0, 0, "Brak danych", new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("c3bd3d42-74ea-478d-b86f-6fefb93d7eae"), new Guid("0bd7b838-66ec-4a31-afb6-bcb3e7d92343"), "Opis.....", 0, 0, "Brak danych", new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("6aff8987-5f3f-46aa-a8ed-afbf6fbe969f"), new Guid("0bd7b838-66ec-4a31-afb6-bcb3e7d92343"), "Opis.....", 0, 0, "Brak danych", new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("1763e12b-1eed-40c0-8032-9345ba3df408"), new Guid("0bd7b838-66ec-4a31-afb6-bcb3e7d92343"), "Opis.....", 0, 0, "Brak danych", new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                    { new Guid("ffdadd8b-743c-4259-bb30-9e1dd34bf5df"), new Guid("c67ef2a5-e584-4a47-bb6c-5089d741c1d3"), "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", 0, 0, "Brak danych", new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                    { new Guid("00a440be-ccc9-4978-83bd-9899aa438bf9"), new Guid("c67ef2a5-e584-4a47-bb6c-5089d741c1d3"), "Brak opisu", 1, 0, "Brak danych", new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Promoters_InstituteId",
                table: "Promoters",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Promoters_UserId",
                table: "Promoters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_CourseId",
                table: "Proposals",
                column: "CourseId");

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
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Promoters");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Institutes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
