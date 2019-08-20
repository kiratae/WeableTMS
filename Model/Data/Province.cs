using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Province
    {
        public Province()
        {
            District = new HashSet<District>();
        }

        public int ProvinceId { get; set; }
        public int? RegionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string GeoName { get; set; }
        public string Note { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual User ModifyUser { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<District> District { get; set; }
    }
}
