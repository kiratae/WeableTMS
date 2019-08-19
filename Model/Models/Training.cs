using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class Training
    {
        public Training()
        {
            Attendee = new HashSet<Attendee>();
            TrnCoordinator = new HashSet<TrnCoordinator>();
            TrnDoc = new HashSet<TrnDoc>();
            TrnImgOther = new HashSet<TrnImgOther>();
            TrnPrerequisite = new HashSet<TrnPrerequisite>();
            TrnResponsible = new HashSet<TrnResponsible>();
            TrnSatisfactionForm = new HashSet<TrnSatisfactionForm>();
            TrnSatisfactionFormCh2 = new HashSet<TrnSatisfactionFormCh2>();
        }

        public int TrainingId { get; set; }
        public int CourseId { get; set; }
        public int TrnImage { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public sbyte IsRecommend { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public string TargetGroup { get; set; }
        public string Condition { get; set; }
        public DateTime? RegisterStartDate { get; set; }
        public DateTime RegisterEndDate { get; set; }
        public DateTime PublishAtdDate { get; set; }
        public DateTime TrnStartDate { get; set; }
        public DateTime TrnEndDate { get; set; }
        public int? SeatQty { get; set; }
        public int? AttendeeQty { get; set; }
        public string Location { get; set; }
        public decimal? LocationLatitude { get; set; }
        public decimal? LocationLongitude { get; set; }
        public sbyte IsPrerequisite { get; set; }
        public sbyte? IsPublishNow { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? Year { get; set; }
        public string Token { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int ModifyUserId { get; set; }

        public virtual Course Course { get; set; }
        public virtual User CreateUser { get; set; }
        public virtual User ModifyUser { get; set; }
        public virtual File TrnImageNavigation { get; set; }
        public virtual ICollection<Attendee> Attendee { get; set; }
        public virtual ICollection<TrnCoordinator> TrnCoordinator { get; set; }
        public virtual ICollection<TrnDoc> TrnDoc { get; set; }
        public virtual ICollection<TrnImgOther> TrnImgOther { get; set; }
        public virtual ICollection<TrnPrerequisite> TrnPrerequisite { get; set; }
        public virtual ICollection<TrnResponsible> TrnResponsible { get; set; }
        public virtual ICollection<TrnSatisfactionForm> TrnSatisfactionForm { get; set; }
        public virtual ICollection<TrnSatisfactionFormCh2> TrnSatisfactionFormCh2 { get; set; }
    }
}
