using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CandidateExpenses.Startup))]
namespace CandidateExpenses
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
