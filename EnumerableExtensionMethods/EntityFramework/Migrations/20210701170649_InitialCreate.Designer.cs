﻿// <auto-generated />
using System;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFramework.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210701170649_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("Domain.ClassMember", b =>
                {
                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClassId", "MemberId");

                    b.HasIndex("MemberId");

                    b.ToTable("ClassMember");
                });

            modelBuilder.Entity("Domain.Facility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Facility");
                });

            modelBuilder.Entity("Domain.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Domain.Class", b =>
                {
                    b.HasOne("Domain.Facility", "Facility")
                        .WithMany("Bookings")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("Domain.ClassMember", b =>
                {
                    b.HasOne("Domain.Class", "Class")
                        .WithMany("Members")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Member", "Member")
                        .WithMany("Classes")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Domain.Class", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Domain.Facility", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Domain.Member", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}
