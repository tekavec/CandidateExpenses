using System;
using System.Web.Mvc;
using CandidateExpenses.Models;
using CandidateExpenses.Services;

namespace CandidateExpenses.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExpenseCalculator _expenseCalculator;

        public HomeController(IExpenseCalculator expenseCalculator)
        {
            _expenseCalculator = expenseCalculator;
        }

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
            return RedirectToAction("Result", new {inputValue = model.InputValue});
        }

        public ActionResult Result(decimal inputValue)
        {
            var expenseStructure = _expenseCalculator.Calculate(inputValue);
            return View(expenseStructure);
        }
    }
}