using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Infrastructure.Model
{
    public class PagedResult<T> : Paging where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
