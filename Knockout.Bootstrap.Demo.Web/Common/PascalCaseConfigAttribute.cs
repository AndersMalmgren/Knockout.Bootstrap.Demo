using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Controllers;
using Newtonsoft.Json.Serialization;

namespace Knockout.Bootstrap.Demo.Web.Common
{
    public class PascalCaseConfigAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings config,
                               HttpControllerDescriptor controllerDescriptor)
        {
            var formatter = config.Formatters.OfType<JsonMediaTypeFormatter>().Single();
            config.Formatters.Remove(formatter);

            formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.ContractResolver = new DefaultContractResolver();

            config.Formatters.Add(formatter);
        }
    }
}