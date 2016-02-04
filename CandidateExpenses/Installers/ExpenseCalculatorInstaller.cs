using System.Web.Mvc;
using CandidateExpenses.Controllers;
using CandidateExpenses.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Diagnostics.Extensions;

namespace CandidateExpenses.Installers
{
    public class ExpenseCalculatorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
            Component
                .For<IExpenseCalculator>()
                .ImplementedBy<MaximizeRateExpenseCalculator>()
                .LifestyleTransient());
        }
    }
}