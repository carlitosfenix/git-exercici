﻿// <auto-generated />
using System;
using Academy.Lib.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Academy.Lib.Migrations
{
    [DbContext(typeof(AcademyDbContext))]
    [Migration("20200608194805_yava")]
    partial class yava
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Academy_4_DbContext.Lib.Model.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateTimeExam")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Score")
                        .HasColumnType("double");

                    b.Property<Guid>("StudentGuid")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SubjectGuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("ListaExams");
                });

            modelBuilder.Entity("Academy_4_DbContext.Lib.Model.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Dni")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ListaStudents");
                });

            modelBuilder.Entity("Academy_4_DbContext.Lib.Model.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Teacher")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ListaSubjets");
                });

            modelBuilder.Entity("Academy_4_DbContext.Lib.Model.Exam", b =>
                {
                    b.HasOne("Academy_4_DbContext.Lib.Model.Student", null)
                        .WithMany("Exams")
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}
