using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weable.TMS.BO.Web.Models
{
    public class BaseModel
    {
        protected string FormatInputDate(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("dd/MM/yyyy") : null;
        }

        protected string FormatDate(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("dd/MM/yyyy") : null;
        }

        protected string FormatDateTime(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm") : null;
        }

        protected string FormatTime(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("HH:mm") : null;
        }

        protected string FormatCurrency(decimal? value)
        {
            return value.HasValue ? value.Value.ToString("#,0.00") : null;
        }

        protected string FormatInteger(int? value)
        {
            return value.HasValue ? value.Value.ToString("#,0") : null;
        }

        protected string FormatInteger(decimal? value)
        {
            return value.HasValue ? value.Value.ToString("#,0") : null;
        }
    }
}
