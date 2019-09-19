﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.ServiceModel;
using Weable.TMS.BO.Web.Models;

namespace Weable.TMS.BO.Web.Controllers
{
    [Authorize]
    public class TargetGroupController : Controller
    {
        private readonly ITargetGroupService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TargetGroupController> _logger;
        public static readonly string Name = "TargetGroup";
        public static readonly string ActionList = "List";
        public static readonly string ActionDelete = "Delete";
        public static readonly string ActionEdit = "Edit";
        public TargetGroupController(
            ITargetGroupService service,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILogger<TargetGroupController> logger)
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
        public IActionResult List(ListCourseModel model, int pageNo = 1)
        {
            const string func = "List";
            try
            {
                //if (model == null)
                //    model = new ListCourseModel();
                //var filter = model.ToCourseFilter();
                //var paging = new Paging(pageNo, 20);
                //var result = _service.GetList(filter, paging);
                //model.Courses.AddRange(CourseModel.createModels(result.Results, _mapper));
                //model.Paging = PagingModel.createPaging(result);
                //return View(model);
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with page no. {1}.", func, pageNo, ex);
                return View("PageNotFound");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromBody] IEnumerable<TargetGroupMember> model)
        {
            const string func = "Edit";
            try
            {

                var targetGroup = new TargetGroup()
                {
                    Name = "test",
                    IsActive = 1,
                    IsPublic = 0,
                    TargetGroupMember = model.ToList()
                };
                await _service.SaveData(targetGroup);
                return Json(targetGroup.TargetGroupId);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught.", func, ex);
                return Json(new AjaxResultModel(AjaxResultModel.StatusCodeError, "Error!"));
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            const string func = "Delete";
            try
            {
                await _service.DeleteData(id);

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