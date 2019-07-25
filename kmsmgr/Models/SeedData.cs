using kmsmgr.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kmsmgr.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User { Id = Guid.NewGuid(), UserName = "admin", Password = "123456", Name = "超级管理员", CreateTime = DateTime.Now, EMail = "admin@admin.com", MobileNumber = "11011112222", CreateUserId = Guid.Empty, DepartmentId = Guid.Empty, LoginCount = 0, IsEnable = true }
                    //new User { Id = Guid.NewGuid(), UserName = "admin", Password = "123456", Name = "超级管理员", EMail = "admin@admin.com", MobileNumber = "11011112222", CreateUserId = Guid.Empty, DepartmentId = Guid.Empty, LoginCount = 0, IsEnable = true }
                    );

                //context.Permissions.AddRange(
                //        new Permission { Id = Guid.NewGuid(), Sort = 1, Name = "机构管理", Code = "Department", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" },
                //        new Permission { Id = Guid.NewGuid(), Sort = 2, Name = "角色管理", Code = "Role", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" },
                //        new Permission { Id = Guid.NewGuid(), Sort = 3, Name = "用户管理", Code = "User", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" },
                //        new Permission { Id = Guid.NewGuid(), Sort = 4, Name = "功能管理", Code = "Permission", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" }

                //        //new Permission { Id = Guid.NewGuid(), Name = "机构管理", Code = "Department", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" },
                //        //new Permission { Id = Guid.NewGuid(), Name = "角色管理", Code = "Role", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" },
                //        //new Permission { Id = Guid.NewGuid(), Name = "用户管理", Code = "User", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" },
                //        //new Permission { Id = Guid.NewGuid(), Name = "功能管理", Code = "Permission", ParentPermissionId = Guid.Empty, Icon = "fa fa-link" }
                //    );

                context.SaveChanges();
            }
        }
    }
}
