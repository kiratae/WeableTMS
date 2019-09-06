using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.BO.Web.Models
{
    public class ListCourseModel: BaseListModel
    {
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public List<CourseModel> Courses { get; protected set; }

        public ListCourseModel() {
            Courses = new List<CourseModel>();
        }

        public CourseFilter ToCourseFilter()
        {
            var filter = new CourseFilter();
            filter.Name = Name;
            return filter;
        }

        public override Dictionary<string, string> ToPagingParameter(int pageNo)
        {
            return new Dictionary<string, string>
                        {
                            { "Name", Name },
                            { "pageNo", pageNo.ToString() }
                        };
        }
    }
}
