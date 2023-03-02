﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieMvcDate.ApplicationDbContext;

#nullable disable

namespace MovieMvcDate.Migrations
{
    [DbContext(typeof(ApplictionContext))]
    [Migration("20230301201309_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MovieMvcDate.Models.Entites.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsdDleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.BookingCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsdDleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("SitNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("bookingcustomers");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsdDleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("customers");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.CustomerMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsdDleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MovieId");

                    b.ToTable("CustomerMovie");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsdDleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MovieFliePath")
                        .HasColumnType("longtext");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("MoviePrice")
                        .HasColumnType("double");

                    b.Property<DateTime>("Moviedate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("TimeCreted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsdDleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.Admin", b =>
                {
                    b.HasOne("MovieMvcDate.Models.Entites.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("MovieMvcDate.Models.Entites.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.BookingCustomer", b =>
                {
                    b.HasOne("MovieMvcDate.Models.Entites.Customer", "Customer")
                        .WithMany("BookingCustomers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.Customer", b =>
                {
                    b.HasOne("MovieMvcDate.Models.Entites.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("MovieMvcDate.Models.Entites.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.CustomerMovie", b =>
                {
                    b.HasOne("MovieMvcDate.Models.Entites.Customer", "Customer")
                        .WithMany("CustomerMovies")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieMvcDate.Models.Entites.Movie", "Movie")
                        .WithMany("CustomerMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.Customer", b =>
                {
                    b.Navigation("BookingCustomers");

                    b.Navigation("CustomerMovies");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.Movie", b =>
                {
                    b.Navigation("CustomerMovies");
                });

            modelBuilder.Entity("MovieMvcDate.Models.Entites.User", b =>
                {
                    b.Navigation("Admin")
                        .IsRequired();

                    b.Navigation("Customer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
