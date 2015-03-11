namespace Palk2000.Application
{
    public class TaxCalculator
    {
        public decimal CalculateSocialTaxAmount(decimal amount)
        {
            return amount * 0.33m;
        }

        public decimal CalculateCompanyUnemploymentTaxAmount(decimal amount)
        {
            return amount * 0.008m;
        }

        public decimal CalculateEmployeeUnemploymentTaxAmount(decimal amount)
        {
            return amount * 0.016m;
        }

        public decimal CalculatePensionFundAmount(decimal amount, bool hasRaisedPercentage)
        {
            return amount * (hasRaisedPercentage ? 0.03m : 0.02m);
        }

        public decimal CalculateIncomeTaxAmount(decimal amount, bool hasRaisedPensionPercentage)
        {
            var incomeTax = amount
                - 154
                - this.CalculateEmployeeUnemploymentTaxAmount(amount)
                - this.CalculatePensionFundAmount(amount, hasRaisedPensionPercentage);

            return incomeTax * 0.2m;
        }

        public decimal CalculateNetPay(decimal amount, bool hasPaisedPercentage)
        {
            return amount
                - this.CalculateEmployeeUnemploymentTaxAmount(amount)
                - this.CalculatePensionFundAmount(amount, hasPaisedPercentage)
                - this.CalculateIncomeTaxAmount(amount, hasPaisedPercentage);
        }
    }
}