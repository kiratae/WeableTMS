using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weable.TMS.BO.Web.Models
{
    public class TargetGroupMemberModel
    {
        public int? TargetGroupMemberId { get; set; }
        public int? TargetGroupId { get; set; }
        public string Identification { get; set; }
        public string VerifyCode { get; set; }
        public string CitizenId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
    }
}
