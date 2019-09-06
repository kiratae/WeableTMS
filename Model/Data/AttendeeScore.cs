using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class AttendeeScore
    {
        public int AttendeeScoreId { get; set; }
        public int AttendeeId { get; set; }
        public int TrnResultScoreId { get; set; }
        public decimal Score { get; set; }

        public virtual Attendee Attendee { get; set; }
        public virtual TrnResultScore TrnResultScore { get; set; }
    }
}
