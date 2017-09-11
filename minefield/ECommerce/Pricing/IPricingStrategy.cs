using System;
using System.Collections.Generic;
using minefield.ecommerce;

namespace minefield.ECommerce.Pricing
{
	public interface IPricingStrategy
	{
		decimal GetPrice(IList<Product> products);
	}
}
