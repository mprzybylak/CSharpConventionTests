using System.Collections.Generic;
using System.Linq;
using minefield.ecommerce;

namespace minefield.ECommerce.Pricing
{
	public class NormalPricingStrategy : IPricingStrategy
	{
		public int GetPrice(IList<Product> products)
		{
			return products.Select(p => p.Price)
				           .Sum();
		}
	}
}
