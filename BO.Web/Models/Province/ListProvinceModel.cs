using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.BO.Web.Models
{
    public class ListProvinceModel : BaseListModel
    {
        public string Name { get; set; }
        public int? RegionId { get; set; }
        public bool IsActive { get; set; }
        public List<ProvinceModel> Provinces { get; protected set; }
        public SelectList ActiveStatuses { get; protected set; }

        public ListProvinceModel()
        {
            Provinces = new List<ProvinceModel>();
        }

        public ProvinceFilter ToProvinceFilter()
        {
            return new ProvinceFilter()
            {
                Name = string.IsNullOrWhiteSpace(Name) ? null : String.Format("%{0}%", Name.Trim()),
                RegionId = RegionId,
                IsActive = IsActive
            };
        }

        public void fillLookupList()
        {
            ActiveStatuses = new SelectList(new List<SelectListItem>() { new SelectListItem("ใช้งาน", true.ToString()), new SelectListItem("ไม่ใช้งาน", false.ToString()) });
        }

        public override Dictionary<string, string> ToPagingParameter(int pageNo)
        {
            return new Dictionary<string, string>
                        {
                            { "IsActive", IsActive.ToString() },
                            { "pageNo", pageNo.ToString() }
                        };
        }
    }
}
