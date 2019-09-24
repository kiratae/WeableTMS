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
    public class PersonService : BaseService, IPersonService
    {
        private readonly ILogger<IPersonService> _logger;
        private readonly IPersonRepository _repository;
        public PersonService(IPersonRepository repository, ILogger<IPersonService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<bool> DeleteData(int? courseId)
        {
            const string func = "DeleteData";
            try
            {
                return await _repository.DeleteData(courseId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
        public async Task<Person> GetData(int? personId)
        {
            const string func = "GetData";
            try
            {
                return await _repository.GetData(personId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
        public PagedResult<Person> GetList(PersonFilter filter, Paging paging)
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
        public async Task<Person> SaveData(Person person)
        {
            const string func = "SaveData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return await _repository.SaveData(person);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
