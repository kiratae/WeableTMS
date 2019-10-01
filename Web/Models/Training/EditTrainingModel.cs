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
        }

        public EditTrainingModel(Training training, IMapper mapper, ICourseService courseService)
          : this()
        {
            _courseService = courseService;
            mapper.Map(training, this, typeof(Training), typeof(EditTrainingModel));
        }

        public int? TrainingId { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; protected set; }
        public int? TrnImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public string TargetGroupNote { get; set; }
        public string Condition { get; set; }

        #region RegisterStartDate
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

    }
}
