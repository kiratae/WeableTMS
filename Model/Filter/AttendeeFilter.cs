using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Model.Filter
{
    public class AttendeeFilter
    {
        public string CitizenId { get; set; }
        public string Keyword { get; set; }
        public int? TrainingId { get; set; }
    }
}
