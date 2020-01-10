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
                        new { Id = new Guid("99d30330-0398-442e-ab8a-a723b542c642"), FacultyId = new Guid("da480316-43e7-4d27-a530-5d31d489e818"), Name = "Architektura" },
                        new { Id = new Guid("53d15d63-d3c6-40cf-8235-be76027a6819"), FacultyId = new Guid("da480316-43e7-4d27-a530-5d31d489e818"), Name = "Architektura Wnętrz" },
                        new { Id = new Guid("f14c0f38-647a-4cac-a2a4-a5aedafdc787"), FacultyId = new Guid("9c087bbe-068f-48c1-bde3-99171ada674c"), Name = "Budownictwo" },
                        new { Id = new Guid("bbfb0b71-e42a-4371-8346-4f09108f7557"), FacultyId = new Guid("9c087bbe-068f-48c1-bde3-99171ada674c"), Name = "Inżynieria Środowiska" },
                        new { Id = new Guid("3c68c746-ac0f-47d2-80b9-f701f54a5bf1"), FacultyId = new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), Name = "Inżynieria Biomedyczna" },
                        new { Id = new Guid("0bc905f1-a00a-40f4-b047-ee94f5962d1a"), FacultyId = new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), Name = "Inżynieria Materiałowa" },
                        new { Id = new Guid("a7d521e5-29c0-440c-b981-7bf6d319bb90"), FacultyId = new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), Name = "Mechanika i Budowa Maszyn" },
                        new { Id = new Guid("8a37703e-70a1-4814-884c-c6d84fdf743e"), FacultyId = new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), Name = "Mechatronika" },
                        new { Id = new Guid("b87294db-52c7-4f5f-a21e-a0a3d5dea5b2"), FacultyId = new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), Name = "Zarządzanie i Inżynieria Produkcji" },
                        new { Id = new Guid("67813ac4-8e5e-43b3-98b6-47f0d2d8b208"), FacultyId = new Guid("c44fa4ca-c966-4fff-a710-d77992b02750"), Name = "Elektronika i Telekomunikacja" },
                        new { Id = new Guid("7047e1c4-a099-49dd-adc6-b2fce4f7b1ca"), FacultyId = new Guid("c44fa4ca-c966-4fff-a710-d77992b02750"), Name = "Teleinformatyka" },
                        new { Id = new Guid("fb87a183-09bb-4e6b-8177-44d2fc68dc4d"), FacultyId = new Guid("72c46ad9-15c6-4a2f-8799-3dc72e5347f6"), Name = "Automatyka i Robotyka" },
                        new { Id = new Guid("4d163beb-2f56-46c2-90bf-45b382959c47"), FacultyId = new Guid("72c46ad9-15c6-4a2f-8799-3dc72e5347f6"), Name = "Elektrotechnika" },
                        new { Id = new Guid("06137145-922f-4572-aa3f-25bfb696cc56"), FacultyId = new Guid("72c46ad9-15c6-4a2f-8799-3dc72e5347f6"), Name = "Energetyka" },
                        new { Id = new Guid("aea9e41b-c496-4ca6-8f5c-7e09bb54b61f"), FacultyId = new Guid("72c46ad9-15c6-4a2f-8799-3dc72e5347f6"), Name = "Matematyka w Technice" },
                        new { Id = new Guid("37ed66c7-d11a-4473-a391-e003e7ea90e2"), FacultyId = new Guid("38b58743-dfd7-4be6-894c-5c36d8b9a908"), Name = "Edukacja Techniczno-Informatyczna" },
                        new { Id = new Guid("c33e1523-aace-4bcf-9525-bc65b9474090"), FacultyId = new Guid("38b58743-dfd7-4be6-894c-5c36d8b9a908"), Name = "Fizyka Techniczna" },
                        new { Id = new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), FacultyId = new Guid("d2f3e024-5219-4b50-8e43-cb3948359671"), Name = "Informatyka" },
                        new { Id = new Guid("f497d9c9-fec1-4f2a-8240-2ef8042efc02"), FacultyId = new Guid("d2f3e024-5219-4b50-8e43-cb3948359671"), Name = "Bioinformatyka" },
                        new { Id = new Guid("e2b02379-dab7-4047-b7d6-8576c60aeba5"), FacultyId = new Guid("d2f3e024-5219-4b50-8e43-cb3948359671"), Name = "Sztuczna Inteligencja / Artificial Intelligence" },
                        new { Id = new Guid("97e989e6-b869-4736-ac81-ed6b78298b87"), FacultyId = new Guid("4edcfa46-1689-46d2-9142-7cb2b00d96c2"), Name = "Konstrukcja i Eksploatacja Środków Transportu" },
                        new { Id = new Guid("2991a7bd-1f64-4643-89c5-8e4743527752"), FacultyId = new Guid("4edcfa46-1689-46d2-9142-7cb2b00d96c2"), Name = "Transport" },
                        new { Id = new Guid("69a63029-326f-4759-8181-47cfd1826696"), FacultyId = new Guid("4edcfa46-1689-46d2-9142-7cb2b00d96c2"), Name = "Lotnictwo i Kosmonautyka" },
                        new { Id = new Guid("fbd863c8-fe4a-477b-b241-f216305b7487"), FacultyId = new Guid("77448c20-20d1-484f-b773-9a2addab9841"), Name = "Logistyka" },
                        new { Id = new Guid("543a844d-00a6-4b91-bc91-fc91b071a804"), FacultyId = new Guid("77448c20-20d1-484f-b773-9a2addab9841"), Name = "Inżynieria Zarządzania" },
                        new { Id = new Guid("3671dd26-139e-4c98-b4cd-1a73a7cdd66c"), FacultyId = new Guid("77448c20-20d1-484f-b773-9a2addab9841"), Name = "Inżynieria Bezpieczeństwa" },
                        new { Id = new Guid("9ee27f18-1893-468b-b7a7-641d8e060e6e"), FacultyId = new Guid("e7d3b852-1caa-47cc-969a-5eeddd21e48c"), Name = "Inżynieria Chemiczna i Procesowa" },
                        new { Id = new Guid("c8d3ff57-500a-4784-8843-14a86201f09e"), FacultyId = new Guid("e7d3b852-1caa-47cc-969a-5eeddd21e48c"), Name = "Technologia Chemiczna / Chemical Technology" },
                        new { Id = new Guid("3fb3628e-6bfa-408b-ac75-741f3cb2a6e1"), FacultyId = new Guid("e7d3b852-1caa-47cc-969a-5eeddd21e48c"), Name = "Technologie Ochrony Środowiska" },
                        new { Id = new Guid("79fbb178-60f2-4e23-8e7f-8e75ebe2e326"), FacultyId = new Guid("e7d3b852-1caa-47cc-969a-5eeddd21e48c"), Name = "Inżynieria Farmaceutyczna" }
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
                        new { Id = new Guid("da480316-43e7-4d27-a530-5d31d489e818"), Name = "Wydział Architektury" },
                        new { Id = new Guid("9c087bbe-068f-48c1-bde3-99171ada674c"), Name = "Wydział Budownictwa i Inżynierii Środowiska" },
                        new { Id = new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), Name = "Wydział Budowy Maszyn i Zarządzania" },
                        new { Id = new Guid("c44fa4ca-c966-4fff-a710-d77992b02750"), Name = "Wydział Elektroniki i Telekomunikacji" },
                        new { Id = new Guid("72c46ad9-15c6-4a2f-8799-3dc72e5347f6"), Name = "Wydział Elektryczny" },
                        new { Id = new Guid("38b58743-dfd7-4be6-894c-5c36d8b9a908"), Name = "Wydział Fizyki Technicznej" },
                        new { Id = new Guid("d2f3e024-5219-4b50-8e43-cb3948359671"), Name = "Wydział Informatyki" },
                        new { Id = new Guid("4edcfa46-1689-46d2-9142-7cb2b00d96c2"), Name = "Wydział Inżynierii Transportu" },
                        new { Id = new Guid("77448c20-20d1-484f-b773-9a2addab9841"), Name = "Wydział Inżynierii Zarządzania" },
                        new { Id = new Guid("e7d3b852-1caa-47cc-969a-5eeddd21e48c"), Name = "Wydział Technologii Chemicznej" }
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
                        new { Id = new Guid("aa07acea-8110-40f3-9bdb-6369749106b7"), ConcurrencyStamp = "10cb18b4-bb03-49d4-888c-61100303c87b", Name = "dean", NormalizedName = "dean" },
                        new { Id = new Guid("c01c613c-5ab1-40af-9667-b0e1d72f481d"), ConcurrencyStamp = "a8d5be8e-a812-4e25-afe8-2460804fd06a", Name = "student", NormalizedName = "student" },
                        new { Id = new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), ConcurrencyStamp = "4a0c232d-b918-4c90-bf37-bf62be8ee801", Name = "promoter", NormalizedName = "promoter" }
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
                        new { Id = new Guid("116f4ddf-99b7-41a0-8fc1-74273f2ee8e8"), RoleId = new Guid("aa07acea-8110-40f3-9bdb-6369749106b7"), UserId = new Guid("fcea29c3-1542-4dc6-9c4a-4fbcaadac34d") },
                        new { Id = new Guid("7bca3eec-4186-497b-8815-7d94ad8717e0"), RoleId = new Guid("aa07acea-8110-40f3-9bdb-6369749106b7"), UserId = new Guid("d6f83679-4245-4bf3-bfe2-b8b76b5d37e0") },
                        new { Id = new Guid("a45d1067-fde3-475e-ab5b-f3ea2b1de71d"), RoleId = new Guid("aa07acea-8110-40f3-9bdb-6369749106b7"), UserId = new Guid("85a79eea-33b1-4de7-840f-6e7011c49729") },
                        new { Id = new Guid("fe3f5061-faeb-49cd-b476-ffe492e05a57"), RoleId = new Guid("aa07acea-8110-40f3-9bdb-6369749106b7"), UserId = new Guid("c5e63a6a-a7f0-425d-beee-c073471fd77a") },
                        new { Id = new Guid("bb328a1d-0215-480b-b8a6-916def4efc77"), RoleId = new Guid("c01c613c-5ab1-40af-9667-b0e1d72f481d"), UserId = new Guid("332a1c73-0058-4594-993d-b843dba83942") },
                        new { Id = new Guid("3af850ac-c162-4641-a2d1-fedc11ae7a26"), RoleId = new Guid("c01c613c-5ab1-40af-9667-b0e1d72f481d"), UserId = new Guid("d17181da-7939-48dd-9849-5ba5d9d2b2aa") },
                        new { Id = new Guid("11f11671-4a81-40da-b4f6-5509908b5845"), RoleId = new Guid("c01c613c-5ab1-40af-9667-b0e1d72f481d"), UserId = new Guid("f0cd5bd8-9ea2-481d-94c1-f6cad5304c86") },
                        new { Id = new Guid("4cbe6280-6c4d-4a36-826a-9ec613ee1fe4"), RoleId = new Guid("c01c613c-5ab1-40af-9667-b0e1d72f481d"), UserId = new Guid("d467e8c7-93cf-4fd4-a935-61be37b22b96") },
                        new { Id = new Guid("1aaf7a09-2056-4706-b7de-87a15dfc9b9e"), RoleId = new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), UserId = new Guid("e985da90-a106-492e-8f4e-0f34a589244e") },
                        new { Id = new Guid("69561be5-7b89-4d78-8cfa-00c5e6e9aa17"), RoleId = new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), UserId = new Guid("dea5d287-75c5-4bd0-88bd-f46ace0298ee") },
                        new { Id = new Guid("bfe6020b-184d-449c-a831-304b0d11d513"), RoleId = new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), UserId = new Guid("5e0135f5-a37f-4dc0-bd9b-0314df51cf5d") },
                        new { Id = new Guid("8466ef23-f581-44e2-90cf-7786b16108e7"), RoleId = new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), UserId = new Guid("6e765418-13c0-4cd6-850d-eff7b0da6726") },
                        new { Id = new Guid("775893e2-58dc-45a8-ba2c-d8fdee730173"), RoleId = new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), UserId = new Guid("1f364e39-216c-4b30-b036-7904ce5052f7") },
                        new { Id = new Guid("64e207b9-9882-4872-ae42-fbf31352ce75"), RoleId = new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), UserId = new Guid("0625cc0d-57e7-4082-889b-e06e5e738bdb") },
                        new { Id = new Guid("e2427d7c-f327-4b81-bb3a-469d90dd5aee"), RoleId = new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), UserId = new Guid("0f74716e-0d32-427a-b0b2-38f4edb0f215") }
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
                        new { Id = new Guid("fcea29c3-1542-4dc6-9c4a-4fbcaadac34d"), AccessFailedCount = 0, ConcurrencyStamp = "29f1dbc6-c342-4171-8a9f-03182cd89b08", Email = "dean1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN1@GMAIL.COM", NormalizedUserName = "DEAN1@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEC1h7NN4p2uX9RmLD59arO/jO1H1i5yqw1l1U2MHk3Z7qbXcbG3B0A/e8FhdVUVQ3Q==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean1@gmail.com" },
                        new { Id = new Guid("d6f83679-4245-4bf3-bfe2-b8b76b5d37e0"), AccessFailedCount = 0, ConcurrencyStamp = "8f2932b7-6f43-47fc-9d9a-bf4c548d5690", Email = "dean2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN2@GMAIL.COM", NormalizedUserName = "DEAN2@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEBsSzrFiExCtghb/8h5lVO011f2lMqX/aKoU57qaisCk/+xwKvseJ1SPZQcMVWIkjQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean2@gmail.com" },
                        new { Id = new Guid("85a79eea-33b1-4de7-840f-6e7011c49729"), AccessFailedCount = 0, ConcurrencyStamp = "0236176e-14d8-4613-bcbd-5825c5c35bf6", Email = "dean3@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN3@GMAIL.COM", NormalizedUserName = "DEAN3@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEBpesy303SD8YK7aMWNn1oKM0j4x0eh6aqruqEsFknatIouepnduKVMuWs5Ku7Qm0Q==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean3@gmail.com" },
                        new { Id = new Guid("c5e63a6a-a7f0-425d-beee-c073471fd77a"), AccessFailedCount = 0, ConcurrencyStamp = "fe365e3e-dd28-4d18-810a-7cece7a28349", Email = "dean4@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "DEAN4@GMAIL.COM", NormalizedUserName = "DEAN4@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEAbLlwiDVTs8ZsmzMSlzDgLpyv71usHGAcqZ43EESs57H1mwPrTKJK82kYdBfIS65Q==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean4@gmail.com" },
                        new { Id = new Guid("332a1c73-0058-4594-993d-b843dba83942"), AccessFailedCount = 0, ConcurrencyStamp = "220b71cd-e95b-4e28-9ce5-e230c78dfdf8", Email = "student1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT1@GMAIL.COM", NormalizedUserName = "STUDENT1@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEEoUHJqVobfXvYU7vj/Pe5ewJhlXPELmD3lgJLXF91ITPjAjwI56g3W2vLXPSirTPQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student1@gmail.com" },
                        new { Id = new Guid("d17181da-7939-48dd-9849-5ba5d9d2b2aa"), AccessFailedCount = 0, ConcurrencyStamp = "0a66526d-c7c9-4b94-bfe5-9bd1f7d39974", Email = "student2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT2@GMAIL.COM", NormalizedUserName = "STUDENT2@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEB+/+5lRUtnLFNBX/454A+zZEES4OGI1N0XFcmV7jjN7tsM2y31QjEM6DuwtWml8kg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student2@gmail.com" },
                        new { Id = new Guid("f0cd5bd8-9ea2-481d-94c1-f6cad5304c86"), AccessFailedCount = 0, ConcurrencyStamp = "c248dfbd-cd25-45a6-b70e-5926da285cdc", Email = "student3@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT3@GMAIL.COM", NormalizedUserName = "STUDENT3@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAED1f12lLid9rAHmTHTHseJVlfCS4xzvcIP0KKPOmDYEneQN0CPohwd5bemCE5XYVwQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student3@gmail.com" },
                        new { Id = new Guid("d467e8c7-93cf-4fd4-a935-61be37b22b96"), AccessFailedCount = 0, ConcurrencyStamp = "6a0b88db-d0ef-4154-a88c-0d6c758c6e20", Email = "student4@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "STUDENT4@GMAIL.COM", NormalizedUserName = "STUDENT4@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEImQ2eXbdU2OQaQ55bXEWyY6FN2Yf/02fbTZ1vmzcEHzW9sEYuk+JruVMY82dMy35g==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student4@gmail.com" },
                        new { Id = new Guid("e985da90-a106-492e-8f4e-0f34a589244e"), AccessFailedCount = 0, ConcurrencyStamp = "035aa1be-55ad-4ebb-b32d-a262a732eca6", Email = "irmina.maslowska@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "IRMINA.MASLOWSKA@PUT.POZNAN.PL", NormalizedUserName = "IRMINA.MASLOWSKA@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEJUl9915Jg3dxGtfbWEbj22wJopCikC1W83DMpIs6D0WuD7KMJPpyQG7KMBhBXh0LA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "irmina.maslowska@put.poznan.pl" },
                        new { Id = new Guid("dea5d287-75c5-4bd0-88bd-f46ace0298ee"), AccessFailedCount = 0, ConcurrencyStamp = "41432f01-a34a-4c63-a32b-ecfcfa7169e5", Email = "bartlomiej.predki@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", NormalizedUserName = "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEKTfAsFSr2GcP+BqmGROFj/kuEhUKcYoDkooILWfi8JdzN2ZLC8FUr8hErlWaiQVqQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "bartlomiej.predki@put.poznan.pl" },
                        new { Id = new Guid("5e0135f5-a37f-4dc0-bd9b-0314df51cf5d"), AccessFailedCount = 0, ConcurrencyStamp = "6fe3e990-7c3f-460c-9e2b-f54ad77290d2", Email = "milosz.kadzinski@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "MILOSZ.KADZINSKI@PUT.POZNAN.PL", NormalizedUserName = "MILOSZ.KADZINSKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAELpLO2G3FvPfyRag8gWP02D04ZK/ZaGIKzMnUFRPIinjqzfLFSUISmBL3IMHBrFZLA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "milosz.kadzinski@put.poznan.pl" },
                        new { Id = new Guid("6e765418-13c0-4cd6-850d-eff7b0da6726"), AccessFailedCount = 0, ConcurrencyStamp = "7999d96a-54ca-4ea6-a848-bc9dbad2d00a", Email = "wojciech.kotlowski@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", NormalizedUserName = "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAED7d4JJX4vlslZqwopcewTURA6TjeU2deYJOrsuqGc/S+CmxeNh/B5AizaZfV/wU/A==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "wojciech.kotlowski@put.poznan.pl" },
                        new { Id = new Guid("1f364e39-216c-4b30-b036-7904ce5052f7"), AccessFailedCount = 0, ConcurrencyStamp = "60f3c5c0-f90c-437a-8536-8a0daed3b599", Email = "jerzy.nawrocki@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "JERZY.NAWROCKI@PUT.POZNAN.PL", NormalizedUserName = "JERZY.NAWROCKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEMsXzAdqL/9bXYzv7WUSSin3P87jiA/ko7U5E0DYYPpeAySvz43IB/aW4VjganXm3g==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "jerzy.nawrocki@put.poznan.pl" },
                        new { Id = new Guid("0625cc0d-57e7-4082-889b-e06e5e738bdb"), AccessFailedCount = 0, ConcurrencyStamp = "3d927959-a2e6-43fa-8b31-07efd3016efb", Email = "katarzyna.adamska@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", NormalizedUserName = "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEAWFoBRXX25onfP/XxH6OSNaPAq+NXdDvNDzRnaoKlqaxo7lg8OTnteoOR3K6Spc5A==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "katarzyna.adamska@put.poznan.pl" },
                        new { Id = new Guid("0f74716e-0d32-427a-b0b2-38f4edb0f215"), AccessFailedCount = 0, ConcurrencyStamp = "dbcd18ec-b0e4-4e9a-a551-c87bf580b203", Email = "krzysztof.alejski@put.poznan.pl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", NormalizedUserName = "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", PasswordHash = "AQAAAAEAACcQAAAAEKVWTBkj2UNtJS15ndNxko4L7Ev+aUvDpPtUwN4mnHQ9PmAYUIHM/YrP6S96h1LodA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "krzysztof.alejski@put.poznan.pl" }
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
                        new { Id = new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), Name = "Instytut Informatyki" },
                        new { Id = new Guid("d8712502-5c83-4299-affa-8c217a4c99fa"), Name = "Instytut Technologii Mechanicznej" },
                        new { Id = new Guid("399e6399-8b71-4a86-99b4-3c1b8867302d"), Name = "Instytut Matematyki" },
                        new { Id = new Guid("7eed4644-f5b0-4330-a757-88a113b6ee2e"), Name = "Instytut Technologii Materiałów" },
                        new { Id = new Guid("91a86ddd-86b6-4bcc-82e3-8aaa2f1f741c"), Name = "Instytut Inżynierii Lądowej" },
                        new { Id = new Guid("1e562620-9280-42be-843e-8d594cece35b"), Name = "Instytut Inżynierii Środowiska" },
                        new { Id = new Guid("dc876d77-a425-415d-a97b-6f12962164d4"), Name = "Instytut Chemii i Elektrochemii Technicznej" },
                        new { Id = new Guid("f0360e1f-0977-4476-8fe9-4cd288afc349"), Name = "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                        new { Id = new Guid("ef34dd01-00ce-4085-b278-4ab8801a129e"), Name = "Instytut Mechaniki Stosowanej" },
                        new { Id = new Guid("a9760a07-dfac-403e-ac9f-f6386f1fd6bd"), Name = "Instytut Technologii i Inżynierii Chemicznej" },
                        new { Id = new Guid("83aaaae9-e0c5-4ba1-a3a1-d6b47449a789"), Name = "Instytut Architektury i Planowania Przestrzennego" }
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
                        new { Id = new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Irmina", InstituteId = new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), LastName = "Masłowska", TitlePostfix = "", TitlePrefix = "dr inż.", UserId = new Guid("e985da90-a106-492e-8f4e-0f34a589244e") },
                        new { Id = new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Bartłomiej", InstituteId = new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), LastName = "Prędki", TitlePostfix = "", TitlePrefix = "dr inż.", UserId = new Guid("dea5d287-75c5-4bd0-88bd-f46ace0298ee") },
                        new { Id = new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Miłosz", InstituteId = new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), LastName = "Kadziński", TitlePostfix = "", TitlePrefix = "dr hab. inż.", UserId = new Guid("5e0135f5-a37f-4dc0-bd9b-0314df51cf5d") },
                        new { Id = new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Wojciech", InstituteId = new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), LastName = "Kotłowski", TitlePostfix = "", TitlePrefix = "dr hab. inż.", UserId = new Guid("6e765418-13c0-4cd6-850d-eff7b0da6726") },
                        new { Id = new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), ExpectedNumberOfBachelorProposals = 2, ExpectedNumberOfMasterProposals = 1, FirstName = "Jerzy", InstituteId = new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), LastName = "Nawrocki", TitlePostfix = "prof. PP", TitlePrefix = "dr hab inż.", UserId = new Guid("1f364e39-216c-4b30-b036-7904ce5052f7") },
                        new { Id = new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), ExpectedNumberOfBachelorProposals = 1, ExpectedNumberOfMasterProposals = 1, FirstName = "Katarzyna", InstituteId = new Guid("a9760a07-dfac-403e-ac9f-f6386f1fd6bd"), LastName = "Adamska", TitlePostfix = "", TitlePrefix = "dr inż.", UserId = new Guid("0625cc0d-57e7-4082-889b-e06e5e738bdb") },
                        new { Id = new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), ExpectedNumberOfBachelorProposals = 3, ExpectedNumberOfMasterProposals = 2, FirstName = "Krzysztof", InstituteId = new Guid("a9760a07-dfac-403e-ac9f-f6386f1fd6bd"), LastName = "Alejski", TitlePostfix = "prof. PP", TitlePrefix = "dr hab. inż.", UserId = new Guid("0f74716e-0d32-427a-b0b2-38f4edb0f215") }
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
                        new { Id = new Guid("fe0a8286-fabb-46c0-9c53-f7e809a988e7"), CourseId = new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), Description = "Opis.....", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Capri 2 - system for managing diploma topic cards", TopicPolish = "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                        new { Id = new Guid("8192d4f8-6f50-4b65-9d7c-c07a7b53b85d"), CourseId = new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), Description = "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Implementation of chosen methods from Electre family", TopicPolish = "Implementacja wybranych metod z rodziny Electre" },
                        new { Id = new Guid("2c4d6857-454d-4624-a3ee-1a1f3fc67c21"), CourseId = new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), Description = "Opis.....", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Implementation of decision support methods based on utility function (UTA, Assess)", TopicPolish = "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                        new { Id = new Guid("7f3e5653-1f78-4d89-8971-706b3e3d1bba"), CourseId = new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), Description = "Opis.....", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Extension of diviz platform", TopicPolish = "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                        new { Id = new Guid("198275cd-f26a-48c0-8bf5-f8d8d106a4d3"), CourseId = new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), Description = "Opis.....", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "Style transfering using a neural network", TopicPolish = "Transfer stylu przy użyciu sieci neuronowej" },
                        new { Id = new Guid("6ea28e5f-a3c8-4105-9a38-de9206559bbb"), CourseId = new Guid("9ee27f18-1893-468b-b7a7-641d8e060e6e"), Description = "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", Level = 0, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "No title", TopicPolish = "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                        new { Id = new Guid("382ab1e5-351b-40f2-8b0d-d3133da33107"), CourseId = new Guid("9ee27f18-1893-468b-b7a7-641d8e060e6e"), Description = "Brak opisu", Level = 1, MaxNumberOfStudents = 4, Mode = 0, OutputData = "Brak danych", PromoterId = new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), Specialization = "-", StartingDate = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, StudyProfile = 0, TopicEnglish = "No title", TopicPolish = "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
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
                        new { Id = new Guid("1242c0ce-39ae-41b9-9325-b85471c8125d"), UserId = new Guid("332a1c73-0058-4594-993d-b843dba83942") },
                        new { Id = new Guid("4af33581-fcd9-4ea2-addd-63c4f0c926ce"), UserId = new Guid("d17181da-7939-48dd-9849-5ba5d9d2b2aa") },
                        new { Id = new Guid("21f129ff-a7be-47b0-8022-d0dcabfaf6c1"), UserId = new Guid("f0cd5bd8-9ea2-481d-94c1-f6cad5304c86") },
                        new { Id = new Guid("98854562-f305-4409-884d-4e548f83c0a1"), UserId = new Guid("d467e8c7-93cf-4fd4-a935-61be37b22b96") }
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
