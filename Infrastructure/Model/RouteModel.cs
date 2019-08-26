using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Infrastructure.Model
{
    public class RouteModel
    {
        public RouteModel() {
        }
        public RouteModel(string controller, string action)
        {
            Controller = controller;
            Action = action;
        }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
