using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Models
{
    public partial class Person
    {
        public Person()
        {
            Attendee = new HashSet<Attendee>();
        }

        public int PersonId { get; set; }
        public string CitizenId { get; set; }
        public sbyte GenderTypeId { get; set; }
        public int TitleId { get; set; }
        public string TitleNote { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string StudentCode { get; set; }
        public int? UniversityCourseId { get; set; }
        public string AddressNo { get; set; }
        public string Moo { get; set; }
        public string Community { get; set; }
        public string Building { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public int? SubdistrictId { get; set; }
        public string PostalCode { get; set; }
        public string Landlines { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string LineId { get; set; }
        public string Facebook { get; set; }
        public int? TrainingAmount { get; set; }

        public virtual Subdistrict Subdistrict { get; set; }
        public virtual Title Title { get; set; }
        public virtual UniversityCourse UniversityCourse { get; set; }
        public virtual ICollection<Attendee> Attendee { get; set; }
    }
}
