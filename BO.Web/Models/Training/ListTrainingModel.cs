using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Enumeration;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Web.Models
{
    public class ListTrainingModel: BaseListModel
    {
        public ListTrainingModel()
        {
            Trainings = new List<TrainingModel>();
            Today = DateTime.Now;
        }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Today { get; set; }

        public List<TrainingModel> Trainings { get; protected set; }

        public int? TabIndex { get; set; }

        public int? TrainingId { get; set; }
        public TrainingStatus? TrnStatusId { get; set; }
        public string TrainingStatusName { get; set; }
        public int? CourseId { get; set; }
        public string CourseName
        {
            get
            {
                //ICourseService service = DIHelper.Resolve<ICourseService>();
                //if (CourseId.HasValue)
                //{
                //    return service.GetData(CourseId.Value).Name;
                //}
                //else
                //{
                    return "";
                //}

            }
        }

        public int TrmImage { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? RegisterStartDate { get; set; }
        public string RegisterStartDateText
        {
            get { return FormatDate(RegisterStartDate); }
        }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? RegisterEndDate { get; set; }
        public string RegisterEndDateText
        {
            get { return FormatDate(RegisterEndDate); }
        }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? TrnStartDate { get; set; }
        public string TrnStartDateText
        {
            get { return FormatDate(TrnStartDate); }
        }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? TrnEndDate { get; set; }
        public string TrnEndDateText
        {
            get { return FormatDate(TrnEndDate); }
        }

        public string Location { get; set; }
        public string Habitat { get; set; }
        public AttendeeType? AttendeeTypeId { get; set; }
        public int SeatQty { get; set; }
        public string SeatQtyText
        {
            get { return FormatInteger(SeatQty); }
        }
        public int AttendeeQty { get; set; }
        public string AttendeeQtyText
        {
            get { return FormatInteger(AttendeeQty); }
        }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublishDate { get; set; }
        public string PublishDateText
        {
            get { return FormatDate(PublishDate); }
        }
        public int? Year { get; set; }

        public List<Attendee> Attendees { get; protected set; }
        public List<Course> ListCourse { get; set; }
        public SelectList TrainingStatusForListTrn { get; protected set; }
        public SelectList TrainingStatus { get; protected set; }
        public SelectList Courses { get; protected set; }
        public SelectList Years { get; protected set; }
        public SelectList Months { get; protected set; }

        public string Keyword { get; set; }

        public override Dictionary<string, string> ToPagingParameter(int pageNo)
        {
            return new Dictionary<string, string>
                        {
                            { "Code", Code },
                            { "Keyword", Keyword },
                            { "pageNo", pageNo.ToString() }
                        };
        }

        public bool? TraningStatusCloseIsNull { get; set; } //สำหรับเช็คโครงการที่ยังไม่จัดอบรม และเผยแพร่แล้ว
        public bool? TrainigStatusNoAlready { get; set; } //สำหรับเช็คโครงการที่ยังไม่ได้จัดอบรม


        public TrainingFilter ToTrainingFilter()
        {
            return new TrainingFilter()
            {
                RegisterStartDate = RegisterStartDate,
                RegisterEndDate = RegisterEndDate,
                TrnStartDate = TrnStartDate,
                TrnEndDate = TrnEndDate,
                TrnStatusId = TrnStatusId,
                CourseId = CourseId,
                Code = string.IsNullOrWhiteSpace(Code) ? null : string.Format("%{0}%", Code.Trim()),
                Name = string.IsNullOrWhiteSpace(Name) ? null : string.Format("%{0}%", Name.Trim()),
                TraningStatusCloseIsNull = TraningStatusCloseIsNull,
                TrainigStatusNoAlready = TrainigStatusNoAlready,
                Year = Year
            };
        }
    }
}
