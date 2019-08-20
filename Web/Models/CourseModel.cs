using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.Web.Models
{
    public class CourseModel : BaseModel
    {
        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public CourseModel()
        {
        }

        public CourseModel(Course course)
        {
            CourseId = course.CourseId;
            Code = course.Code;
            Name = course.Name;
            IsActive = course.IsActive == 1 ? true : false;
        }

        public static List<CourseModel> createModels(List<Course> courses)
        {
            var list = new List<CourseModel>();
            foreach (Course course in courses)
            {
                list.Add(new CourseModel(course));
            }
            return list;
        }
    }
}
