using System;
namespace minefield.ECommerce.Taxes
{
    public class PolishTax : TaxCalculator
    {
        public override decimal taxRate()
        {
            return 0.23M;
        }
    }
}
