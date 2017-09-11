using System;
using minefield.ECommerce.Pricing;
using System.Linq;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace minefieldtests
{
    public class GettingTypesByNames
    {
        private const string Namespace = "minefield.ECommerce.Pricing";
        private const string Suffix = "Strategy";

        [Test]
        public void ShouldGetAllTypesInGivenNamespace() {

            // when
            var inNamespace = typeof(IPricingStrategy).Assembly
                                                      .GetTypes()
                                                      .Where(t => t.Namespace.Equals(Namespace))
                                                      .ToList();

            // then
            Assert.IsTrue(inNamespace.First().Namespace.Equals(Namespace));
        }

        [Test]
        public void ShouldGetAllTypesThatMatchesClassNamePattern() {

            // when
            var withName = typeof(IPricingStrategy).Assembly
                                                      .GetTypes()
                                                      .Where(t => t.Name.EndsWith(Suffix))
                                                      .ToList();

            Assert.IsTrue(Regex.IsMatch(withName.First().Name, "(Strategy)$"));
        }
    }
}
