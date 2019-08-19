using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class TrnPrerequisite
    {
        public int TrnPrerequisiteId { get; set; }
        public int TrainingId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Training Training { get; set; }
    }
}
