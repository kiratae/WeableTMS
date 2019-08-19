using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class Sequence
    {
        public Sequence()
        {
            SequencePeriod = new HashSet<SequencePeriod>();
        }

        public int SequenceId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public byte PeriodPattern { get; set; }
        public byte Len { get; set; }
        public string PrefixPattern { get; set; }
        public string SuffixPattern { get; set; }
        public string Note { get; set; }

        public virtual ICollection<SequencePeriod> SequencePeriod { get; set; }
    }
}
