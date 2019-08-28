using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;

namespace Weable.TMS.BO.Web.Models
{
    public class BaseListModel : BaseEditModel
    {
        public BaseListModel()
        {
            Paging = new PagingModel();
        }

        #region IPagingable Implementation
        public virtual PagingModel Paging { get; set; }

        public virtual Dictionary<string, string> ToPagingParameter(int pageNo)
        {
            return new Dictionary<string, string>
                        {
                            { "pageNo", pageNo.ToString() }
                        };
        }
        #endregion
    }
}