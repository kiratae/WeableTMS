using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.ServiceModel;
using Weable.TMS.Web.Models;

namespace Weable.TMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITrainingService _service;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;
        public static readonly string Name = "Home";
        public static readonly string ActionTraining = "Index";
        public static readonly string ActionDetail = "Detail";

        public HomeController(
            ITrainingService service,
            ICourseService courseService,
            IMapper mapper,
            ILogger<HomeController> logger)
        {
            _service = service;
            _courseService = courseService;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index(ListTrainingModel model)
        {
            const string func = "Index";
            try
            {
                if (model == null)
                    model = new ListTrainingModel();
                var filter = model.ToTrainingFilter();
                var result = _service.GetList(filter, null);
                model.Trainings.AddRange(TrainingModel.createModels(result.Results, _mapper));
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught", func, ex);
                return View("PageNotFound");
            }
        }

        public async Task<IActionResult> Detail(int? id, string returnUrl)
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
                    throw new Exception("id not found");
                model.ReturnUrl = returnUrl;
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with id {1}.", func, id, ex);
                return View("PageNotFound");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
