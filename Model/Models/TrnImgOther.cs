using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class TrnImgOther
    {
        public int TrnImgOtherId { get; set; }
        public int TrainingId { get; set; }
        public int FileId { get; set; }
        public string Note { get; set; }

        public virtual File File { get; set; }
        public virtual Training Training { get; set; }
    }
}
