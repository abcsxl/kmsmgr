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
        /// ��������
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// ���ű��
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ���Ÿ�����
        /// </summary>
        public string Manager { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string ContactNumber { get; set; }
        /// <summary>
        /// ������Id
        /// </summary>
        public Guid? CreateUserId { get; set; }
        /// <summary>
        /// �ϼ�����ID
        /// </summary>
        public Guid? ParentDepartmentId { get; set; }
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
        /// �ϼ�������Ϣ
        /// </summary>
        public virtual Department ParentDepartment { get; set; }
        /// <summary>
        /// �����ŵ������û��б�
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
