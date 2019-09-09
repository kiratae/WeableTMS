using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Training
    {
        public Training()
        {
            Attendee = new HashSet<Attendee>();
            TrnCoordinator = new HashSet<TrnCoordinator>();
            TrnPrerequisite = new HashSet<TrnPrerequisite>();
            TrnResponsible = new HashSet<TrnResponsible>();
            TrnResultScore = new HashSet<TrnResultScore>();
        }

        public int TrainingId { get; set; }
        public int CourseId { get; set; }
        public int TrnImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public string TargetGroupNote { get; set; }
        public int? TargetGroupId { get; set; }
        public string Condition { get; set; }
        public DateTime? RegisterStartDate { get; set; }
        public DateTime RegisterEndDate { get; set; }
        public DateTime PublishAtdDate { get; set; }
        public DateTime TrnStartDate { get; set; }
        public DateTime TrnEndDate { get; set; }
        public int? SeatQty { get; set; }
        public int? AttendeeQty { get; set; }
        public string Location { get; set; }
        public sbyte IsPrerequisite { get; set; }
        public sbyte? IsPublishNow { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

        public virtual Course Course { get; set; }
        public virtual TargetMarket TargetGroup { get; set; }
        public virtual File TrnImageNavigation { get; set; }
        public virtual ICollection<Attendee> Attendee { get; set; }
        public virtual ICollection<TrnCoordinator> TrnCoordinator { get; set; }
        public virtual ICollection<TrnPrerequisite> TrnPrerequisite { get; set; }
        public virtual ICollection<TrnResponsible> TrnResponsible { get; set; }
        public virtual ICollection<TrnResultScore> TrnResultScore { get; set; }
    }
}
