using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class TrnResultScore
    {
        public TrnResultScore()
        {
            AttendeeScore = new HashSet<AttendeeScore>();
        }

        public int TrnResultScoreId { get; set; }
        public int TrainingId { get; set; }
        public string Name { get; set; }
        public int MaxScore { get; set; }
        public int ScoreRatio { get; set; }

        public virtual Training Training { get; set; }
        public virtual ICollection<AttendeeScore> AttendeeScore { get; set; }
    }
}
