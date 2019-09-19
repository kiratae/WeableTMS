using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

            RegisterStartDate = DateTime.Today;
            RegisterEndDate = DateTime.Today;
            TrnStartDate = DateTime.Today;
            TrnEndDate = DateTime.Today;
            PublishAtdDate = DateTime.Today;
            PublishDate = DateTime.Today;

            IsPrerequisite = false;
            IsPublishNow = true;
        }

        public EditTrainingModel(Training training, IMapper mapper, ICourseService courseService)
          : this()
        {
            _courseService = courseService;
            mapper.Map(training, this, typeof(Training), typeof(EditTrainingModel));
            PublishHour = training.PublishDate.HasValue ? training.PublishDate.Value.Hour : (int?)null;
            PublishMinute = training.PublishDate.HasValue ? training.PublishDate.Value.Minute : (int?)null;
            PublishAtdHour = training.PublishAtdDate.Hour;
            PublishAtdMinute = training.PublishAtdDate.Minute;
            TrnStartHour = training.TrnStartDate.Hour;
            TrnStartMinute = training.TrnStartDate.Minute;
            TrnEndHour = training.TrnEndDate.Hour;
            TrnEndMinute = training.TrnEndDate.Minute;
        }

        public int? TrainingId { get; set; }
        [Required(ErrorMessage = "กรุณาเลือกหลักสูตร")]
        [DisplayName("หลักสูตร")]
        public int? CourseId { get; set; }
        public Course Course { get; protected set; }
        public int TrnImage { get; set; }
        public string Code { get; set; }
        [Required]
        [DisplayName("ชื่อโครงการ")]
        public string Name { get; set; }
        public bool IsRecommend { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public string TargetGroupNote { get; set; }
        public string Condition { get; set; }

        #region RegisterStartDate
        [Required]
        [DisplayName("วันรับสมัคร")]
        public DateTime? RegisterStartDate { get; set; }
        public string RegisterStartDateText
        {
            get { return FormatDate(RegisterStartDate); }
        }
        public string RegisterStartDateTextTH
        {
            get { return FormatShortDate(RegisterStartDate); }
        }
        #endregion

        #region RegisterEndDate
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? RegisterEndDate { get; set; }
        public string RegisterEndDateText
        {
            get { return FormatDate(RegisterEndDate); }
        }
        public string RegisterEndDateTextTH
        {
            get { return FormatShortDate(RegisterEndDate); }
        }
        #endregion

        #region PublishAtdDate
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PublishAtdDate { get; set; }
        public string PublishAtdDateText
        {
            get { return FormatDate(PublishAtdDate); }
        }
        public string PublishAtdDateTextTH
        {
            get { return FormatShortDate(PublishAtdDate); }
        }
        public string PublishAtdDateTimeTextTH
        {
            get { return FormatShortDateTime(PublishAtdDate); }
        }
        public int? PublishAtdHour { get; set; }
        public int? PublishAtdMinute { get; set; }
        #endregion

        #region TrnStartDate
        public DateTime? TrnStartDate { get; set; }
        public string TrnStartDateText
        {
            get { return FormatDate(TrnStartDate); }
        }
        public string TrnStartDateTextTH
        {
            get { return FormatShortDate(TrnStartDate); }
        }
        public int? TrnStartHour { get; set; }
        public int? TrnStartMinute { get; set; }
        #endregion

        #region TrnEndDate
        public DateTime? TrnEndDate { get; set; }
        public string TrnEndDateText
        {
            get { return FormatDate(TrnEndDate); }
        }
        public string TrnEndDateTextTH
        {
            get { return FormatShortDate(TrnEndDate); }
        }
        public int? TrnEndHour { get; set; }
        public int? TrnEndMinute { get; set; }
        #endregion

        public int? SeatQty { get; set; }
        public int ? AttendeeQty { get; set; }
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
        public SelectList PublishHours { get; set; }
        public SelectList PublishMinutes { get; set; }
        public SelectList PublishAtdHours { get; set; }
        public SelectList PublishAtdMinutes { get; set; }
        public SelectList TrnStartHours { get; set; }
        public SelectList TrnStartMinutes { get; set; }
        public SelectList TrnEndHours { get; set; }
        public SelectList TrnEndMinutes { get; set; }

        public Training ToDataModel(IMapper mapper, Training training = null)
        {
            training = mapper.Map(this, training == null ? new Training() : training);

            if (training.PublishDate.HasValue)
            {
                training.PublishDate = training.PublishDate.Value.Date;
                if (PublishHour != null && PublishMinute != null)
                {
                    training.PublishDate = training.PublishDate.Value.AddHours(PublishHour.Value);
                    training.PublishDate = training.PublishDate.Value.AddMinutes(PublishMinute.Value);
                }
            }

            return training;
        }

        public void FillLookupList()
        {
            Courses = new SelectList(_courseService.GetList(new CourseFilter() { IsActive = true }, null).Results, "CourseId", "Name");

            #region Hours
            List<SelectListItem> hours = new List<SelectListItem>();
            for (int i = 0; i <= 23; i++)
            {
                hours.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString("00") });
            }
            #endregion

            #region Minutes
            List<SelectListItem> minutes = new List<SelectListItem>();
            for (int i = 0; i < 60; i++)
            {
                minutes.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString("00") });
            }
            #endregion

            PublishHours = new SelectList(hours, "Value", "Text");
            PublishMinutes = new SelectList(minutes, "Value", "Text");

            PublishAtdHours = new SelectList(hours, "Value", "Text");
            PublishAtdMinutes = new SelectList(minutes, "Value", "Text");

            TrnStartHours = new SelectList(hours, "Value", "Text");
            TrnStartMinutes = new SelectList(minutes, "Value", "Text");

            TrnEndHours = new SelectList(hours, "Value", "Text");
            TrnEndMinutes = new SelectList(minutes, "Value", "Text");

        }

    }
}
