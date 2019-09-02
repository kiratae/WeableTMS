using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class UniversityCourse
    {
        public UniversityCourse()
        {
            Person = new HashSet<Person>();
        }

        public int UniversityCourseId { get; set; }
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public string DegreeName { get; set; }
        public sbyte UniversityCourseTypeId { get; set; }
        public string Note { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyUserId { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
