using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.RepositoryModel;
using Weable.TMS.Model.ServiceModel;

namespace Weable.TMS.Model.Service
{
    public class TargetGroupService : BaseService, ITargetGroupService
    {
        private readonly ILogger<ICourseService> _logger;
        private readonly ITargetGroupRepository _repository;
        public TargetGroupService(
            ITargetGroupRepository repository,
            ILogger<ICourseService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> DeleteData(int? targetGroupId)
        {
            const string func = "DeleteData";
            try
            {
                return await _repository.DeleteData(targetGroupId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public Task<bool> DeleteMemberData(int? targetGroupMemberId)
        {
            throw new NotImplementedException();
        }

        public async Task<TargetGroup> GetData(int? targetGroupId)
        {
            const string func = "GetData";
            try
            {
                return await _repository.GetData(targetGroupId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public PagedResult<TargetGroup> GetList(TargetGroupFilter filter, Paging paging)
        {
            const string func = "GetList";
            try
            {
                return  _repository.GetList(filter, paging);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public Task<TargetGroupMember> GetMemberData(int? targetGroupMemberId)
        {
            throw new NotImplementedException();
        }

        public PagedResult<TargetGroupMember> GetMemberList(TargetGroupMemberFilter filter, Paging paging)
        {
            throw new NotImplementedException();
        }

        public async Task<TargetGroup> SaveData(TargetGroup targetGroup)
        {
            const string func = "SaveData";
            try
            {
                return await _repository.SaveData(targetGroup);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public Task<TargetGroupMember> SaveMemberData(TargetGroupMember targetGroupMember)
        {
            throw new NotImplementedException();
        }
    }
}
