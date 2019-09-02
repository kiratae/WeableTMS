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

namespace Weable.TMS.Entity.Repository
{
    public class RegionRepository : BaseRepository, IRegionRepository
    {
        private readonly TMSDBContext _context;
        private readonly ILogger<IRegionRepository> _logger;
        public RegionRepository(TMSDBContext context, ILogger<IRegionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public PagedResult<Region> GetList(RegionFilter filter, Paging paging)
        {
            const string func = "GetList";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var regions = from r in _context.Region
                             select r;
                if (filter.IsActive.HasValue)
                    regions = regions.Where(t => t.IsActive == Convert.ToSByte(filter.IsActive));
                if (!string.IsNullOrEmpty(filter.Name))
                    regions = regions.Where(t => t.Name.ToLower().Contains(filter.Name.ToLower()));

                // Not paging
                if (paging == null)
                {
                    paging = new Paging() {
                        CurrentPage = 1,
                        PageSize = int.MaxValue
                    };
                }

                var result = regions.GetPaged(paging.CurrentPage, paging.PageSize);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<Region> GetData(int? regionId)
        {
            const string func = "GetData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return await _context.Region.FindAsync(regionId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<Region> SaveData(Region region)
        {
            const string func = "SaveData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                if (region.RegionId == 0)
                {
                    _context.Region.Add(region);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Region.Update(region);
                    await _context.SaveChangesAsync();
                }
                return region;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<bool> DeleteData(int? regionId)
        {
            const string func = "DeleteData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var region = await _context.Region.FindAsync(regionId);
                _context.Region.Remove(region);
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
