using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.Bootstrap.Demo.Web.Models
{
    public class TestViewModel
    {
        public TestViewModel(int randomNumber)
        {
            RandomNumber = randomNumber;
        }

        public int RandomNumber { get; set; }
    }
}