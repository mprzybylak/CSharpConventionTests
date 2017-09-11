using System;
using System.Collections.Generic;
using System.Linq;
using minefield.ECommerce;
using minefield.ECommerce.Products;

namespace minefield.ECommerce.Pricing
{
	public class VipPricingStrategy : IPricingStrategy
	{
		public decimal GetPrice(IList<Product> products)
		{
			var basePrice = products.Select(p => p.Price)
			                        .Sum();

			return (basePrice - (basePrice * 0.2M));
		}
	}
}
