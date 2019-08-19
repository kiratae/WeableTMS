using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleMember = new HashSet<RoleMember>();
            SecurablePermission = new HashSet<SecurablePermission>();
        }

        public int RoleId { get; set; }
        public int ApplicationId { get; set; }
        public short OrderNo { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public sbyte IsActive { get; set; }
        public sbyte IsSystem { get; set; }

        public virtual Application Application { get; set; }
        public virtual ICollection<RoleMember> RoleMember { get; set; }
        public virtual ICollection<SecurablePermission> SecurablePermission { get; set; }
    }
}
