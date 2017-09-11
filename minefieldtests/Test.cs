using NUnit.Framework;
using minefield.ECommerce.Pricing;
using System.Linq;
using minefield.ECommerce;
using System;
using System.Text.RegularExpressions;
using minefield.ECommerce.Taxes;

namespace minefieldtests
{
	public class Test
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

        private void methodsForCheckingOfGivenMethods() {
            // TODO add method checkings

            typeof(IPricingStrategy).GetMethods().First().GetCustomAttributes(true);
            typeof(IPricingStrategy).GetMethods().First().GetGenericArguments();
            var a = typeof(IPricingStrategy).GetMethods().First().IsAbstract;
            var b = typeof(IPricingStrategy).GetMethods().First().IsFinal;
            var c = typeof(IPricingStrategy).GetMethods().First().IsPublic;
            var d = typeof(IPricingStrategy).GetMethods().First().IsPrivate;
            var e = typeof(IPricingStrategy).GetMethods().First().IsVirtual;
            var f = typeof(IPricingStrategy).GetMethods().First().IsAbstract;

            // add test for existance of parametrless constructor

            // constructor info is not that different from method info in our case to distinct
            //typeof(NormalPricingStrategy).GetConstructors().First();

            // event info does not provide useful methods from our perspective
            //typeof(NormalPricingStrategy).GetEvents().First();

            // propert info does not provide useful methods from our perspective
            //typeof(NormalPricingStrategy).GetProperties().First();
		}


	}
}
