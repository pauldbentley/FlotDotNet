using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FlotDotNet.Web.Controllers
{
    public partial class ExamplesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}