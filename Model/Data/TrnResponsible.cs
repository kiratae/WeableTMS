using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class TrnResponsible
    {
        public int TrnResponsibleId { get; set; }
        public int TrainingId { get; set; }
        public string ResponsibleName { get; set; }

        public virtual Training Training { get; set; }
    }
}
