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
                        new { Id = new Guid("455badb2-e1e8-4431-bbd8-54a0bcb5d992"), FacultyId = new Guid("286182fb-2eff-4f6e-bec6-cf86373bfb06"), Name = "Architektura" },
                        new { Id = new Guid("051a4255-39d4-4526-976c-629bb8101c36"), FacultyId = new Guid("286182fb-2eff-4f6e-bec6-cf86373bfb06"), Name = "Architektura Wnętrz" },
                        new { Id = new Guid("b2199a8a-a5c0-4c2d-bbe1-d94479b51c4c"), FacultyId = new Guid("74de6b59-54f9-449f-b895-bf54f7f4cc0e"), Name = "Budownictwo" },
                        new { Id = new Guid("3349c8ec-5316-4e5e-9790-e388c7f1dbf6"), FacultyId = new Guid("74de6b59-54f9-449f-b895-bf54f7f4cc0e"), Name = "Inżynieria Środowiska" },
                        new { Id = new Guid("6233296a-f86c-4c96-ab8c-c5c3409ba0f5"), FacultyId = new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), Name = "Inżynieria Biomedyczna" },
                        new { Id = new Guid("4c559e9b-8302-497b-83d4-5478fafc9976"), FacultyId = new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), Name = "Inżynieria Materiałowa" },
                        new { Id = new Guid("1d29813f-61cb-48a8-83b0-8a80c2e0d4e5"), FacultyId = new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), Name = "Mechanika i Budowa Maszyn" },
                        new { Id = new Guid("c9f4acb5-5217-48a1-b734-95e73db5709b"), FacultyId = new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), Name = "Mechatronika" },
                        new { Id = new Guid("359b3ce3-c3e9-40a8-9481-9f950c5b84fd"), FacultyId = new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), Name = "Zarządzanie i Inżynieria Produkcji" },
                        new { Id = new Guid("780bdacd-04aa-4919-873c-246e7b6c13a2"), FacultyId = new Guid("35095857-bb5a-4d2c-bf7d-94bae1eeed06"), Name = "Elektronika i Telekomunikacja" },
                        new { Id = new Guid("8c1ec866-5ac9-4756-9468-df9e06804638"), FacultyId = new Guid("35095857-bb5a-4d2c-bf7d-94bae1eeed06"), Name = "Teleinformatyka" },
                        new { Id = new Guid("47ce10ca-4612-4553-a065-2def9a55e2ba"), FacultyId = new Guid("7fa3fbf3-e14f-4942-8195-8d2693260dfd"), Name = "Automatyka i Robotyka" },
                        new { Id = new Guid("10b6913f-e4ad-4886-b729-c21bbb33eddf"), FacultyId = new Guid("7fa3fbf3-e14f-4942-8195-8d2693260dfd"), Name = "Elektrotechnika" },
                        new { Id = new Guid("c38d9fa2-5d3e-4cab-b955-aae7dda4e088"), FacultyId = new Guid("7fa3fbf3-e14f-4942-8195-8d2693260dfd"), Name = "Energetyka" },
                        new { Id = new Guid("2e65d34d-45aa-4c0d-b8d6-6c90d37eb6ac"), FacultyId = new Guid("7fa3fbf3-e14f-4942-8195-8d2693260dfd"), Name = "Matematyka w Technice" },
                        new { Id = new Guid("65f312a0-c6d9-4fe6-a89f-d29e8bd50fe8"), FacultyId = new Guid("3803621e-d4fc-40d2-af6f-bb6423d4fa10"), Name = "Edukacja Techniczno-Informatyczna" },
                        new { Id = new Guid("5e4c5c6b-74fb-4cc7-9974-a620d8efec50"), FacultyId = new Guid("3803621e-d4fc-40d2-af6f-bb6423d4fa10"), Name = "Fizyka Techniczna" },
                        new { Id = new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), FacultyId = new Guid("53cfd11a-f8d3-40df-aeb8-56b2a28a7c6e"), Name = "Informatyka" },
                        new { Id = new Guid("1bb31a59-ba48-4f26-934f-c17748347901"), FacultyId = new Guid("53cfd11a-f8d3-40df-aeb8-56b2a28a7c6e"), Name = "Bioinformatyka" },
                        new { Id = new Guid("b6a1b4fd-681d-4f19-a843-052c1cf0112b"), FacultyId = new Guid("53cfd11a-f8d3-40df-aeb8-56b2a28a7c6e"), Name = "Sztuczna Inteligencja / Artificial Intelligence" },
                        new { Id = new Guid("0544acdb-6930-4c4b-9812-87263500c38e"), FacultyId = new Guid("a223465f-4d7c-42d8-bb26-4b36ddd22338"), Name = "Konstrukcja i Eksploatacja Środków Transportu" },
                        new { Id = new Guid("dc90996a-cda3-4394-b748-7dbea1bb8ba5"), FacultyId = new Guid("a223465f-4d7c-42d8-bb26-4b36ddd22338"), Name = "Transport" },
                        new { Id = new Guid("640f9230-2faa-40c3-9cb9-a55fa5fe25ec"), FacultyId = new Guid("a223465f-4d7c-42d8-bb26-4b36ddd22338"), Name = "Lotnictwo i Kosmonautyka" },
                        new { Id = new Guid("ae99b625-b072-4de9-873e-f8ebe5f266be"), FacultyId = new Guid("daf819dd-4dd8-4477-8879-c711bf424562"), Name = "Logistyka" },
                        new { Id = new Guid("50d88bde-02aa-45fa-9961-8011cffa3a47"), FacultyId = new Guid("daf819dd-4dd8-4477-8879-c711bf424562"), Name = "Inżynieria Zarządzania" },
                        new { Id = new Guid("c869999c-bf22-404b-accb-e1ec78d5ad95"), FacultyId = new Guid("daf819dd-4dd8-4477-8879-c711bf424562"), Name = "Inżynieria Bezpieczeństwa" },
                        new { Id = new Guid("eadc3557-5492-4085-b95e-a08f1d31e8b5"), FacultyId = new Guid("13ebb15c-f09c-4600-b2c8-1e9bd5c268dd"), Name = "Inżynieria Chemiczna i Procesowa" },
                        new { Id = new Guid("ab9c2ba9-01fa-4f73-b61a-e8c9be81bf0a"), FacultyId = new Guid("13ebb15c-f09c-4600-b2c8-1e9bd5c268dd"), Name = "Technologia Chemiczna / Chemical Technology" },
                        new { Id = new Guid("68f55fa9-4cd6-4fae-9f68-e07409212a82"), FacultyId = new Guid("13ebb15c-f09c-4600-b2c8-1e9bd5c268dd"), Name = "Technologie Ochrony Środowiska" },
                        new { Id = new Guid("5b6bb82d-bf2a-40fd-b4f4-d155c44b4f36"), FacultyId = new Guid("13ebb15c-f09c-4600-b2c8-1e9bd5c268dd"), Name = "Inżynieria Farmaceutyczna" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Faculties");

                    b.HasData(
                        new { Id = new Guid("286182fb-2eff-4f6e-bec6-cf86373bfb06"), Name = "Wydział Architektury" },
                        new { Id = new Guid("74de6b59-54f9-449f-b895-bf54f7f4cc0e"), Name = "Wydział Budownictwa i Inżynierii Środowiska" },
                        new { Id = new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), Name = "Wydział Budowy Maszyn i Zarządzania" },
                        new { Id = new Guid("35095857-bb5a-4d2c-bf7d-94bae1eeed06"), Name = "Wydział Elektroniki i Telekomunikacji" },
                        new { Id = new Guid("7fa3fbf3-e14f-4942-8195-8d2693260dfd"), Name = "Wydział Elektryczny" },
                        new { Id = new Guid("3803621e-d4fc-40d2-af6f-bb6423d4fa10"), Name = "Wydział Fizyki Technicznej" },
                        new { Id = new Guid("53cfd11a-f8d3-40df-aeb8-56b2a28a7c6e"), Name = "Wydział Informatyki" },
                        new { Id = new Guid("a223465f-4d7c-42d8-bb26-4b36ddd22338"), Name = "Wydział Inżynierii Transportu" },
                        new { Id = new Guid("daf819dd-4dd8-4477-8879-c711bf424562"), Name = "Wydział Inżynierii Zarządzania" },
                        new { Id = new Guid("13ebb15c-f09c-4600-b2c8-1e9bd5c268dd"), Name = "Wydział Technologii Chemicznej" }
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
                        new { Id = new Guid("b9115348-2ffa-4cf1-b282-e3008665c149"), ConcurrencyStamp = "922f5127-ea0a-41fe-931d-5d6f836a29c0", Name = "Dean", NormalizedName = "Dean" },
                        new { Id = new Guid("8270982e-fadd-4d16-b472-f07716ed50fc"), ConcurrencyStamp = "921987da-89c9-47f9-96fe-23516f7c4467", Name = "Student", NormalizedName = "Student" },
                        new { Id = new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), ConcurrencyStamp = "21b4787b-64c9-49c8-8b09-93be716ad2a3", Name = "Promoter", NormalizedName = "Promoter" }
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
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("UserId", "RoleId");

                    b.HasAlternateKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new { UserId = new Guid("187cf661-0d86-4174-a94f-4c20fc2f91cf"), RoleId = new Guid("b9115348-2ffa-4cf1-b282-e3008665c149"), Id = new Guid("ac13a907-df76-4a63-8a62-7f8ba3434975") },
                        new { UserId = new Guid("c50fef05-5454-47e0-93a4-507b6b309961"), RoleId = new Guid("b9115348-2ffa-4cf1-b282-e3008665c149"), Id = new Guid("64aba70d-2c2a-4c95-97ff-fdeb001ea1cc") },
                        new { UserId = new Guid("79051779-d90e-4f32-8a54-09f25a519229"), RoleId = new Guid("b9115348-2ffa-4cf1-b282-e3008665c149"), Id = new Guid("168b98c1-43a3-4e51-9aea-195d98cd2cb9") },
                        new { UserId = new Guid("0ef4a4ca-9cfc-4753-8054-9a339fda4dd9"), RoleId = new Guid("b9115348-2ffa-4cf1-b282-e3008665c149"), Id = new Guid("2833d2dc-8bc0-4986-b492-3b64fc3d4a05") },
                        new { UserId = new Guid("dcab23ee-6e30-401e-a477-82d0747f4620"), RoleId = new Guid("8270982e-fadd-4d16-b472-f07716ed50fc"), Id = new Guid("d1823795-cdca-4962-83ae-75084b0be85e") },
                        new { UserId = new Guid("e8a680ad-4d03-4805-bde5-53929e509d8d"), RoleId = new Guid("8270982e-fadd-4d16-b472-f07716ed50fc"), Id = new Guid("546f878e-5073-435b-a4e5-4108e5c6576c") },
                        new { UserId = new Guid("365a985a-a140-411a-b829-6c00124b0985"), RoleId = new Guid("8270982e-fadd-4d16-b472-f07716ed50fc"), Id = new Guid("2041656d-ded7-40e4-8b03-12467a9579b6") },
                        new { UserId = new Guid("414b4914-be9c-4774-bb04-c0d3db715797"), RoleId = new Guid("8270982e-fadd-4d16-b472-f07716ed50fc"), Id = new Guid("f989d191-edc2-4562-9bff-7a31e16fd937") },
                        new { UserId = new Guid("32de6a04-27ce-4c4c-bc6f-3dc9863aa3b8"), RoleId = new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), Id = new Guid("20f17f4b-8203-42f6-928c-d9b4abfb32c2") },
                        new { UserId = new Guid("d7fccab2-21c9-4a89-8f72-f0e342481692"), RoleId = new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), Id = new Guid("1e55ba59-5acd-4579-b62c-ec08a08b90f1") },
                        new { UserId = new Guid("2e970899-3edd-41bb-9119-9685aee185a3"), RoleId = new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), Id = new Guid("e72ea699-96ae-48a7-aa94-0b8060663ffb") },
                        new { UserId = new Guid("008121fd-7e0b-4ff5-bc86-65ab0502da1a"), RoleId = new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), Id = new Guid("da63d89f-4863-4c1b-a0a6-8faa50f68b12") },
                        new { UserId = new Guid("32a29b01-4688-4de7-98e2-9183357a1fd3"), RoleId = new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), Id = new Guid("b6144062-8217-46d4-9cdc-077b0b513ba1") },
                        new { UserId = new Guid("c91ff433-4a4f-496a-a7c9-1bf7f81ffaaf"), RoleId = new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), Id = new Guid("7449130f-eddc-4c60-93ff-d52707fa84fe") },
                        new { UserId = new Guid("7e0d1efd-5265-4527-8d78-ea00678ae77f"), RoleId = new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), Id = new Guid("b3c93855-8964-4ad4-a179-411ed7fb7f28") }
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
                        new { Id = new Guid("187cf661-0d86-4174-a94f-4c20fc2f91cf"), AccessFailedCount = 0, ConcurrencyStamp = "08367d25-c254-461e-8de6-c62b7420082d", Email = "dean1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN1@GMAIL.COM", NormalizedUserName = "DEAN1@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEGCiEzE8bXa/tad8sfuvCm5ZUpfxiMhV19u3i2x5RCjf2rtQVLwMfDjxe213n+Y+Fw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean1@gmail.com" },
                        new { Id = new Guid("c50fef05-5454-47e0-93a4-507b6b309961"), AccessFailedCount = 0, ConcurrencyStamp = "8ac4dc76-f8e5-42b0-9ca4-35d04e516492", Email = "dean2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN2@GMAIL.COM", NormalizedUserName = "DEAN2@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEErdZ6LnXfGFlVOmVOuI7egDPXji4hEAunf/rRyPz8tYk1PvLTtho66Gd095yZgpMA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean2@gmail.com" },
                        new { Id = new Guid("79051779-d90e-4f32-8a54-09f25a519229"), AccessFailedCount = 0, ConcurrencyStamp = "336c905a-0bc6-415e-b35f-8c9a7a6fecc2", Email = "dean3@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN3@GMAIL.COM", NormalizedUserName = "DEAN3@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEOCJG9JeMN7EVkd22IbsEZAb91yxtSd3mnaRhx2LvQeBOZkaGf6OnoKi7MmKO2ZBsQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean3@gmail.com" },
                        new { Id = new Guid("0ef4a4ca-9cfc-4753-8054-9a339fda4dd9"), AccessFailedCount = 0, ConcurrencyStamp = "01aaffbc-f775-4020-a91c-d982770006b5", Email = "dean4@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN4@GMAIL.COM", NormalizedUserName = "DEAN4@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEJV54TpvcU9DqQ3SEVHZwfndzaRmiSBQEfOgN0noHPb0FcVHYcSLyqDp9GsMbR8ZLA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean4@gmail.com" },
                        new { Id = new Guid("dcab23ee-6e30-401e-a477-82d0747f4620"), AccessFailedCount = 0, ConcurrencyStamp = "e81c46a6-2c77-4874-8fe0-8cded227b83b", Email = "student1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT1@GMAIL.COM", NormalizedUserName = "STUDENT1@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEDh28hderJzB5cxqyaJkWvpFu3FKAPLk7SEfBsbi661EvmQGHBVHxM+MjvdXefa1Uw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student1@gmail.com" },
                        new { Id = new Guid("e8a680ad-4d03-4805-bde5-53929e509d8d"), AccessFailedCount = 0, ConcurrencyStamp = "38a52f22-c8d6-4b91-8f02-10049d158e8e", Email = "student2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT2@GMAIL.COM", NormalizedUserName = "STUDENT2@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEOlF564Hk040wSG4T2eZU2N+o5hE8AoiUEiCsjkiEd5L/OrmyW7hIkJJ8WjhwMrYWA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student2@gmail.com" },
                        new { Id = new Guid("365a985a-a140-411a-b829-6c00124b0985"), AccessFailedCount = 0, ConcurrencyStamp = "ad2aa486-8ef4-462a-adbe-3faf89c12283", Email = "student3@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT3@GMAIL.COM", NormalizedUserName = "STUDENT3@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEFTRjvCsb9OzMSjq+GaVBVJK9mWw+aGQvZXF3gN4c6i46YwsQYEEFKAzF/3UIO9zxw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student3@gmail.com" },
                        new { Id = new Guid("414b4914-be9c-4774-bb04-c0d3db715797"), AccessFailedCount = 0, ConcurrencyStamp = "9f162f3f-6727-408f-b0af-5387958348b5", Email = "student4@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT4@GMAIL.COM", NormalizedUserName = "STUDENT4@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEN0bDNHTllw36luG/aopDbykqRFgDmJjShLmsV5wZ8lEc0KJ5js8T6p3n+aTLkJ0jA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student4@gmail.com" },
                        new { Id = new Guid("32de6a04-27ce-4c4c-bc6f-3dc9863aa3b8"), AccessFailedCount = 0, ConcurrencyStamp = "cbb7f42a-179f-416c-98bf-dbc91e060ebe", Email = "irmina.maslowska@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "IRMINA.MASLOWSKA@PUT.POZNAN.PL", NormalizedUserName = "IRMINA.MASLOWSKA@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEFYrmhYQAZgvEy+6Oqbi09lyiRXYcuaI3ayX1lyhKIW+EoHSD4sKO7UHzNBXCstw8Q==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "irmina.maslowska@put.poznan.pl" },
                        new { Id = new Guid("d7fccab2-21c9-4a89-8f72-f0e342481692"), AccessFailedCount = 0, ConcurrencyStamp = "43286458-65a2-4a07-a2da-fa5ee9b60d2f", Email = "bartlomiej.predki@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", NormalizedUserName = "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEIEAnPrDlpg0JHN3k6XodohuJUJzsyPvt/B2SAVV+S4ZC/IzJIIphoqlmMVlE5r4vQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "bartlomiej.predki@put.poznan.pl" },
                        new { Id = new Guid("2e970899-3edd-41bb-9119-9685aee185a3"), AccessFailedCount = 0, ConcurrencyStamp = "9b1c5d9c-39b1-4c8b-ad15-e83d1d7c373b", Email = "milosz.kadzinski@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "MILOSZ.KADZINSKI@PUT.POZNAN.PL", NormalizedUserName = "MILOSZ.KADZINSKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEJfmFLPus+w+zWyB4R81G866vQjjaAjFIJS99Ekt3iXh1OXynUCoz0G+N7Fmjk6slQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "milosz.kadzinski@put.poznan.pl" },
                        new { Id = new Guid("008121fd-7e0b-4ff5-bc86-65ab0502da1a"), AccessFailedCount = 0, ConcurrencyStamp = "42c0feee-3c0b-41b7-b78a-d5a62da87490", Email = "wojciech.kotlowski@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", NormalizedUserName = "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEDwR3a5ICbhmKMb/NYbXU1GL/NFdXX7Ym4G6Z0H3wwxMFnARzzw3fVAAgHINHOOn/g==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "wojciech.kotlowski@put.poznan.pl" },
                        new { Id = new Guid("32a29b01-4688-4de7-98e2-9183357a1fd3"), AccessFailedCount = 0, ConcurrencyStamp = "481e3b0d-7e46-4acc-b471-2e1b3a2f04ce", Email = "jerzy.nawrocki@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "JERZY.NAWROCKI@PUT.POZNAN.PL", NormalizedUserName = "JERZY.NAWROCKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEIn10ZK9t0yT97PAPTDfZNTwdbYPJVRxO12R/Fj2SEiQlaIXtUz5MVoz2FOOoYJl/A==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "jerzy.nawrocki@put.poznan.pl" },
                        new { Id = new Guid("c91ff433-4a4f-496a-a7c9-1bf7f81ffaaf"), AccessFailedCount = 0, ConcurrencyStamp = "7b846c1e-64d4-43c6-82b6-c56a5d43a530", Email = "katarzyna.adamska@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", NormalizedUserName = "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAECngEYilsdaFSa4MoV70arqJBnU4KGC9x3wZ1pxmjmispqzRMcnLNI7c0nG8sPcYxg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "katarzyna.adamska@put.poznan.pl" },
                        new { Id = new Guid("7e0d1efd-5265-4527-8d78-ea00678ae77f"), AccessFailedCount = 0, ConcurrencyStamp = "c2f136c1-6987-4b6d-9cdf-1b740777877a", Email = "krzysztof.alejski@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", NormalizedUserName = "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEAlDq6najfQ0dLS/zn8SsdL79YJmvOTB77j5JRaMJ2CUrmZV/M6epTQuvLojzevVaA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "krzysztof.alejski@put.poznan.pl" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Institute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Institutes");

                    b.HasData(
                        new { Id = new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), Name = "Instytut Informatyki" },
                        new { Id = new Guid("631f6158-f915-41d5-9cb7-8611d4462061"), Name = "Instytut Technologii Mechanicznej" },
                        new { Id = new Guid("6b04ff5e-f41c-4e22-9c0d-be270b222538"), Name = "Instytut Matematyki" },
                        new { Id = new Guid("19cc3f15-00b5-435c-ab18-5dd9a64a4f6d"), Name = "Instytut Technologii Materiałów" },
                        new { Id = new Guid("e76e64dc-b1f1-4926-9d25-2fa7f5fa7685"), Name = "Instytut Inżynierii Lądowej" },
                        new { Id = new Guid("ff82c6fe-347b-401b-afd2-4cad0e684f91"), Name = "Instytut Inżynierii Środowiska" },
                        new { Id = new Guid("38c10662-59bd-4ac9-a5cf-866ce527349a"), Name = "Instytut Chemii i Elektrochemii Technicznej" },
                        new { Id = new Guid("6c48f51c-3310-44f5-9a88-38c250fa23f8"), Name = "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                        new { Id = new Guid("8fd0290d-6fce-4aeb-abd1-7eb438014300"), Name = "Instytut Mechaniki Stosowanej" },
                        new { Id = new Guid("767083df-627d-4549-bf34-31d94855431b"), Name = "Instytut Technologii i Inżynierii Chemicznej" },
                        new { Id = new Guid("366fc5ee-ff85-4ca3-bf6e-a1cc24284a25"), Name = "Instytut Architektury i Planowania Przestrzennego" }
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
                        new { Id = new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Irmina", InstituteId = new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), LastName = "Masłowska", TitlePostfix = "", TitlePrefix = "dr inż.", UserId = new Guid("32de6a04-27ce-4c4c-bc6f-3dc9863aa3b8") },
                        new { Id = new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Bartłomiej", InstituteId = new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), LastName = "Prędki", TitlePostfix = "", TitlePrefix = "dr inż.", UserId = new Guid("d7fccab2-21c9-4a89-8f72-f0e342481692") },
                        new { Id = new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Miłosz", InstituteId = new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), LastName = "Kadziński", TitlePostfix = "", TitlePrefix = "dr hab. inż.", UserId = new Guid("2e970899-3edd-41bb-9119-9685aee185a3") },
                        new { Id = new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Wojciech", InstituteId = new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), LastName = "Kotłowski", TitlePostfix = "", TitlePrefix = "dr hab. inż.", UserId = new Guid("008121fd-7e0b-4ff5-bc86-65ab0502da1a") },
                        new { Id = new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Jerzy", InstituteId = new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), LastName = "Nawrocki", TitlePostfix = "prof. PP", TitlePrefix = "dr hab inż.", UserId = new Guid("32a29b01-4688-4de7-98e2-9183357a1fd3") },
                        new { Id = new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), ExpectedNumberOfBachelorProposals = 1, ExpectedNumberOfMasterProposals = 1, FirstName = "Katarzyna", InstituteId = new Guid("767083df-627d-4549-bf34-31d94855431b"), LastName = "Adamska", TitlePostfix = "", TitlePrefix = "dr inż.", UserId = new Guid("c91ff433-4a4f-496a-a7c9-1bf7f81ffaaf") },
                        new { Id = new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), ExpectedNumberOfBachelorProposals = 3, ExpectedNumberOfMasterProposals = 2, FirstName = "Krzysztof", InstituteId = new Guid("767083df-627d-4549-bf34-31d94855431b"), LastName = "Alejski", TitlePostfix = "prof. PP", TitlePrefix = "dr hab. inż.", UserId = new Guid("7e0d1efd-5265-4527-8d78-ea00678ae77f") }
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

                    b.Property<int>("MaxNumberOfStudents");

                    b.Property<int>("Mode");

                    b.Property<string>("OutputData");

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
                        new { Id = new Guid("3444ec67-ee14-4546-8f04-786d27e0080a"), CourseId = new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), Description = "Opis.....", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Capri 2 - system for managing diploma topic cards", TopicPolish = "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                        new { Id = new Guid("6b596b4c-c2b6-4084-a628-e535824ce7a3"), CourseId = new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), Description = "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Implementation of chosen methods from Electre family", TopicPolish = "Implementacja wybranych metod z rodziny Electre" },
                        new { Id = new Guid("c11e5a70-1991-4dbc-9deb-53c24c1c55ac"), CourseId = new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), Description = "Opis.....", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Implementation of decision support methods based on utility function (UTA, Assess)", TopicPolish = "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                        new { Id = new Guid("4f210ca3-e6d1-4ae1-b776-fe8ff0292247"), CourseId = new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), Description = "Opis.....", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Extension of diviz platform", TopicPolish = "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                        new { Id = new Guid("67828e42-918c-4e7b-a381-aa279c785803"), CourseId = new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), Description = "Opis.....", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Style transfering using a neural network", TopicPolish = "Transfer stylu przy użyciu sieci neuronowej" },
                        new { Id = new Guid("a6c7e366-0f7b-43b5-baad-6edbbeb92bc7"), CourseId = new Guid("eadc3557-5492-4085-b95e-a08f1d31e8b5"), Description = "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "No title", TopicPolish = "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                        new { Id = new Guid("783b7d9b-8fbf-4612-a038-eb763158d34b"), CourseId = new Guid("eadc3557-5492-4085-b95e-a08f1d31e8b5"), Description = "Brak opisu", Level = 1, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "No title", TopicPolish = "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProposalId");

                    b.Property<int>("Semester");

                    b.Property<int>("StudyLevel");

                    b.Property<int>("StudyMode");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProposalId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");

                    b.HasData(
                        new { Id = new Guid("9a3169d3-1751-4637-b057-4f9f5a4fa8ce"), Semester = 6, StudyLevel = 0, StudyMode = 0, UserId = new Guid("dcab23ee-6e30-401e-a477-82d0747f4620") },
                        new { Id = new Guid("6e90bc48-ed5e-45c1-9226-af30a6d134eb"), Semester = 6, StudyLevel = 0, StudyMode = 0, UserId = new Guid("e8a680ad-4d03-4805-bde5-53929e509d8d") },
                        new { Id = new Guid("8c2f224a-38ee-4fc8-811d-09f2705990b2"), Semester = 6, StudyLevel = 0, StudyMode = 0, UserId = new Guid("365a985a-a140-411a-b829-6c00124b0985") },
                        new { Id = new Guid("6a8672dc-a7d0-4f15-a6d6-b14b6b8c98b9"), Semester = 6, StudyLevel = 0, StudyMode = 0, UserId = new Guid("414b4914-be9c-4774-bb04-c0d3db715797") }
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
                    b.HasOne("Capri.Database.Entities.Proposal", "Proposal")
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
