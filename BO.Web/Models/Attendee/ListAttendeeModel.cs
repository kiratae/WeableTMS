using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.BO.Web.Models
{
    public class ListAttendeeModel: BaseListModel
    {
        public ListAttendeeModel()
        {
            Attendees = new List<AttendeeModel>();
        }

        public int? TrainingId { get; set; }
        public string CitizenId { get; set; }
        public string Keyword { get; set; }
        public TrainingModel Training { get; set; }
        public List<AttendeeModel> Attendees { get; set; }

        public AttendeeFilter ToAttendeeFilter() 
        {
            return new AttendeeFilter() 
            {
                CitizenId = CitizenId,
                Keyword = Keyword,
                TrainingId = TrainingId
            };
        }
    }
}
