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
        private readonly IExpenseCalculator _expenseCalculator = Substitute.For<IExpenseCalculator>();
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

            controller.WithCallTo(a => a.Index(model)).ShouldRedirectTo<decimal>(a => a.Result);
        }

        [Test]
        public void return_a_default_view_with_input_data_on_invalid_data()
        {
            var model = new InputModel { InputValue = new Random().Next(123456789)/100m };
            HomeController controller = new HomeController(_expenseCalculator);
            controller.ModelState.AddModelError("key", "error message");

            controller.WithCallTo(a => a.Index(model)).ShouldRenderView("Index").WithModel(model);
        }

        [Test]
        public void render_a_result_view()
        {
            HomeController controller = new HomeController(_expenseCalculator);
            var model = new InputModel { InputValue = new Random().Next(123456789) / 100m };
            var expenseStructure = new ExpenseStructure(new Random().Next(99), new Random().Next(99), model.InputValue);
            _expenseCalculator.Calculate(model.InputValue).Returns(expenseStructure);

            controller.WithCallTo(a => a.Result(model.InputValue)).ShouldRenderView("Result").WithModel(expenseStructure);
        }
    }
}
