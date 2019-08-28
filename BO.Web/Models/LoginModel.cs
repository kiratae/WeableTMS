using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Weable.TMS.Web.Models
{
    public class LoginModel
    {
        [DisplayName("ชื่อผู้ใช้")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("รหัสผ่าน")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
