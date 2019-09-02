using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Model.Filter
{
    public class SubdistrictFilter
    {
        public string Name { get; set; }
        public int? DistrictId { get; set; }
        public bool? IsActive { get; set; }
        
    }
}
