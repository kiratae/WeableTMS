using System;
using System.Collections.Generic;
using System.Text;
using Weable.TMS.Model.Enumeration;

namespace Weable.TMS.Model.Filter
{
    public class TrainingFilter
    {
        public int? CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public TrainingStatus? TrnStatusId { get; set; }
        public DateTime? RegisterStartDate { get; set; }
        public DateTime? RegisterEndDate { get; set; }
        public DateTime? TrnStartDate { get; set; }
        public DateTime? TrnEndDate { get; set; }
        public bool? TraningStatusCloseIsNull { get; set; }
        public bool? TrainigStatusNoAlready { get; set; }
        public int? Year { get; set; }
        public string Token { get; set; }
    }
}
