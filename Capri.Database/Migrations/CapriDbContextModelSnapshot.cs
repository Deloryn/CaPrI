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
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
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
                        new { Id = new Guid("d27e8d35-4423-47f4-bc24-0a732641e438"), ConcurrencyStamp = "6effc538-245e-46ab-9782-8695a8d6f7de", Name = "admin", NormalizedName = "admin" },
                        new { Id = new Guid("42419760-47c3-4067-bf28-8572c09bd396"), ConcurrencyStamp = "3e19bea4-8fb0-4643-892c-37289eb15489", Name = "dean", NormalizedName = "dean" },
                        new { Id = new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), ConcurrencyStamp = "901407ed-f931-4fef-aa23-5c848ca16b24", Name = "student", NormalizedName = "student" },
                        new { Id = new Guid("f7cda159-c95a-441a-a013-a39545da25cf"), ConcurrencyStamp = "1e75401a-935a-40f8-8bf3-6037b03fe4b8", Name = "promoter", NormalizedName = "promoter" }
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
                        new { Id = new Guid("4416e55f-d838-44d7-8409-cdb2b5bba4ef"), RoleId = new Guid("d27e8d35-4423-47f4-bc24-0a732641e438"), UserId = new Guid("cc994903-703a-43b0-8524-0d5e0771d264") },
                        new { Id = new Guid("a56977ff-4914-48ff-9a4d-2899f5af034a"), RoleId = new Guid("42419760-47c3-4067-bf28-8572c09bd396"), UserId = new Guid("cb041449-6144-4a78-a425-b8bcdb816c74") },
                        new { Id = new Guid("0c33c043-0de7-4f35-ab92-233d91547de1"), RoleId = new Guid("42419760-47c3-4067-bf28-8572c09bd396"), UserId = new Guid("c1f09835-b040-440a-a7bf-af9fd8c2cec8") },
                        new { Id = new Guid("7d37d06e-af45-4a2d-aee0-93cffc149603"), RoleId = new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), UserId = new Guid("81c25a34-37bd-40ab-89ea-b21d2b92e899") },
                        new { Id = new Guid("10d9c6f2-151b-4cbf-a2a2-b8274f4bfa9e"), RoleId = new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), UserId = new Guid("9c2d6bdf-6bbf-400f-a8a0-acb3a34a4f2e") },
                        new { Id = new Guid("66acae93-76c0-4d3e-b22e-e4542c37f884"), RoleId = new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), UserId = new Guid("6abf766e-a637-41cf-93f3-a099cce68b30") },
                        new { Id = new Guid("b88a5077-5308-449f-a715-cfc40fa12dc6"), RoleId = new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), UserId = new Guid("9cc14694-f564-4f55-a15f-86e47f14922e") },
                        new { Id = new Guid("5072b464-08c9-4454-acee-48c9cf5c1a76"), RoleId = new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), UserId = new Guid("d7512dc4-2423-45d1-bd8d-e71a47bb12fd") },
                        new { Id = new Guid("7a74e2a8-6d7e-4f86-a943-0e8bcf3ca7d8"), RoleId = new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), UserId = new Guid("d77cb639-f8a0-46be-8724-72b0772158cf") },
                        new { Id = new Guid("88df3316-340c-4b9a-8043-9948d9bfab78"), RoleId = new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), UserId = new Guid("ad1a346e-b0d8-46b6-b76d-d96b63840993") },
                        new { Id = new Guid("bff047f6-d6e9-4b0f-8ae4-bf1287cdf2bd"), RoleId = new Guid("249d418b-d2b5-442f-879b-4885f31ec48e"), UserId = new Guid("9ddff194-d407-454b-918e-ce3fee675608") },
                        new { Id = new Guid("d5e4ac4a-781a-4681-8519-e3d0cd93b4be"), RoleId = new Guid("f7cda159-c95a-441a-a013-a39545da25cf"), UserId = new Guid("04bb5bb4-8ec8-4b42-b753-dddf057797c7") },
                        new { Id = new Guid("689cb556-a244-42c8-9df6-4f1cd813370a"), RoleId = new Guid("f7cda159-c95a-441a-a013-a39545da25cf"), UserId = new Guid("4e8351ab-6b59-4f13-8f28-7313d8af4585") }
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
                        new { Id = new Guid("cc994903-703a-43b0-8524-0d5e0771d264"), AccessFailedCount = 0, ConcurrencyStamp = "8125b0aa-8de0-44bc-b583-7337d9677bf2", Email = "admin1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "admin1@gmail.com", NormalizedUserName = "admin1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAECKvYpds5CdeDfw9auu70C1jhA/zRDvMnMQ90fIMAnOBfZHu78sKe1Q2cxdGPGm50w==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "admin1@gmail.com" },
                        new { Id = new Guid("cb041449-6144-4a78-a425-b8bcdb816c74"), AccessFailedCount = 0, ConcurrencyStamp = "8e0a5c75-3520-41d1-93eb-2ef21c67e5a3", Email = "dean1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "dean1@gmail.com", NormalizedUserName = "dean1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEJJL2dgRPxu22Vb5eGxJVGV5G/tBIUVZSMEWa1aUOad+TML1PxOLEKSLgK7coK+kKw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean1@gmail.com" },
                        new { Id = new Guid("c1f09835-b040-440a-a7bf-af9fd8c2cec8"), AccessFailedCount = 0, ConcurrencyStamp = "34cc3103-d68a-4a48-9c43-0c8bb09552c8", Email = "dean2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "dean2@gmail.com", NormalizedUserName = "dean2@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAELbntyE7M2fgJzVDuM7oPHMoiJ7cbIgw4iOhzu9qxHogsCDxaS8Aqp4IdPv50AZ0Nw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean2@gmail.com" },
                        new { Id = new Guid("81c25a34-37bd-40ab-89ea-b21d2b92e899"), AccessFailedCount = 0, ConcurrencyStamp = "b3a9205a-dcc2-40b1-b7ed-98876ac6b5a3", Email = "student1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student1@gmail.com", NormalizedUserName = "student1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEAcirm8jUUWUY3e5p8cLJMWjxdgCpBPrcMBUa94qcZ5TAeWr3O6NVhilPbzIeEd9cA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student1@gmail.com" },
                        new { Id = new Guid("9c2d6bdf-6bbf-400f-a8a0-acb3a34a4f2e"), AccessFailedCount = 0, ConcurrencyStamp = "727f5a7b-aba8-44ba-90de-3afda021c8ae", Email = "student2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student2@gmail.com", NormalizedUserName = "student2@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEKlUvlkYX8w5SYQ5esY6X/TWVDfV/oJx4y5t7RRKDvuNdNGZCPaq/WtR8ASHztVEXA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student2@gmail.com" },
                        new { Id = new Guid("6abf766e-a637-41cf-93f3-a099cce68b30"), AccessFailedCount = 0, ConcurrencyStamp = "0bc6df4a-7be3-4b85-a556-60fbbbf361d3", Email = "student3@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student3@gmail.com", NormalizedUserName = "student3@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEAbMbed3z+Qwa03WDYzLnuEllPhOBGqWogYvZzdtPVCAzu/tFjlp+RnUpXZ3xOgo1w==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student3@gmail.com" },
                        new { Id = new Guid("9cc14694-f564-4f55-a15f-86e47f14922e"), AccessFailedCount = 0, ConcurrencyStamp = "54202bcb-6d99-4163-ad1c-0cfbe3e79a6e", Email = "student4@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student4@gmail.com", NormalizedUserName = "student4@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAENe0fNAT70puryj0ue5UE20ioNQl/XA8HcLjkpy1VgsuEE65CKLBotjeCyV3G3wkdw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student4@gmail.com" },
                        new { Id = new Guid("d7512dc4-2423-45d1-bd8d-e71a47bb12fd"), AccessFailedCount = 0, ConcurrencyStamp = "a1dde13b-30a5-4640-8727-a421629ea0fe", Email = "student5@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student5@gmail.com", NormalizedUserName = "student5@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEF1azm1+Nmkxbt3HivQOGrdAn4QzGJfq9C/vJeGEwWDhF8+hYThpEfsXJvkrmOMfuQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student5@gmail.com" },
                        new { Id = new Guid("d77cb639-f8a0-46be-8724-72b0772158cf"), AccessFailedCount = 0, ConcurrencyStamp = "05ecbe17-d37e-4cb9-bdd5-dfe82b8c6304", Email = "student6@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student6@gmail.com", NormalizedUserName = "student6@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEPhbSd9nn35ZIH80VXMJtHZGtU+tQLedYGUDuMIK+hYgKwrOGjKhYh4MMh+Ntovz/A==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student6@gmail.com" },
                        new { Id = new Guid("ad1a346e-b0d8-46b6-b76d-d96b63840993"), AccessFailedCount = 0, ConcurrencyStamp = "21ffe6f7-302b-4289-af47-a77c3f65280a", Email = "student7@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student7@gmail.com", NormalizedUserName = "student7@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEEISrmpeNwOeVdHWHsHh+PjvV9DtMPrv8awwQhxKbGBDATcbQF9Np7jeoOowqrKvqg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student7@gmail.com" },
                        new { Id = new Guid("9ddff194-d407-454b-918e-ce3fee675608"), AccessFailedCount = 0, ConcurrencyStamp = "896eb097-30c1-4732-a344-01d037c9433c", Email = "student8@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student8@gmail.com", NormalizedUserName = "student8@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEBumkWfFP3TsXgbHV5GuOKETT2t1l2A3XEvEosJ5+TGw/sxAlxte+fHyNw/D7LjgAw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student8@gmail.com" },
                        new { Id = new Guid("04bb5bb4-8ec8-4b42-b753-dddf057797c7"), AccessFailedCount = 0, ConcurrencyStamp = "c12ec296-b13c-4940-9c62-03d19ddba8b6", Email = "promoter1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "promoter1@gmail.com", NormalizedUserName = "promoter1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEFIR2iqdmPJqOgSIPJOXmFmQjFZxnR1mUSgL2unqlJbo5OuLZlr+JvHOlJerPdePPA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "promoter1@gmail.com" },
                        new { Id = new Guid("4e8351ab-6b59-4f13-8f28-7313d8af4585"), AccessFailedCount = 0, ConcurrencyStamp = "da8d9e55-ef8c-48ee-ab2d-caaf503144b8", Email = "promoter2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "promoter2@gmail.com", NormalizedUserName = "promoter2@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEA6ixEs9n44U5fuQoWfq6lNXArndiMQCo4A1g8pGdQUtJ2l1RLyilqQxHBWxKvhEBg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "promoter2@gmail.com" }
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

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Promoters");

                    b.HasData(
                        new { Id = new Guid("2c764fdf-b14f-4553-877c-d953450bc2eb"), ExpectedNumberOfBachelorProposals = 3, ExpectedNumberOfMasterProposals = 4, FirstName = "Jan", LastName = "Kowalski", UserId = new Guid("04bb5bb4-8ec8-4b42-b753-dddf057797c7") },
                        new { Id = new Guid("fd7b776a-cc16-468b-b3ec-63c00f33ddac"), ExpectedNumberOfBachelorProposals = 3, ExpectedNumberOfMasterProposals = 4, FirstName = "Jan", LastName = "Kowalski", UserId = new Guid("4e8351ab-6b59-4f13-8f28-7313d8af4585") }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Proposal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Level");

                    b.Property<int>("Mode");

                    b.Property<Guid>("PromoterId");

                    b.Property<int>("Status");

                    b.Property<string>("Topic")
                        .IsRequired();

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
                        new { Id = new Guid("2a76da8a-018b-4878-a14f-401a6025ff9a"), UserId = new Guid("81c25a34-37bd-40ab-89ea-b21d2b92e899") },
                        new { Id = new Guid("d18cd9e5-fa11-499c-a52e-cae5fc63cf99"), UserId = new Guid("9c2d6bdf-6bbf-400f-a8a0-acb3a34a4f2e") },
                        new { Id = new Guid("56d18300-066b-41e0-9c7f-f145a3853537"), UserId = new Guid("6abf766e-a637-41cf-93f3-a099cce68b30") },
                        new { Id = new Guid("ed4ef787-5e8a-4117-a95b-95dbc1c751fd"), UserId = new Guid("9cc14694-f564-4f55-a15f-86e47f14922e") },
                        new { Id = new Guid("a0495b29-831b-48b5-b291-4d8fa2e99d4e"), UserId = new Guid("d7512dc4-2423-45d1-bd8d-e71a47bb12fd") },
                        new { Id = new Guid("1aa2ae96-ed80-47f2-99d4-d4182130448d"), UserId = new Guid("d77cb639-f8a0-46be-8724-72b0772158cf") },
                        new { Id = new Guid("084c36ee-4f48-4f18-be8f-4590bdcc63ef"), UserId = new Guid("ad1a346e-b0d8-46b6-b76d-d96b63840993") },
                        new { Id = new Guid("abd9b78c-2508-4935-944a-8c81b242e5d2"), UserId = new Guid("9ddff194-d407-454b-918e-ce3fee675608") }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Promoter", b =>
                {
                    b.HasOne("Capri.Database.Entities.Identity.User", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Capri.Database.Entities.Proposal", b =>
                {
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
