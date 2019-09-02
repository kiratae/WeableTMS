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

        public TrainingModel Training { get; set; }

        #region เงื่อนไขการสมัคร
        public bool? IsPrerequisite { get; set; }
        #endregion


        [Required]
        public string CitizenId { get; set; }

        #region tab 2 ข้อมูลผู้สมัคร
        public int? PersonId { get; set; }
        public string StudentCode { get; set; }
        public int? UniversityCourseId { get; set; }

        [Required]
        [DisplayName("เพศ / sex")]
        public GenderType? GenderTypeId { get; set; }
        public string GenderTypeText
        {
            get
            {
                var text = "";
                if (GenderTypeId == GenderType.Female)
                    text = "หญิง";
                else if (GenderTypeId == GenderType.Male)
                {
                    text = "ชาย";
                }

                return text;
            }
        }

        [Required]
        [DisplayName("คำนำหน้า / Title")]
        public int? TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNote { get; set; }

        [Required]
        [DisplayName("ชื่อ / First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("นามสกุล / Last name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("วันเกิด / Birthday")]
        public DateTime? BirthDate { get; set; }

        public string BirthDateText
        {
            get { return FormatShortDate(BirthDate); }
        }
        public string AddressNo { get; set; }
        public string Moo { get; set; }
        public string Community { get; set; }
        public string Building { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }

        [Required]
        [DisplayName("จังหวัด / Province")]
        public int? ProvinceId { get; set; }
        public string ProvinceName { get; set; }

        [Required]
        [DisplayName("อำเภอ / District")]
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }

        [Required]
        [DisplayName("ตำบล / Subdistrict")]
        public int? SubdistrictId { get; set; }
        public string SubdistrictName { get; set; }
        public string PostalCode { get; set; }

        [Required]
        [DisplayName("เบอร์โทรศัพท์ / Mobile No.")]
        public string MobilePhone { get; set; }

        [Required]
        [DisplayName("อีเมล / E-mail")]
        public string Email { get; set; }
        #endregion

        public AttendeeModel Attendee { get; set; }

        public bool IsFirst { get; set; }

        public SelectList Universities { get; protected set; }
        public SelectList Faculties { get; protected set; }
        public SelectList UniversityCourses { get; protected set; }
        public SelectList Provinces { get; protected set; }
        public SelectList Districts { get; protected set; }
        public SelectList Subdistricts { get; protected set; }
        public SelectList Titles { get; protected set; }

        public Person ToPersonDataModel(IMapper mapper)
        {
            Person person = new Person();
            person = mapper.Map(this, person);

            return person;
        }

        public Attendee ToAttendeeDataModel(IMapper mapper)
        {
            Attendee attendee = new Attendee();
            attendee = mapper.Map(this, attendee);

            return attendee;
        }

        public Training ToTrainingDataModel(IMapper mapper)
        {
            Training training = new Training();
            training = mapper.Map(this, training);

            return training;
        }

    }
}
