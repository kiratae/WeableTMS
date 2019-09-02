using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface IRegionRepository
    {
        PagedResult<Region> GetList(RegionFilter filter, Paging paging);
        Task<Region> GetData(int? regionId);
        Task<Region> SaveData(Region region);
        Task<bool> DeleteData(int? regionId);
    }
}
