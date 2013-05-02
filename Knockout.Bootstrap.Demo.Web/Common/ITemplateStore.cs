using System.Collections.Generic;

namespace Knockout.Bootstrap.Demo.Web.Common
{
    public interface ITemplateStore
    {
        Dictionary<string, string> LoadTemplates(string root);
    }
}