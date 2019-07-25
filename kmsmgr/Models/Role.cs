using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace kmsmgr.Models
{
    public class Role
    {
        public Role()
        {
            this.IsEnable = true;
            this.UserRoles = new HashSet<UserRole>();
            this.RolePermissions = new HashSet<RolePermission>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public Guid? CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }
        
        /// <summary>
        /// 创建人信息
        /// </summary>
        public virtual User CreateUser { get; set; }
        /// <summary>
        /// 本角色具备的所有权限列表
        /// </summary>
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        /// <summary>
        /// 具备本角色的所有用户列表
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
