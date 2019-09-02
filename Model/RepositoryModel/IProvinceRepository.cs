using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface IProvinceRepository
    {
        PagedResult<Province> GetList(ProvinceFilter filter, Paging paging);
        Task<Province> GetData(int? provinceId);
        Task<Province> SaveData(Province province);
        Task<bool> DeleteData(int? provinceId);
    }
}
