using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class File
    {
        public File()
        {
            Training = new HashSet<Training>();
        }

        public int FileId { get; set; }
        public string FileGuid { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public int FileSize { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public sbyte IsTemp { get; set; }

        public virtual ICollection<Training> Training { get; set; }
    }
}
