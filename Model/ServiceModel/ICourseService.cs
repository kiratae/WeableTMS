using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.ServiceModel
{
    public interface ICourseService
    {
        PagedResult<Course> GetList(CourseFilter filter, Paging paging);
        Task<Course> GetData(int? courseId);
        Task<Course> SaveData(Course course);
        Task<bool> DeleteData(int? courseId);
    }
}
