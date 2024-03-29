﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kmsmgr.Data;

namespace kmsmgr.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190726054732_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("kmsmgr.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("ContactNumber");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreateUserId");

                    b.Property<bool>("IsEnable");

                    b.Property<string>("Manager");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("534eec64-c8e3-4748-8353-1abe6ed5ad2b"),
                            Code = "root",
                            CreateTime = new DateTime(2019, 7, 26, 13, 47, 32, 214, DateTimeKind.Local).AddTicks(4718),
                            IsEnable = true,
                            Name = "全国密钥管理中心",
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("kmsmgr.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Icon");

                    b.Property<bool>("IsEnable");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("Remarks");

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("91ebc230-277f-4666-ad1f-daf4bdaad9b4"),
                            Code = "Department",
                            Icon = "fa fa-link",
                            IsEnable = true,
                            Name = "机构管理",
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Sort = 1
                        },
                        new
                        {
                            Id = new Guid("5a52c006-6f34-4787-9598-0409282cfeee"),
                            Code = "Role",
                            Icon = "fa fa-link",
                            IsEnable = true,
                            Name = "角色管理",
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Sort = 2
                        },
                        new
                        {
                            Id = new Guid("e7f397a2-d387-4325-ae20-ef616f4929d5"),
                            Code = "User",
                            Icon = "fa fa-link",
                            IsEnable = true,
                            Name = "用户管理",
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Sort = 3
                        },
                        new
                        {
                            Id = new Guid("8fcdec2b-d6b9-43e5-9523-8f62779e42fd"),
                            Code = "Permission",
                            Icon = "fa fa-link",
                            IsEnable = true,
                            Name = "功能管理",
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Sort = 4
                        });
                });

            modelBuilder.Entity("kmsmgr.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreateUserId");

                    b.Property<bool>("IsEnable");

                    b.Property<string>("Name");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("kmsmgr.Models.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("PermissionId");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("kmsmgr.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreateUserId");

                    b.Property<Guid?>("DepartmentId");

                    b.Property<string>("EMail");

                    b.Property<bool>("IsEnable");

                    b.Property<string>("LastLoginIP");

                    b.Property<DateTime?>("LastLoginTime")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("LoginCount");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Name");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Remarks");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6d4f6ce-67af-47fa-a96c-85b842eb5349"),
                            CreateTime = new DateTime(2019, 7, 26, 13, 47, 32, 217, DateTimeKind.Local).AddTicks(3560),
                            CreateUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            DepartmentId = new Guid("534eec64-c8e3-4748-8353-1abe6ed5ad2b"),
                            EMail = "admin@admin.com",
                            IsEnable = true,
                            LoginCount = 0,
                            MobileNumber = "11011112222",
                            Name = "超级管理员",
                            Password = "123456",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("kmsmgr.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("kmsmgr.Models.RolePermission", b =>
                {
                    b.HasOne("kmsmgr.Models.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("kmsmgr.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("kmsmgr.Models.User", b =>
                {
                    b.HasOne("kmsmgr.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("kmsmgr.Models.UserRole", b =>
                {
                    b.HasOne("kmsmgr.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("kmsmgr.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
