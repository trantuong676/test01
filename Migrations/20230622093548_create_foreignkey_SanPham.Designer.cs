﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TEST02.Migrations
{
    [DbContext(typeof(LTQLDBb))]
    [Migration("20230622093548_create_foreignkey_SanPham")]
    partial class create_foreignkey_SanPham
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("TEST02.Models.NhaCungCap", b =>
                {
                    b.Property<int>("MaNhaCungCap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenNhaCungCap")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNhaCungCap");

                    b.ToTable("NhaCungCap");
                });

            modelBuilder.Entity("TEST02.Models.SanPham", b =>
                {
                    b.Property<int>("MaNhaCungCap")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MaSanPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNhaCungCap");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("TEST02.Models.SanPham", b =>
                {
                    b.HasOne("TEST02.Models.NhaCungCap", "NhaCungCap")
                        .WithMany()
                        .HasForeignKey("MaNhaCungCap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaCungCap");
                });
#pragma warning restore 612, 618
        }
    }
}
