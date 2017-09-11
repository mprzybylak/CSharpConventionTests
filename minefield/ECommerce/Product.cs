using System;

namespace minefield.ecommerce
{
	public class Product
	{
		readonly decimal _price;
		readonly string _name;

		public Product(string name, decimal price)
		{
			_name = name;
			_price = price;
		}

		public decimal Price
		{
			get
			{
				return _price;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}
	}
}
