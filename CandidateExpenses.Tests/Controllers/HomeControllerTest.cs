using CandidateExpenses.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CandidateExpenses.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            HomeController controller = new HomeController();

            controller.WithCallTo(a => a.Index()).ShouldRenderDefaultView();
        }

    }
}
