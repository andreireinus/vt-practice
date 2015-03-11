namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Palk2000.Application;

    using Web.Models;

    public class HomeController : Controller
    {
        private readonly SalaryReport report = new SalaryReport(new TaxCalculator(), new EmployeeRepository());

        public ActionResult Index()
        {
            var data = this.report.GetData();

            return this.View(data.ToArray());
        }
    }
}