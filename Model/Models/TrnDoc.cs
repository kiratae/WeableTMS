using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class TrnDoc
    {
        public int TrnDocId { get; set; }
        public int TrainingId { get; set; }
        public int FileId { get; set; }
        public string Note { get; set; }

        public virtual File File { get; set; }
        public virtual Training Training { get; set; }
    }
}
