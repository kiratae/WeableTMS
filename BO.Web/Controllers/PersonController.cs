using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weable.TMS.BO.Web.Models;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.ServiceModel;

namespace Weable.TMS.BO.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonController> _logger;
        public static readonly string Name = "Person";
        public static readonly string ActionList = "List";
        public static readonly string ActionDelete = "Delete";
        public static readonly string ActionEdit = "Edit";

        public PersonController(
            IPersonService service,
            ILogger<PersonController> logger,
            IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return RedirectToAction(ActionList);
        }

        public IActionResult List(ListPersonModel model, int pageNo = 1)
        {
            const string func = "List";
            try
            {
                var filter = model.ToPersonFilter();
                var paging = new Paging(pageNo, 20);
                var result = _service.GetList(filter, paging);
                model.Persons.AddRange(PersonModel.createModels(result.Results, _mapper));
                model.Paging = PagingModel.createPaging(result);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with page no. {1}.", func, pageNo, ex);
                return View("PageNotFound");
            }
        }
    }
}