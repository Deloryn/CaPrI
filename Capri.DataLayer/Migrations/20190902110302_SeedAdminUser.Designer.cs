﻿// <auto-generated />
using System;
using Capri.DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capri.DataLayer.Migrations
{
    [DbContext(typeof(CapriDbContextImpl))]
    [Migration("20190902110302_SeedAdminUser")]
    partial class SeedAdminUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Capri.DataLayer.Entities.Proposal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("PromoterID");

                    b.Property<int>("Status");

                    b.Property<string>("Topic")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("PromoterID");

                    b.ToTable("Proposals");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Proposal");
                });

            modelBuilder.Entity("Capri.DataLayer.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("Token");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Capri.DataLayer.Entities.BachelorProposal", b =>
                {
                    b.HasBaseType("Capri.DataLayer.Entities.Proposal");


                    b.ToTable("BachelorProposal");

                    b.HasDiscriminator().HasValue("BachelorProposal");
                });

            modelBuilder.Entity("Capri.DataLayer.Entities.MasterProposal", b =>
                {
                    b.HasBaseType("Capri.DataLayer.Entities.Proposal");


                    b.ToTable("MasterProposal");

                    b.HasDiscriminator().HasValue("MasterProposal");
                });

            modelBuilder.Entity("Capri.DataLayer.Entities.DeanEmployee", b =>
                {
                    b.HasBaseType("Capri.DataLayer.Entities.User");


                    b.ToTable("DeanEmployee");

                    b.HasDiscriminator().HasValue("DeanEmployee");

                    b.HasData(
                        new { ID = 2, Email = "admin@gmail.com", Name = "Admin", PasswordHash = "AQAAAAEAACcQAAAAEFEi3ENOvfrddNbHhAukGm/C6Zcp4Bv0ucVcrldi1IQT+AHV1bwa+aScbwjxk7GZUg==" }
                    );
                });

            modelBuilder.Entity("Capri.DataLayer.Entities.Promoter", b =>
                {
                    b.HasBaseType("Capri.DataLayer.Entities.User");

                    b.Property<bool>("CanSubmitBachelorProposals");

                    b.ToTable("Promoter");

                    b.HasDiscriminator().HasValue("Promoter");

                    b.HasData(
                        new { ID = 1, Email = "john.smith@gmail.com", Name = "John Smith", PasswordHash = "AQAAAAEAACcQAAAAEC87thx7Ap3bha2GAZESLYFJg2rmuVIBXJcR+UiQPkguNggRCJiCYb5MLccfR5x6zQ==", CanSubmitBachelorProposals = true }
                    );
                });

            modelBuilder.Entity("Capri.DataLayer.Entities.Student", b =>
                {
                    b.HasBaseType("Capri.DataLayer.Entities.User");

                    b.Property<int?>("ProposalID");

                    b.Property<int?>("ProposalID1");

                    b.HasIndex("ProposalID");

                    b.HasIndex("ProposalID1");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Capri.DataLayer.Entities.Proposal", b =>
                {
                    b.HasOne("Capri.DataLayer.Entities.Promoter")
                        .WithMany("Proposals")
                        .HasForeignKey("PromoterID");
                });

            modelBuilder.Entity("Capri.DataLayer.Entities.Student", b =>
                {
                    b.HasOne("Capri.DataLayer.Entities.Proposal")
                        .WithMany("AssignedStudents")
                        .HasForeignKey("ProposalID");

                    b.HasOne("Capri.DataLayer.Entities.Proposal")
                        .WithMany("WillingCandidates")
                        .HasForeignKey("ProposalID1");
                });
#pragma warning restore 612, 618
        }
    }
}
