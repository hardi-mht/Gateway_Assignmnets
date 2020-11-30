using DataAnnotations_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnnotations_Assignment.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(WebForm_Demo we)
        {
            if(ModelState.IsValid == true)
            {
                ViewData["SuccessMessage"] = "<script>alert('Data has been submitted' ) </script>";
                ModelState.Clear();
            }
            return View();
        }

    }
}