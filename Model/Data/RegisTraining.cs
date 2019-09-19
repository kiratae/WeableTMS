using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Model.Data
{
    public class RegisTraining
    {
        public RegisTraining()
        {

        }

        public TargetGroupMember TargetGroupMember { get; set; }
        public Person Person { get; set; }
        public Attendee Attendee { get; set; }
        public Training Training { get; set; }
    }
}
