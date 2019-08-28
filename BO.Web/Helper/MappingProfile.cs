using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.BO.Web.Models;

namespace Weable.TMS.Web.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Course, CourseModel>();
            CreateMap<Course, EditCourseModel>();
            CreateMap<EditCourseModel, Course>();

            CreateMap<Training, TrainingModel>();
            CreateMap<Training, EditTrainingModel>();
            CreateMap<EditTrainingModel, Training>();
        }
    }
}
