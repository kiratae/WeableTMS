using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class RoleMember
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public sbyte IsSystem { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
