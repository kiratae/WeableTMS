using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.ServiceModel
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetList(CourseFilter filter);
        Task<Course> GetData(int? courseId);
        Task<Course> SaveData(Course course);
        Task<bool> DeleteData(int? courseId);
    }
}
