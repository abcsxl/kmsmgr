using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kmsmgr.Models
{ 
    public partial class Permission
    {
        public Permission()
        {
            this.IsEnable = true;
            this.RolePermissions = new HashSet<RolePermission>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sort { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 权限编码
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// 权限地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 权限图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 上级权限ID
        /// </summary>
        public Guid? ParentPermissionId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 上级权限信息
        /// </summary>
        public virtual Permission ParentPermission { get; set; }
        /// <summary>
        /// 具备本权限的所有角色列表
        /// </summary>
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
