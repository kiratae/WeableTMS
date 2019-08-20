using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Reference
    {
        public string GroupName { get; set; }
        public int ReferenceId { get; set; }
        public short OrderNo { get; set; }
        public string Name { get; set; }
        public string EnUsText { get; set; }
        public string ThThText { get; set; }
    }
}
