using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.BO.Web.Models
{
    public class EditProvinceModel
    {
        public int? ProvinceId { get; set; }
        public int? RegionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string GeoName { get; set; }
        public bool IsActive { get; set; }

        public EditProvinceModel()
        {
            IsActive = true;
        }

        public EditProvinceModel(Province province, IMapper mapper)
          : this()
        {
            mapper.Map(province, this, typeof(Province), typeof(EditProvinceModel));
        }

        public Province ToDataModel(IMapper mapper, Province province = null)
        {
            return mapper.Map(this, province == null ? new Province() : province);
        }
    }
}
