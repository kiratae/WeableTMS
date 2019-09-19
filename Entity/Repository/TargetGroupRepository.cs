using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Infrastructure.Extension;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.RepositoryModel;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Weable.TMS.Entity.Repository
{
    public class TargetGroupRepository : BaseRepository, ITargetGroupRepository
    {
        private readonly TMSDBContext _context;
        private readonly ILogger<ITargetGroupRepository> _logger;
        public TargetGroupRepository(TMSDBContext context, ILogger<ITargetGroupRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public PagedResult<TargetGroup> GetList(TargetGroupFilter filter, Paging paging)
        {
            const string func = "GetList";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                //var courses = from c in _context.Course
                //              select c;
                var targetGroups = _context.TargetGroup.Include(t => t.TargetGroupMember).AsNoTracking();
                if (filter.IsActive.HasValue)
                    targetGroups = targetGroups.Where(t => t.IsActive == Convert.ToSByte(filter.IsActive));
                if (!string.IsNullOrEmpty(filter.Name))
                    targetGroups = targetGroups.Where(t => t.Name.ToLower().Contains(filter.Name.ToLower()));

                // Not paging
                if (paging == null)
                {
                    paging = new Paging()
                    {
                        CurrentPage = 1,
                        PageSize = int.MaxValue
                    };
                }

                var result = targetGroups.GetPaged(paging.CurrentPage, paging.PageSize);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<TargetGroup> GetData(int? targetGroupId)
        {
            const string func = "GetData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return await _context.TargetGroup.Include(t => t.TargetGroupMember).Where(t => t.TargetGroupId == targetGroupId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<TargetGroup> SaveData(TargetGroup targetGroup)
        {
            const string func = "SaveData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                if (targetGroup.TargetGroupId == 0)
                {
                    foreach (var m in targetGroup.TargetGroupMember)
                    {
                        m.CreateDate = DateTime.Now;
                        m.CreateUserId = 1;
                        _context.TargetGroupMember.Add(m);
                    }
                    targetGroup.CreateDate = DateTime.Now;
                    targetGroup.CreateUserId = 1;
                    _context.TargetGroup.Add(targetGroup);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.TargetGroup.Update(targetGroup);
                    foreach (var m in targetGroup.TargetGroupMember)
                    {
                        _context.TargetGroupMember.Update(m);
                    }
                    await _context.SaveChangesAsync();
                }
                return targetGroup;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<bool> DeleteData(int? targetGroupId)
        {
            const string func = "DeleteData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var training = await _context.Training.Where(t => t.TargetGroupId == targetGroupId).ToArrayAsync();
                foreach (var t in training)
                {
                    t.TargetGroupId = null;
                }
                _context.Training.UpdateRange(training);
                var targetGroup = await _context.TargetGroup.Include(t => t.TargetGroupMember).Where(t => t.TargetGroupId == targetGroupId).FirstOrDefaultAsync();
                _context.TargetGroupMember.RemoveRange(targetGroup.TargetGroupMember);
                _context.TargetGroup.Remove(targetGroup);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

    }
}
