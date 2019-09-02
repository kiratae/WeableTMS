using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Title
    {
        public Title()
        {
            Person = new HashSet<Person>();
        }

        public int TitleId { get; set; }
        public short OrderNo { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyUserId { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
