using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.ServiceModel;
using Weable.TMS.BO.Web.Models;
using Weable.TMS.BO.Web.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Weable.TMS.BO.Web.Controllers
{
    [Authorize]
    public class TrainingController : Controller
    {
        private readonly ITrainingService _service;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStringLocalizer<TrainingController> _resourses;
        private readonly ILogger<TrainingController> _logger;
        public static readonly string Name = "Training";
        public static readonly string ActionList = "List";
        public static readonly string ActionDetail = "Detail";
        public static readonly string ActionDelete = "Delete";
        public static readonly string ActionEdit = "Edit";

        public TrainingController(
            ITrainingService service,
            ICourseService courseService,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IStringLocalizer<TrainingController> resourses,
            ILogger<TrainingController> logger)
        {
            _service = service;
            _courseService = courseService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _resourses = resourses;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction(ActionList);
        }

        public IActionResult List(ListTrainingModel model, int pageNo = 1)
        {
            const string func = "List";
            try
            {
                var filter = model.ToTrainingFilter();
                var paging = new Paging(pageNo, 20);
                var result = _service.GetList(filter, paging);
                model.Trainings.AddRange(TrainingModel.createModels(result.Results, _mapper));
                model.Paging = PagingModel.createPaging(result);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with page no. {1}.", func, pageNo, ex);
                return View("PageNotFound");
            }
        }

        public async Task<IActionResult> Edit(int? id, int? courseId, string returnUrl)
        {
            const string func = "Edit";
            try
            {
                EditTrainingModel model;
                if (id.HasValue)
                {
                    model = new EditTrainingModel(await _service.GetData(id), _mapper, _courseService);
                }
                else
                    model = new EditTrainingModel(_courseService);
                model.CourseId = (courseId.HasValue ? courseId : model.CourseId);
                model.ReturnUrl = returnUrl;
                model.FillLookupList();
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
        public async Task<IActionResult> Edit(EditTrainingModel model)
        {
            const string func = "Edit";
            if (ModelState.IsValid)
            {
                try
                {
                    Training existing = null;
                    if (model.TrainingId.HasValue)
                    {
                        existing = await _service.GetData(model.TrainingId.Value);
                        existing.ModifyUserId = 1;
                        existing.ModifyDate = DateTime.Now;
                        Training training = model.ToDataModel(_mapper, existing);
                        await _service.SaveData(training);
                    }
                    else
                    {
                        Training training = model.ToDataModel(_mapper, existing);
                        training.TrnImage = 1;
                        training.CreateUserId = 1;
                        training.CreateDate = DateTime.Now;
                        await _service.SaveData(training);
                    }
                    return Json(new AjaxResultModel(AjaxResultModel.StatusCodeSuccess, _resourses["DlgSaveMsgSuccess"].ToString()));
                }
                catch (Exception ex)
                {
                    _logger.LogError("{0}: Exception caught.", func, ex);
                    ModelState.AddModelError("", "Save Failed! Database error");
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
    }
}