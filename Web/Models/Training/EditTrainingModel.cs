using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.ServiceModel;

namespace Weable.TMS.Web.Models
{
    public class EditTrainingModel : BaseEditModel
    {
        private readonly ICourseService _courseService;
        public EditTrainingModel()
        {
        }
        public EditTrainingModel(ICourseService courseService)
        {
            _courseService = courseService;

            RegisterStartDate = DateTime.Now;
            RegisterEndDate = DateTime.Now;
            TrnStartDate = DateTime.Now;
            TrnEndDate = DateTime.Now;
            PublishAtdDate = DateTime.Now;
            PublishDate = DateTime.Now;
        }

        public EditTrainingModel(Training training, IMapper mapper, ICourseService courseService)
          : this()
        {
            _courseService = courseService;
            mapper.Map(training, this, typeof(Training), typeof(EditTrainingModel));
        }

        public int? TrainingId { get; set; }
        public int? CourseId { get; set; }
        public int TrnImage { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsRecommend { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public string TargetGroup { get; set; }
        public string Condition { get; set; }
        public DateTime? RegisterStartDate { get; set; }
        public DateTime RegisterEndDate { get; set; }
        public DateTime PublishAtdDate { get; set; }
        public DateTime TrnStartDate { get; set; }
        public DateTime TrnEndDate { get; set; }
        public string TrnEndDateText
        {
            get { return FormatDate(TrnEndDate); }
        }
        public string TrnEndDateTextTH
        {
            get { return FormatDate(TrnEndDate); }
        }
        public int? TrnEndHour { get; set; }
        public int? TrnEndMinute { get; set; }

        public int? SeatQty { get; set; }
        public string Location { get; set; }
        public decimal? LocationLatitude { get; set; }
        public decimal? LocationLongitude { get; set; }
        public bool IsPrerequisite { get; set; }
        public bool? IsPublishNow { get; set; }
        public DateTime? PublishDate { get; set; }
        public string PublishDateText
        {
            get { return FormatDate(PublishDate); }
        }

        public int? PublishHour { get; set; }
        public int? PublishMinute { get; set; }
        public int? Year { get; set; }

        public SelectList Courses { get; set; }

        public Training ToDataModel(IMapper mapper, Training training = null)
        {
            return mapper.Map(this, training == null ? new Training() : training);
        }

        public void FillLookupList()
        {
            Courses = new SelectList(_courseService.GetList(new CourseFilter() { IsActive = true }, null).Results, "CourseId", "Name");
        }

    }
}
