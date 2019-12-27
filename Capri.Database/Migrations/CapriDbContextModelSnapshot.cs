﻿// <auto-generated />
using System;
using Capri.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capri.Database.Migrations
{
    [DbContext(typeof(CapriDbContext))]
    partial class CapriDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Capri.Database.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FacultyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Courses");

                    b.HasData(
                        new { Id = new Guid("823edd98-b38f-44c7-b313-c86dea1fc873"), FacultyId = new Guid("a49b15c4-8f76-4d77-a05c-2d64c35aff84"), Name = "Architektura" },
                        new { Id = new Guid("239fb8c5-70ba-4be9-97f2-091e22327252"), FacultyId = new Guid("a49b15c4-8f76-4d77-a05c-2d64c35aff84"), Name = "Architektura Wnętrz" },
                        new { Id = new Guid("a8f3cc69-48a5-454f-8b82-8f5bebb595c0"), FacultyId = new Guid("4bd3f046-143a-411c-9d4f-a20680c33c4c"), Name = "Budownictwo" },
                        new { Id = new Guid("dac18d57-b8ad-4da2-b5d1-db291c84443f"), FacultyId = new Guid("4bd3f046-143a-411c-9d4f-a20680c33c4c"), Name = "Inżynieria Środowiska" },
                        new { Id = new Guid("2d5627aa-b8c8-4a90-b8b2-39469bcb535a"), FacultyId = new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), Name = "Inżynieria Biomedyczna" },
                        new { Id = new Guid("80be4439-220b-416c-aa18-df9f41fb3396"), FacultyId = new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), Name = "Inżynieria Materiałowa" },
                        new { Id = new Guid("9f6358fa-ea24-4f92-83dd-b1c3f4fe0b8a"), FacultyId = new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), Name = "Mechanika i Budowa Maszyn" },
                        new { Id = new Guid("948aced7-bfa0-4036-a563-3548cf6c6b5b"), FacultyId = new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), Name = "Mechatronika" },
                        new { Id = new Guid("81ba48f8-df52-4560-9fb9-62a54a6b06d3"), FacultyId = new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), Name = "Zarządzanie i Inżynieria Produkcji" },
                        new { Id = new Guid("6ebfda66-12d7-48bf-9245-34b0f26967fa"), FacultyId = new Guid("b7dc094f-a595-4844-b429-fd21ca170dd4"), Name = "Elektronika i Telekomunikacja" },
                        new { Id = new Guid("aeedf3b3-2476-4e43-96ed-d9bc2308b499"), FacultyId = new Guid("b7dc094f-a595-4844-b429-fd21ca170dd4"), Name = "Teleinformatyka" },
                        new { Id = new Guid("0888425b-f839-48a3-9521-f92a884474d8"), FacultyId = new Guid("9277bcfa-9071-4069-9134-b04cb767557e"), Name = "Automatyka i Robotyka" },
                        new { Id = new Guid("c9cae424-f28f-426c-8e3e-1b2a21915c70"), FacultyId = new Guid("9277bcfa-9071-4069-9134-b04cb767557e"), Name = "Elektrotechnika" },
                        new { Id = new Guid("8dfc1e9c-95c3-487c-bcf9-7188ad66322c"), FacultyId = new Guid("9277bcfa-9071-4069-9134-b04cb767557e"), Name = "Energetyka" },
                        new { Id = new Guid("59daf147-b7d2-4b2d-99c0-fbdf02684f43"), FacultyId = new Guid("9277bcfa-9071-4069-9134-b04cb767557e"), Name = "Matematyka w Technice" },
                        new { Id = new Guid("fd63ebb1-e8b2-4a93-94cd-5aa640d09d30"), FacultyId = new Guid("1cbb8c1b-e8b5-4de2-8ed1-f55640b4fdc8"), Name = "Edukacja Techniczno-Informatyczna" },
                        new { Id = new Guid("85bc0243-91a4-4abc-8b32-784486b46a45"), FacultyId = new Guid("1cbb8c1b-e8b5-4de2-8ed1-f55640b4fdc8"), Name = "Fizyka Techniczna" },
                        new { Id = new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), FacultyId = new Guid("326956a0-0805-4480-a31f-59d0f9e535fc"), Name = "Informatyka" },
                        new { Id = new Guid("07923f63-2c45-4374-a42f-71224e3cfa24"), FacultyId = new Guid("326956a0-0805-4480-a31f-59d0f9e535fc"), Name = "Bioinformatyka" },
                        new { Id = new Guid("d5e90033-3d72-43a0-95c1-47ad83712b9e"), FacultyId = new Guid("326956a0-0805-4480-a31f-59d0f9e535fc"), Name = "Sztuczna Inteligencja / Artificial Intelligence" },
                        new { Id = new Guid("3cccfb8b-35f8-4553-864a-8840bc25ffa5"), FacultyId = new Guid("81c99cbd-7707-4823-8905-87bce684512f"), Name = "Konstrukcja i Eksploatacja Środków Transportu" },
                        new { Id = new Guid("bffaf0af-bf69-4c5c-ba91-9a1410bb836b"), FacultyId = new Guid("81c99cbd-7707-4823-8905-87bce684512f"), Name = "Transport" },
                        new { Id = new Guid("a5e0509a-c780-4abd-9c54-fd83d2a8ebe3"), FacultyId = new Guid("81c99cbd-7707-4823-8905-87bce684512f"), Name = "Lotnictwo i Kosmonautyka" },
                        new { Id = new Guid("d2991164-c272-4d7a-8841-689ef5b9e3f5"), FacultyId = new Guid("bf273264-0019-4e2e-9932-cfd5941d9e30"), Name = "Logistyka" },
                        new { Id = new Guid("91fb6d64-f449-4339-8650-9da156671852"), FacultyId = new Guid("bf273264-0019-4e2e-9932-cfd5941d9e30"), Name = "Inżynieria Zarządzania" },
                        new { Id = new Guid("c06b5d56-2ca7-4bfd-887e-3a2ce7ec4f4d"), FacultyId = new Guid("bf273264-0019-4e2e-9932-cfd5941d9e30"), Name = "Inżynieria Bezpieczeństwa" },
                        new { Id = new Guid("b7ab2cab-7cdc-4085-9c8a-84e3e9d04ab5"), FacultyId = new Guid("8ce48e70-e5b4-4224-8ad8-393b2a1a7201"), Name = "Inżynieria Chemiczna i Procesowa" },
                        new { Id = new Guid("cd4135cf-a0d9-4af5-803a-106de8167b08"), FacultyId = new Guid("8ce48e70-e5b4-4224-8ad8-393b2a1a7201"), Name = "Technologia Chemiczna / Chemical Technology" },
                        new { Id = new Guid("834044be-6d79-4214-8084-7cf29b333164"), FacultyId = new Guid("8ce48e70-e5b4-4224-8ad8-393b2a1a7201"), Name = "Technologie Ochrony Środowiska" },
                        new { Id = new Guid("5f316447-13ad-4a9c-9da6-72cd5ed29940"), FacultyId = new Guid("8ce48e70-e5b4-4224-8ad8-393b2a1a7201"), Name = "Inżynieria Farmaceutyczna" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Faculties");

                    b.HasData(
                        new { Id = new Guid("a49b15c4-8f76-4d77-a05c-2d64c35aff84"), Name = "Wydział Architektury" },
                        new { Id = new Guid("4bd3f046-143a-411c-9d4f-a20680c33c4c"), Name = "Wydział Budownictwa i Inżynierii Środowiska" },
                        new { Id = new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), Name = "Wydział Budowy Maszyn i Zarządzania" },
                        new { Id = new Guid("b7dc094f-a595-4844-b429-fd21ca170dd4"), Name = "Wydział Elektroniki i Telekomunikacji" },
                        new { Id = new Guid("9277bcfa-9071-4069-9134-b04cb767557e"), Name = "Wydział Elektryczny" },
                        new { Id = new Guid("1cbb8c1b-e8b5-4de2-8ed1-f55640b4fdc8"), Name = "Wydział Fizyki Technicznej" },
                        new { Id = new Guid("326956a0-0805-4480-a31f-59d0f9e535fc"), Name = "Wydział Informatyki" },
                        new { Id = new Guid("81c99cbd-7707-4823-8905-87bce684512f"), Name = "Wydział Inżynierii Transportu" },
                        new { Id = new Guid("bf273264-0019-4e2e-9932-cfd5941d9e30"), Name = "Wydział Inżynierii Zarządzania" },
                        new { Id = new Guid("8ce48e70-e5b4-4224-8ad8-393b2a1a7201"), Name = "Wydział Technologii Chemicznej" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Identity.GuidRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = new Guid("d8913f5b-b1b0-449b-9349-9718e0206680"), ConcurrencyStamp = "ec745d6d-d31a-4a18-a6d4-ecf4fe2141f2", Name = "dean", NormalizedName = "dean" },
                        new { Id = new Guid("9af01217-da5a-4579-a2c0-6aeaa03036ea"), ConcurrencyStamp = "73ee5189-87c4-483a-8f84-d38ee2e5e6d8", Name = "student", NormalizedName = "student" },
                        new { Id = new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), ConcurrencyStamp = "989aa01e-61a6-4474-bf42-0eef6d6933dd", Name = "promoter", NormalizedName = "promoter" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Identity.GuidRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Capri.Database.Entities.Identity.GuidUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Capri.Database.Entities.Identity.GuidUserLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Capri.Database.Entities.Identity.GuidUserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new { Id = new Guid("55a3d68a-df5b-48a7-b660-8d770d86ad36"), RoleId = new Guid("d8913f5b-b1b0-449b-9349-9718e0206680"), UserId = new Guid("eb9e3d32-b583-4f7b-814d-d08a42c638cb") },
                        new { Id = new Guid("0d9cccdc-d1d0-4a5d-8f3d-ddfdfdc029bf"), RoleId = new Guid("d8913f5b-b1b0-449b-9349-9718e0206680"), UserId = new Guid("83f8037a-11ec-4849-b43f-3f3e7c038844") },
                        new { Id = new Guid("c852ea34-1286-4000-9e33-7893c6b5f6ae"), RoleId = new Guid("d8913f5b-b1b0-449b-9349-9718e0206680"), UserId = new Guid("20063150-21cd-49d9-9fd3-97e241a719f6") },
                        new { Id = new Guid("754a9cd2-c452-4f29-b070-02ecad9dfeac"), RoleId = new Guid("d8913f5b-b1b0-449b-9349-9718e0206680"), UserId = new Guid("8ba1a21b-3199-4737-81bd-0b11553af41a") },
                        new { Id = new Guid("337063d6-ede9-4577-9efa-cae35173e4b7"), RoleId = new Guid("9af01217-da5a-4579-a2c0-6aeaa03036ea"), UserId = new Guid("4671073c-6dc6-4daf-8ba9-6c5deda31612") },
                        new { Id = new Guid("46fce63b-3a84-4125-a1db-a0ada1f2d95a"), RoleId = new Guid("9af01217-da5a-4579-a2c0-6aeaa03036ea"), UserId = new Guid("0b76826e-692f-46b8-805a-f4b6e723bae4") },
                        new { Id = new Guid("0e61918e-987e-4b2d-bf62-4972b0ca5827"), RoleId = new Guid("9af01217-da5a-4579-a2c0-6aeaa03036ea"), UserId = new Guid("bec3a8c9-7e41-4279-9882-319eabf2f3f7") },
                        new { Id = new Guid("f363fdc5-b02e-45d6-b9ad-b09ea62e9ee6"), RoleId = new Guid("9af01217-da5a-4579-a2c0-6aeaa03036ea"), UserId = new Guid("9a256119-b8a2-45f7-9a85-5726258e8d16") },
                        new { Id = new Guid("7617d1f9-5107-406e-98ff-fc58d5f24a5a"), RoleId = new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), UserId = new Guid("b497e663-8983-408d-a788-840e34c0736a") },
                        new { Id = new Guid("a58896a5-4917-4be8-9ef8-e2a93993fb67"), RoleId = new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), UserId = new Guid("ee871f12-cecd-4b28-ab6e-8087c5db4b92") },
                        new { Id = new Guid("3e5a370f-f66b-4d62-9556-f796f710f253"), RoleId = new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), UserId = new Guid("eee1aac1-756d-4715-abc8-7145358db933") },
                        new { Id = new Guid("fad5a3ac-9aab-46e6-bbce-7c5b25c091f7"), RoleId = new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), UserId = new Guid("562482e9-4bc3-4820-af9b-0d3d475af6f0") },
                        new { Id = new Guid("8e279b9e-6ad5-4609-80d5-3b62d174f756"), RoleId = new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), UserId = new Guid("dab87c07-dd82-47d0-b556-f42fc91b80df") },
                        new { Id = new Guid("86c81919-9cd5-4fba-919c-1fff5e9a47b3"), RoleId = new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), UserId = new Guid("651ede50-8a9d-46b6-975c-df5e10ffe63f") },
                        new { Id = new Guid("4c31c578-a24e-4ff6-aec7-a7c8cf79995a"), RoleId = new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), UserId = new Guid("c198a53a-ca32-4a8e-aff1-b6766f8c0e6d") }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Identity.GuidUserToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<Guid>("UserId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Capri.Database.Entities.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = new Guid("eb9e3d32-b583-4f7b-814d-d08a42c638cb"), AccessFailedCount = 0, ConcurrencyStamp = "ad67859a-7dee-4a58-b35e-3e49e4482610", Email = "dean1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN1@GMAIL.COM", NormalizedUserName = "DEAN1@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEA9zU2gmZXipYPHe9E37v1cIclqFjnVPLyGC7u13C7uy52azamufMRixAFSJKLrsvw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean1@gmail.com" },
                        new { Id = new Guid("83f8037a-11ec-4849-b43f-3f3e7c038844"), AccessFailedCount = 0, ConcurrencyStamp = "6081e9b9-ca08-4f8a-9daa-9a2cc8ddf317", Email = "dean2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN2@GMAIL.COM", NormalizedUserName = "DEAN2@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAELlV5l2NPuhH8yBKbiIDFbGwHW1022fzuElWAgqw4RFk/KdZAfI4yUGWlxYAENGPJQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean2@gmail.com" },
                        new { Id = new Guid("20063150-21cd-49d9-9fd3-97e241a719f6"), AccessFailedCount = 0, ConcurrencyStamp = "00a69def-ad1e-49d7-b2c4-94de7eea0f68", Email = "dean3@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN3@GMAIL.COM", NormalizedUserName = "DEAN3@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEAplASKpCPIUvT2oK/tpzIeu9IyenqPvcjD1a1lCXjNxZLg3dnrGfP1/aqSkOr//7A==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean3@gmail.com" },
                        new { Id = new Guid("8ba1a21b-3199-4737-81bd-0b11553af41a"), AccessFailedCount = 0, ConcurrencyStamp = "f37df815-4f37-4595-838e-8bb4524b2d2a", Email = "dean4@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN4@GMAIL.COM", NormalizedUserName = "DEAN4@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEA/4Z3GLh2QRjD8Impxsz/Cwl/V0g/GM2hdi42A5klPiH5VeRn+a+aA2NFnLXKqzwg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean4@gmail.com" },
                        new { Id = new Guid("4671073c-6dc6-4daf-8ba9-6c5deda31612"), AccessFailedCount = 0, ConcurrencyStamp = "39b6992d-33dc-4d3c-9176-c9e1543f5d08", Email = "student1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT1@GMAIL.COM", NormalizedUserName = "STUDENT1@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEO3XlgZYWij3Y06Kn8dx9tO4AicJq2a+mJcmYSSx9aDRBA0RvC5zZoVpRMiwp6VvPA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student1@gmail.com" },
                        new { Id = new Guid("0b76826e-692f-46b8-805a-f4b6e723bae4"), AccessFailedCount = 0, ConcurrencyStamp = "9b77f725-d2b1-4741-ab10-0dd6cdc410b0", Email = "student2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT2@GMAIL.COM", NormalizedUserName = "STUDENT2@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAECVHDDBAhGzffnC2PqLUpXneffqKPjhmirIXKoepbGXfOde/ho3XZ+//ZjXPNw8+Bg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student2@gmail.com" },
                        new { Id = new Guid("bec3a8c9-7e41-4279-9882-319eabf2f3f7"), AccessFailedCount = 0, ConcurrencyStamp = "1f9b0142-f90c-4883-b6b8-0d67ce7fb98b", Email = "student3@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT3@GMAIL.COM", NormalizedUserName = "STUDENT3@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEPQ2XV8YYps6lr76hh+UPa5uovTceEAq0LAsRjOagGgejFcj9egCW+9eN+DirUrz6A==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student3@gmail.com" },
                        new { Id = new Guid("9a256119-b8a2-45f7-9a85-5726258e8d16"), AccessFailedCount = 0, ConcurrencyStamp = "d3dd5c2c-fbe9-49db-af0f-d6120a0b8ce8", Email = "student4@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT4@GMAIL.COM", NormalizedUserName = "STUDENT4@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAECXhPah4jSnpi8mUzv0OXBFCF2vvrBvnXifhHuzfNVgoJH5dqHsuHgyho7MRG0q5Pg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student4@gmail.com" },
                        new { Id = new Guid("b497e663-8983-408d-a788-840e34c0736a"), AccessFailedCount = 0, ConcurrencyStamp = "e6055a53-4377-48ee-a016-a419944d5494", Email = "irmina.maslowska@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "IRMINA.MASLOWSKA@PUT.POZNAN.PL", NormalizedUserName = "IRMINA.MASLOWSKA@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEDrjQ4aoFyxU0pZ9107rbzHxVXwZooPuTk+9jicnqXT3XC0Yp8RIbqJD9ToMNWpxhQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "irmina.maslowska@put.poznan.pl" },
                        new { Id = new Guid("ee871f12-cecd-4b28-ab6e-8087c5db4b92"), AccessFailedCount = 0, ConcurrencyStamp = "43f678a7-f09a-4ede-a018-075ae2987178", Email = "bartlomiej.predki@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", NormalizedUserName = "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEORJI+JaqCt12/3kFAf/rZA3Q5tkXwmNU5ErG5Bmf2yz2JkU0QKArQgKkOiGmAmP3w==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "bartlomiej.predki@put.poznan.pl" },
                        new { Id = new Guid("eee1aac1-756d-4715-abc8-7145358db933"), AccessFailedCount = 0, ConcurrencyStamp = "475cbb51-e4b4-41e5-b33f-3fc1f0e67419", Email = "milosz.kadzinski@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "MILOSZ.KADZINSKI@PUT.POZNAN.PL", NormalizedUserName = "MILOSZ.KADZINSKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEIsPExQOzrqQqCN2QuZ0p9j8G3olMeXk202trS8CIKLJc+CDz2qEA/Pn5kr9tmK23g==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "milosz.kadzinski@put.poznan.pl" },
                        new { Id = new Guid("562482e9-4bc3-4820-af9b-0d3d475af6f0"), AccessFailedCount = 0, ConcurrencyStamp = "e4b14a1f-8c2d-49dd-9fdb-44bd87d6ca15", Email = "wojciech.kotlowski@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", NormalizedUserName = "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEBQN2+4azM+k3ogt+I4d0Li1FVv7n1QAbC9m94mmensWEpeLW8ZCiqzeU7pLAK+hhg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "wojciech.kotlowski@put.poznan.pl" },
                        new { Id = new Guid("dab87c07-dd82-47d0-b556-f42fc91b80df"), AccessFailedCount = 0, ConcurrencyStamp = "3f012fa8-e815-4724-aabe-0be3423e5e07", Email = "jerzy.nawrocki@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "JERZY.NAWROCKI@PUT.POZNAN.PL", NormalizedUserName = "JERZY.NAWROCKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEHtr4/qmdXbKz8NNpC6ww9R3IsaVNEqTKYW0HKav+BIgCyGkw+gQwozSfGQnE1lkYg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "jerzy.nawrocki@put.poznan.pl" },
                        new { Id = new Guid("651ede50-8a9d-46b6-975c-df5e10ffe63f"), AccessFailedCount = 0, ConcurrencyStamp = "77029560-381e-498d-9829-58376f422195", Email = "katarzyna.adamska@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", NormalizedUserName = "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEFleeHHguT+oXRP+7DubkU2Tyokez7AbOFox4BbrSOPDkOuCns94J4bKcQzOoILkaw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "katarzyna.adamska@put.poznan.pl" },
                        new { Id = new Guid("c198a53a-ca32-4a8e-aff1-b6766f8c0e6d"), AccessFailedCount = 0, ConcurrencyStamp = "42c6a5dd-c30a-4032-bdfe-b59beaa6b427", Email = "krzysztof.alejski@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", NormalizedUserName = "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEFTz6rVVq0tOrVbTUJy8QRlu7SI97EReBDYsFl8El5psNZCnM4NWkk7O+87yPE0bGg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "krzysztof.alejski@put.poznan.pl" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Institute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Institutes");

                    b.HasData(
                        new { Id = new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), Name = "Instytut Informatyki" },
                        new { Id = new Guid("d0ca6c83-b39c-4058-b59e-7d6f42ba082c"), Name = "Instytut Technologii Mechanicznej" },
                        new { Id = new Guid("fd6cfd16-b293-4198-8820-1bf378fb9a22"), Name = "Instytut Matematyki" },
                        new { Id = new Guid("571363ac-7947-47ce-9023-c5eb00e9df57"), Name = "Instytut Technologii Materiałów" },
                        new { Id = new Guid("5de0c4f2-84ff-4b1b-a06b-2b083bbbd296"), Name = "Instytut Inżynierii Lądowej" },
                        new { Id = new Guid("e05293a1-2bf6-4959-870f-7b49938a1f2f"), Name = "Instytut Inżynierii Środowiska" },
                        new { Id = new Guid("dfad55a5-680b-4bd1-9307-021f3e7b229b"), Name = "Instytut Chemii i Elektrochemii Technicznej" },
                        new { Id = new Guid("fb20aef9-be52-4a5a-992c-120f9c11d0ce"), Name = "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                        new { Id = new Guid("f1c4a3c9-3e12-4155-b385-d3f2fb770771"), Name = "Instytut Mechaniki Stosowanej" },
                        new { Id = new Guid("5904aba9-0699-4e40-bea5-3fc76d42785c"), Name = "Instytut Technologii i Inżynierii Chemicznej" },
                        new { Id = new Guid("354656a2-1a96-4037-b49e-df56c2c1864b"), Name = "Instytut Architektury i Planowania Przestrzennego" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Promoter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExpectedNumberOfBachelorProposals");

                    b.Property<int>("ExpectedNumberOfMasterProposals");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<Guid>("InstituteId");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("TitlePostfix");

                    b.Property<string>("TitlePrefix")
                        .IsRequired();

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.HasIndex("UserId");

                    b.ToTable("Promoters");

                    b.HasData(
                        new { Id = new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Irmina", InstituteId = new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), LastName = "Masłowska", TitlePostfix = "", TitlePrefix = "dr inż.", UserId = new Guid("b497e663-8983-408d-a788-840e34c0736a") },
                        new { Id = new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Bartłomiej", InstituteId = new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), LastName = "Prędki", TitlePostfix = "", TitlePrefix = "dr inż.", UserId = new Guid("ee871f12-cecd-4b28-ab6e-8087c5db4b92") },
                        new { Id = new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Miłosz", InstituteId = new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), LastName = "Kadziński", TitlePostfix = "", TitlePrefix = "dr hab. inż.", UserId = new Guid("eee1aac1-756d-4715-abc8-7145358db933") },
                        new { Id = new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Wojciech", InstituteId = new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), LastName = "Kotłowski", TitlePostfix = "", TitlePrefix = "dr hab. inż.", UserId = new Guid("562482e9-4bc3-4820-af9b-0d3d475af6f0") },
                        new { Id = new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Jerzy", InstituteId = new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), LastName = "Nawrocki", TitlePostfix = "prof. PP", TitlePrefix = "dr hab inż.", UserId = new Guid("dab87c07-dd82-47d0-b556-f42fc91b80df") },
                        new { Id = new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), ExpectedNumberOfBachelorProposals = 1, ExpectedNumberOfMasterProposals = 1, FirstName = "Katarzyna", InstituteId = new Guid("5904aba9-0699-4e40-bea5-3fc76d42785c"), LastName = "Adamska", TitlePostfix = "", TitlePrefix = "dr inż.", UserId = new Guid("651ede50-8a9d-46b6-975c-df5e10ffe63f") },
                        new { Id = new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), ExpectedNumberOfBachelorProposals = 3, ExpectedNumberOfMasterProposals = 2, FirstName = "Krzysztof", InstituteId = new Guid("5904aba9-0699-4e40-bea5-3fc76d42785c"), LastName = "Alejski", TitlePostfix = "prof. PP", TitlePrefix = "dr hab. inż.", UserId = new Guid("c198a53a-ca32-4a8e-aff1-b6766f8c0e6d") }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Proposal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Level");

                    b.Property<int>("Mode");

                    b.Property<Guid>("PromoterId");

                    b.Property<string>("Specialization");

                    b.Property<DateTime>("StartingDate");

                    b.Property<int>("Status");

                    b.Property<int>("StudyProfile");

                    b.Property<string>("TopicEnglish")
                        .IsRequired();

                    b.Property<string>("TopicPolish")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("PromoterId");

                    b.ToTable("Proposals");

                    b.HasData(
                        new { Id = new Guid("f384af8a-5457-497b-906e-956030d704a5"), CourseId = new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), Description = "Opis.....", Level = 0, Mode = 0, PromoterId = new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), Specialization = "Opis.......", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Capri 2 - system for managing diploma topic cards", TopicPolish = "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                        new { Id = new Guid("5d8c4d5d-33cc-443f-baca-6212990f8fd1"), CourseId = new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), Description = "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", Level = 0, Mode = 0, PromoterId = new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), Specialization = "....................................", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Implementation of chosen methods from Electre family", TopicPolish = "Implementacja wybranych metod z rodziny Electre" },
                        new { Id = new Guid("1e956971-1e05-4c1c-b512-04b088e05eae"), CourseId = new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), Description = "Opis.....", Level = 0, Mode = 0, PromoterId = new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), Specialization = "Opis.......", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Implementation of decision support methods based on utility function (UTA, Assess)", TopicPolish = "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                        new { Id = new Guid("115fd046-b41a-434e-9c72-ece1a0183487"), CourseId = new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), Description = "Opis.....", Level = 0, Mode = 0, PromoterId = new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), Specialization = "Opis.......", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Extension of diviz platform", TopicPolish = "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                        new { Id = new Guid("48df0675-acc0-452f-bc6d-6245719f0ce6"), CourseId = new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), Description = "Opis.....", Level = 0, Mode = 0, PromoterId = new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), Specialization = "Opis.......", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Style transfering using a neural network", TopicPolish = "Transfer stylu przy użyciu sieci neuronowej" },
                        new { Id = new Guid("79f2ec6f-b816-4d95-b3a2-9db668aefd3b"), CourseId = new Guid("b7ab2cab-7cdc-4085-9c8a-84e3e9d04ab5"), Description = "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", Level = 0, Mode = 0, PromoterId = new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), Specialization = "Brak opisu", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "No title", TopicPolish = "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                        new { Id = new Guid("05d765bf-af90-450b-bef4-e97bb073125e"), CourseId = new Guid("b7ab2cab-7cdc-4085-9c8a-84e3e9d04ab5"), Description = "Brak opisu", Level = 1, Mode = 0, PromoterId = new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), Specialization = "Brak opisu", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "No title", TopicPolish = "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProposalId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProposalId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");

                    b.HasData(
                        new { Id = new Guid("448c9194-e82d-4963-958f-8ddc850dc95f"), UserId = new Guid("4671073c-6dc6-4daf-8ba9-6c5deda31612") },
                        new { Id = new Guid("ecbd0c64-740e-41fe-99f2-5bfce5cb1318"), UserId = new Guid("0b76826e-692f-46b8-805a-f4b6e723bae4") },
                        new { Id = new Guid("919a2a2d-8cce-445b-b723-6748929d6e11"), UserId = new Guid("bec3a8c9-7e41-4279-9882-319eabf2f3f7") },
                        new { Id = new Guid("aabd8c30-187f-4cd0-abb0-daca200e905c"), UserId = new Guid("9a256119-b8a2-45f7-9a85-5726258e8d16") }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Course", b =>
                {
                    b.HasOne("Capri.Database.Entities.Faculty", "Faculty")
                        .WithMany("Courses")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Capri.Database.Entities.Promoter", b =>
                {
                    b.HasOne("Capri.Database.Entities.Institute", "Institute")
                        .WithMany("Promoters")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Capri.Database.Entities.Identity.User", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Capri.Database.Entities.Proposal", b =>
                {
                    b.HasOne("Capri.Database.Entities.Course", "Course")
                        .WithMany("Proposals")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Capri.Database.Entities.Promoter", "Promoter")
                        .WithMany("Proposals")
                        .HasForeignKey("PromoterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Capri.Database.Entities.Student", b =>
                {
                    b.HasOne("Capri.Database.Entities.Proposal")
                        .WithMany("Students")
                        .HasForeignKey("ProposalId");

                    b.HasOne("Capri.Database.Entities.Identity.User", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
