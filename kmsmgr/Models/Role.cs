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
        /// ��ɫ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// ������Id
        /// </summary>
        public Guid? CreateUserId { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsEnable { get; set; }
        
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        public virtual User CreateUser { get; set; }
        /// <summary>
        /// ����ɫ�߱�������Ȩ���б�
        /// </summary>
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        /// <summary>
        /// �߱�����ɫ�������û��б�
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
