using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.BO.Web.Models
{
    public class EditCourseModel : BaseEditModel
    {
        public int? CourseId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public EditCourseModel()
        {
            IsActive = true;
        }

        public EditCourseModel(Course course, IMapper mapper)
          : this()
        {
            mapper.Map(course, this, typeof(Course), typeof(EditCourseModel));
        }

        public Course ToDataModel(IMapper mapper, Course course = null)
        {
            return mapper.Map(this, course == null ? new Course() : course);
        }

    }
}
