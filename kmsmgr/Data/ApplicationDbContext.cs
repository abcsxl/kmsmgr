using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using kmsmgr.Models;

namespace kmsmgr.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext(
            DbSet<Role> roles,
            DbSet<User> users,
            DbSet<Permission> permissions,
            DbSet<Department> departments)
        {
            Roles = roles;
            Users = users;
            Permissions = permissions;
            Departments = departments;
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 部门和用户的一对多关系
            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users);

            // 角色和权限的多对多关系
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            // 用户和角色的多对多关系
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>()
               .HasOne(ur => ur.User)
               .WithMany(u => u.UserRoles)
               .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // 用户表的用户名创建索引
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique(true);

            //modelBuilder.Entity<Permission>()
            //    .Property(p => p.Sort)
            //    .ValueGeneratedOnAdd();

            //// 填充默认记录
            //modelBuilder.Entity<User>().HasData(
            //    new User { Id = Guid.NewGuid(), UserName = "admin", Password = "123456", Name = "超级管理员", CreateTime = DateTime.Now, EMail = "admin@admin.com", MobileNumber = "11011112222", CreateUserId = Guid.Empty, DepartmentId = Guid.Empty, LoginCount = 0, IsEnable = true }
            //    );

            //modelBuilder.Entity<Permission>().HasData(
            //    new Permission { Id = Guid.NewGuid(), Sort = 1, Name = "机构管理", Code = "Department", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" },
            //    new Permission { Id = Guid.NewGuid(), Sort = 2, Name = "角色管理", Code = "Role", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" },
            //    new Permission { Id = Guid.NewGuid(), Sort = 3, Name = "用户管理", Code = "User", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" },
            //    new Permission { Id = Guid.NewGuid(), Sort = 4, Name = "功能管理", Code = "Permission", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" }
            //    );


            base.OnModelCreating(modelBuilder);
        }
    }
}
