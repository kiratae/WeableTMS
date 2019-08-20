using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetList(CourseFilter filter);
        Task<Course> GetData(int? courseId);
        Task<Course> SaveData(Course course);
        Task<bool> DeleteData(int? courseId);
    }
}
