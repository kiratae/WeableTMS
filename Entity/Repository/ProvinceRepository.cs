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
    public class ProvinceRepository : BaseRepository, IProvinceRepository
    {
        private readonly TMSDBContext _context;
        private readonly ILogger<IProvinceRepository> _logger;
        public ProvinceRepository(TMSDBContext context, ILogger<IProvinceRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public PagedResult<Province> GetList(ProvinceFilter filter, Paging paging)
        {
            const string func = "GetList";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var provinces = from p in _context.Province
                             select p;
                if (filter.IsActive.HasValue)
                    provinces = provinces.Where(t => t.IsActive == Convert.ToSByte(filter.IsActive));
                if (!string.IsNullOrEmpty(filter.Name))
                    provinces = provinces.Where(t => t.Name.ToLower().Contains(filter.Name.ToLower()));
                if (filter.RegionId.HasValue)
                    provinces = provinces.Where(t => t.RegionId == filter.RegionId);

                // Not paging
                if (paging == null)
                {
                    paging = new Paging() {
                        CurrentPage = 1,
                        PageSize = int.MaxValue
                    };
                }

                var result = provinces.GetPaged(paging.CurrentPage, paging.PageSize);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<Province> GetData(int? provinceId)
        {
            const string func = "GetData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return await _context.Province.FindAsync(provinceId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<Province> SaveData(Province province)
        {
            const string func = "SaveData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                if (province.ProvinceId == 0)
                {
                    _context.Province.Add(province);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Province.Update(province);
                    await _context.SaveChangesAsync();
                }
                return province;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<bool> DeleteData(int? provinceId)
        {
            const string func = "DeleteData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var province = await _context.Province.FindAsync(provinceId);
                _context.Province.Remove(province);
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
