using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.ServiceModel;
using Weable.TMS.Web.Models;

namespace Weable.TMS.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<CourseController> _logger;
        public static readonly string Name = "Course";
        public static readonly string ActionList = "List";
        public static readonly string ActionListTrn = "ListTrn";
        public static readonly string ActionDelete = "Delete";
        public static readonly string ActionEdit = "Edit";
        public CourseController(ICourseService courseRepository, IMapper mapper, ILogger<CourseController> logger)
        {
            _courseRepo = courseRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public ActionResult Index()
        {
            return RedirectToAction(ActionList);
        }
        public IActionResult List(ListCourseModel model, int pageNo = 1)
        {
            const string func = "List";
            try
            {
                if (model == null)
                    model = new ListCourseModel();
                var filter = model.ToCourseFilter();
                var paging = new Paging(pageNo, 2);
                var result = _courseRepo.GetList(filter, paging);
                model.Courses.AddRange(CourseModel.createModels(result.Results, _mapper));
                model.Paging = PagingModel.createPaging(result);
                model.setRoute(Name, ActionList);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with page no. {1}.", func, pageNo, ex);
                return NotFound();
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            const string func = "Edit";
            try
            {
                EditCourseModel model;
                if (id.HasValue)
                {
                    model = new EditCourseModel(await _courseRepo.GetData(id), _mapper);
                }
                else
                    model = new EditCourseModel();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with id {1}.", func, id, ex);
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCourseModel model)
        {
            const string func = "Edit";
            if (ModelState.IsValid)
            {
                try
                {
                    Course existing = null;
                    if (model.CourseId.HasValue)
                        existing = await _courseRepo.GetData(model.CourseId.Value);
                    Course course = model.ToDataModel(_mapper, existing);
                    course.ModifyUserId = 1;
                    course.ModifyDate = DateTime.Now;
                    await _courseRepo.SaveData(course);
                    return Json(new AjaxResultModel(AjaxResultModel.StatusCodeSuccess, "Save Complete!"));
                }
                catch (Exception ex)
                {
                    _logger.LogError("{0}: Exception caught.", func, ex);
                    ModelState.AddModelError("", "Save Failed!");
                }
            }
            return Json(new AjaxResultModel(AjaxResultModel.StatusCodeError, ModelState));
        }

        public async Task<IActionResult> Delete(int[] ids)
        {
            const string func = "Delete";
            try
            {
                foreach (int id in ids)
                {
                    try
                    {
                        await _courseRepo.DeleteData(id);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("{0}: Exception caught with id {1}.", func, id, ex);
                        throw ex;
                    }
                }
                return Json(new AjaxResultModel(AjaxResultModel.StatusCodeSuccess, "Delete Complete!"));
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught.", func, ex);
                ModelState.AddModelError("", "Delete Failed!");
            }
            return Json(new AjaxResultModel(AjaxResultModel.StatusCodeError, ModelState));
        }

        public ActionResult ListTrn(ListTrainingModel model, int pageNo = 1)
        {
            const string func = "ListTrn";
            try
            {
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with page no. {1}.", func, pageNo, ex);
                return NotFound();
            }
        }

    }

}