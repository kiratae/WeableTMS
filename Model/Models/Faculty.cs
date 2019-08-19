using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            UniversityCourse = new HashSet<UniversityCourse>();
            User = new HashSet<User>();
        }

        public int FacultyId { get; set; }
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
        public virtual University University { get; set; }
        public virtual ICollection<UniversityCourse> UniversityCourse { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
