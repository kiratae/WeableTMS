using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Attendee
    {
        public Attendee()
        {
            AttendeeScore = new HashSet<AttendeeScore>();
        }

        public int AttendeeId { get; set; }
        public string CitizenId { get; set; }
        public int PersonId { get; set; }
        public int TrainingId { get; set; }
        public sbyte AtdStatusId { get; set; }
        public DateTime? Registeration { get; set; }
        public sbyte TrainingResultId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Training Training { get; set; }
        public virtual ICollection<AttendeeScore> AttendeeScore { get; set; }
    }
}
