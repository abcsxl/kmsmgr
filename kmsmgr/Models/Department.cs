using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kmsmgr.Models
{
    public partial class Department
    {
        public Department()
        {
            this.IsEnable = true;
            this.Users = new HashSet<User>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 部门负责人
        /// </summary>
        public string Manager { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactNumber { get; set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public Guid? CreateUserId { get; set; }
        /// <summary>
        /// 上级部门ID
        /// </summary>
        public Guid? ParentDepartmentId { get; set; }
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
        /// 上级部门信息
        /// </summary>
        public virtual Department ParentDepartment { get; set; }
        /// <summary>
        /// 本部门的所有用户列表
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
