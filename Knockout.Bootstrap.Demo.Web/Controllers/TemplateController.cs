using System.Collections.Generic;
using System.Web.Http;
using Knockout.Bootstrap.Demo.Web.Common;

namespace Knockout.Bootstrap.Demo.Web.Controllers
{
    [PascalCaseConfig]
    public class TemplateController : ApiController
    {
        private readonly ITemplateStore templateStore;

        public TemplateController(ITemplateStore templateStore)
        {
            this.templateStore = templateStore;
        }

        // GET api/default1
        public Dictionary<string, string> Get(string root)
        {
            return templateStore.LoadTemplates(root);
        }

    }
}
