﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webgk.Models;

#nullable disable

namespace webgk.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241127090820_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webgk.Models.DonHang", b =>
                {
                    b.Property<int>("MaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDon"));

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("MaKhach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayBan")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TrangThaiDH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDon");

                    b.ToTable("DonHangs");
                });

            modelBuilder.Entity("webgk.Models.Khach", b =>
                {
                    b.Property<string>("MaKhach")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKhach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKhach");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("webgk.Models.sanpham", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("GiaBan")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("GiaNhap")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("LoaiSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SanPhams");
                });
#pragma warning restore 612, 618
        }
    }
}
