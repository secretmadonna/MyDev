using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyDev.UserInterface.WebSite.Portal.WebLogic
{
    public class CustomModelBinder : DefaultModelBinder
    {
        private readonly string _pageIndexParameter = "pageindex";
        private readonly string _pageSizeParameter = "pagesize";
        public CustomModelBinder() { }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = base.BindModel(controllerContext, bindingContext);
            if (model is PageModel)
            {
                var pageIndex = 1;//默认值
                var pageSize = 10;//默认值
                var vprPageIndex = bindingContext.ValueProvider.GetValue(_pageIndexParameter);
                if (vprPageIndex != null)
                {
                    int.TryParse(vprPageIndex.AttemptedValue, out pageIndex);
                }
                var vprPageSize = bindingContext.ValueProvider.GetValue(_pageSizeParameter);
                if (vprPageSize != null)
                {
                    int.TryParse(vprPageSize.AttemptedValue, out pageSize);
                }
                ((PageModel)model).PageIndex = pageIndex;
                ((PageModel)model).PageSize = pageSize;
            }
            return model;
        }
    }
}
