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
        private readonly ICourseService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<CourseController> _logger;
        public static readonly string Name = "Course";
        public static readonly string ActionList = "List";
        public static readonly string ActionListTrn = "ListTrn";
        public static readonly string ActionDelete = "Delete";
        public static readonly string ActionEdit = "Edit";
        public CourseController(ICourseService service, IMapper mapper, ILogger<CourseController> logger)
        {
            _service = service;
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
                var paging = new Paging(pageNo, 20);
                var result = _service.GetList(filter, paging);
                model.Courses.AddRange(CourseModel.createModels(result.Results, _mapper));
                model.Paging = PagingModel.createPaging(result);
                model.setRoute(Name, ActionList);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with page no. {1}.", func, pageNo, ex);
                return View("PageNotFound");
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
                    model = new EditCourseModel(await _service.GetData(id), _mapper);
                }
                else
                    model = new EditCourseModel();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with id {1}.", func, id, ex);
                return View("PageNotFound");
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
                    {
                        existing = await _service.GetData(model.CourseId.Value);
                        existing.ModifyUserId = 1;
                        existing.ModifyDate = DateTime.Now;
                        Course course = model.ToDataModel(_mapper, existing);
                        await _service.SaveData(course);
                    }
                    else {
                        Course course = model.ToDataModel(_mapper, existing);
                        course.CreateUserId = 1;
                        course.CreateDate = DateTime.Now;
                        await _service.SaveData(course);
                    }
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
                        await _service.DeleteData(id);
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