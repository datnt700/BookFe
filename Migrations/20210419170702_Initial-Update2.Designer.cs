﻿// <auto-generated />
using System;
using LibraryBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryBook.Migrations
{
    [DbContext(typeof(BookDBContext))]
    [Migration("20210419170702_Initial-Update2")]
    partial class InitialUpdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryBook.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            CategoryId = 1,
                            Description = "Abc",
                            Title = "ABC"
                        });
                });

            modelBuilder.Entity("LibraryBook.Models.BookBorrowingRequest", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApprovalUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRequest")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RejectUserId")
                        .HasColumnType("int");

                    b.Property<int>("RequestUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnRequest")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("RequestId");

                    b.HasIndex("RequestUserId");

                    b.ToTable("BookBorrowingRequests");
                });

            modelBuilder.Entity("LibraryBook.Models.BookBorrowingRequestDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("RequestId");

                    b.ToTable("BookBorrowRequestDetails");
                });

            modelBuilder.Entity("LibraryBook.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Math"
                        },
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Sciene"
                        });
                });

            modelBuilder.Entity("LibraryBook.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DoB = new DateTime(2001, 4, 20, 0, 7, 1, 909, DateTimeKind.Local).AddTicks(7465),
                            Name = "Nguyen Van A",
                            Password = "123",
                            Role = 0,
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            DoB = new DateTime(1991, 4, 20, 0, 7, 1, 910, DateTimeKind.Local).AddTicks(7662),
                            Name = "Nguyen Van B",
                            Password = "123",
                            Role = 1,
                            Username = "user"
                        });
                });

            modelBuilder.Entity("LibraryBook.Models.Book", b =>
                {
                    b.HasOne("LibraryBook.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LibraryBook.Models.BookBorrowingRequest", b =>
                {
                    b.HasOne("LibraryBook.Models.User", "RequestUser")
                        .WithMany("BookBorrowingRequests")
                        .HasForeignKey("RequestUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestUser");
                });

            modelBuilder.Entity("LibraryBook.Models.BookBorrowingRequestDetail", b =>
                {
                    b.HasOne("LibraryBook.Models.Book", "Book")
                        .WithMany("BookBorrowingRequestDetails")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryBook.Models.BookBorrowingRequest", "Request")
                        .WithMany("BookBorrowRequestDetails")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("LibraryBook.Models.Book", b =>
                {
                    b.Navigation("BookBorrowingRequestDetails");
                });

            modelBuilder.Entity("LibraryBook.Models.BookBorrowingRequest", b =>
                {
                    b.Navigation("BookBorrowRequestDetails");
                });

            modelBuilder.Entity("LibraryBook.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryBook.Models.User", b =>
                {
                    b.Navigation("BookBorrowingRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
