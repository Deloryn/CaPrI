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

                    b.Property<string>("Discriminator")
                        .IsRequired();

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

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.HasData(
                        new { Id = new Guid("d184c718-b6b3-498f-8f83-df68251257db"), AccessFailedCount = 0, ConcurrencyStamp = "0dfdf2d2-e0c3-4763-9372-ada56475a5cc", Email = "admin@gmail.com", EmailConfirmed = false, LockoutEnabled = false, PasswordHash = "AQAAAAEAACcQAAAAENNo4TTIcEwZshPE9K7B7o9SynFtAK4eKCEtKj1nTr2N4hZOTyGPc3r5Kd/mIs+OQA==", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "admin@gmail.com" }
                    );
                });

            modelBuilder.Entity("Capri.Database.Entities.Proposal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<Guid?>("PromoterId");

                    b.Property<int>("Status");

                    b.Property<string>("Topic")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PromoterId");

                    b.ToTable("Proposal");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Proposal");
                });

            modelBuilder.Entity("Capri.Database.Entities.DeanEmployee", b =>
                {
                    b.HasBaseType("Capri.Database.Entities.Identity.User");


                    b.ToTable("DeanEmployee");

                    b.HasDiscriminator().HasValue("DeanEmployee");
                });

            modelBuilder.Entity("Capri.Database.Entities.Promoter", b =>
                {
                    b.HasBaseType("Capri.Database.Entities.Identity.User");

                    b.Property<bool>("CanSubmitBachelorProposals");

                    b.ToTable("Promoter");

                    b.HasDiscriminator().HasValue("Promoter");
                });

            modelBuilder.Entity("Capri.Database.Entities.Student", b =>
                {
                    b.HasBaseType("Capri.Database.Entities.Identity.User");

                    b.Property<Guid?>("ProposalId");

                    b.Property<Guid?>("ProposalId1");

                    b.HasIndex("ProposalId");

                    b.HasIndex("ProposalId1");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Capri.Database.Entities.BachelorProposal", b =>
                {
                    b.HasBaseType("Capri.Database.Entities.Proposal");


                    b.ToTable("BachelorProposal");

                    b.HasDiscriminator().HasValue("BachelorProposal");
                });

            modelBuilder.Entity("Capri.Database.Entities.MasterProposal", b =>
                {
                    b.HasBaseType("Capri.Database.Entities.Proposal");


                    b.ToTable("MasterProposal");

                    b.HasDiscriminator().HasValue("MasterProposal");
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
                        .WithMany("AssignedStudents")
                        .HasForeignKey("ProposalId");

                    b.HasOne("Capri.Database.Entities.Proposal")
                        .WithMany("WillingCandidates")
                        .HasForeignKey("ProposalId1");
                });
#pragma warning restore 612, 618
        }
    }
}
