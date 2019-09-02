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
    public class DistrictRepository : BaseRepository, IDistrictRepository
    {
        private readonly TMSDBContext _context;
        private readonly ILogger<IDistrictRepository> _logger;
        public DistrictRepository(TMSDBContext context, ILogger<IDistrictRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public PagedResult<District> GetList(DistrictFilter filter, Paging paging)
        {
            const string func = "GetList";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var districts = from d in _context.District
                             select d;
                if (filter.IsActive.HasValue)
                    districts = districts.Where(t => t.IsActive == Convert.ToSByte(filter.IsActive));
                if (!string.IsNullOrEmpty(filter.Name))
                    districts = districts.Where(t => t.Name.ToLower().Contains(filter.Name.ToLower()));
                if (filter.ProvinceId.HasValue)
                    districts = districts.Where(t => t.ProvinceId == filter.ProvinceId);

                // Not paging
                if (paging == null)
                {
                    paging = new Paging() {
                        CurrentPage = 1,
                        PageSize = int.MaxValue
                    };
                }

                var result = districts.GetPaged(paging.CurrentPage, paging.PageSize);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<District> GetData(int? districtId)
        {
            const string func = "GetData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return await _context.District.FindAsync(districtId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<District> SaveData(District district)
        {
            const string func = "SaveData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                if (district.DistrictId == 0)
                {
                    _context.District.Add(district);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.District.Update(district);
                    await _context.SaveChangesAsync();
                }
                return district;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<bool> DeleteData(int? districtId)
        {
            const string func = "DeleteData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var district = await _context.District.FindAsync(districtId);
                _context.District.Remove(district);
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
