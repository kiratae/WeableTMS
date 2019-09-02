using System;
using System.Collections.Generic;
using System.Text;
using Weable.TMS.Model.Data;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> GetData();
        IEnumerable<Menu> GetData(string UserRole);
    }
}
