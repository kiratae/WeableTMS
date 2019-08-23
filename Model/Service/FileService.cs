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
    public class FileService: BaseService, IFileService
    {
        private readonly ILogger<IFileService> _logger;
        private readonly IFileRepository _repository;
        public FileService(IFileRepository repository, ILogger<IFileService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> DeleteData(int fileId)
        {
            const string func = "DeleteData";
            try
            {
                return await _repository.DeleteData(fileId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<File> GetData(int fileId)
        {
            const string func = "GetData";
            try
            {
                return await _repository.GetData(fileId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<File> SaveData(File file)
        {
            const string func = "SaveData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return await _repository.SaveData(file);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
