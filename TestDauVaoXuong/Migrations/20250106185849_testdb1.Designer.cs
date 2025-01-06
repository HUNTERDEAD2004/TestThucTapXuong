﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestDauVaoXuong.Models;

#nullable disable

namespace TestDauVaoXuong.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    [Migration("20250106185849_testdb1")]
    partial class testdb1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestDauVaoXuong.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440020"),
                            Code = "DEP001",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Department One",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440021"),
                            Code = "DEP002",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Department Two",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440022"),
                            Code = "DEP003",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Department Three",
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.DepartmentFacility", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FacilityId");

                    b.HasIndex("StaffId");

                    b.ToTable("DepartmentFacilities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440030"),
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = new Guid("550e8400-e29b-41d4-a716-446655440020"),
                            FacilityId = new Guid("550e8400-e29b-41d4-a716-446655440010"),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            StaffId = new Guid("550e8400-e29b-41d4-a716-446655440000"),
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440031"),
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = new Guid("550e8400-e29b-41d4-a716-446655440021"),
                            FacilityId = new Guid("550e8400-e29b-41d4-a716-446655440011"),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            StaffId = new Guid("550e8400-e29b-41d4-a716-446655440001"),
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440032"),
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = new Guid("550e8400-e29b-41d4-a716-446655440022"),
                            FacilityId = new Guid("550e8400-e29b-41d4-a716-446655440011"),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            StaffId = new Guid("550e8400-e29b-41d4-a716-446655440002"),
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.Facility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Facilities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440010"),
                            Code = "FAC001",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "HN",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440011"),
                            Code = "FAC002",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "HCM",
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.Major", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Majors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440040"),
                            Code = "MAJ001",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Major One",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440041"),
                            Code = "MAJ002",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Major Two",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440042"),
                            Code = "MAJ003",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Major Three",
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.MajorFacility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DepartmentFacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MajorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentFacilityId");

                    b.HasIndex("MajorId");

                    b.ToTable("MajorFacilities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440050"),
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentFacilityId = new Guid("550e8400-e29b-41d4-a716-446655440030"),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            MajorId = new Guid("550e8400-e29b-41d4-a716-446655440040"),
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440051"),
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentFacilityId = new Guid("550e8400-e29b-41d4-a716-446655440031"),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            MajorId = new Guid("550e8400-e29b-41d4-a716-446655440041"),
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440052"),
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentFacilityId = new Guid("550e8400-e29b-41d4-a716-446655440032"),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            MajorId = new Guid("550e8400-e29b-41d4-a716-446655440042"),
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountFe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountFpt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Staff");

                    b.HasData(
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440000"),
                            AccountFe = "fe_account1@fe.edu.vn",
                            AccountFpt = "fpt_account1@fpt.edu.vn",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "John Wick",
                            StaffCode = "ST001",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440001"),
                            AccountFe = "fe_account2@fe.edu.vn",
                            AccountFpt = "fpt_account2@fpt.edu.vn",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Top1 Flo",
                            StaffCode = "ST002",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440002"),
                            AccountFe = "fe_account3@fe.edu.vn",
                            AccountFpt = "fpt_account3@fpt.edu.vn",
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lục Luật",
                            StaffCode = "ST003",
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.StaffMajorFacility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MajorFacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("MajorFacilityId");

                    b.HasIndex("StaffId");

                    b.ToTable("StaffMajorFacilities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440060"),
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            MajorFacilityId = new Guid("550e8400-e29b-41d4-a716-446655440050"),
                            StaffId = new Guid("550e8400-e29b-41d4-a716-446655440000"),
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440061"),
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            MajorFacilityId = new Guid("550e8400-e29b-41d4-a716-446655440051"),
                            StaffId = new Guid("550e8400-e29b-41d4-a716-446655440001"),
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("550e8400-e29b-41d4-a716-446655440062"),
                            CreatedDate = new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            MajorFacilityId = new Guid("550e8400-e29b-41d4-a716-446655440052"),
                            StaffId = new Guid("550e8400-e29b-41d4-a716-446655440002"),
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.DepartmentFacility", b =>
                {
                    b.HasOne("TestDauVaoXuong.Models.Department", "Department")
                        .WithMany("DepartmentFacilities")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("TestDauVaoXuong.Models.Facility", "Facility")
                        .WithMany("DepartmentFacilities")
                        .HasForeignKey("FacilityId");

                    b.HasOne("TestDauVaoXuong.Models.Staff", "Staff")
                        .WithMany("DepartmentFacilities")
                        .HasForeignKey("StaffId");

                    b.Navigation("Department");

                    b.Navigation("Facility");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.MajorFacility", b =>
                {
                    b.HasOne("TestDauVaoXuong.Models.DepartmentFacility", "DepartmentFacility")
                        .WithMany("MajorFacilities")
                        .HasForeignKey("DepartmentFacilityId");

                    b.HasOne("TestDauVaoXuong.Models.Major", "Major")
                        .WithMany("MajorFacilities")
                        .HasForeignKey("MajorId");

                    b.Navigation("DepartmentFacility");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.StaffMajorFacility", b =>
                {
                    b.HasOne("TestDauVaoXuong.Models.MajorFacility", "MajorFacility")
                        .WithMany("StaffMajorFacilities")
                        .HasForeignKey("MajorFacilityId");

                    b.HasOne("TestDauVaoXuong.Models.Staff", "Staff")
                        .WithMany("StaffMajorFacilities")
                        .HasForeignKey("StaffId");

                    b.Navigation("MajorFacility");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.Department", b =>
                {
                    b.Navigation("DepartmentFacilities");
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.DepartmentFacility", b =>
                {
                    b.Navigation("MajorFacilities");
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.Facility", b =>
                {
                    b.Navigation("DepartmentFacilities");
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.Major", b =>
                {
                    b.Navigation("MajorFacilities");
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.MajorFacility", b =>
                {
                    b.Navigation("StaffMajorFacilities");
                });

            modelBuilder.Entity("TestDauVaoXuong.Models.Staff", b =>
                {
                    b.Navigation("DepartmentFacilities");

                    b.Navigation("StaffMajorFacilities");
                });
#pragma warning restore 612, 618
        }
    }
}