using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.BO.Web.Models
{
    public class ProvinceModel
    {
        public int ProvinceId { get; set; }
        public int? RegionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string GeoName { get; set; }
        public bool IsActive { get; set; }

        public ProvinceModel()
        {

        }

        public ProvinceModel(Province province, IMapper mapper)
        {
            mapper.Map(province, this);
        }

        public static List<ProvinceModel> createModels(IList<Province> provinces, IMapper mapper)
        {
            var list = new List<ProvinceModel>();
            foreach (Province province in provinces)
                list.Add(new ProvinceModel(province, mapper));
            return list;
        }
    }
}
