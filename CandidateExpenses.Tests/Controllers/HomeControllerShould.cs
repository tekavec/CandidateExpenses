using System;
using CandidateExpenses.Controllers;
using CandidateExpenses.Models;
using CandidateExpenses.Services;
using NSubstitute;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CandidateExpenses.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerShould
    {
        private IExpenseCalculator _expenseCalculator = Substitute.For<IExpenseCalculator>();
        [Test]
        public void render_a_default_view()
        {

            HomeController controller = new HomeController(_expenseCalculator);

            controller.WithCallTo(a => a.Index()).ShouldRenderDefaultView();
        }

        [Test]
        public void redirect_to_result_view_on_valid_input_data()
        {
            var model = new InputModel();
            HomeController controller = new HomeController(_expenseCalculator);

            controller.WithCallTo(a => a.Index(model)).ShouldRedirectTo<InputModel>(a => a.Result);
        }

        [Test]
        public void return_a_default_view_with_input_data_on_invalid_data()
        {
            var model = new InputModel { Amount = new Random().Next(123456789)/100m };
            HomeController controller = new HomeController(_expenseCalculator);
            controller.ModelState.AddModelError("key", "error message");

            controller.WithCallTo(a => a.Index(model)).ShouldRenderView("Index").WithModel(model);
        }

        [Test]
        public void render_a_result_view()
        {
            HomeController controller = new HomeController(_expenseCalculator);
            var model = new InputModel { Amount = new Random().Next(123456789) / 100m };
            var expenseStructure = new ExpenseStructure();
            _expenseCalculator.Calculate(model.Amount).Returns(expenseStructure);

            controller.WithCallTo(a => a.Result(model)).ShouldRenderView("Result").WithModel<ExpenseStructure>(expenseStructure);
        }
    }
}
