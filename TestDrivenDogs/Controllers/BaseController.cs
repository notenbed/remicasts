using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDrivenDogs
{
    public class BaseController : Controller
    {
        public DogsContext Context { get { return MvcApplication.CurrentDogsContext; } }
    }
}