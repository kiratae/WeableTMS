using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.Web.Models
{
    public class TrainingModel : BaseModel
    {
        public int? TrainingId { get; set; }
        public int CourseId { get; set; }
        public int? TrnImage { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsRecommend { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public string TargetGroupNote { get; set; }
        public int? TargetGroupId { get; set; }
        public string Condition { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? RegisterStartDate { get; set; }
        public string RegisterStartDateText
        {
            get { return FormatShortDate(RegisterStartDate); }
        }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegisterEndDate { get; set; }
        public string RegisterEndDateText
        {
            get { return FormatShortDate(RegisterEndDate); }
        }
        public DateTime PublishAtdDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TrnStartDate { get; set; }
        public string TrnStartDateText
        {
            get { return FormatShortDate(TrnStartDate); }
        }
        public string TrnStartTimeText
        {
            get { return FormatTime(TrnStartDate); }
        }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TrnEndDate { get; set; }
        public string TrnEndDateText
        {
            get { return FormatShortDate(TrnEndDate); }
        }
        public string TrnEndTimeText
        {
            get { return FormatTime(TrnEndDate); }
        }
        public int? SeatQty { get; set; }
        public int? AttendeeQty { get; set; }
        public string Location { get; set; }
        public decimal? LocationLatitude { get; set; }
        public decimal? LocationLongitude { get; set; }
        public bool IsPrerequisite { get; set; }
        public bool? IsPublishNow { get; set; }
        public DateTime? PublishDate { get; set; }

        public Course Course { get; set; }

        public TrainingModel()
        {
        }
        public TrainingModel(Training training, IMapper mapper)
        {
            mapper.Map(training, this, typeof(Training), typeof(TrainingModel));
        }
        public static List<TrainingModel> createModels(IList<Training> trainings, IMapper mapper)
        {
            var list = new List<TrainingModel>();
            foreach (Training training in trainings)
                list.Add(new TrainingModel(training, mapper));
            return list;
        }
    }
}
