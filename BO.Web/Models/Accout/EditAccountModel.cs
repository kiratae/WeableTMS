using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weable.TMS.BO.Web.Models
{
    public class EditAccountModel : BaseEditModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string IsActive { get; set; }

        public EditAccountModel()
        {

        }
    }
}
