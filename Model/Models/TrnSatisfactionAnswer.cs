using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class TrnSatisfactionAnswer
    {
        public int TrnSatisfactionAnswerId { get; set; }
        public int TrnSatisfactionFormId { get; set; }
        public int TrnSatisfactionFormCh2Id { get; set; }
        public int TrnSatisfactionCh2Answer { get; set; }

        public virtual TrnSatisfactionForm TrnSatisfactionForm { get; set; }
        public virtual TrnSatisfactionFormCh2 TrnSatisfactionFormCh2 { get; set; }
    }
}
