using System;
using CandidateExpenses.Controllers;
using CandidateExpenses.Models;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CandidateExpenses.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerShould
    {
        [Test]
        public void render_a_default_view()
        {
            HomeController controller = new HomeController();

            controller.WithCallTo(a => a.Index()).ShouldRenderDefaultView();
        }

        [Test]
        public void redirect_to_result_view_on_valid_input_data()
        {
            var model = new InputModel();
            HomeController controller = new HomeController();

            controller.WithCallTo(a => a.Index(model)).ShouldRedirectTo<InputModel>(a => a.Result);
        }

        [Test]
        public void return_a_default_view_with_input_data_on_invalid_data()
        {
            var model = new InputModel { Amount = new Random().Next(123456789)/100m };
            HomeController controller = new HomeController();
            controller.ModelState.AddModelError("key", "error message");

            controller.WithCallTo(a => a.Index(model)).ShouldRenderView("Index").WithModel(model);
        }


    }
}
