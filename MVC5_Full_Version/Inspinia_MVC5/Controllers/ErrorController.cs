using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error()
        {
            return View("Error");
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("NotFound");
        }

        public ViewResult Malformed()
        {
            Response.StatusCode = 200;  //you may want to set this to 200
            return View("Malformed");
        }
    }
}