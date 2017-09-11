using System;
namespace minefield.ECommerce.Taxes
{
    public class SpanishTax : TaxCalculator
    {
        public override decimal taxRate()
        {
            return 0.21M;
        }
    }
}
