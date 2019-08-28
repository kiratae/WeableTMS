using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class SecurablePermission
    {
        public int SecurablePermissionId { get; set; }
        public int SecurableId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public sbyte IsSystem { get; set; }

        public virtual Securable Securable { get; set; }
        public virtual User User { get; set; }
    }
}
