using NUnit.Framework;
using minefield.ECommerce.Pricing;
using System.Linq;

namespace minefieldtests
{
	public class Test
	{
		[Test]
		public void TestCase()
		{
			var a = typeof(IPricingStrategy).Assembly.ExportedTypes; // types that are visible outside of solution
			typeof(IPricingStrategy).Assembly.GetCustomAttributes(true); // custom attrybuty
			typeof(IPricingStrategy).Assembly.GetTypes(); // types from assembly

			var b = typeof(IPricingStrategy).Attributes; // get attributes for current type
			var c = typeof(IPricingStrategy).BaseType; // get base type for current type
			typeof(IPricingStrategy).GetConstructors(); // get all constructor
			typeof(IPricingStrategy).GetEnumNames(); // get all names defined in this enum - exception if not enum
			typeof(IPricingStrategy).GetEvents(); // get all events defined in type
			typeof(IPricingStrategy).GetInterfaces(); // get all implemented interfaces
			typeof(IPricingStrategy).GetMembers(); // get public members
			typeof(IPricingStrategy).GetMethods(); // get all methods
			typeof(IPricingStrategy).GetProperties();

			var d = typeof(IPricingStrategy).IsAbstract;
			var e = typeof(IPricingStrategy).IsEnum;
			var f = typeof(IPricingStrategy).IsClass;

			var g = typeof(IPricingStrategy).IsInterface;
			var h = typeof(IPricingStrategy).IsValueType;
			typeof(IPricingStrategy).IsSubclassOf(typeof(object));
			typeof(IPricingStrategy).IsAssignableFrom(typeof(object));
			typeof(IPricingStrategy).IsInstanceOfType(typeof(object));

			var l = typeof(IPricingStrategy).Namespace;
			var m = typeof(IPricingStrategy).Name;

		}
	}
}
