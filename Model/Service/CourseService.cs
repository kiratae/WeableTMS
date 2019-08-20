using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        private readonly ICourseRepository _courseRepo;
        public CourseService(ICourseRepository courseRepository, ILogger<ICourseService> logger)
        {
            _courseRepo = courseRepository;
            _logger = logger;
        }
        public async Task<bool> DeleteData(int? courseId)
        {
            const string func = "DeleteData";
            try
            {
                return await _courseRepo.DeleteData(courseId);
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
                return await _courseRepo.GetData(courseId);
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
                return _courseRepo.GetList(filter, paging);
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
                return await _courseRepo.SaveData(course);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
