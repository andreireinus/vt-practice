namespace Palk2000.Application.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class TaxCalculatorTests
    {
        private readonly TaxCalculator calculator = new TaxCalculator();

        [Test]
        public void CalculateSocialTaxAmount_WhenSalaryIs1000_Then330Euros()
        {
            Assert.That(this.calculator.CalculateSocialTaxAmount(1000), Is.EqualTo(330));
        }

        [Test]
        public void CalculateCompanyUnemploymentTaxAmount_WhenSalaryIs1000_Then8()
        {
            Assert.That(this.calculator.CalculateCompanyUnemploymentTaxAmount(1000), Is.EqualTo(8));
        }

        [Test]
        public void CalculateEmployeeUnemploymentTaxAmount_WhenSalaryIs1000_Then16()
        {
            Assert.That(this.calculator.CalculateEmployeeUnemploymentTaxAmount(1000), Is.EqualTo(16));
        }

        [Test]
        public void CalculatePensionFundAmount_WhenSalaryIs1000AndHaventRaisedPercentage_Then20()
        {
            Assert.That(this.calculator.CalculatePensionFundAmount(1000, false), Is.EqualTo(20));
        }

        [Test]
        public void CalculatePensionFundAmount_WhenSalaryIs1000AndHasRaisedPercentage_Then30()
        {
            Assert.That(this.calculator.CalculatePensionFundAmount(1000, true), Is.EqualTo(30));
        }

        [Test]
        public void CalculateIncomeTaxAmount_WhenSalaryIs1000AndHasRaisedPensionPercentage_Then160()
        {
            Assert.That(this.calculator.CalculateIncomeTaxAmount(1000, true), Is.EqualTo(160));
        }

        [Test]
        public void CalculateNetPayh_WhenSalaryIs1000AndHasRaisedPensionPercentage_Then794()
        {
            Assert.That(this.calculator.CalculateNetPay(1000, true), Is.EqualTo(794.00));
        }
    }
}