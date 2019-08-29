﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Weable.TMS.Web.Models
{
    public class AjaxResultModel
    {
        public const string StatusCodeSuccess = "0";
        public const string StatusCodeError = "1";
        public const string StatusCodeBizError = "2";
        public const string StatusCodeUnauthorized = "3";

        public AjaxResultModel(string statusCode = StatusCodeSuccess)
        {
            StatusCode = statusCode;
            Errors = new List<string>();
        }

        public AjaxResultModel(string statusCode, string message)
            : this(statusCode)
        {
            Message = message;
        }

        public AjaxResultModel(string statusCode, List<string> errors)
            : this(statusCode)
        {
            if (errors != null && errors.Count > 0)
                Errors.AddRange(errors);
        }

        public AjaxResultModel(string statusCode, ModelStateDictionary modelState)
            : this(statusCode)
        {
            foreach (ModelStateEntry state in modelState.Values)
            {
                foreach (var error in state.Errors)
                {
                    if (string.IsNullOrWhiteSpace(error.ErrorMessage))
                        continue;
                    Errors.Add(error.ErrorMessage);
                }
            }
        }

        public string StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; protected set; }
        public int? Id { get; set; }
        public object Data { get; set; }
    }
}
