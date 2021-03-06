﻿// <auto-generated />
using System;
using DataAccessLayer.AppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190504182458_Role")]
    partial class Role
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entity.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AuthorId")
                        .HasColumnName("AuthorID");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("CreateAt");

                    b.Property<bool>("Deleted")
                        .HasColumnName("Deleted");

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<decimal>("Rate")
                        .HasColumnName("Rate");

                    b.Property<int>("Status")
                        .HasColumnName("Status");

                    b.Property<string>("Title")
                        .HasColumnName("Title");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnName("UpdateAt");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Core.Entity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Core.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .HasColumnName("Password");

                    b.Property<Guid?>("RoleId");

                    b.Property<string>("Username")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Core.Entity.Project", b =>
                {
                    b.HasOne("Core.Entity.User", "Author")
                        .WithMany("Projects")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("Core.Entity.User", b =>
                {
                    b.HasOne("Core.Entity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
