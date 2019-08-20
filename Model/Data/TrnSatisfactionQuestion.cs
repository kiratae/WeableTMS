using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class TrnSatisfactionQuestion
    {
        public TrnSatisfactionQuestion()
        {
            TrnSatisfactionFormCh2 = new HashSet<TrnSatisfactionFormCh2>();
        }

        public int TrnSatisfactionQuestionId { get; set; }
        public short OrderNo { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual User ModifyUser { get; set; }
        public virtual ICollection<TrnSatisfactionFormCh2> TrnSatisfactionFormCh2 { get; set; }
    }
}
