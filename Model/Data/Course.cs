using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Course
    {
        public Course()
        {
            Training = new HashSet<Training>();
            TrnPrerequisite = new HashSet<TrnPrerequisite>();
        }

        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual User ModifyUser { get; set; }
        public virtual ICollection<Training> Training { get; set; }
        public virtual ICollection<TrnPrerequisite> TrnPrerequisite { get; set; }
    }
}
