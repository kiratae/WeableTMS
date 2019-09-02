using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface ISubdistrictRepository
    {
        PagedResult<Subdistrict> GetList(SubdistrictFilter filter, Paging paging);
        Task<Subdistrict> GetData(int? subdistrictId);
        Task<Subdistrict> SaveData(Subdistrict subdistrict);
        Task<bool> DeleteData(int? subdistrictId);
    }
}
