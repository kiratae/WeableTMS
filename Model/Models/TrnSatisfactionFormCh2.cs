using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class TrnSatisfactionFormCh2
    {
        public TrnSatisfactionFormCh2()
        {
            TrnSatisfactionAnswer = new HashSet<TrnSatisfactionAnswer>();
        }

        public int TrnSatisfactionFormCh2Id { get; set; }
        public int TrainingId { get; set; }
        public short OrderNo { get; set; }
        public int? TrnSatisfactionQuestionId { get; set; }
        public string Question { get; set; }

        public virtual Training Training { get; set; }
        public virtual TrnSatisfactionQuestion TrnSatisfactionQuestion { get; set; }
        public virtual ICollection<TrnSatisfactionAnswer> TrnSatisfactionAnswer { get; set; }
    }
}
