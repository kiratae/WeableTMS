using System;
using System.Collections.Generic;
using System.Text;
using Weable.TMS.Model.Data;

namespace Weable.TMS.Model.ServiceModel
{
    public interface IMenuService
    {
        IEnumerable<Menu> GetData();
        IEnumerable<Menu> GetData(string UserRole);
    }
}
