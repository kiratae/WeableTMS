using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Configuration
    {
        public int ConfigurationId { get; set; }
        public int ConfigSectionId { get; set; }
        public short OrderNo { get; set; }
        public string Name { get; set; }
        public byte DataType { get; set; }
        public string DefaultValue { get; set; }
        public string Value { get; set; }

        public virtual ConfigSection ConfigSection { get; set; }
    }
}
