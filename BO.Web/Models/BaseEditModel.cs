using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;

namespace Weable.TMS.Web.Models
{
    public class BaseEditModel: BaseModel
    {
        public string ReturnUrl { get; set; }
    }
}
