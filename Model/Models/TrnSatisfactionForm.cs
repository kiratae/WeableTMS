using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class TrnSatisfactionForm
    {
        public TrnSatisfactionForm()
        {
            TrnSatisfactionAnswer = new HashSet<TrnSatisfactionAnswer>();
        }

        public int TrnSatisfactionFormId { get; set; }
        public int TrainingId { get; set; }
        public sbyte? Ch1GenderType { get; set; }
        public sbyte? Ch1AgeRangeTypeId { get; set; }
        public sbyte? Ch1KnowTrainingTypeId { get; set; }
        public string Ch1KnowTrainingNote { get; set; }
        public string Ch3Note { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Training Training { get; set; }
        public virtual ICollection<TrnSatisfactionAnswer> TrnSatisfactionAnswer { get; set; }
    }
}
