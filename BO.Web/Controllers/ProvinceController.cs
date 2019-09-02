using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weable.TMS.BO.Web.Models;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.ServiceModel;

namespace Weable.TMS.BO.Web.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly IProvinceService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ProvinceController> _logger;
        public static readonly string Name = "Title";
        public static readonly string ActionList = "List";
        public static readonly string ActionDelete = "Delete";
        public static readonly string ActionEdit = "Edit";
        public ProvinceController(
            IProvinceService service,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILogger<ProvinceController> logger
            )
        {
            _service = service;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }
        public ActionResult Index()
        {
            return RedirectToAction(ActionList);
        }
        public IActionResult List(ListProvinceModel model, int pageNo = 1)
        {
            const string func = "List";
            try
            {
                if (model == null)
                    model = new ListProvinceModel();
                var filter = model.ToProvinceFilter();
                var paging = new Paging(pageNo, 20);
                var result = _service.GetList(filter, paging);
                model.Provinces.AddRange(ProvinceModel.createModels(result.Results, _mapper));
                model.Paging = PagingModel.createPaging(result);
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
                EditProvinceModel model;
                if (id.HasValue)
                {
                    model = new EditProvinceModel(await _service.GetData(id), _mapper);
                }
                else
                    model = new EditProvinceModel();

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
        public async Task<IActionResult> Edit(EditProvinceModel model)
        {
            const string func = "Edit";
            if (ModelState.IsValid)
            {
                try
                {
                    Province existing = null;
                    if (model.ProvinceId.HasValue)
                    {
                        existing = await _service.GetData(model.ProvinceId.Value);
                        existing.ModifyUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                        existing.ModifyDate = DateTime.Now;
                        Province province = model.ToDataModel(_mapper, existing);
                        await _service.SaveData(province);
                    }
                    else
                    {
                        Province province = model.ToDataModel(_mapper, existing);
                        province.CreateUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                        province.CreateDate = DateTime.Now;
                        await _service.SaveData(province);
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