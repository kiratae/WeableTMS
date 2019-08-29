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

        public Person Person { get; set; }
        public Attendee Attendee { get; set; }
        public Training Training { get; set; }
    }
}
