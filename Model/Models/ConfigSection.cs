using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class ConfigSection
    {
        public ConfigSection()
        {
            Configuration = new HashSet<Configuration>();
        }

        public int ConfigSectionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Configuration> Configuration { get; set; }
    }
}
