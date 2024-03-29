﻿// <auto-generated />
using Emp_performance_appraisal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Emp_performance_appraisal.Migrations
{
    [DbContext(typeof(EmpContext))]
    [Migration("20230403034535_updateapp")]
    partial class updateapp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Emp_performance_appraisal.Models.Appraisal", b =>
                {
                    b.Property<int>("AppraisalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppraisalId"), 1L, 1);

                    b.Property<string>("BCompetency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpID")
                        .HasColumnType("int");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("Objectives")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCompetency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppraisalId");

                    b.ToTable("Appraisal");
                });

            modelBuilder.Entity("Emp_performance_appraisal.Models.Employee", b =>
                {
                    b.Property<int>("EmpID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpID"), 1L, 1);

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MgrId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("EmpID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Emp_performance_appraisal.Models.Form", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Appraisalid")
                        .HasColumnType("int");

                    b.Property<string>("EmpCommentsB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpCommentsT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpRatingB")
                        .HasColumnType("int");

                    b.Property<int>("EmpRatingT")
                        .HasColumnType("int");

                    b.Property<string>("MgrCommentsB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MgrCommentsT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MgrRatingB")
                        .HasColumnType("int");

                    b.Property<int>("MgrRatingT")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Form");
                });
#pragma warning restore 612, 618
        }
    }
}
