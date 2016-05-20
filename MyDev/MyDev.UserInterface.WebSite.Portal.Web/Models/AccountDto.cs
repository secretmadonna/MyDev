using MyDev.BusinessLogic.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.UserInterface.WebSite.Portal.Web.Models
{
    public class LoginDto : LoginModel
    {
        public string CodeToken { get; set; }
        public string Code { get; set; }
        public bool IsRemember { get; set; }
        public string RetUrl { get; set; }
    }
}
