using System;
using System.Linq;
using minefield.ECommerce;
using minefield.ECommerce.Pricing;
using minefield.ECommerce.Products;
using NUnit.Framework;

namespace minefieldtests
{
    public class GettingMethods
    {
        [Test]
        public void ShouldGetAllMethods() {

            // when
            var count = typeof(NormalPricingStrategy).GetMethods()
                                                     .Count();

            // then
            Assert.IsTrue(count > 0);
        }

        [Test]
        public void ShouldGetAllMethodsThatMatchesNamePattern() {

            // when
            var count = typeof(NormalPricingStrategy).GetMethods()
                                                     .Where(m => m.Name.Contains("Price"))
                                                     .Count();

            // then
            Assert.IsTrue(count > 0);
        }

        [Test]
        public void ShouldGetAllConstructors() {

            // when
            var count = typeof(NormalPricingStrategy).GetConstructors().Count();

            // then
            Assert.IsTrue(count > 0);
        }

        [Test]
        public void ShouldGetAllProperties() {

            // when
            var count = typeof(Product).GetProperties()
                                       .Count();

            // then
            Assert.IsTrue(count > 0);
        }

        [Test]
        public void ShouldGetAllEvents() {

            // when
            var count = typeof(SellingService).GetEvents()
                                              .Count();

            // then
            Assert.IsTrue(count > 0);
        }

        [Test]
        public void ShouldGetMutatorOfProperty() {

            // when
            var count = typeof(Product).GetProperties()
                                       .Select(p => p.GetGetMethod())
                                       .Count();

            // then
            Assert.IsTrue(count > 0);
        }

        [Test]
        public void ShouldGetAccessorOfProperty() {

			// when
			var count = typeof(Product).GetProperties()
                                       .Select(p => p.GetSetMethod())
									   .Count();

			// then
			Assert.IsTrue(count > 0);
        }
    }
}
