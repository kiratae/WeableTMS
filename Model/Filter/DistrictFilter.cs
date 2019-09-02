using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Model.Filter
{
    public class DistrictFilter
    {
        public string Name { get; set; }
        public int? ProvinceId { get; set; }
        public bool? IsActive { get; set; }
        
    }
}
