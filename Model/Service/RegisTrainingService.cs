using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.RepositoryModel;
using Weable.TMS.Model.ServiceModel;

namespace Weable.TMS.Model.Service
{
    public class RegisTrainingService : BaseService, IRegisTrainingService
    {
        private readonly ILogger<IRegisTrainingService> _logger;
        private readonly IRegisTrainingRepository _repository;

        public RegisTrainingService(IRegisTrainingRepository repository, ILogger<IRegisTrainingService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public RegisTraining CheckRepeat(string citizenId, int? trainingId)
        {
            const string func = "CheckRepeat";
            try
            {
                return _repository.CheckRepeat(citizenId, trainingId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public RegisTraining Authentication(string identification, string verifyCode, int? trainingId)
        {
            const string func = "Authentication";
            try
            {
                return _repository.Authentication(identification, verifyCode, trainingId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public bool CheckTrnPrerequisite(string citizenId, int? trainingId)
        {
            const string func = "CheckTrnPrerequisite";
            try
            {
                return _repository.CheckTrnPrerequisite(citizenId, trainingId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public int GetAttendeeQty(int trainingId)
        {
            const string func = "CheckRepeatRegis";
            try
            {
                return _repository.GetAttendeeQty(trainingId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public RegisTraining GetRegisTraining(string citizenId, int? targetGroupId)
        {
            const string func = "GetRegisTraining";
            try
            {
                return _repository.GetRegisTraining(citizenId, targetGroupId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<RegisTraining> SaveRegisTraining(RegisTraining regisTraining)
        {
            const string func = "SaveRegisTraining";
            try
            {
                return await _repository.SaveRegisTraining(regisTraining);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
