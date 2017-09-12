using System;
using minefield.ECommerce.Pricing;
using NUnit.Framework;
using System.Linq;
using minefield.ECommerce;
using System.IO;

namespace minefieldtests
{
    public class AnalyseOfMethods
    {
        [Test]
        public void ShouldCheckIfClassHaveZeroArgContructor() {

            // given
            var type = typeof(NormalPricingStrategy);


            // when
            var ctors = type.GetConstructors()
                .Where(c => c.GetParameters().Count() == 0)
                .ToList();

            // then
            Assert.IsTrue(ctors.Count() == 1);
        }

        [Test]
        public void ShouldCheckIfMethodFollowsNamingConvention() {

            // given
            var type = typeof(NormalPricingStrategy);

            // when
            var methods = type.GetMethods()
                              .Where(m => m.IsPublic)
                              .Select(m => m.Name)
                              .Where(n => !n.StartsWith("Get") && !n.Equals("ToString") && !n.Equals("Equals"))
                              .ToList();

            // then
            Assert.AreEqual(0, methods.Count());
        }

        [Test]
        public void ShouldCheckIfMethodIsPublic() {

            // given
            var type = typeof(NormalPricingStrategy);

            // when
            var methods = type.GetMethods()
                             .Where(m => m.Name.Equals("GetPrice"))
                             .Where(m => !m.IsPublic)
                             .ToList();

            // then
            Assert.AreEqual(0, methods.Count());
        }

        [Test]
        public void ShouldCheckIfMethodIsAbstract() {

            // given
            var type = typeof(IPricingStrategy);

            // when
            var methods = type.GetMethods()
                             .Where(m => m.Name.Equals("GetPrice"))
                             .Where(m => !m.IsAbstract)
                             .ToList();

            // then
            Assert.AreEqual(0, methods.Count());
        }

        [Test]
        public void ShouldCheckIfMethodIsVirtual() {

			// given
			var type = typeof(IPricingStrategy);

			// when
			var methods = type.GetMethods()
							 .Where(m => m.Name.Equals("GetPrice"))
                             .Where(m => !m.IsVirtual)
							 .ToList();

			// then
			Assert.AreEqual(0, methods.Count());
        }
    }
}
