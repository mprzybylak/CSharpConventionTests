using System;
using System.Linq;
using minefield.ECommerce.Pricing;
using NUnit.Framework;

namespace minefieldtests
{
    public class ExploringAssembly
    {
        [Test]
        public void ShouldGetAllTypesFromAssembly() {

            // when
            var allTypesFromAssembly = typeof(IPricingStrategy).Assembly
                                                               .GetTypes()
                                                               .ToList();

            // then
            Assert.True(allTypesFromAssembly.Count() > 0);
        }

        [Test]
        public void ShouldGetAllTypesExposedByAssembly() {

            // when
            var allExposedFromAssembly = typeof(IPricingStrategy).Assembly
                                                                 // might be useful when we are providing some sort of library
                                                                 .GetExportedTypes()
                                                                 .ToList();

            // then
            Assert.True(allExposedFromAssembly.Count() > 0);
        }
    }
}
