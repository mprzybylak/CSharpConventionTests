using System;
using System.Collections.Generic;
using minefield.ECommerce.Products;

namespace minefield.ECommerce.Pricing
{
	public interface IPricingStrategy
	{
		decimal GetPrice(IList<Product> products);
	}
}
