using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.BO.Web.Models
{
    public class ListPersonModel : BaseListModel
    {
        public ListPersonModel()
        {
            Persons = new List<PersonModel>();
        }

        public string CitizenId { get; set; }
        public string FullName { get; set; }
        public List<PersonModel> Persons { get; set; }

        public PersonFilter ToPersonFilter()
        {
            return new PersonFilter()
            {
                CitizenId = string.IsNullOrWhiteSpace(CitizenId) ? null : string.Format("%{0}%", CitizenId.Trim()),
                FullName = string.IsNullOrWhiteSpace(FullName) ? null : string.Format("%{0}%", FullName.Trim())
            };
        }

        public override Dictionary<string, string> ToPagingParameter(int pageNo)
        {
            return new Dictionary<string, string>
                        {
                            { "CitizenId", CitizenId },
                            { "FullName", FullName },
                            { "pageNo", pageNo.ToString() }
                        };
        }

    }
}
