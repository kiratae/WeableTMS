using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class TargetMarketMember
    {
        public int TargetMarketMemberId { get; set; }
        public int TargetMarketId { get; set; }
        public string Identification { get; set; }
        public string VerifyCode { get; set; }
        public string CitizenId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }

        public virtual TargetMarket TargetMarket { get; set; }
    }
}
