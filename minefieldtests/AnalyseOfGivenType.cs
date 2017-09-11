using System;
using minefield.ECommerce.Products;
using System.Linq;
using NUnit.Framework;
using System.Runtime.Serialization;
using minefield.ECommerce.Pricing;
using minefield.ECommerce.Taxes;

namespace minefieldtests
{
    public class AnalyseOfGivenType
    {
        [Test]
        public void ShouldCheckForClassAttributes() {

            // given
            var t = typeof(ProductDto);

            // when
            var count = t.GetCustomAttributes(true)
             .Where(a => a.GetType() == typeof(DataContractAttribute))
             .Count();

            // then
            Assert.IsTrue(count == 1);
        }

        [Test]
        public void ShouldCheckForBaseType() {

            // given
            var taxCalculators = typeof(TaxCalculator).Assembly
                                                     .GetTypes()
                                                     .Where(t => t.IsClass && t.Name.EndsWith("Tax"))
                                                     .ToList();

            // when
            var count = taxCalculators.Where(t => t.BaseType != typeof(TaxCalculator))
                                      .Count();

            // then
            Assert.AreEqual(0, count);
        }

        [Test]
        public void ShouldImplementGivenInterface() {

            // given
            var strategies = typeof(IPricingStrategy).Assembly
                                                     .GetTypes()
                                                     .Where(t => t.IsClass && t.Name.EndsWith("Strategy"))
                                                     .ToList();

            // when
            var count = strategies.Where(t => !t.GetInterfaces().Contains(typeof(IPricingStrategy)))
                                  .Count();

            // then
            Assert.AreEqual(0, count);
        }

        [Test]
        public void ShouldNamesFollowSomeNamingConvention() {

            // given
            var names = typeof(IPricingStrategy).Assembly
                                                .GetTypes()
                                                .Where(t => t.IsClass && t.Name.EndsWith("Strategy"))
                                                .Select(t => t.Name)
                                                .ToList();

            // when
            var count = names.Where(n => !n.Contains("PricingStrategy"))
                             .Count();

            // then
            Assert.AreEqual(0, count);
        }

        [Test]
        public void ShouldAllTaxPoliciesBeInTheSameNamespace() {

            // given
            var namespaces = typeof(TaxCalculator).Assembly
                                                  .GetTypes()
                                                  .Where(t => t.IsSubclassOf(typeof(TaxCalculator)))
                                                  .Select(t => t.Namespace)
                                                  .ToList();

            // when
            var count = namespaces.Where(n => !n.Equals("minefield.ECommerce.Taxes"))
                                  .Count();

            // then
            Assert.AreEqual(0, count);
        }

        [Test]
        public void ShouldAllEnumsHaveNamesLongerThanTwoCharacters() {

            // given
            var enumsConstants = typeof(IPricingStrategy).Assembly
                                                         .GetTypes()
                                                         .Where(t => t.IsEnum)
                                                         .SelectMany(e => e.GetEnumNames())
                                                         .ToList();

            // where
            var count = enumsConstants.Where(ec => ec.Length <= 2)
                                      .Count();

            // then
            Assert.AreEqual(0, count);
        }
    }
}
