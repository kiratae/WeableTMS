using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Log
    {
        public int LogId { get; set; }
        public DateTime LogDate { get; set; }
        public int LogTypeId { get; set; }
        public sbyte LogResultId { get; set; }
        public string UserId { get; set; }
        public int? FacultyId { get; set; }
        public string RemoteIp { get; set; }
        public string ForwardedIp { get; set; }
        public string Description { get; set; }
    }
}
