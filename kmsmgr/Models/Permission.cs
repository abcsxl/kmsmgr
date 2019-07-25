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
        /// ���
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sort { get; set; }
        /// <summary>
        /// Ȩ������
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Ȩ�ޱ���
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// Ȩ�޵�ַ
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Ȩ��ͼ��
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// �ϼ�Ȩ��ID
        /// </summary>
        public Guid? ParentPermissionId { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// �ϼ�Ȩ����Ϣ
        /// </summary>
        public virtual Permission ParentPermission { get; set; }
        /// <summary>
        /// �߱���Ȩ�޵����н�ɫ�б�
        /// </summary>
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
