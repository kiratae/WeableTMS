using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weable.TMS.Model.Models;
using Weable.TMS.Web.Repositories;

namespace Weable.TMS.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseRepository courseRepository;

        public CourseController(CourseRepository courseRepository) {
            this.courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            List<Course> list = courseRepository.GetList();
            Course course = new Course();
            course.Code = "C-0001";
            course.Name = "test";
            course.IsActive = 1;
            course.CreateDate = DateTime.Now;
            course.CreateUserId = 1;
            courseRepository.SaveData(course);
            return View();
        }
    }
}