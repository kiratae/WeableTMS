using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class Application
    {
        public Application()
        {
            Role = new HashSet<Role>();
            Securable = new HashSet<Securable>();
        }

        public int ApplicationId { get; set; }
        public short OrderNo { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<Securable> Securable { get; set; }
    }
}
