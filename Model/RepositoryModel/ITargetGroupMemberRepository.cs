using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface ITargetGroupMemberRepository
    {
        PagedResult<TargetGroupMember> GetList(TargetGroupMemberFilter filter, Paging paging);
        Task<TargetGroupMember> GetData(int? targetGroupMemberId);
        Task<TargetGroupMember> SaveData(TargetGroupMember targetGroupMember);
        Task<bool> DeleteData(int? targetGroupMemberId);
    }
}
