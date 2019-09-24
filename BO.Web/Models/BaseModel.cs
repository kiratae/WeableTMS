using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        protected string FormatShortDate(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("d MMM yy", CultureInfo.GetCultureInfo("th-TH")) : null;
        }

        public string FormatShortDate(DateTime? value, string startDate, string endDate)
        {
            return value.HasValue ? startDate + "-" + endDate + value.Value.ToString(" MMM yy", CultureInfo.GetCultureInfo("th-TH")) : null;
        }

        protected string FormatShortDateTime(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("d MMM yy HH:mm", CultureInfo.GetCultureInfo("th-TH")) : null;
        }

        protected string FormatLongDate(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("th-TH")) : null;
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
