using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface IDistrictRepository
    {
        PagedResult<District> GetList(DistrictFilter filter, Paging paging);
        Task<District> GetData(int? districtId);
        Task<District> SaveData(District district);
        Task<bool> DeleteData(int? districtId);
    }
}
