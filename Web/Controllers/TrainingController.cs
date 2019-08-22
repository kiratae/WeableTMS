using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.ServiceModel;
using Weable.TMS.Web.Models;

namespace Weable.TMS.Web.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingService _service;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        private readonly ILogger<TrainingController> _logger;
        public static readonly string Name = "Training";
        public static readonly string ActionList = "List";
        public static readonly string ActionListTrn = "ListTrn";
        public static readonly string ActionDelete = "Delete";
        public static readonly string ActionEdit = "Edit";

        public TrainingController(
            ITrainingService service,
            ICourseService courseService,
            IMapper mapper, 
            ILogger<TrainingController> logger)
        {
            _service = service;
            _courseService = courseService;
            _mapper = mapper;
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
                if (model == null)
                    model = new ListTrainingModel();
                var filter = model.ToTrainingFilter();
                var paging = new Paging(pageNo, 20);
                var result = _service.GetList(filter, paging);
                model.Trainings.AddRange(TrainingModel.createModels(result.Results, _mapper));
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
                EditTrainingModel model;
                if (id.HasValue)
                {
                    model = new EditTrainingModel(await _service.GetData(id), _mapper, _courseService);
                }
                else
                    model = new EditTrainingModel(_courseService);
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
                        training.CreateUserId = 1;
                        training.CreateDate = DateTime.Now;
                        await _service.SaveData(training);
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
    }
}