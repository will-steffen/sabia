﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sabia.Api;

namespace Sabia.Api.Migrations
{
    [DbContext(typeof(SabiaContext))]
    [Migration("20181103170102_user-skill")]
    partial class userskill
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sabia.Api.Model.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Sabia.Api.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<string>("Password")
                        .HasMaxLength(250);

                    b.Property<string>("Username")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Sabia.Api.Model.UserSkill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("Level");

                    b.Property<long>("SkillId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkill");
                });

            modelBuilder.Entity("Sabia.Api.Model.UserSkill", b =>
                {
                    b.HasOne("Sabia.Api.Model.Skill", "Skill")
                        .WithMany("UserSkillList")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sabia.Api.Model.User", "User")
                        .WithMany("UserSkillList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
