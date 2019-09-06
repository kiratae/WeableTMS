﻿using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Course
    {
        public Course()
        {
            Prerequisite = new HashSet<Prerequisite>();
            Training = new HashSet<Training>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

        public virtual ICollection<Prerequisite> Prerequisite { get; set; }
        public virtual ICollection<Training> Training { get; set; }
    }
}
