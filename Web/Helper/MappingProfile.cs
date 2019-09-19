using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Web.Models;

namespace Weable.TMS.Web.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Training, TrainingModel>();
            CreateMap<TrainingModel, Training>();
            CreateMap<EditTrainingModel, Training>();
            CreateMap<Training, EditTrainingModel>();


            CreateMap<Attendee, AttendeeModel>();
            CreateMap<AttendeeModel, Attendee>();

            CreateMap<TargetGroupMember, EditRegisTrainingModel>();
            CreateMap<EditRegisTrainingModel, TargetGroupMember>();

            CreateMap<Training, EditRegisTrainingModel>();
            CreateMap<EditRegisTrainingModel, Training>();

            CreateMap<Person, EditRegisTrainingModel>();
            CreateMap<EditRegisTrainingModel, Person>();
        }
    }
}
