﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zaren.Data;

namespace Zaren.Data.Migrations
{
    [DbContext(typeof(SanProjectDBContext))]
    [Migration("20220612125848_Reservations are added")]
    partial class Reservationsareadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Zaren.Domain.ReservationDBDTO", b =>
                {
                    b.Property<string>("reservationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("beginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("bookingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buyerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("hotelHomePage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hotelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hotelPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("paymentAmount")
                        .HasColumnType("float");

                    b.Property<int>("paymentNo")
                        .HasColumnType("int");

                    b.Property<string>("paymetCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("travellerNumber")
                        .HasColumnType("int");

                    b.HasKey("reservationNumber");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Zaren.Domain.Token", b =>
                {
                    b.Property<int>("tokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tokenId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("Zaren.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
