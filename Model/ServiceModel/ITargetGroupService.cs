using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.ServiceModel
{
    public interface ITargetGroupService
    {
        PagedResult<TargetGroup> GetList(TargetGroupFilter filter, Paging paging);
        Task<TargetGroup> GetData(int? targetGroupId);
        Task<TargetGroup> SaveData(TargetGroup targetGroup);
        Task<bool> DeleteData(int? targetGroupId);

        PagedResult<TargetGroupMember> GetMemberList(TargetGroupMemberFilter filter, Paging paging);
        Task<TargetGroupMember> GetMemberData(int? targetGroupMemberId);
        Task<TargetGroupMember> SaveMemberData(TargetGroupMember targetGroupMember);
        Task<bool> DeleteMemberData(int? targetGroupMemberId);
    }
}
