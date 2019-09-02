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
    public class ProvinceService : BaseService, IProvinceService
    {
        private readonly ILogger<IProvinceService> _logger;
        private readonly IProvinceRepository _repository;
        public ProvinceService(IProvinceRepository repository, ILogger<IProvinceService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<bool> DeleteData(int? provinceId)
        {
            const string func = "DeleteData";
            try
            {
                return await _repository.DeleteData(provinceId);
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
            try
            {
                return await _repository.GetData(provinceId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
        public PagedResult<Province> GetList(ProvinceFilter filter, Paging paging)
        {
            const string func = "GetList";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return _repository.GetList(filter, paging);
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
                return await _repository.SaveData(province);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
