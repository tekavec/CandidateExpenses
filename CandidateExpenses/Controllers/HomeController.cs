using System;
using System.Web.Mvc;
using CandidateExpenses.Models;

namespace CandidateExpenses.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new InputModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(InputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            return RedirectToAction("Result");
        }

        public ActionResult Result(InputModel model)
        {
            return View();
        }
    }
}