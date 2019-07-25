using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kmsmgr.Models
{
    public partial class User
    {
        public User()
        {
            this.IsEnable = true;
            this.UserRoles = new HashSet<UserRole>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobileNumber { get; set; }       
        /// <summary>
        /// 创建人Id
        /// </summary>
        public Guid? CreateUserId { get; set; }
        /// <summary>
        /// 所属部门Id
        /// </summary>
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 总登录次数
        /// </summary>
        public int LoginCount { get; set; }
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
        /// 所属部门信息
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// 本用户所具备的所有角色
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
