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
        /// �û���
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// �û�����
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �����ʼ�
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// �ֻ�����
        /// </summary>
        public string MobileNumber { get; set; }       
        /// <summary>
        /// ������Id
        /// </summary>
        public Guid? CreateUserId { get; set; }
        /// <summary>
        /// ��������Id
        /// </summary>
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// ����¼IP
        /// </summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// �ܵ�¼����
        /// </summary>
        public int LoginCount { get; set; }
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
        /// ����������Ϣ
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// ���û����߱������н�ɫ
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
