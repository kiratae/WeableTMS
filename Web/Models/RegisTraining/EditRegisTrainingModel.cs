using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Enumeration;
using Weable.TMS.Web.Models;

namespace Weable.TMS.Web.Models
{
    public class EditRegisTrainingModel : BaseEditModel
    {
        public EditRegisTrainingModel()
        {
            Attendee = new AttendeeModel();
            Training = new TrainingModel();
        }

        public EditRegisTrainingModel(TrainingModel training, Person person, IMapper mapper)
          : this()
        {
            //TO DO: Mapping
            Training = training;
            mapper.Map(person, this, typeof(Person), typeof(EditRegisTrainingModel));
        }

        public EditRegisTrainingModel(TrainingModel training, TargetGroupMember targetGroupMember, IMapper mapper)
          : this()
        {
            //TO DO: Mapping
            Training = training;
            mapper.Map(targetGroupMember, this, typeof(TargetGroupMember), typeof(EditRegisTrainingModel));
        }

        public TrainingModel Training { get; set; }

        #region เงื่อนไขการสมัคร
        public bool? IsPrerequisite { get; set; }
        #endregion


        [Required]
        public string CitizenId { get; set; }
        public string Identification { get; set; }
        public string VerifyCode { get; set; }

        #region tab 2 ข้อมูลผู้สมัคร
        public int? PersonId { get; set; }
        public int? TargetGroupMemberId { get; set; }

        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("เบอร์โทรศัพท์")]
        public string MobilePhone { get; set; }

        [DisplayName("อีเมล")]
        public string Email { get; set; }
        #endregion

        public AttendeeModel Attendee { get; set; }

        public bool IsFirst { get; set; }

        public Person ToPersonDataModel(IMapper mapper)
        {
            Person person = new Person()
            {
                PersonId = PersonId.GetValueOrDefault(),
                CitizenId = CitizenId,
                Prefix = Prefix,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                MobilePhone = MobilePhone
            };

            return person;
        }

        public Attendee ToAttendeeDataModel(IMapper mapper)
        {
            Attendee attendee = new Attendee();
            attendee = mapper.Map(Attendee, attendee);

            return attendee;
        }

        public Training ToTrainingDataModel(IMapper mapper)
        {
            Training training = new Training();
            training = mapper.Map(Training, training);

            return training;
        }

    }
}
