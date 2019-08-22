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
    public class TrainingService : BaseService, ITrainingService
    {
        private readonly ILogger<ITrainingService> _logger;
        private readonly ITrainingRepository _repository;
        public TrainingService(ITrainingRepository repository, ILogger<ITrainingService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<bool> DeleteData(int? trainingId)
        {
            const string func = "DeleteData";
            try
            {
                return await _repository.DeleteData(trainingId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
        public async Task<Training> GetData(int? trainingId)
        {
            const string func = "GetData";
            try
            {
                return await _repository.GetData(trainingId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
        public PagedResult<Training> GetList(TrainingFilter filter, Paging paging)
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
        public async Task<Training> SaveData(Training course)
        {
            const string func = "SaveData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return await _repository.SaveData(course);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
