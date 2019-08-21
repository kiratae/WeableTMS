using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;

namespace Weable.TMS.Web.Models
{
    public class BaseEditModel: BaseModel
    {
        public BaseEditModel()
        {
            Route = new RouteModel();
        }
        public virtual RouteModel Route { get; set; }

        public void setRoute(string controller, string action)
        {
            Route.Controller = controller;
            Route.Action = action;
        }
    }
}
