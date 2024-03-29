﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rookie.AssetManagement.DataAccessor.Data;

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220402020822_add_assetcategory_and_asset")]
    partial class add_assetcategory_and_asset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Rookie.AssetManagement.DataAccessor.Entities.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InstallDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Assets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 1,
                            Code = "LA000001",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 781, DateTimeKind.Local).AddTicks(3913),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(3042),
                            Location = 1,
                            Name = "Laptop HP Pro Book 450 G1",
                            Specification = "Specification of Laptop",
                            State = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 1,
                            Code = "LA000002",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4366),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4375),
                            Location = 1,
                            Name = "Laptop HP Pro Book 450 G1",
                            Specification = "Specification of Laptop",
                            State = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryID = 1,
                            Code = "LA000003",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4378),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4379),
                            Location = 1,
                            Name = "Laptop HP Pro Book 450 G1",
                            Specification = "Specification of Laptop",
                            State = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryID = 1,
                            Code = "LA000004",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4380),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4381),
                            Location = 1,
                            Name = "Laptop HP Pro Book 450 G1",
                            Specification = "Specification of Laptop",
                            State = 2
                        },
                        new
                        {
                            Id = 5,
                            CategoryID = 1,
                            Code = "LA000005",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4382),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4383),
                            Location = 2,
                            Name = "Laptop HP Pro Book 450 G1",
                            Specification = "Specification of Laptop",
                            State = 1
                        },
                        new
                        {
                            Id = 6,
                            CategoryID = 2,
                            Code = "MO000001",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4385),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4386),
                            Location = 1,
                            Name = "Monitor Dell UltraSharp",
                            Specification = "Specification of Monitor",
                            State = 1
                        },
                        new
                        {
                            Id = 7,
                            CategoryID = 2,
                            Code = "MO000002",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4387),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4388),
                            Location = 1,
                            Name = "Monitor Dell UltraSharp",
                            Specification = "Specification of Monitor",
                            State = 2
                        },
                        new
                        {
                            Id = 8,
                            CategoryID = 2,
                            Code = "MO000003",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4389),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4390),
                            Location = 1,
                            Name = "Monitor Dell UltraSharp",
                            Specification = "Specification of Monitor",
                            State = 1
                        },
                        new
                        {
                            Id = 9,
                            CategoryID = 2,
                            Code = "MO000004",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4391),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4392),
                            Location = 2,
                            Name = "Monitor Dell UltraSharp",
                            Specification = "Specification of Monitor",
                            State = 1
                        },
                        new
                        {
                            Id = 10,
                            CategoryID = 2,
                            Code = "MO000005",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4394),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4394),
                            Location = 2,
                            Name = "Monitor Dell UltraSharp",
                            Specification = "Specification of Monitor",
                            State = 2
                        },
                        new
                        {
                            Id = 11,
                            CategoryID = 2,
                            Code = "MO000006",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4396),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4397),
                            Location = 2,
                            Name = "Monitor Dell UltraSharp",
                            Specification = "Specification of Monitor",
                            State = 1
                        },
                        new
                        {
                            Id = 12,
                            CategoryID = 3,
                            Code = "PC000001",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4398),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4399),
                            Location = 1,
                            Name = "Personal Computer",
                            Specification = "Specification of PC",
                            State = 1
                        },
                        new
                        {
                            Id = 13,
                            CategoryID = 3,
                            Code = "PC000002",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4400),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4401),
                            Location = 1,
                            Name = "Personal Computer",
                            Specification = "Specification of PC",
                            State = 2
                        },
                        new
                        {
                            Id = 14,
                            CategoryID = 3,
                            Code = "PC000003",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4403),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4403),
                            Location = 2,
                            Name = "Personal Computer",
                            Specification = "Specification of PC",
                            State = 1
                        },
                        new
                        {
                            Id = 15,
                            CategoryID = 3,
                            Code = "PC000004",
                            InstallDate = new DateTime(2023, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4405),
                            LastUpdate = new DateTime(2022, 4, 2, 9, 8, 21, 782, DateTimeKind.Local).AddTicks(4406),
                            Location = 2,
                            Name = "Personal Computer",
                            Specification = "Specification of PC",
                            State = 2
                        });
                });

            modelBuilder.Entity("Rookie.AssetManagement.DataAccessor.Entities.AssetCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssetCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Laptop",
                            ShortName = "LA"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Monitor",
                            ShortName = "MO"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Personal Computer",
                            ShortName = "PC"
                        });
                });

            modelBuilder.Entity("Rookie.AssetManagement.DataAccessor.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("FirstLogin")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDisable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Rookie.AssetManagement.DataAccessor.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Rookie.AssetManagement.DataAccessor.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rookie.AssetManagement.DataAccessor.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Rookie.AssetManagement.DataAccessor.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rookie.AssetManagement.DataAccessor.Entities.Asset", b =>
                {
                    b.HasOne("Rookie.AssetManagement.DataAccessor.Entities.AssetCategory", "Category")
                        .WithMany("Assets")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Rookie.AssetManagement.DataAccessor.Entities.AssetCategory", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
