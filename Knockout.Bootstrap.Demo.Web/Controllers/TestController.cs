using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Knockout.Bootstrap.Demo.Web.Models;

namespace Knockout.Bootstrap.Demo.Web.Controllers
{
    public class TestController : ApiController
    {
        // GET api/values
        public TestViewModel Get()
        {
            return new TestViewModel(new Random().Next());
        }

    }
}