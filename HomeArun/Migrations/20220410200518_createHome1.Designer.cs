﻿// <auto-generated />
using System;
using HomeArun.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeArun.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    [Migration("20220410200518_createHome1")]
    partial class createHome1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HomeLoanManagementSysytem.Models.IncomeDetails", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationId"), 1L, 1);

                    b.Property<string>("EmployerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EstimatedAmount")
                        .HasColumnType("float");

                    b.Property<string>("OrganizationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RetirementAge")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("HomeLoanManagementSysytem.Models.LoanDetails", b =>
                {
                    b.Property<int?>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("LoanId"), 1L, 1);

                    b.Property<double?>("InterestRate")
                        .HasColumnType("float");

                    b.Property<double?>("MaxAmountGrantable")
                        .HasColumnType("float");

                    b.Property<double?>("TotalLoanAmount")
                        .HasColumnType("float");

                    b.Property<int?>("tenure")
                        .HasColumnType("int");

                    b.HasKey("LoanId");

                    b.ToTable("LoanDetails");
                });

            modelBuilder.Entity("HomeLoanManagementSysytem.Models.LoanTracker", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationId"), 1L, 1);

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationId");

                    b.ToTable("LoanTrackers");
                });

            modelBuilder.Entity("HomeLoanManagementSysytem.Models.Login", b =>
                {
                    b.Property<int?>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ApplicationId"), 1L, 1);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationId");

                    b.ToTable("logins");
                });

            modelBuilder.Entity("HomeLoanManagementSysytem.Models.PersonalDetails", b =>
                {
                    b.Property<int?>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ApplicationID"), 1L, 1);

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationID");

                    b.ToTable("Personals");
                });

            modelBuilder.Entity("HomeLoanManagementSysytem.Models.UploadedDocument", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationId"), 1L, 1);

                    b.Property<string>("AadharCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Agreement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("DocumentverifiedStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Loa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanApprovalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Noc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PanCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalarySlip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationId");

                    b.ToTable("UploadedDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}
