using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Enumeration;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.ServiceModel;

namespace Weable.TMS.BO.Web.Models
{
    public class ListTrainingModel: BaseListModel
    {

        public ListTrainingModel()
        {
            Trainings = new List<TrainingModel>();
        }

        public List<TrainingModel> Trainings { get; protected set; }

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

        public string Name { get; set; }
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

        public List<Attendee> Attendees { get; protected set; }
        public List<Course> ListCourse { get; set; }
        public SelectList TrainingStatusForListTrn { get; protected set; }
        public SelectList TrainingStatus { get; protected set; }
        public SelectList Courses { get; protected set; }

        public string Keyword { get; set; }

        public override Dictionary<string, string> ToPagingParameter(int pageNo)
        {
            return new Dictionary<string, string>
                        {
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
                Name = string.IsNullOrWhiteSpace(Name) ? null : string.Format("%{0}%", Name.Trim()),
                TraningStatusCloseIsNull = TraningStatusCloseIsNull,
                TrainigStatusNoAlready = TrainigStatusNoAlready,
            };
        }

    }
}
