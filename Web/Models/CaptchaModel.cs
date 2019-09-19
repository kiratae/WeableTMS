using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weable.TMS.Web.Models
{
    public class CaptchaModel
    {
        public bool Success { get; set; }
        public DateTime ChallengeTS { get; set; }
        public string Hostname { get; set; }
        public string[] ErrorCodes { get; set; }
    }
}
