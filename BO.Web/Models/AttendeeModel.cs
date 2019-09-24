using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.BO.Web.Models
{
    public class AttendeeModel: BaseModel
    {
        public int? AttendeeId { get; set; }
        public string CitizenId { get; set; }
        public int PersonId { get; set; }
        public int TrainingId { get; set; }
        public short AtdStatusId { get; set; }
        public DateTime? Registeration { get; set; }
        public short TrainingResultId { get; set; }

        public Person Person { get; set; }

        public AttendeeModel()
        {
            Person = new Person();
        }

        public AttendeeModel(Attendee course, IMapper mapper)
        {
            mapper.Map(course, this);
        }

        public static List<AttendeeModel> createModels(IList<Attendee> attendees, IMapper mapper)
        {
            var list = new List<AttendeeModel>();
            foreach (Attendee attendee in attendees)
                list.Add(new AttendeeModel(attendee, mapper));
            return list;
        }
    }
}
