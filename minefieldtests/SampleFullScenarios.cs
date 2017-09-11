using NUnit.Framework;
using minefield.ECommerce.Pricing;
using System.Linq;
using minefield.ECommerce;
using System;
using System.Text.RegularExpressions;
using minefield.ECommerce.Taxes;

namespace minefieldtests
{
	public class SampleFullScenarios
	{
		[Test]
		public void StrategiesShouldHaveNamesThatEndsWithWordStrategy()
		{
			var count = typeof(IPricingStrategy).Assembly
												.GetTypes()
			                                    .Where(t => t.GetInterfaces().Contains(typeof(IPricingStrategy)))
												.Select(t => t.Name)
												.Where(n => n.EndsWith("Strategy") == false)
												.Count();

			Assert.AreEqual(0, count);
		}

		[Test]
		public void MoreMeaningfulErrorMessage()
		{
			typeof(IPricingStrategy).Assembly
			                        .GetTypes()
									.Where(t => t.GetInterfaces().Contains(typeof(IPricingStrategy)))
									.Where(t => t.Name.EndsWith("Strategy") == false)
									.ToList()
			                        .ForEach(t => Assert.Fail(string.Format("The type {0} doesn't have name that ends with 'Strategy'", t.Name)));
		}

		[Test]
		public void EnumsShouldBeNotEmpty()
		{
            var count = typeof(IPricingStrategy).Assembly
										   .GetTypes()
										   .Where(t => t.IsEnum)
										   .Select(t => t.GetEnumNames().Length)
										   .Where(c => c == 0)
										   .Count();

			Assert.AreEqual(0, count);
		}
	}
}
