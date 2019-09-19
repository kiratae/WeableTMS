using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class Person
    {
        public Person()
        {
            Attendee = new HashSet<Attendee>();
        }

        public int PersonId { get; set; }
        public string CitizenId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public int? TrainingAmount { get; set; }

        public virtual ICollection<Attendee> Attendee { get; set; }
    }
}
