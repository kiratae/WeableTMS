using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.ServiceModel;
using Weable.TMS.Web.Models;

namespace Weable.TMS.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseRepo;

        public CourseController(ICourseService courseRepository)
        {
            _courseRepo = courseRepository;
        }
        public async Task<IActionResult> Index(ListCourseModel model)
        {
            if (model == null)
                model = new ListCourseModel();
            var filter = model.ToCourseFilter();
            var course = await _courseRepo.GetList(filter);
            model.Courses.AddRange(CourseModel.createModels(course));
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            course.CreateUserId = 1;
            course.CreateDate = DateTime.Now;
            await _courseRepo.SaveData(course);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var model = await _courseRepo.GetData(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            if (id != course.CourseId)
                return NotFound();

            if (ModelState.IsValid)
            {
                course.ModifyUserId = 1;
                course.ModifyDate = DateTime.Now;
                await _courseRepo.SaveData(course);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}