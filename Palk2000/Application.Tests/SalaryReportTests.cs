namespace Palk2000.Application.Tests
{
    using System.Linq;

    using NUnit.Framework;

    using Palk2000.Application.Tests.Internal;

    public class SalaryReportTests
    {
        [Test]
        public void GetData_WhenEmptyDataset_ReturnsEmptyFooterRow()
        {
            var report = new SalaryReport(new TaxCalculator(), new FakeEmployeeRepository());

            var result = report.GetData().ToArray();

            Assert.That(result, Is.Not.Empty);
            Assert.That(result.First().Type, Is.EqualTo(SalaryReportRowType.Footer));
        }

        [Test]
        public void GetData_WithSingleEmployee_ReturnsTwoRows()
        {
            var repository = new FakeEmployeeRepository();
            repository.Add(new Employee { Name = "Jaan Juurikas", Salary = 1000, HasRaisedPensionPercentage = true });

            var report = new SalaryReport(new TaxCalculator(), repository);

            var result = report.GetData().ToArray();

            Assert.That(result, Is.Not.Empty);
            Assert.That(result.First().Type, Is.EqualTo(SalaryReportRowType.Data));

            var footer = result.Last();
            Assert.That(footer.Type, Is.EqualTo(SalaryReportRowType.Footer));

            Assert.That(footer.SocialTaxAmount, Is.EqualTo(330));
            Assert.That(footer.CompanyUnemploymentTaxAmount, Is.EqualTo(8));
            Assert.That(footer.EmployeeUnemploymentTaxAmount, Is.EqualTo(16));
            Assert.That(footer.PensionFundAmount, Is.EqualTo(30));
            Assert.That(footer.IncomeTaxAmount, Is.EqualTo(160));
            Assert.That(footer.NetPay, Is.EqualTo(794));
        }

        [Test]
        public void GetData_WithTwoEmployee_ReturnsThreeRows()
        {
            var repository = new FakeEmployeeRepository();
            repository.Add(new Employee { Name = "Jaan Juurikas", Salary = 400, HasRaisedPensionPercentage = true });
            repository.Add(new Employee { Name = "Mari Maasikas", Salary = 1000, HasRaisedPensionPercentage = false });

            var report = new SalaryReport(new TaxCalculator(), repository);

            var result = report.GetData().ToArray();

            Assert.That(result.Length, Is.EqualTo(3));

            var footer = result.Last();
            Assert.That(footer.Type, Is.EqualTo(SalaryReportRowType.Footer));

            Assert.That(footer.SocialTaxAmount, Is.EqualTo(462));
            Assert.That(footer.CompanyUnemploymentTaxAmount, Is.EqualTo(11.2));
            Assert.That(footer.EmployeeUnemploymentTaxAmount, Is.EqualTo(22.4));
            Assert.That(footer.PensionFundAmount, Is.EqualTo(32));
            Assert.That(footer.IncomeTaxAmount, Is.EqualTo(207.52));
        }

        [Test]
        public void GetData_WithTwoEmployee_ReturnsThreeRows_Taketwo()
        {
            var repository = new FakeEmployeeRepository();
            repository.Add(new Employee { Name = "Jaan Juurikas", Salary = 650, HasRaisedPensionPercentage = true });
            repository.Add(new Employee { Name = "Mari Maasikas", Salary = 750, HasRaisedPensionPercentage = true });

            var report = new SalaryReport(new TaxCalculator(), repository);

            var result = report.GetData().ToArray();

            Assert.That(result.Length, Is.EqualTo(3));

            var footer = result.Last();
            Assert.That(footer.Type, Is.EqualTo(SalaryReportRowType.Footer));

            Assert.That(footer.SocialTaxAmount, Is.EqualTo(462));
            Assert.That(footer.CompanyUnemploymentTaxAmount, Is.EqualTo(11.2));
            Assert.That(footer.EmployeeUnemploymentTaxAmount, Is.EqualTo(22.4));
            Assert.That(footer.PensionFundAmount, Is.EqualTo(42));
            Assert.That(footer.IncomeTaxAmount, Is.EqualTo(205.52));
        }

        [Test]
        public void GetData_WithTwoEmployee_ReturnsThreeRows_TakeThree()
        {
            var repository = new FakeEmployeeRepository();
            repository.Add(new Employee { Name = "Jaan Juurikas", Salary = 700, HasRaisedPensionPercentage = true });
            repository.Add(new Employee { Name = "Mari Maasikas", Salary = 700, HasRaisedPensionPercentage = true });

            var report = new SalaryReport(new TaxCalculator(), repository);

            var result = report.GetData().ToArray();

            Assert.That(result.Length, Is.EqualTo(3));

            var footer = result.Last();
            Assert.That(footer.Type, Is.EqualTo(SalaryReportRowType.Footer));

            Assert.That(footer.SocialTaxAmount, Is.EqualTo(462));
            Assert.That(footer.CompanyUnemploymentTaxAmount, Is.EqualTo(11.2));
            Assert.That(footer.EmployeeUnemploymentTaxAmount, Is.EqualTo(22.4));
            Assert.That(footer.PensionFundAmount, Is.EqualTo(42));
            Assert.That(footer.IncomeTaxAmount, Is.EqualTo(205.52));
        }

        [Test]
        public void GetDataRow_Employee_IsDataRow()
        {
            var report = new SalaryReport(new TaxCalculator(), new FakeEmployeeRepository());
            var result = report.GetDataRow(new Employee { Name = "Jaan Juurikas", Salary = 1000, HasRaisedPensionPercentage = true });

            Assert.That(result.Type, Is.EqualTo(SalaryReportRowType.Data));
        }
    }
}