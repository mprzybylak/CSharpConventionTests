using System;
using minefield.ecommerce;

namespace minefield.ECommerce.Taxes
{
    public abstract class TaxCalculator
    {
        public abstract decimal taxRate();

        public decimal CalculatePriceWithTax(Product product) {
            return product.Price + (product.Price * taxRate());
        }
    }
}
