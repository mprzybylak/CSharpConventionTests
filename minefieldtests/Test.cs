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
			// when
			var implements = typeof(IPricingStrategy).Assembly
													 .GetTypes()
                                                     .Where(t => typeof(IPricingStrategy).IsAssignableFrom(t) && !t.IsInterface )
													 .ToList();

			// then
			Assert.IsTrue(implements.First().GetInterfaces().Contains(typeof(IPricingStrategy)));





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
			var count = typeof(SeasonsEnum).Assembly
										   .GetTypes()
										   .Where(t => t.IsEnum)
										   .Select(t => t.GetEnumNames().Length)
										   .Where(c => c == 0)
										   .Count();

			Assert.AreEqual(0, count);
		}

		private void assemblyUsefulMethods()
		{
			var a = typeof(IPricingStrategy).Assembly.ExportedTypes; // types that are visible outside of solution
			typeof(IPricingStrategy).Assembly.GetTypes(); // types from assembly
		}

		private void methodsToUseAfterFiltering()
		{

            // TODO add method checkings

			var b = typeof(IPricingStrategy).Attributes; // get attributes for current type
			var c = typeof(IPricingStrategy).BaseType; // get base type for current type
			typeof(IPricingStrategy).GetConstructors(); // get all constructor
			typeof(IPricingStrategy).GetEnumNames(); // get all names defined in this enum - exception if not enum
			typeof(IPricingStrategy).GetEvents(); // get all events defined in type
			typeof(IPricingStrategy).GetInterfaces(); // get all implemented interfaces
			typeof(IPricingStrategy).GetMembers(); // get public members
			typeof(IPricingStrategy).GetMethods(); // get all methods
			typeof(IPricingStrategy).GetProperties(); // get all properties
		}
	}
}
