using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.BO.Web.Models
{
    public class CourseModel : BaseModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Training> Training { get; set; }

        public CourseModel()
        {
            Training = new List<Training>();
        }

        public CourseModel(Course course, IMapper mapper)
        {
            mapper.Map(course, this);
        }

        public static List<CourseModel> createModels(IList<Course> courses, IMapper mapper)
        {
            var list = new List<CourseModel>();
            foreach (Course course in courses)
                list.Add(new CourseModel(course, mapper));
            return list;
        }
    }
}
