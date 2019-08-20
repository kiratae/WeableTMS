using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class University
    {
        public University()
        {
            Faculty = new HashSet<Faculty>();
        }

        public int UniversityId { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public string Note { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual User ModifyUser { get; set; }
        public virtual ICollection<Faculty> Faculty { get; set; }
    }
}
