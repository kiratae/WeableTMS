using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class TargetMarket
    {
        public TargetMarket()
        {
            TargetMarketMember = new HashSet<TargetMarketMember>();
            Training = new HashSet<Training>();
        }

        public int TargetMarketId { get; set; }
        public string Name { get; set; }
        public sbyte IsPublic { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

        public virtual ICollection<TargetMarketMember> TargetMarketMember { get; set; }
        public virtual ICollection<Training> Training { get; set; }
    }
}
