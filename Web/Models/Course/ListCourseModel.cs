using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Web.Models
{
    public class ListCourseModel: BaseListModel
    {
        public string Keyword { get; set; }
        public List<CourseModel> Courses { get; set; }

        public ListCourseModel() {
            Courses = new List<CourseModel>();
        }

        public CourseFilter ToCourseFilter()
        {
            var filter = new CourseFilter();
            filter.Keyword = Keyword;
            return filter;
        }

        public override Dictionary<string, string> ToPagingParameter(int pageNo)
        {
            return new Dictionary<string, string>
                        {
                            { "Keyword", Keyword },
                            { "pageNo", pageNo.ToString() }
                        };
        }
    }
}
