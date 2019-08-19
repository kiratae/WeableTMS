using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class Securable
    {
        public Securable()
        {
            InverseParent = new HashSet<Securable>();
            InverseRoot = new HashSet<Securable>();
            SecurablePermission = new HashSet<SecurablePermission>();
        }

        public int SecurableId { get; set; }
        public int ApplicationId { get; set; }
        public byte SecurableType { get; set; }
        public short OrderNo { get; set; }
        public string Name { get; set; }
        public string Signature { get; set; }
        public string Data { get; set; }
        public sbyte IsExcluded { get; set; }
        public sbyte IsActive { get; set; }
        public int? ParentId { get; set; }
        public int? RootId { get; set; }

        public virtual Application Application { get; set; }
        public virtual Securable Parent { get; set; }
        public virtual Securable Root { get; set; }
        public virtual ICollection<Securable> InverseParent { get; set; }
        public virtual ICollection<Securable> InverseRoot { get; set; }
        public virtual ICollection<SecurablePermission> SecurablePermission { get; set; }
    }
}
