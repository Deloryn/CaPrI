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
                        new { Id = new Guid("f61e3c32-58ca-42e4-b70c-3e87cbab88ac"), ConcurrencyStamp = "e3449912-7001-47f4-ab68-22c51db82774", Name = "admin", NormalizedName = "admin" },
                        new { Id = new Guid("560513df-4210-4ca4-b4dd-8b4b2890bb0b"), ConcurrencyStamp = "67f9ac58-b1c2-4dd1-96c5-44aed605d580", Name = "dean", NormalizedName = "dean" },
                        new { Id = new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), ConcurrencyStamp = "139f2a78-adee-4dc8-9a28-cec36c74d4c4", Name = "student", NormalizedName = "student" },
                        new { Id = new Guid("52b0fee2-7ed7-4dc2-b39e-901a85bd5c72"), ConcurrencyStamp = "3debde0a-b320-48e0-9bbd-5dd85a6ff6ec", Name = "promoter", NormalizedName = "promoter" }
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
                        new { Id = new Guid("0a362762-20d5-43ce-a423-9469b284d735"), RoleId = new Guid("f61e3c32-58ca-42e4-b70c-3e87cbab88ac"), UserId = new Guid("8fc81b45-6907-47d4-bbfa-dfb79e240527") },
                        new { Id = new Guid("f9c97bb9-c44c-4f90-849e-360f6a4dd070"), RoleId = new Guid("560513df-4210-4ca4-b4dd-8b4b2890bb0b"), UserId = new Guid("443154d5-030a-433f-a490-7caad4cc3bb7") },
                        new { Id = new Guid("25e51715-7b1d-41b3-b2e8-689afb170d1a"), RoleId = new Guid("560513df-4210-4ca4-b4dd-8b4b2890bb0b"), UserId = new Guid("a3d47d5b-6153-4279-94ba-bfb1530e4cc6") },
                        new { Id = new Guid("566b6d3e-922c-46ee-9b51-c885eab74b1b"), RoleId = new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), UserId = new Guid("45e1a663-02bb-432f-9f39-4f16a147128a") },
                        new { Id = new Guid("599948c0-e1ce-40ea-8159-302bfb035959"), RoleId = new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), UserId = new Guid("c4fccbdc-bbd5-4178-8a10-b57c314739b4") },
                        new { Id = new Guid("90e28168-f20c-4cfa-8050-fc6be9aac0d4"), RoleId = new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), UserId = new Guid("fd079259-7702-40cd-888e-a2a30d9349ea") },
                        new { Id = new Guid("50b51a21-021c-4a7a-b82b-111398e1efef"), RoleId = new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), UserId = new Guid("28c7ab57-e880-449f-8872-bcb3926af60e") },
                        new { Id = new Guid("fb73c8ce-61f0-4099-a140-d87118bb7e64"), RoleId = new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), UserId = new Guid("86dd4cfb-8c25-4ea2-b9e4-02a3bf90f04b") },
                        new { Id = new Guid("1387dc83-9467-4ddd-bb74-6dbceab9df8d"), RoleId = new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), UserId = new Guid("3b3d8bfa-4f33-40c7-97fa-c7603c8e01dc") },
                        new { Id = new Guid("3f17fadc-69e2-472a-a562-ea271dc3ba41"), RoleId = new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), UserId = new Guid("651e94f8-c4c9-422e-9a18-0a97f346f711") },
                        new { Id = new Guid("2d9043b3-cbb5-4926-904d-a87c66376dc3"), RoleId = new Guid("a495a706-6296-4bd1-9b06-854760c5a372"), UserId = new Guid("b0a39d16-11c1-4839-a85d-eb1b1516a26a") },
                        new { Id = new Guid("e808945f-f753-411d-b630-667052e45100"), RoleId = new Guid("52b0fee2-7ed7-4dc2-b39e-901a85bd5c72"), UserId = new Guid("f5ddef41-423c-4019-86c6-6a1ad7b118d9") },
                        new { Id = new Guid("1d306d4b-ac61-4d02-8333-e883dbc5bc23"), RoleId = new Guid("52b0fee2-7ed7-4dc2-b39e-901a85bd5c72"), UserId = new Guid("4d017242-93a8-4846-bc37-19af61bf8c3c") }
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
                        new { Id = new Guid("8fc81b45-6907-47d4-bbfa-dfb79e240527"), AccessFailedCount = 0, ConcurrencyStamp = "45ecf151-2a59-4341-b05b-802e14b4389a", Email = "admin1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "admin1@gmail.com", NormalizedUserName = "admin1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEOqMknFptMq+z/4CbdmcWKRnmCtnTMItBy3wfteuErI6rlmH9ju5vMURdoKXwyNwdw==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "admin1@gmail.com" },
                        new { Id = new Guid("443154d5-030a-433f-a490-7caad4cc3bb7"), AccessFailedCount = 0, ConcurrencyStamp = "98a100bc-ee4e-463e-b84b-f3a0ccf89fe9", Email = "dean1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "dean1@gmail.com", NormalizedUserName = "dean1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEOT742qr0L1boAeHjveg1hbaix9az3/2HNnIqPJdyKV8UP5jlwZ9rmmLguNlzZY/TA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean1@gmail.com" },
                        new { Id = new Guid("a3d47d5b-6153-4279-94ba-bfb1530e4cc6"), AccessFailedCount = 0, ConcurrencyStamp = "8e4808ad-d820-4f67-a91f-0f9f30e775a9", Email = "dean2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "dean2@gmail.com", NormalizedUserName = "dean2@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEJ2PkgRIe0yyxDke4xV0JxJ02da8KeDcjMXtNe3yVZORRDqeptUjQmx2qsuJWPInhA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "dean2@gmail.com" },
                        new { Id = new Guid("45e1a663-02bb-432f-9f39-4f16a147128a"), AccessFailedCount = 0, ConcurrencyStamp = "8156e2a7-b2b3-4347-91ed-a28be611e5c5", Email = "student1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student1@gmail.com", NormalizedUserName = "student1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEJbBmtcBs+kxFIX1P/PKqQALqLHbZLgM2D1wMS8FmiBlu7ZUCDAGUs9MgzhdUnd+1w==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student1@gmail.com" },
                        new { Id = new Guid("c4fccbdc-bbd5-4178-8a10-b57c314739b4"), AccessFailedCount = 0, ConcurrencyStamp = "39a03667-e007-4b50-a903-d9423455433c", Email = "student2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student2@gmail.com", NormalizedUserName = "student2@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEGyR/pUSgmkvqI08P4Tby4s39sHkREDSuz8g+I1NyMTbnQ/73PIDGOL66dRtTQEcDg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student2@gmail.com" },
                        new { Id = new Guid("fd079259-7702-40cd-888e-a2a30d9349ea"), AccessFailedCount = 0, ConcurrencyStamp = "dc161edc-ef2e-4dc3-b57d-c360976b538f", Email = "student3@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student3@gmail.com", NormalizedUserName = "student3@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAENUIvlf+mVPWRFqhUnHQOrSDvoAeh9EXTizqOT2YNAYbSBOwq1ZP0S69qbNCV6/vEQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student3@gmail.com" },
                        new { Id = new Guid("28c7ab57-e880-449f-8872-bcb3926af60e"), AccessFailedCount = 0, ConcurrencyStamp = "560e50ff-2d71-4d2c-a5c5-329aac9c51d9", Email = "student4@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student4@gmail.com", NormalizedUserName = "student4@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEIr6TtMpOwYIJ+GAGYCKCClkfYXhIHSNV7zV60JXJ4xhOoWMAOOpZcbHvBHEdgvaYQ==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student4@gmail.com" },
                        new { Id = new Guid("86dd4cfb-8c25-4ea2-b9e4-02a3bf90f04b"), AccessFailedCount = 0, ConcurrencyStamp = "3c94716e-0ed4-47c7-b049-cf9b4bc7d1f7", Email = "student5@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student5@gmail.com", NormalizedUserName = "student5@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEOyjhSBbuqB6awdSR27znkGdMfp9YEsQ7agGcpqK/Ykr5SH4mbbG5bKEG4I7rRFmiA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student5@gmail.com" },
                        new { Id = new Guid("3b3d8bfa-4f33-40c7-97fa-c7603c8e01dc"), AccessFailedCount = 0, ConcurrencyStamp = "e62b6462-4370-432e-8266-0a7bdbb6da6c", Email = "student6@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student6@gmail.com", NormalizedUserName = "student6@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEATtNCBpuxVciS78cymFo1iBDHtn89tw2censmFwvanOUmQYivCLaBLx/TBBd2bKxA==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student6@gmail.com" },
                        new { Id = new Guid("651e94f8-c4c9-422e-9a18-0a97f346f711"), AccessFailedCount = 0, ConcurrencyStamp = "f4a14606-3c64-49d0-a306-fe1e05121989", Email = "student7@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student7@gmail.com", NormalizedUserName = "student7@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEK20+0iRuXGc7HvqILynWbaWDYvlRiDXsv+UR+16o/oo/2Rgc1DNOkdGR6JzDafQDg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student7@gmail.com" },
                        new { Id = new Guid("b0a39d16-11c1-4839-a85d-eb1b1516a26a"), AccessFailedCount = 0, ConcurrencyStamp = "b9265335-bc06-43c5-ae96-ff2a53cb6992", Email = "student8@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "student8@gmail.com", NormalizedUserName = "student8@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEIijz/GYn5qYisJBD2bSVlM4vzYVnNDoLKDteeCq9SFv8aMRSceNEhD3BQZ9rgx86g==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "student8@gmail.com" },
                        new { Id = new Guid("f5ddef41-423c-4019-86c6-6a1ad7b118d9"), AccessFailedCount = 0, ConcurrencyStamp = "0cc797b9-0962-4650-afc1-b9572f50e29d", Email = "promoter1@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "promoter1@gmail.com", NormalizedUserName = "promoter1@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAECkv6u/sScVM2E0+DFLdurnzaAQ+1201hxGZXHengcpQmFl7M1bs4h2pefa4Cb9uug==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "promoter1@gmail.com" },
                        new { Id = new Guid("4d017242-93a8-4846-bc37-19af61bf8c3c"), AccessFailedCount = 0, ConcurrencyStamp = "b081d0fd-a687-4166-9efb-721a18354b73", Email = "promoter2@gmail.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "promoter2@gmail.com", NormalizedUserName = "promoter2@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEATgum8Pkx/dg3flk5y9NwDzoQBdzP5OLNIS8gCAsFcVW14VsCT/SB0ZJ952shfhKg==", PhoneNumberConfirmed = false, SecurityStamp = "", TwoFactorEnabled = false, UserName = "promoter2@gmail.com" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Promoter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanSubmitBachelorProposals");

                    b.Property<bool>("CanSubmitMasterProposals");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Promoters");

                    b.HasData(
                        new { Id = new Guid("32e7fdda-9528-4263-a6db-0f3e079039de"), CanSubmitBachelorProposals = true, CanSubmitMasterProposals = true, FirstName = "Jan", LastName = "Kowalski", UserId = new Guid("f5ddef41-423c-4019-86c6-6a1ad7b118d9") },
                        new { Id = new Guid("fca052f9-566f-4b50-9ef0-233af72b6888"), CanSubmitBachelorProposals = true, CanSubmitMasterProposals = true, FirstName = "Jan", LastName = "Kowalski", UserId = new Guid("4d017242-93a8-4846-bc37-19af61bf8c3c") }
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

                    b.Property<Guid?>("PromoterId1");

                    b.Property<int>("Status");

                    b.Property<string>("Topic")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PromoterId");

                    b.HasIndex("PromoterId1");

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
                        new { Id = new Guid("c161a023-1257-4431-8667-03b7919fc332"), UserId = new Guid("45e1a663-02bb-432f-9f39-4f16a147128a") },
                        new { Id = new Guid("d3cba93a-4da5-455f-a70b-b9452be27792"), UserId = new Guid("c4fccbdc-bbd5-4178-8a10-b57c314739b4") },
                        new { Id = new Guid("34c9ff28-5d56-49aa-ba79-94dce9f74c23"), UserId = new Guid("fd079259-7702-40cd-888e-a2a30d9349ea") },
                        new { Id = new Guid("ae4d7ac1-d95c-435e-96b2-0b712cb11631"), UserId = new Guid("28c7ab57-e880-449f-8872-bcb3926af60e") },
                        new { Id = new Guid("eedf24b6-330d-4766-a146-a5926a59fd19"), UserId = new Guid("86dd4cfb-8c25-4ea2-b9e4-02a3bf90f04b") },
                        new { Id = new Guid("8886bc27-8c6d-4093-9da9-dba6544143c1"), UserId = new Guid("3b3d8bfa-4f33-40c7-97fa-c7603c8e01dc") },
                        new { Id = new Guid("5ffe2239-13e1-40bf-9374-2337b191262a"), UserId = new Guid("651e94f8-c4c9-422e-9a18-0a97f346f711") },
                        new { Id = new Guid("8cf38aac-02c7-4703-a650-2243def3705a"), UserId = new Guid("b0a39d16-11c1-4839-a85d-eb1b1516a26a") }
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
                        .WithMany()
                        .HasForeignKey("PromoterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Capri.Database.Entities.Promoter")
                        .WithMany("Proposals")
                        .HasForeignKey("PromoterId1");
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
