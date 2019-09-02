using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class District
    {
        public District()
        {
            Subdistrict = new HashSet<Subdistrict>();
        }

        public int DistrictId { get; set; }
        public int ProvinceId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string GeoName { get; set; }
        public string Note { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyUserId { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<Subdistrict> Subdistrict { get; set; }
    }
}
