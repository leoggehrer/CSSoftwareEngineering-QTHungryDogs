﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QTHungryDogs.Logic.DataContext;

#nullable disable

namespace QTHungryDogs.Logic.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    partial class ProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IdentityRole", b =>
                {
                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("IdentityId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("IdentityRole", "account");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Account.Identity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("EnableJwtAuth")
                        .HasColumnType("bit");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varbinary(512)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varbinary(512)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("TimeOutInMinutes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Identities", "account");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Account.LoginSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LogoutTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OptionalInfo")
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("SessionToken")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("TimeOutInMinutes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("LoginSessions", "account");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Account.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Designation")
                        .IsUnique();

                    b.ToTable("Roles", "account");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Account.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("Users", "account");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.App.SpecialOpeningHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("From")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("SpecialOpeningHours", "app");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Base.OpeningHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<TimeSpan>("OpenFrom")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("OpenTo")
                        .HasColumnType("time");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("Weekday")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("OpeningHours", "base");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Base.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("AddressHousenumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("AddressZipcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("UniqueName")
                        .IsUnique();

                    b.ToTable("Restaurants", "base");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Base.RestaurantXUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId", "UserId")
                        .IsUnique();

                    b.ToTable("RestaurantXUsers", "base");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Logging.ActionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ActionLogs", "logging");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Revision.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ActionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<string>("JsonData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Histories", "revision");
                });

            modelBuilder.Entity("IdentityRole", b =>
                {
                    b.HasOne("QTHungryDogs.Logic.Entities.Account.Role", null)
                        .WithMany()
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QTHungryDogs.Logic.Entities.Account.Identity", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Account.LoginSession", b =>
                {
                    b.HasOne("QTHungryDogs.Logic.Entities.Account.Identity", "Identity")
                        .WithMany("LoginSessions")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Account.User", b =>
                {
                    b.HasOne("QTHungryDogs.Logic.Entities.Account.Identity", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.App.SpecialOpeningHour", b =>
                {
                    b.HasOne("QTHungryDogs.Logic.Entities.Base.Restaurant", "Restaurant")
                        .WithMany("SpecialOpeningHours")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Base.OpeningHour", b =>
                {
                    b.HasOne("QTHungryDogs.Logic.Entities.Base.Restaurant", "Restaurant")
                        .WithMany("OpeningHours")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Base.RestaurantXUser", b =>
                {
                    b.HasOne("QTHungryDogs.Logic.Entities.Base.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Account.Identity", b =>
                {
                    b.Navigation("LoginSessions");
                });

            modelBuilder.Entity("QTHungryDogs.Logic.Entities.Base.Restaurant", b =>
                {
                    b.Navigation("OpeningHours");

                    b.Navigation("SpecialOpeningHours");
                });
#pragma warning restore 612, 618
        }
    }
}
