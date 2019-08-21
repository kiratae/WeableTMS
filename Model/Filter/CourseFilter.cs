using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Model.Filter
{
    public class CourseFilter
    {
        public string Code { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
    }
}
