using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class SequencePeriod
    {
        public int SequencePeriodId { get; set; }
        public int SequenceId { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }
        public int NextNumber { get; set; }
        public byte Len { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Note { get; set; }

        public virtual Sequence Sequence { get; set; }
    }
}
