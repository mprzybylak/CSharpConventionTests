using System;
using minefield.ECommerce.Pricing;
using System.Linq;
using NUnit.Framework;
using minefield.ECommerce.Taxes;

namespace minefieldtests
{
    public class GettingTypesByInheritanceHierarchy
    {
        [Test]
        public void ShouldGetSubclassesOfClass() {

            // when
            var subclasses = typeof(TaxCalculator).Assembly
                                                       .GetTypes()
                                                       .Where(t => t.IsSubclassOf(typeof(TaxCalculator)))
                                                       .ToList();

            // then
            Assert.IsTrue(subclasses.First().BaseType == typeof(TaxCalculator));

            // you will not have parent class in list of sub classes
            subclasses.ForEach(t => Assert.IsFalse(t == typeof(TaxCalculator)));
        }

        [Test]
        public void ShouldGetClassImplementingInterface() {

			// when
			var implements = typeof(IPricingStrategy).Assembly
													 .GetTypes()
                                                     // is assignable from will return also interface itself
													 .Where(t => typeof(IPricingStrategy).IsAssignableFrom(t) && !t.IsInterface)
													 .ToList();

			// then
			Assert.IsTrue(implements.First().GetInterfaces().Contains(typeof(IPricingStrategy)));

        }

    }
}
