﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PakVisa.DataAccess;

namespace PakVisa.DataAccess.Migrations
{
    [DbContext(typeof(PakVisaDbContext))]
    [Migration("20181025183847_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PakVisa.Models.Advertisement", b =>
                {
                    b.Property<int>("AdvertismentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId");

                    b.Property<int?>("CountryId");

                    b.Property<string>("Description");

                    b.Property<int>("FranchiseId");

                    b.Property<byte[]>("Image2");

                    b.Property<byte[]>("Image3");

                    b.Property<byte[]>("Image4");

                    b.Property<byte[]>("Image5");

                    b.Property<bool>("IsApproved");

                    b.Property<byte[]>("Logo");

                    b.Property<byte[]>("MainImage")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.Property<DateTime>("Time");

                    b.Property<double>("VisaPrice");

                    b.Property<string>("VisaTitle")
                        .IsRequired();

                    b.Property<int?>("VisaTypeId");

                    b.HasKey("AdvertismentId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("FranchiseId");

                    b.HasIndex("VisaTypeId");

                    b.ToTable("Advertisement","Catalog");
                });

            modelBuilder.Entity("PakVisa.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("City","Catalog");
                });

            modelBuilder.Entity("PakVisa.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("CountryId");

                    b.ToTable("Country","Catalog");
                });

            modelBuilder.Entity("PakVisa.Models.Franchise", b =>
                {
                    b.Property<int>("FranchiseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<byte[]>("Agreement");

                    b.Property<byte[]>("CNICPassport");

                    b.Property<byte[]>("DTSLicense");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Fax");

                    b.Property<byte[]>("IATALicense");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsRestrict");

                    b.Property<double>("Landline");

                    b.Property<byte[]>("Logo");

                    b.Property<byte[]>("NTNCertificate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Phone");

                    b.Property<double>("Phone2");

                    b.Property<int>("UserloginId");

                    b.HasKey("FranchiseId");

                    b.HasIndex("UserloginId");

                    b.ToTable("Franchise","Catalog");
                });

            modelBuilder.Entity("PakVisa.Models.Userlogin", b =>
                {
                    b.Property<int>("UserloginId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsUserAdmin");

                    b.Property<bool>("IsUserClient");

                    b.Property<bool>("IsUserVisitor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("UserloginId");

                    b.ToTable("Userlogin","Users");
                });

            modelBuilder.Entity("PakVisa.Models.VisaType", b =>
                {
                    b.Property<int>("VisaTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("VisaTypeId");

                    b.ToTable("VisaType","Catalog");
                });

            modelBuilder.Entity("PakVisa.Models.Advertisement", b =>
                {
                    b.HasOne("PakVisa.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("PakVisa.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("PakVisa.Models.Franchise", "Franchise")
                        .WithMany()
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PakVisa.Models.VisaType", "VisaType")
                        .WithMany()
                        .HasForeignKey("VisaTypeId");
                });

            modelBuilder.Entity("PakVisa.Models.City", b =>
                {
                    b.HasOne("PakVisa.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PakVisa.Models.Franchise", b =>
                {
                    b.HasOne("PakVisa.Models.Userlogin", "Userlogin")
                        .WithMany()
                        .HasForeignKey("UserloginId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
