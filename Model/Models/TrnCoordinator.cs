using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class TrnCoordinator
    {
        public int TrnCoordinatorId { get; set; }
        public int TrainingId { get; set; }
        public string CoordinatorName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public virtual Training Training { get; set; }
    }
}
