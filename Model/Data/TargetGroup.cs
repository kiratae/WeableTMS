using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class TargetGroup
    {
        public TargetGroup()
        {
            TargetGroupMember = new HashSet<TargetGroupMember>();
            Training = new HashSet<Training>();
        }

        public int TargetGroupId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

        public virtual ICollection<TargetGroupMember> TargetGroupMember { get; set; }
        public virtual ICollection<Training> Training { get; set; }
    }
}
