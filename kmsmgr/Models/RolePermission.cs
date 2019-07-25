using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kmsmgr.Models
{
    public class RolePermission
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
