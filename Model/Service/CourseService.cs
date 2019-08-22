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
    public class CourseService : BaseService, ICourseService
    {
        private readonly ILogger<ICourseService> _logger;
        private readonly ICourseRepository _repository;
        public CourseService(ICourseRepository repository, ILogger<ICourseService> logger)
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
        public async Task<Course> GetData(int? courseId)
        {
            const string func = "GetData";
            try
            {
                return await _repository.GetData(courseId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
        public PagedResult<Course> GetList(CourseFilter filter, Paging paging)
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
        public async Task<Course> SaveData(Course course)
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
