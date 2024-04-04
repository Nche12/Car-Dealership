﻿// <auto-generated />
using System;
using Car_Dealership.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Car_Dealership.Migrations
{
    [DbContext(typeof(TenantContext))]
    [Migration("20231215102510_adPlatformToClient")]
    partial class adPlatformToClient
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Car_Dealership.Models.AdvertisingPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FrequencyId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PaymentAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("FrequencyId");

                    b.ToTable("AdvertisingPlatforms");
                });

            modelBuilder.Entity("Car_Dealership.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AdvertisingPlatformId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BroughtDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<double?>("ClientAmount")
                        .HasColumnType("float");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("CommissionAmount")
                        .HasColumnType("float");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsSold")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Mileage")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ResoldDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("SoldAmount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("SoldDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TransferedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("AdvertisingPlatformId");

                    b.HasIndex("CarModelId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Car_Dealership.Models.CarColour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.ToTable("CarColours");
                });

            modelBuilder.Entity("Car_Dealership.Models.CarDriveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.ToTable("CarDriveTypes");
                });

            modelBuilder.Entity("Car_Dealership.Models.CarMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CarMakes");
                });

            modelBuilder.Entity("Car_Dealership.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarMakeId")
                        .HasColumnType("int");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("CarMakeId");

                    b.HasIndex("DeletedById");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("Car_Dealership.Models.CarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CarTypes");
                });

            modelBuilder.Entity("Car_Dealership.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AdvertisingPlatformId")
                        .HasColumnType("int");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PnoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("AdvertisingPlatformId");

                    b.HasIndex("DeletedById");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Car_Dealership.Models.Frequency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.ToTable("Frequencies");
                });

            modelBuilder.Entity("Car_Dealership.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("Car_Dealership.Models.SeatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SeatTypes");
                });

            modelBuilder.Entity("Car_Dealership.Models.TransmissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TransmissionTypes");
                });

            modelBuilder.Entity("Car_Dealership.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Car_Dealership.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("Role")
                        .IsUnique()
                        .HasFilter("[Role] IS NOT NULL");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Car_Dealership.Models.AdvertisingPlatform", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("Car_Dealership.Models.Frequency", "Frequency")
                        .WithMany()
                        .HasForeignKey("FrequencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("Frequency");
                });

            modelBuilder.Entity("Car_Dealership.Models.Car", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.AdvertisingPlatform", "AdvertisingPlatform")
                        .WithMany()
                        .HasForeignKey("AdvertisingPlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car_Dealership.Models.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car_Dealership.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("Car_Dealership.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedBy");

                    b.Navigation("AdvertisingPlatform");

                    b.Navigation("CarModel");

                    b.Navigation("Client");

                    b.Navigation("DeletedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Car_Dealership.Models.CarColour", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.CarDriveType", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.CarMake", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.CarModel", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.CarMake", "CarMake")
                        .WithMany()
                        .HasForeignKey("CarMakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("CarMake");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.CarType", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.Client", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.AdvertisingPlatform", "AdvertisingPlatform")
                        .WithMany()
                        .HasForeignKey("AdvertisingPlatformId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("AdvertisingPlatform");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.Frequency", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.FuelType", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.SeatType", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.TransmissionType", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.User", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany("UsersAdded")
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany("UsersDeleted")
                        .HasForeignKey("DeletedById");

                    b.HasOne("Car_Dealership.Models.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Car_Dealership.Models.UserRole", b =>
                {
                    b.HasOne("Car_Dealership.Models.User", "AddedBy")
                        .WithMany("UserRolesAdded")
                        .HasForeignKey("AddedById");

                    b.HasOne("Car_Dealership.Models.User", "DeletedBy")
                        .WithMany("UserRolesDeleted")
                        .HasForeignKey("DeletedById");

                    b.Navigation("AddedBy");

                    b.Navigation("DeletedBy");
                });

            modelBuilder.Entity("Car_Dealership.Models.User", b =>
                {
                    b.Navigation("UserRolesAdded");

                    b.Navigation("UserRolesDeleted");

                    b.Navigation("UsersAdded");

                    b.Navigation("UsersDeleted");
                });

            modelBuilder.Entity("Car_Dealership.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
