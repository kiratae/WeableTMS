using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Menu
    {
        public int MenuId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string UserRole { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyUserId { get; set; }
    }
}
