﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sabia.Api;

namespace Sabia.Api.Migrations
{
    [DbContext(typeof(SabiaContext))]
    partial class SabiaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sabia.Api.Model.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("CourseTypeId");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<float>("ExpectedHours");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(250);

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<long?>("RequirementCourseId");

                    b.HasKey("Id");

                    b.HasIndex("CourseTypeId");

                    b.HasIndex("RequirementCourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Sabia.Api.Model.CourseClass", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("ClassNumber");

                    b.Property<long>("CourseId");

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseClasses");
                });

            modelBuilder.Entity("Sabia.Api.Model.CourseType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<bool>("Basic");

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("CourseTypes");
                });

            modelBuilder.Entity("Sabia.Api.Model.Job", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("BaseCode")
                        .HasColumnType("LONGTEXT");

                    b.Property<bool>("Completed");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<float>("EstimatedHours");

                    b.Property<float>("Money");

                    b.Property<long>("ReportedProgression");

                    b.Property<string>("Title")
                        .HasMaxLength(250);

                    b.Property<float>("UsedHours");

                    b.Property<long?>("UserId");

                    b.Property<string>("VerificationCode")
                        .HasColumnType("LONGTEXT");

                    b.Property<string>("imagePath")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Sabia.Api.Model.JobRequirement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("CourseId");

                    b.Property<long>("JobId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("JobId");

                    b.ToTable("JobsRequirements");
                });

            modelBuilder.Entity("Sabia.Api.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<float>("MoneyEarned");

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<float>("StudyHours");

                    b.Property<float>("TotalHour");

                    b.Property<string>("Username")
                        .HasMaxLength(250);

                    b.Property<float>("WorkedHours");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Sabia.Api.Model.UserCourse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("CourseId");

                    b.Property<float>("Progression");

                    b.Property<float>("UsedHours");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("Sabia.Api.Model.Course", b =>
                {
                    b.HasOne("Sabia.Api.Model.CourseType", "Type")
                        .WithMany("Courses")
                        .HasForeignKey("CourseTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sabia.Api.Model.Course", "RequiredCourse")
                        .WithMany()
                        .HasForeignKey("RequirementCourseId");
                });

            modelBuilder.Entity("Sabia.Api.Model.CourseClass", b =>
                {
                    b.HasOne("Sabia.Api.Model.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sabia.Api.Model.Job", b =>
                {
                    b.HasOne("Sabia.Api.Model.User", "UserDoingJob")
                        .WithOne("CurrentJob")
                        .HasForeignKey("Sabia.Api.Model.Job", "UserId");
                });

            modelBuilder.Entity("Sabia.Api.Model.JobRequirement", b =>
                {
                    b.HasOne("Sabia.Api.Model.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sabia.Api.Model.Job", "Job")
                        .WithMany("Requirements")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sabia.Api.Model.UserCourse", b =>
                {
                    b.HasOne("Sabia.Api.Model.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sabia.Api.Model.User", "User")
                        .WithMany("Courses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
