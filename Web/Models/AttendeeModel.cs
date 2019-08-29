using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weable.TMS.Web.Models
{
    public class AttendeeModel
    {
        public AttendeeModel()
        {

        }

        public int? AttendeeId { get; set; }
        public string CitizenId { get; set; }
        public int? PersonId { get; set; }
        public int? TrainingId { get; set; }
        public int AtdStatusId { get; set; }
        public int TrainingResultId { get; set; }
    }
}
