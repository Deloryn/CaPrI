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
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        new { Id = new Guid("3320f3b2-d22e-4d18-bdc1-8bf8411be231"), ConcurrencyStamp = "75f0eb09-31c3-41ed-915b-24b33453ca17", Name = "admin", NormalizedName = "admin" },
                        new { Id = new Guid("2af475c9-03ce-4a1c-bd55-86bf18ece3f6"), ConcurrencyStamp = "fb7cf5d3-5060-46da-8e25-186543972c9a", Name = "dean", NormalizedName = "dean" },
                        new { Id = new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), ConcurrencyStamp = "7f227860-a7e0-4929-951b-6a9b1ee04c03", Name = "student", NormalizedName = "student" },
                        new { Id = new Guid("03fd825e-aa55-4d3d-8583-fbce5b83ac18"), ConcurrencyStamp = "aa049462-d709-40a4-9704-279e3ca89f0e", Name = "promoter", NormalizedName = "promoter" }
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
                        new { Id = new Guid("edea3f4d-b79b-4d83-a172-c94c25550e9e"), RoleId = new Guid("3320f3b2-d22e-4d18-bdc1-8bf8411be231"), UserId = new Guid("62a89d6a-6575-4788-8066-a016ffbe0a27") },
                        new { Id = new Guid("d3d374fa-6362-4ec3-a3c8-0ed971181846"), RoleId = new Guid("2af475c9-03ce-4a1c-bd55-86bf18ece3f6"), UserId = new Guid("07f15bd8-ddf3-47ed-b0c8-d852bb26ec26") },
                        new { Id = new Guid("b4a952d2-3532-4346-af37-67e383293519"), RoleId = new Guid("2af475c9-03ce-4a1c-bd55-86bf18ece3f6"), UserId = new Guid("ec46f545-78f6-468f-b2b7-a178ecc58f52") },
                        new { Id = new Guid("7990a2ba-20a8-49a2-84e0-897972b57d01"), RoleId = new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), UserId = new Guid("682012ab-eb2b-4859-9dee-9f96c2d6cfe8") },
                        new { Id = new Guid("e3817af2-a9a9-4e97-9424-c2e1574af0d6"), RoleId = new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), UserId = new Guid("55484603-706d-4b4e-986c-5b328442e235") },
                        new { Id = new Guid("f8c0ec88-24fa-428d-8c0d-55962f2c9bc3"), RoleId = new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), UserId = new Guid("af40789e-e3ec-4567-96f1-4926f084d8d3") },
                        new { Id = new Guid("3e2b9c2c-1522-43d7-a435-b2cfb6927f57"), RoleId = new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), UserId = new Guid("08fcb9cf-f01c-4f86-a771-1656ee2111db") },
                        new { Id = new Guid("97d00e38-fcb5-4c48-8caa-a40d8ab58a50"), RoleId = new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), UserId = new Guid("8c06eedc-20df-4a7b-a2bb-0f9f07d5cf6a") },
                        new { Id = new Guid("0d58c1b1-7541-4fcc-b411-350e1e562bb2"), RoleId = new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), UserId = new Guid("365bd06d-a898-4355-9434-771f1e6ac147") },
                        new { Id = new Guid("c2239e7a-ef13-4943-9868-da5480728bff"), RoleId = new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), UserId = new Guid("65a4a37d-c825-4c3a-8dac-0c7be338dd69") },
                        new { Id = new Guid("66b20c88-a0a9-45a1-8305-967c80a4e909"), RoleId = new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), UserId = new Guid("25b33791-0989-4356-a3c0-62c065de2d6b") },
                        new { Id = new Guid("f27e76b5-e568-434d-8378-8a73d86a2c57"), RoleId = new Guid("03fd825e-aa55-4d3d-8583-fbce5b83ac18"), UserId = new Guid("f7be09ae-a9d6-4084-8496-fbdc48de617b") },
                        new { Id = new Guid("840960e9-460a-4b4b-9575-8ec35c54fe5d"), RoleId = new Guid("03fd825e-aa55-4d3d-8583-fbce5b83ac18"), UserId = new Guid("ec82c37d-6314-4e3d-ac14-30bea0158549") }
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

                    b.ToTable("User");

                    b.HasData(
                        new { Id = new Guid("62a89d6a-6575-4788-8066-a016ffbe0a27"), AccessFailedCount = 0, ConcurrencyStamp = "e0ce0ffd-a882-4f7e-b440-dbb635951f40", Email = "admin1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "admin1@gmail.com", NormalizedUserName = "admin1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEEUG7jfWDUkAkxhAXhgTbgbg3RwLblENjYwI7INxlMvU6Onh29C06pfoi2k/PjEB5g==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "admin1@gmail.com" },
                        new { Id = new Guid("07f15bd8-ddf3-47ed-b0c8-d852bb26ec26"), AccessFailedCount = 0, ConcurrencyStamp = "f9ef3a94-fa42-4d69-ad27-c0dd83e2a991", Email = "dean1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "dean1@gmail.com", NormalizedUserName = "dean1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEIzdDOSzv9UC676nVwzzdAy2zAYqsfM30Yd+SrPOLRbicWA9IH+sefli7TBvs/FHhg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean1@gmail.com" },
                        new { Id = new Guid("ec46f545-78f6-468f-b2b7-a178ecc58f52"), AccessFailedCount = 0, ConcurrencyStamp = "5819d2c5-9d55-4c27-80ef-8db2e20824c3", Email = "dean2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "dean2@gmail.com", NormalizedUserName = "dean2@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEHpjUW/QyhOZ/XTIgTMEbYm5BPyKDSNtB/ntd33hb/iEDO6ZF7ONEfCWuemPJTJkCw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean2@gmail.com" },
                        new { Id = new Guid("682012ab-eb2b-4859-9dee-9f96c2d6cfe8"), AccessFailedCount = 0, ConcurrencyStamp = "0103d511-0ca4-47fd-ac36-df505da9df94", Email = "student1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student1@gmail.com", NormalizedUserName = "student1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEO5a3b9XP89PhfSkRlzkT+rkoKUfD+S+ryBdTiIidyECAckp2Qty5tNesYirbRo/og==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student1@gmail.com" },
                        new { Id = new Guid("55484603-706d-4b4e-986c-5b328442e235"), AccessFailedCount = 0, ConcurrencyStamp = "f9f6cd2f-acc0-4589-9393-f4ab46dbf965", Email = "student2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student2@gmail.com", NormalizedUserName = "student2@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEGMj0aSuCcqIzl+HixTKPv0VBBOE6crSfAq+U9/+yOHuL2eGoVxlXotINY3eLoesJA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student2@gmail.com" },
                        new { Id = new Guid("af40789e-e3ec-4567-96f1-4926f084d8d3"), AccessFailedCount = 0, ConcurrencyStamp = "d94f4a95-8861-4507-be50-274e959ba548", Email = "student3@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student3@gmail.com", NormalizedUserName = "student3@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEFIxRWG6c2mEYk0brexKie2ConpbLUvbWBEixjom90gasw99MLeJOxE0iwx9/JUVsQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student3@gmail.com" },
                        new { Id = new Guid("08fcb9cf-f01c-4f86-a771-1656ee2111db"), AccessFailedCount = 0, ConcurrencyStamp = "bc552325-20e5-4eb3-9540-d2d43d2d91c0", Email = "student4@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student4@gmail.com", NormalizedUserName = "student4@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEASzaHmiIQfsh+fExi8NFH14FDW+fZNOGPiB2CZ0CnVdztJptj2kREKIOJTfxLQK+Q==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student4@gmail.com" },
                        new { Id = new Guid("8c06eedc-20df-4a7b-a2bb-0f9f07d5cf6a"), AccessFailedCount = 0, ConcurrencyStamp = "ae248118-f20a-4ff3-b6f8-a4b16eee0fba", Email = "student5@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student5@gmail.com", NormalizedUserName = "student5@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEP7amYjrr56jH9IParZzXf/qEgax7F9GkyGIX+5B1OR7wsW0PKCem32aMdJz/2l3Eg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student5@gmail.com" },
                        new { Id = new Guid("365bd06d-a898-4355-9434-771f1e6ac147"), AccessFailedCount = 0, ConcurrencyStamp = "f27afaa5-0840-473d-b0b8-ece9a6c0adfd", Email = "student6@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student6@gmail.com", NormalizedUserName = "student6@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEMk9dNvmdBzqg4L3ZB+FTlGl01aV5pzFiWCPzWwvcc7GCbqddR5ycfBTG6NNaN640g==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student6@gmail.com" },
                        new { Id = new Guid("65a4a37d-c825-4c3a-8dac-0c7be338dd69"), AccessFailedCount = 0, ConcurrencyStamp = "edf6b308-784b-4e3b-a9bd-9e10eaf17134", Email = "student7@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student7@gmail.com", NormalizedUserName = "student7@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEAQb/8sz9Vs8Sov6RohY9Dqg4YIi83DuhnOd1Sh5s3At/3PZT8pHj8CF8gmM9Zze6w==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student7@gmail.com" },
                        new { Id = new Guid("25b33791-0989-4356-a3c0-62c065de2d6b"), AccessFailedCount = 0, ConcurrencyStamp = "5a3b7b73-8ec6-4a84-8fce-6759abd17bc3", Email = "student8@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student8@gmail.com", NormalizedUserName = "student8@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEJ92KLnIEwT8JYDYf1XQVFH6//fwSk57h1toKzh28Y9p7CIeapBf24D/O4wM0Qvk2w==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student8@gmail.com" },
                        new { Id = new Guid("f7be09ae-a9d6-4084-8496-fbdc48de617b"), AccessFailedCount = 0, ConcurrencyStamp = "525df277-69de-4be6-bab7-8065e8099128", Email = "promoter1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "promoter1@gmail.com", NormalizedUserName = "promoter1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEPVTnlBBwymSzVb+vFrWNWW+ayRE/bH+QYZNPF/KIfQAs7F2930qOXIZkgb3sWAjeA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "promoter1@gmail.com" },
                        new { Id = new Guid("ec82c37d-6314-4e3d-ac14-30bea0158549"), AccessFailedCount = 0, ConcurrencyStamp = "3c8f14b7-7b2c-420b-ae6d-1befb2fbdf49", Email = "promoter2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "promoter2@gmail.com", NormalizedUserName = "promoter2@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAELhF7UIUhZdVWbc6mCSM/CjX4FYnB3kq3Ej+DnAJKP0ZaNHrhfzokK1BzzLrqV2CeA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "promoter2@gmail.com" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Promoter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanSubmitBachelorProposals");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Promoters");

                    b.HasData(
                        new { Id = new Guid("d91d2f52-29b9-4d27-85d5-83479ff89aa7"), CanSubmitBachelorProposals = true, UserId = new Guid("f7be09ae-a9d6-4084-8496-fbdc48de617b") },
                        new { Id = new Guid("0d526f29-f6e7-4131-901c-01197567e0c6"), CanSubmitBachelorProposals = true, UserId = new Guid("ec82c37d-6314-4e3d-ac14-30bea0158549") }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Proposal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<Guid?>("PromoterId");

                    b.Property<int>("Status");

                    b.Property<string>("Topic")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("PromoterId");

                    b.ToTable("Proposals");
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
                        new { Id = new Guid("32b1b7df-b45e-427d-bd76-94da0b73b37a"), UserId = new Guid("682012ab-eb2b-4859-9dee-9f96c2d6cfe8") },
                        new { Id = new Guid("22243950-f281-4cca-959e-13ddc00477f4"), UserId = new Guid("55484603-706d-4b4e-986c-5b328442e235") },
                        new { Id = new Guid("5510515f-ec45-4e8a-b28c-c357942c3686"), UserId = new Guid("af40789e-e3ec-4567-96f1-4926f084d8d3") },
                        new { Id = new Guid("319c9c7b-9b9d-412e-b5d9-cefa0fad0153"), UserId = new Guid("08fcb9cf-f01c-4f86-a771-1656ee2111db") },
                        new { Id = new Guid("8721d0c1-4dd7-4863-bd59-6ababd1b9af1"), UserId = new Guid("8c06eedc-20df-4a7b-a2bb-0f9f07d5cf6a") },
                        new { Id = new Guid("eb3666f4-a133-4ed6-ae3d-c064923f414b"), UserId = new Guid("365bd06d-a898-4355-9434-771f1e6ac147") },
                        new { Id = new Guid("ed4470b0-d8ba-41b7-9cf2-836472fe83fd"), UserId = new Guid("65a4a37d-c825-4c3a-8dac-0c7be338dd69") },
                        new { Id = new Guid("9743e7fb-11af-4e36-b1f1-68d4092f66bd"), UserId = new Guid("25b33791-0989-4356-a3c0-62c065de2d6b") }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Promoter", b =>
                {
                    b.HasOne("Capri.Database.Entities.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Capri.Database.Entities.Proposal", b =>
                {
                    b.HasOne("Capri.Database.Entities.Promoter")
                        .WithMany("Proposals")
                        .HasForeignKey("PromoterId");
                });

            modelBuilder.Entity("Capri.Database.Entities.Student", b =>
                {
                    b.HasOne("Capri.Database.Entities.Proposal")
                        .WithMany("Students")
                        .HasForeignKey("ProposalId");

                    b.HasOne("Capri.Database.Entities.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
