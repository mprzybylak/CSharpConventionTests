using System.Collections.Generic;
using System.Linq;
using minefield.ecommerce;

namespace minefield.ECommerce.Pricing
{
	public class NormalPricing : IPricingStrategy
	{
		public int GetPrice(IList<Product> products)
		{
			return products.Select(p => p.Price)
				           .Sum();
		}
	}
}
