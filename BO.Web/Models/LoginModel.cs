using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Weable.TMS.BO.Web.Models
{
    public class LoginModel
    {
        [Required]
        [DisplayName("ชื่อผู้ใช้")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("รหัสผ่าน")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
