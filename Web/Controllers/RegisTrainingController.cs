using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.ServiceModel;
using Weable.TMS.Web.Models;

namespace Weable.TMS.Web.Controllers
{
    public class RegisTrainingController : Controller
    {
        private readonly ITrainingService _trainingService;
        private readonly IRegisTrainingService _regisService;
        private readonly IMapper _mapper;
        private readonly ILogger<RegisTrainingController> _logger;
        public static readonly string Name = "RegisTraining";
        public static readonly string ActionIndex = "Index";
        public static readonly string ActionGetRegister = "GetRegister";
        public static readonly string ActionPostRegister = "PostRegister";
        public static readonly string ActionRegisterConfirm = "RegisterConfirm";
        public static readonly string ActionCheckAllCondition = "CheckAllCondition";

        public RegisTrainingController(
            ITrainingService trainingService,
            IRegisTrainingService regisService,
            IMapper mapper,
            ILogger<RegisTrainingController> logger)
        {
            _trainingService = trainingService;
            _regisService = regisService;
            _mapper = mapper;
            _logger = logger;
        }
        public ActionResult Index()
        {
            return RedirectToAction(HomeController.ActionTraining);
        }

        public async Task<ActionResult> CheckAllCondition(string identification, string verifyCode, string captcha, int? trainingId)
        {
            const string func = "CheckAllCondition";
            string citizenId = "";
            try
            {
                CaptchaModel capcha;
                #region เงื่อนไขที่ 0 ตรวจสอบ reCAPTCHA
                string secret = "6LezA7kUAAAAAAUfRqVcvugu6SM1MQKYxkGYhxCz";
                using (HttpClient client = new HttpClient())
                {
                    var parameters = new Dictionary<string, string> { { "secret", secret }, { "response", captcha } };
                    var encodedContent = new FormUrlEncodedContent(parameters);
                    try
                    {
                        HttpResponseMessage response = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", encodedContent).Result;
                        response.EnsureSuccessStatusCode();
                        capcha = response.Content.ReadAsAsync<CaptchaModel>().Result;
                        if (!capcha.Success)
                        {
                            return Json(new { msgCode = 0, msg = "ท่านไม่ผ่านการยืนยันจาก reCAPTCHA" });
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        _logger.LogError("{0}: Exception caught with reCAPTCHA.", func, ex);
                    }
                }

                #endregion

                #region เงื่อนไขที่ 1 ตรวจสอบว่าอยู่ในกลุ่มเป้าหมายหรือไม่
                var regisTraining = _regisService.Authentication(identification, verifyCode, trainingId);
                if (regisTraining.TargetGroupMember == null)
                    return Json(new { msgCode = 0, msg = "ท่านไม่อยู่ในกลุ่มเป้าหมายที่การฝึกอบรมกำหนด" });
                else
                    citizenId = regisTraining.TargetGroupMember.CitizenId;
                #endregion

                #region เงื่อนไขที่ 2 เช็คว่าเคยสมัครโครงการนี้แล้วหรือยัง                   
                RegisTraining checkRepeat = _regisService.CheckRepeat(citizenId, trainingId);
                if (checkRepeat.Attendee != null)
                {
                    return Json(new { msgCode = 0, msg = "ท่านได้ทำการลงทะเบียนเรียบร้อยแล้ว" });
                }
                #endregion

                TrainingModel training = new TrainingModel(await _trainingService.GetData(trainingId), _mapper);

                #region เงื่อนไขที่ 3 การฝึกอบรมที่เคยเข้าร่วม ?
                if (training.IsPrerequisite == true)
                {
                    var check = _regisService.CheckTrnPrerequisite(citizenId, trainingId);
                    if (!check)
                    {
                        return Json(new { msgCode = 0, msg = "ท่านยังไม่ผ่านการฝึกอบรมก่อนหน้า ที่การฝึกอบรมนี้ต้องการ" });
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with citizenId {1}.", func, identification, ex);
                throw ex;
            }
            return Json(new { msgCode = 1, msg = "ok", citizenId = citizenId });
        }

        [HttpGet("[controller]/Register/{id}", Name = "GetRegister")]
        [HttpPost("[controller]/Register/{id}", Name = "PostRegister")]
        public async Task<ActionResult> Edit(int? id, EditRegisTrainingModel model, string returnUrl, bool isFirst = true)
        {
            const string func = "Edit";
            try
            {
                string tempCitizen = model.CitizenId;
                if (id.HasValue)
                {
                    TrainingModel training = new TrainingModel(await _trainingService.GetData(id), _mapper);
                    model.Training = training;
                    if (isFirst == false)
                    {
                        if (model.CitizenId != null)
                        {
                            RegisTraining regisTraining = _regisService.GetRegisTraining(model.CitizenId, training.TargetGroupId);
                            if (regisTraining.Person != null)
                            {
                                model = new EditRegisTrainingModel(training, regisTraining.Person, _mapper);
                            }
                            else if (regisTraining.TargetGroupMember != null)
                            {
                                model = new EditRegisTrainingModel(training, regisTraining.TargetGroupMember, _mapper);
                            }
                            else
                            {
                                model = new EditRegisTrainingModel();
                            }
                        }
                        else
                        {
                            if (ModelState.IsValid) { }
                            return Json(new AjaxResultModel(AjaxResultModel.StatusCodeError, ModelState));
                        }
                    }
                    model.Training.AttendeeQty = training.AttendeeQty;
                }
                else
                {
                    model = new EditRegisTrainingModel();
                }

                model.Training.TrainingId = id;
                model.CitizenId = tempCitizen;
                model.IsFirst = isFirst;
                model.ReturnUrl = returnUrl;
                //model.FillLookupList();
                //model.FillLookupItem();
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught with id {1}.", func, id, ex);
                throw ex;
            }
        }

        [HttpPost("[controller]/RegisterConfirm/{id}", Name = "RegisterConfirm")]
        public ActionResult Edit(EditRegisTrainingModel model)
        {
            const string func = "Edit";
            if (ModelState.IsValid)
            {
                try
                {
                    #region Check Attendee Qty 
                    int atdQty = _regisService.GetAttendeeQty(model.Training.TrainingId.Value);
                    model.Training.AttendeeQty = atdQty;
                    #endregion

                    model.Training.AttendeeQty = model.Training.AttendeeQty + 1;
                    RegisTraining regisTraining = new RegisTraining
                    {
                        Training = model.ToTrainingDataModel(_mapper),
                        Attendee = model.ToAttendeeDataModel(_mapper),
                        Person = model.ToPersonDataModel(_mapper),
                    };
                    _regisService.SaveRegisTraining(regisTraining);
                    return Json(new AjaxResultModel(AjaxResultModel.StatusCodeSuccess, "Save Success"));
                }
                catch (Exception ex)
                {
                    _logger.LogError("{0}: Exception caught.", func, ex);
                    ModelState.AddModelError("", "Save Failed");
                }
            }
            return Json(new AjaxResultModel(AjaxResultModel.StatusCodeError, ModelState));
        }
    }
}