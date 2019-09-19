using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface ITargetGroupRepository
    {
        PagedResult<TargetGroup> GetList(TargetGroupFilter filter, Paging paging);
        Task<TargetGroup> GetData(int? targetGroupId);
        Task<TargetGroup> SaveData(TargetGroup targetGroup);
        Task<bool> DeleteData(int? targetGroupId);
    }
}
