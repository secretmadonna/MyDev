using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.WebSite.Portal.Web.Models
{
    public class LoginVm
    {
        [RequiredAttribute]
        public string UserName { get; set; }
        [RequiredAttribute]
        public string PassWord { get; set; }
        public string ValidateCode { get; set; }
        public bool? IsRemenberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
