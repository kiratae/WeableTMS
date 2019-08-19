using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class Subdistrict
    {
        public Subdistrict()
        {
            Person = new HashSet<Person>();
        }

        public int SubdistrictId { get; set; }
        public int DistrictId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string GeoName { get; set; }
        public string Note { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual District District { get; set; }
        public virtual User ModifyUser { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
