using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.RepositoryModel;
using Weable.TMS.Model.ServiceModel;

namespace Weable.TMS.Model.Service
{
    public class MenuService : BaseService, IMenuService
    {
        private readonly ILogger<IMenuService> _logger;
        private readonly IMenuRepository _repository;
        public MenuService(IMenuRepository repository, ILogger<IMenuService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public IEnumerable<Menu> GetData()
        {
            const string func = "GetData";
            try
            {
                return _repository.GetData();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public IEnumerable<Menu> GetData(string UserRole)
        {
            const string func = "GetData";
            try
            {
                return _repository.GetData(UserRole);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
