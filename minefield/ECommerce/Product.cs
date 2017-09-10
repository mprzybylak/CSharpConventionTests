using System;

namespace minefield.ecommerce
{
	public class Product
	{
		readonly int _price;
		readonly string _name;

		public Product(string name, int price)
		{
			_name = name;
			_price = price;
		}

		public int Price
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
