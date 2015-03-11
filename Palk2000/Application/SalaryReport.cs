namespace Palk2000.Application
{
    using System.Collections.Generic;
    using System.Linq;

    public class SalaryReport
    {
        private readonly TaxCalculator calculator;

        private readonly IEmployeeRepository repository;

        public SalaryReport(TaxCalculator calculator, IEmployeeRepository repository)
        {
            this.calculator = calculator;
            this.repository = repository;
        }

        public IEnumerable<SalaryReportRow> GetData()
        {
            var summary = new SalaryReportRow
                          {
                              Type = SalaryReportRowType.Footer,
                              CompanyUnemploymentTaxAmount = 0,
                              EmployeeUnemploymentTaxAmount = 0,
                              IncomeTaxAmount = 0,
                              PensionFundAmount = 0,
                              SocialTaxAmount = 0,
                              NetPay = 0
                          };

            foreach (var row in this.repository.GetEmployees().Select(this.GetDataRow))
            {
                summary.SocialTaxAmount += row.SocialTaxAmount;
                summary.CompanyUnemploymentTaxAmount += row.CompanyUnemploymentTaxAmount;
                summary.EmployeeUnemploymentTaxAmount += row.EmployeeUnemploymentTaxAmount;
                summary.PensionFundAmount += row.PensionFundAmount;
                summary.IncomeTaxAmount += row.IncomeTaxAmount;
                summary.NetPay += row.NetPay;

                yield return row;
            }

            yield return summary;
        }

        public SalaryReportRow GetDataRow(Employee employee)
        {
            return new SalaryReportRow
                   {
                       Type = SalaryReportRowType.Data,
                       Name = employee.Name,
                       SocialTaxAmount = this.calculator.CalculateSocialTaxAmount(employee.Salary),
                       CompanyUnemploymentTaxAmount = this.calculator.CalculateCompanyUnemploymentTaxAmount(employee.Salary),
                       EmployeeUnemploymentTaxAmount = this.calculator.CalculateEmployeeUnemploymentTaxAmount(employee.Salary),
                       PensionFundAmount = this.calculator.CalculatePensionFundAmount(employee.Salary, employee.HasRaisedPensionPercentage),
                       IncomeTaxAmount = this.calculator.CalculateIncomeTaxAmount(employee.Salary, employee.HasRaisedPensionPercentage),
                       NetPay = this.calculator.CalculateNetPay(employee.Salary, employee.HasRaisedPensionPercentage)
                   };
        }
    }

    public enum SalaryReportRowType
    {
        Data,
        Footer
    }

    public class SalaryReportRow
    {
        public SalaryReportRowType Type { get; set; }

        public string Name { get; set; }

        public decimal SocialTaxAmount { get; set; }

        public decimal CompanyUnemploymentTaxAmount { get; set; }

        public decimal EmployeeUnemploymentTaxAmount { get; set; }

        public decimal PensionFundAmount { get; set; }

        public decimal IncomeTaxAmount { get; set; }

        public decimal NetPay { get; set; }
    }
}