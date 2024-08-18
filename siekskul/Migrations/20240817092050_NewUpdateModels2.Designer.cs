﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using siekskul.Data;

#nullable disable

namespace siekskul.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240817092050_NewUpdateModels2")]
    partial class NewUpdateModels2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("siekskul.Models.Guru", b =>
                {
                    b.Property<int>("GuruId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuruId"));

                    b.Property<string>("Agama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BidangEkstrakurikuler")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JenisKelamin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NIP")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("TanggalLahir")
                        .HasColumnType("date");

                    b.Property<string>("TempatLahir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GuruId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Gurus");
                });

            modelBuilder.Entity("siekskul.Models.Siswa", b =>
                {
                    b.Property<int>("SiswaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiswaId"));

                    b.Property<string>("Agama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JenisKelamin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kelas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NIS")
                        .HasColumnType("int");

                    b.Property<string>("NamaAyah")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaIbu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("TanggalLahir")
                        .HasColumnType("date");

                    b.Property<string>("TempatLahir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SiswaId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Siswas");
                });

            modelBuilder.Entity("siekskul.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
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
                });

            modelBuilder.Entity("siekskul.Models.Guru", b =>
                {
                    b.HasOne("siekskul.Models.User", "User")
                        .WithOne("Guru")
                        .HasForeignKey("siekskul.Models.Guru", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("siekskul.Models.Siswa", b =>
                {
                    b.HasOne("siekskul.Models.User", "User")
                        .WithOne("Siswa")
                        .HasForeignKey("siekskul.Models.Siswa", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("siekskul.Models.User", b =>
                {
                    b.Navigation("Guru")
                        .IsRequired();

                    b.Navigation("Siswa")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
