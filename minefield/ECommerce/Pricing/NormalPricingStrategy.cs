using System.Collections.Generic;
using System.Linq;
using minefield.ECommerce;
using minefield.ECommerce.Products;

namespace minefield.ECommerce.Pricing
{
	public class NormalPricingStrategy : IPricingStrategy
	{
		public decimal GetPrice(IList<Product> products)
		{
			return products.Select(p => p.Price)
				           .Sum();
		}
	}
}
