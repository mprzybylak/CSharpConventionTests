using System;
using System.Collections.Generic;
using System.Linq;
using minefield.ecommerce;

namespace minefield.ECommerce.Pricing
{
	public class VipPricing : IPricingStrategy
	{
		public int GetPrice(IList<Product> products)
		{
			var basePrice = products.Select(p => p.Price)
			                        .Sum();

			return (int)(basePrice - (basePrice * 0.2));
		}
	}
}
