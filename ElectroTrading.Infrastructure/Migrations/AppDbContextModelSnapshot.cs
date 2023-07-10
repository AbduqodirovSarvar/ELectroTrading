﻿// <auto-generated />
using System;
using ElectroTrading.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ElectroTrading.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ElectroTrading.Domain.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ByWhomId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("Day")
                        .HasColumnType("date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsExtraWork")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMainWork")
                        .HasColumnType("boolean");

                    b.Property<int?>("MasterId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("MasterId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("JoinedDate")
                        .HasColumnType("date");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.EmployeeDebt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ByWhomId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int?>("MasterId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Summs")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("MasterId");

                    b.ToTable("EmployeesDebts");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.Master", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Masters");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.PaymentSalary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ByWhomId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int?>("MasterId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Summs")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("MasterId");

                    b.ToTable("PaymentSalary");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.Admin", b =>
                {
                    b.HasOne("ElectroTrading.Domain.Entities.User", "UserAdmin")
                        .WithOne("Admin")
                        .HasForeignKey("ElectroTrading.Domain.Entities.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAdmin");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.Attendance", b =>
                {
                    b.HasOne("ElectroTrading.Domain.Entities.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroTrading.Domain.Entities.Master", "Master")
                        .WithMany("Attendances")
                        .HasForeignKey("MasterId");

                    b.Navigation("Employee");

                    b.Navigation("Master");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.Employee", b =>
                {
                    b.HasOne("ElectroTrading.Domain.Entities.User", "UserEmployee")
                        .WithOne("Employee")
                        .HasForeignKey("ElectroTrading.Domain.Entities.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEmployee");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.EmployeeDebt", b =>
                {
                    b.HasOne("ElectroTrading.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeeDebts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroTrading.Domain.Entities.Master", "Master")
                        .WithMany("EmployeeDebts")
                        .HasForeignKey("MasterId");

                    b.Navigation("Employee");

                    b.Navigation("Master");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.Master", b =>
                {
                    b.HasOne("ElectroTrading.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.PaymentSalary", b =>
                {
                    b.HasOne("ElectroTrading.Domain.Entities.Employee", "Employee")
                        .WithMany("PaymentSalarys")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroTrading.Domain.Entities.Master", "Master")
                        .WithMany("PaymentSalarys")
                        .HasForeignKey("MasterId");

                    b.Navigation("Employee");

                    b.Navigation("Master");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("EmployeeDebts");

                    b.Navigation("PaymentSalarys");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.Master", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("EmployeeDebts");

                    b.Navigation("PaymentSalarys");
                });

            modelBuilder.Entity("ElectroTrading.Domain.Entities.User", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
