using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weable.TMS.BO.Web.Models
{
    public class ListAttendeeModel: BaseListModel
    {
        public ListAttendeeModel()
        {

        }

        public int? TrainingId { get; set; }
        public TrainingModel Training { get; set; }
    }
}
